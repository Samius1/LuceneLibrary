namespace LuceneConsole.Entities
{
    internal class LuceneResult
    {
        public string FilePath { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public IEnumerable<string> Hightlights { get; set; }
    }
}
