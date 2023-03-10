using Lucene.Net.Analysis;
using Lucene.Net.Analysis.En;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Analysis.Util;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Search;
using Lucene.Net.Search.Highlight;
using Lucene.Net.Store;
using Lucene.Net.Util;
using LuceneConsole.Entities;

namespace LuceneConsole.DomainServices
{
    internal class LuceneService
    {
        const LuceneVersion AppLuceneVersion = LuceneVersion.LUCENE_48;

        public static void InitializeIndex(string folderPath, ProgressBar progressBar)
        {
            var indexPath = Path.Combine(folderPath, "index");

            using var dir = FSDirectory.Open(indexPath);

            var stopWords = GetStoppedWords();
            var analyzer = new EnglishAnalyzer(AppLuceneVersion, stopWords);

            var indexConfig = new IndexWriterConfig(AppLuceneVersion, analyzer);
            using var writer = new IndexWriter(dir, indexConfig);
            foreach (var file in System.IO.Directory.GetFiles(folderPath))
            {
                var content = File.ReadAllText(file);
                var title = content.Split("Title: ")[1].Split("\r\n\r\n")[0];
                var author = string.Empty;
                try
                {
                    author = content.Split("Author: ")[1].Split("\r\n\r\n")[0];
                }
                catch (Exception exception)
                {

                }

                var titleField = new TextField("Title", title, Field.Store.YES);
                var authorField = new TextField("Author", author, Field.Store.YES);
                var contentField = new TextField("Content", content, Field.Store.YES);
                titleField.Boost = 1.75f;
                authorField.Boost = 1.75f;
                contentField.Boost = 0.9f;
                var document = new Document
                {
                    new StringField("FilePath", file, Field.Store.YES),
                    titleField,
                    authorField,
                    contentField
                };
                writer.AddDocument(document);
                progressBar.Value++;
            }

            writer.Flush(triggerMerge: false, applyAllDeletes: false);
        }

        public static IEnumerable<LuceneResult> GetResults(string folderPath, string userQuery)
        {
            var indexPath = Path.Combine(folderPath, "index");
            
            using var dir = FSDirectory.Open(indexPath);

            var stopWords = GetStoppedWords();
            var analyzer = new EnglishAnalyzer(AppLuceneVersion, stopWords);

            var indexConfig = new IndexWriterConfig(AppLuceneVersion, analyzer);
            using var writer = new IndexWriter(dir, indexConfig);

            var weights = new Dictionary<string, float>
            {
                { "Author", 2.5f },
                { "Title", 2.5f },
                { "Content", 0.5f }
            };

            var queryParser = new MultiFieldQueryParser(
                                        AppLuceneVersion,
                                        weights.Keys.ToArray(),
                                        analyzer,
                                        weights);

            using var reader = writer.GetReader(applyAllDeletes: true);
            var searcher = new IndexSearcher(reader);
            var query = queryParser.Parse(userQuery);
            var hits = searcher.Search(query, 20).ScoreDocs;

            var htmlFormatter = new SimpleHTMLFormatter();
            var highlighter = new Highlighter(htmlFormatter, new QueryScorer(query));

            var results = new List<LuceneResult>();
            foreach (var hit in hits.OrderByDescending(x => x.Score))
            {
                var luceneResult = new LuceneResult();
                var foundDoc = searcher.Doc(hit.Doc);

                var highlighted1 = GetHighlights(searcher, analyzer, highlighter, hit.Doc, "Title", foundDoc.Get("Title"));
                highlighted1.AddRange(GetHighlights(searcher, analyzer, highlighter, hit.Doc, "Author", foundDoc.Get("Author")));
                highlighted1.AddRange(GetHighlights(searcher, analyzer, highlighter, hit.Doc, "Content", foundDoc.Get("Content")));

                luceneResult.Author = foundDoc.Get("Author");
                luceneResult.Title = foundDoc.Get("Title");
                luceneResult.FilePath = foundDoc.Get("FilePath");
                luceneResult.Hightlights = highlighted1;

                System.Diagnostics.Debug.WriteLine($"Score -> {hit.Score} Author -> {luceneResult.Author}");

                results.Add(luceneResult);
            }

            System.Diagnostics.Debug.WriteLine("---------------Ended----------------");

            return results;
        }

        private static IList<string> GetHighlights(IndexSearcher searcher, Analyzer analyzer, Highlighter highLighter, int docId, string field, string relevantText)
        {
            var highlights = new List<string>();
            highLighter.MaxDocCharsToAnalyze = relevantText.Length;
            var tokenStream = TokenSources.GetAnyTokenStream(searcher.IndexReader, docId, field, analyzer);
            var frag = highLighter.GetBestTextFragments(
                tokenStream, relevantText, mergeContiguousFragments: true, maxNumFragments: 10);
            for (int j = 0; j < frag.Length; j++)
            {
                if (frag[j] != null && frag[j].Score > 0)
                {
                    highlights.Add(frag[j].ToString());
                }
            }
            return highlights;
        }

        private static CharArraySet GetStoppedWords()
        {
            var stopWords = CharArraySet.Copy(AppLuceneVersion, StandardAnalyzer.STOP_WORDS_SET);

            using (StringReader reader = new StringReader(Properties.Resources.english_stopwords))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    stopWords.Add(line);
                }
            }

            return stopWords;
        }
    }
}
