using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Util;

namespace LuceneConsole.DomainServices
{
    internal class LuceneService
    {
        const LuceneVersion AppLuceneVersion = LuceneVersion.LUCENE_48;

        public static void InitializeIndex(string folderPath)
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
            }

            writer.Flush(triggerMerge: false, applyAllDeletes: false);

            // Querying is not working, need to investigate more
            var phrase = new MultiPhraseQuery
            {
                new Term("Content", "Conan")
            };

            using var reader = writer.GetReader(applyAllDeletes: true);
            var searcher = new IndexSearcher(reader);
            var hits = searcher.Search(phrase, 20).ScoreDocs;

            // Display somehow the results, old code not working
            Console.WriteLine($"{"Score",10}" +
                $" {"Name",-15}" +
                $" {"Favorite Phrase",-40}");
            foreach (var hit in hits)
            {
                var foundDoc = searcher.Doc(hit.Doc);
                Console.WriteLine($"{hit.Score:f8}" +
                    $" {foundDoc.Get("name"),-15}" +
                    $" {foundDoc.Get("favoritePhrase"),-40}");
            }
        }
    }
}
