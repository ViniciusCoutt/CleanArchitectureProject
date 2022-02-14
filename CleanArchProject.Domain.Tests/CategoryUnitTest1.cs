using CleanArchProject.Domain.Entities;
using CleanArchProject.Domain.Validation;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchProject.Domain.Tests
{
    public class CategoryTest
    {
        [Fact(DisplayName = "New Category With Valid State")]
        public void NewCategory_WithValidParameters_NotThrowException()
        {
            Action action = () => new Category(1, "Category name");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category With Negative id Value")]
        public void NewCategory_WithNegativeIdValue_ThrowInvalidIdException()
        {
            Action action = () => new Category(-1, "Category name");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id Value");
        }


        [Fact(DisplayName = "Create Category With short Name")]
        public void NewCategory_WithShortName_ThrowTooShortException()
        {
            Action action = () => new Category(1, "Ca");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minium 3 characters");
        }

        [Theory(DisplayName = "Create Category With Null, Empty and White Space Name")]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public void CreateCategory_WithNullEmptyOrWithSpaceName_ThrowInvalidName(string name)
        {
            Action action = () => new Category(1, name);
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }
        [Fact]
        public void UpdateCategory_WithValidParam_NotThrowException()
        {
            Action action = () => new Category(1, "Category").Update("New Category");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }
    }
}
