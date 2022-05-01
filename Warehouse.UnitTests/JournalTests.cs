using System;
using AutoFixture;
using Warehouse.Domain;
using Xunit;

namespace Warehouse.UnitTests
{
    public class JournalTests
    {
        [Fact]
        public void Create_ShouldReturnJournal()
        {
            // Arrange подготовка данных для теста
            Random random = new Random();
            var createdDate = DateTime.Now.AddDays(random.Next(0, 365));

            // Act Тут выполняется тестируемый код
            var (journal, errors) = Journal.Create(createdDate);

            // Assert проверка результатов тестов
            Assert.NotNull(journal);
            Assert.Empty(errors);
        }

        [Fact]
        public void Create_ShouldReturnErrors()
        {
            // Arrange подготовка данных для теста
            Random random = new Random();
            var createdDate = DateTime.Now.AddDays(random.Next(-365, 0));

            // Act Тут выполняется тестируемый код
            var (journal, errors) = Journal.Create(createdDate);

            // Assert проверка результатов тестов
            Assert.Null(journal);
            Assert.NotEmpty(errors);
        }

        [Fact]
        public void AddProduct_ShouldReturnProduct()
        {
            // Arrange
            var journal = CreateJournal();
            var product = CreateProduct();

            // Act
            var isAdded = journal.AddProduct(product);

            // Assert
            Assert.True(isAdded);
        }

        [Fact]
        public void AddProduct_ShouldReturnProduct2()
        {
            // Arrange
            var journal = CreateJournal();
            var product = CreateProduct();

            // Act
            var isAdded1 = journal.AddProduct(product);
            var isAdded2 = journal.AddProduct(product);

            // Assert
            Assert.True(isAdded1);
            Assert.False(isAdded2);
        }

        private static Journal CreateJournal()
        {
            Random random = new Random();
            var createdDate = DateTime.Now.AddDays(random.Next(0, 365));

            var (journal, errors) = Journal.Create(createdDate);
            if (journal == null)
            {
                var message = string.Join(Environment.NewLine, errors);
                throw new Exception(message);
            }

            return journal;
        }

        private Product CreateProduct()
        {
            var fixture = new Fixture();
            var (product, errors) = Product
                .CreateProduct(
                    name: fixture.Create<string>(),
                    description: fixture.Create<string>(),
                    pricePerKg: fixture.Create<double>(),
                    weight: fixture.Create<double>(),
                    category: fixture.Create<ProductCategory>());

            if (product == null)
            {
                var message = string.Join(Environment.NewLine, errors);
                throw new Exception(message);
            }

            return product;
        }
    }
}