namespace SingleResponsibilityBooksAfter
{
    class BookManager
    {
        private readonly Book book;

        private int page = 0;

        public BookManager(Book book)
        {
            this.book = book;
        }

        public string TurnPage()
        {
            this.page++;

            return this.book.getPageContent(this.page);
        }
    }
}
