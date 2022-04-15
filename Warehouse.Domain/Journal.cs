namespace Warehouse.Domain
{
    public record Journal
    {
        private List<int> _products;

        private Journal(int id, DateTime createdDate, int[] products)
        {
            Id = id;
            CreatedDate = createdDate;
            _products = new List<int>(products);
        }

        public int Id { get; init; }

        public DateTime CreatedDate { get; }

        public int[] Products => _products.ToArray();

        public bool AddProduct(params int[] products)
        {
            if (products.Length == 0)
            {
               return false;
            }

            _products.AddRange(products);
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