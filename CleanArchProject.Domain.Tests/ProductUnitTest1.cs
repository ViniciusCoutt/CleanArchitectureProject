using CleanArchProject.Domain.Entities;
using CleanArchProject.Domain.Validation;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchProject.Domain.Tests
{
    public class ProductDomainUnitTest1
    {
        [Fact]
        public void NewProduct_WithValidParams_NotThrowException()
        {
            Action action = () => new Product(1, "Name", "Description", 100.50m, 5, "image code");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void NewProduct_WithInvalidIdParam_ThrowException()
        {
            Action action = () => new Product(-1, "Name", "Description", 100.50m, 5, "image code");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }

        [Theory(DisplayName = "Create Product With Null, Empty and White Space Name")]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public void NewProduct_WithNullEmptyOrWithSpaceName_ThrowException(string name)
        {
            Action action = () => new Product(1, name, "Description", 100.50m, 5, "image code");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }

        [Fact]
        public void NewProduct_WithTooShortName_ThrowException()
        {
            Action action = () => new Product(1, "Na", "Description", 100.50m, 5, "image code");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minium 3 characteres");
        }

        [Fact]
        public void NewProduct_WithInvalidPrice_ThrowException()
        {
            Action action = () => new Product(1, "Name", "Description", -1, 5, "image code");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid price value");
        }

        [Fact]
        public void NewProduct_WithInvalidStock_ThrowException()
        {
            Action action = () => new Product(1, "Name", "Description", 10, -1, "image code");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid stock value");
        }

        [Fact]
        public void NewProduct_WithTooLongImageName_ThrowException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m,
                99, "product image toooooooooooooooooooooooooooooooooooooooooooo loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooogggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg");

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid image name, too long, maximum is 250 characters");
        }

        [Fact]
        public void NewProduct_WithNullImageName_NotThrowNullReferenceException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);
            action.Should().NotThrow<NullReferenceException>();
        }

        [Fact]
        public void NewProduct_WithEmptyImageName_NotThrowDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void UpdateCategory_WithValidParam_NotThrowException()
        {
            Action action = () => new Product(1, "name", "Description", 100.50m, 5, "image code").Update("name2", "Description2", 100.50m, 5, "image code2", 2);
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

    }
}
