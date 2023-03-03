using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Util;

namespace LuceneConsole.DomainServices
{
    internal class LuceneService
    {
        const LuceneVersion AppLuceneVersion = LuceneVersion.LUCENE_48;

        public static void InitializeIndex(string folderPath, ProgressBar progressBar)
        {
            var indexPath = Path.Combine(folderPath, "index");

            using var dir = FSDirectory.Open(indexPath);

            var analyzer = new StandardAnalyzer(AppLuceneVersion);

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

                var document = new Document
                {
                    new StringField("Title", title, Field.Store.YES),
                    new StringField("Author", author, Field.Store.YES),
                    new TextField("Content", content, Field.Store.YES)
                };
                writer.AddDocument(document);
                progressBar.Value++;
            }

            writer.Flush(triggerMerge: false, applyAllDeletes: false);
        }

        public static IEnumerable<string> GetResults(string folderPath, string query)
        {
            var indexPath = Path.Combine(folderPath, "index");
            
            using var dir = FSDirectory.Open(indexPath);

            var analyzer = new StandardAnalyzer(AppLuceneVersion);

            var indexConfig = new IndexWriterConfig(AppLuceneVersion, analyzer);
            using var writer = new IndexWriter(dir, indexConfig);

            var parser = new QueryParser(AppLuceneVersion, "Content", analyzer);
            Query luceneQuery = parser.Parse(query);

            using var reader = writer.GetReader(applyAllDeletes: true);
            var searcher = new IndexSearcher(reader);
            var hits = searcher.Search(luceneQuery, 20).ScoreDocs;

            var results = new List<string>();
            foreach (var hit in hits)
            {
                var foundDoc = searcher.Doc(hit.Doc);
                results.Add($"{foundDoc.Get("Title")} by {foundDoc.Get("Author")}");
            }

            return results;
        }
    }
}
