using CleanArchProject.Domain.Validation;

namespace CleanArchProject.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        // Propriedades de navegação, não fazem parte do modelo de domínio.
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Product(int id, string name, string description, decimal price, int stock, string image, int categoryId)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId; 
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name), 
                "Invalid name. Name is required");

            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minium 3 characteres");

            DomainExceptionValidation.When(price < 0, "Invalid price value");
            DomainExceptionValidation.When(stock < 0, "Invalid stock value");

            DomainExceptionValidation.When(image?.Length > 255,
                "Invalid image name, too long, maximum is 250 characters");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image; 
        }
    }
}
