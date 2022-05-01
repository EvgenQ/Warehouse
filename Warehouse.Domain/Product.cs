namespace Warehouse.Domain
{
    public record Product
    {
        private Product(
            int id,
            string? name,
            string? description,
            double totalPrice,
            double pricePerKg,
            double weight,
            ProductCategory category)
        {
            Id = id;
            Name = name;
            Description = description;
            TotalPrice = totalPrice;
            PricePerKg = pricePerKg;
            Weight = weight;
            Category = category;
        }

        public int Id { get; init; }

        public string? Name { get; }

        public string? Description { get; }

        public double TotalPrice { get; }

        public double PricePerKg { get; }

        public double Weight { get; }

        public ProductCategory Category { get; }

        public static (Product? Result, string[] Error) CreateProduct(string? name, string? description, double pricePerKg, double weight, ProductCategory category)
        {
            double totalPrice = weight * pricePerKg;

            if (name == string.Empty)
            {
                return (null, new[] { $"Поле Имя: не заполнено, заполните поле." });
            }

            if (pricePerKg <= 0)
            {
                return (null, new[] { $"Поле Цена за килограмм: меньше или равно 0, заполните поле." });
            }

            if (weight <= 0)
            {
                return (null, new[] { $"Поле Вес: меньше или равно 0, заполните поле." });
            }

            var product = new Product(name, description, totalPrice, pricePerKg, weight, category);

            return (product, Array.Empty<string>());
        }
    }
}