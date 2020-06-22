namespace SingleResponsibilityBooksAfter
{
    class Book
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public int Location { get; set; }

        public string getPageContent(int page)
        {
            return "Page " + page;
        }
    }
}
