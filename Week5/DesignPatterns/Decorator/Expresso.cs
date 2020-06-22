namespace ExDecorator
{
    class ExpressoCoffe : ICoffee
    {
        private string price;
        private string description = "Expresso";

        public ExpressoCoffe(string price)
        {
            this.price = price;
        }

        public string GetDescription()
        {
            return this.description;
        }

        public string GetPrice()
        {
            return this.price;
        }


    }
}