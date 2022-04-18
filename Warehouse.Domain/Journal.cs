namespace Warehouse.Domain
{
    public record Journal
    {
        private List<int> _productsID;
        private readonly List<Product> _productsp;

        private Journal(int id, DateTime createdDate, int[] products)
        {
            Id = id;
            CreatedDate = createdDate;
            _productsID = new List<int>(products);
            _productsp = new List<Product>();
        }

        public int Id { get; init; }

        public DateTime CreatedDate { get; }

        public int[] Products => _productsID.ToArray();

        public List<Product> ProductsP { get => _productsp; }

        public bool AddProduct(params int[] products)
        {
            if (products.Length == 0)
            {
               return false;
            }

            _productsID.AddRange(products);
            return true;
        }

        public bool AddProduct(Product product)
        {
            _productsp.Add(product);

            return true;
        }

        public static (Journal? Result, string[] Errors) Create(DateTime createdDate)
        {
            if (createdDate.Day < DateTime.Today.Day)
            {
                return (null, new[] { "Дата создания журнала меньше сегодняшней даты." });
            }

            var journal = new Journal(0, createdDate, Array.Empty<int>());
            return (journal, Array.Empty<string>());
        }
    }
}