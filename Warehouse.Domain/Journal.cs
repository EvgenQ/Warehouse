namespace Warehouse.Domain
{
    public class Journal
    {
        private Journal(int id, DateTime createdDate, Product[] products)
        {
            Id = id;
            CreatedDate = createdDate;
            Products = products;
        }

        public int Id { get; }

        public DateTime CreatedDate { get; }

        public Product[] Products { get; }

        public static (Journal? Result, string[] Errors) Create(DateTime createdDate)
        {
            if (createdDate.Day < DateTime.Today.Day)
            {
                return (null, new[] { "Дата создания журнала меньше сегодняшней даты." });
            }

            var journal = new Journal(0, createdDate, Array.Empty<Product>());
            return (journal, Array.Empty<string>());
        }
    }
}