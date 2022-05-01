namespace Warehouse.Domain
{
    public record Journal
    {
        private List<int> _productsID;
        private readonly List<Product> _products;

        private Journal(int id, DateTime createdDate, int[] products)
        {
            Id = id;
            CreatedDate = createdDate;
            _productsID = new List<int>(products);
            _products = new List<Product>();
        }

        public int Id { get; init; }

        public DateTime CreatedDate { get; }

        public int[] Products => _productsID.ToArray();

        public List<Product> ProductsP { get => _products; }

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
            foreach (var productItem in _products)
            {
                if (productItem != product)
                {
                    _products.Add(productItem);
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public static (Journal? Result, string[] Errors) Create(DateTime createdDate)
        {
            var endOfToday = DateTime.Today.AddDays(1).AddMilliseconds(-1); // конец сегоднешнего дня

            if (createdDate < endOfToday)
            {
                return (null, new[] { "Дата создания журнала меньше сегодняшней даты." });
            }

            var journal = new Journal(0, createdDate, Array.Empty<int>());
            return (journal, Array.Empty<string>());
        }
    }
}