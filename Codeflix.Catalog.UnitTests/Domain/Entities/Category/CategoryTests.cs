using Codeflix.Catalog.Domain.Entities;
using Codeflix.Catalog.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using DomainEntities = Codeflix.Catalog.Domain.Entities;

namespace CodeFlux.Catalog.UnitTests.Domain.Entities.Category
{
    public class CategoryTest
    {
        [Fact(DisplayName = nameof(Instantiate))]
        [Trait("Domain", "Category - Aggregates")]
        public void Instantiate()
        {
            var validData = new
            {
                Name = "category name",
                Description = "Description"
            };

            var dateTimeBefore = DateTime.Now;

            var category = new DomainEntities.Category(validData.Name, validData.Description);

            var datetimeAfter = DateTime.Now;

            Assert.NotNull(category);
            Assert.Equal(validData.Name, category.Name);
            Assert.Equal(validData.Description, category.Description);
            Assert.NotEqual(default(Guid), category.Id);
            Assert.NotEqual(default(DateTime), category.CreatedAt);
            Assert.True(category.CreatedAt > dateTimeBefore);
            Assert.True(category.CreatedAt < datetimeAfter);
            Assert.True(category.IsActive);
        }

        [Theory(DisplayName = nameof(InstantiateWithIsActivate))]
        [Trait("Domain", "Category - Aggregates")]
        [InlineData(true)]
        [InlineData(false)]

        public void InstantiateWithIsActivate(bool isActive)
        {
            var validData = new
            {
                Name = "category name",
                Description = "Description"
            };

            var dateTimeBefore = DateTime.Now;

            var category = new DomainEntities.Category(validData.Name, validData.Description, isActive);

            var datetimeAfter = DateTime.Now;

            Assert.NotNull(category);
            Assert.Equal(validData.Name, category.Name);
            Assert.Equal(validData.Description, category.Description);
            Assert.NotEqual(default(Guid), category.Id);
            Assert.NotEqual(default(DateTime), category.CreatedAt);
            Assert.True(category.CreatedAt > dateTimeBefore);
            Assert.True(category.CreatedAt < datetimeAfter);
            Assert.Equal(isActive, category.IsActive);
        }


        [Theory(DisplayName = nameof(InstantiateErrorWhenNameIsEmpty))]
        [Trait("Domain", "Category - Aggregates")]
        [InlineData("")]
        [InlineData(null)]
        public void InstantiateErrorWhenNameIsEmpty(string name)
        {
            Action action = () => new DomainEntities.Category(name, "Category Description");

            var exception = Assert.Throws<EntityValidationException>(action);
            Assert.Equal("Name should not be empty or null", exception.Message);
        }

        [Theory(DisplayName = nameof(InstantiateErrorWhenDescriptionIsEmpty))]
        [Trait("Domain", "Category - Aggregates")]
        [InlineData("")]
        [InlineData(null)]
        public void InstantiateErrorWhenDescriptionIsEmpty(string description)
        {
            Action action = () => new DomainEntities.Category("Category Name", description);

            var exception = Assert.Throws<EntityValidationException>(action);
            Assert.Equal("Description should not be empty or null", exception.Message);
        }

        [Theory(DisplayName = nameof(InstantiateErrorWhenNameIsLessThan3Characters))]
        [Trait("Domain", "Category - Aggregates")]
        [InlineData("1")]
        [InlineData("12")]
        [InlineData("a")]
        [InlineData("ab")]
        public void InstantiateErrorWhenNameIsLessThan3Characters(string name)
        {
            Action action = () => new DomainEntities.Category(name, "Category description");

            var exception = Assert.Throws<EntityValidationException>(action);
            Assert.Equal("Name should be at least 3 characters long", exception.Message);
        }

        [Fact(DisplayName = nameof(InstantiateErrorWhenNameIsGreaterThan255Characters))]
        [Trait("Domain", "Category - Aggregates")]
        public void InstantiateErrorWhenNameIsGreaterThan255Characters()
        {
            string invalidName = string.Join(null, Enumerable.Range(1, 256).Select(_ => "a"));
            Action action = () => new DomainEntities.Category(invalidName, "Category description");

            var exception = Assert.Throws<EntityValidationException>(action);
            Assert.Equal("Name should be less or equal 255 characters long", exception.Message);
        }

        [Fact(DisplayName = nameof(InstantiateErrorWhenDescriptionIsGreaterThan10_000Characters))]
        [Trait("Domain", "Category - Aggregates")]
        public void InstantiateErrorWhenDescriptionIsGreaterThan10_000Characters()
        {
            string invalidDescription = string.Join(null, Enumerable.Range(1, 10001).Select(_ => "a"));
            Action action = () => new DomainEntities.Category("Category Name", invalidDescription);

            var exception = Assert.Throws<EntityValidationException>(action);
            Assert.Equal("Description should be less or equal 10000 characters long", exception.Message);
        }

        [Fact(DisplayName = nameof(InstantiateWithIsActive))]
        [Trait("Domain", "Category - Aggregates")]
        public void InstantiateWithIsActive()
        {
            var validData = new
            {
                Name = "category name",
                Description = "Description"
            };

            var category = new DomainEntities.Category(validData.Name, validData.Description, false);

            category.Activate();

            Assert.True(category.IsActive);
        }

        [Fact(DisplayName = nameof(Deactivate))]
        [Trait("Domain", "Category - Aggregates")]
        public void Deactivate()
        {
            var validData = new
            {
                Name = "category name",
                Description = "Description"
            };

            var category = new DomainEntities.Category(validData.Name, validData.Description, true);

            category.Deactivate();

            Assert.False(category.IsActive);
        }

        [Fact(DisplayName = nameof(Update))]
        [Trait("Domain", "Category - Aggregates")]
        public void Update()
        {
            var category = new DomainEntities.Category("Category Name", "Description");
            var newValues = new {Name = "New Name", Description = "New Description"};
            category.Update(newValues.Name, newValues.Description);

            Assert.Equal(newValues.Name, category.Name);
            Assert.Equal(newValues.Description, category.Description);
        }

        [Fact(DisplayName = nameof(UpdateOnlyName))]
        [Trait("Domain", "Category - Aggregates")]
        public void UpdateOnlyName()
        {
            var category = new DomainEntities.Category("Category Name", "Description");
            var newValues = new { Name = "New Name"};
            category.Update(newValues.Name);

            Assert.Equal(newValues.Name, category.Name);
        }

        [Theory(DisplayName = nameof(UpdateErrorWhenNameIsEmpty))]
        [Trait("Domain", "Category - Aggregates")]
        [InlineData("")]
        [InlineData(null)]
        public void UpdateErrorWhenNameIsEmpty(string? name)
        {
            var category = new DomainEntities.Category("Category Name", "Description");
            var newValues = new { Name = "New Name" };
            Action action = () => category.Update(name!);

            var exception = Assert.Throws<EntityValidationException>(action);

            Assert.Equal("Name should not be empty or null", exception.Message);
        }

        [Theory(DisplayName = nameof(UpdateErrorWhenNameIsLessThan3Characters))]
        [Trait("Domain", "Category - Aggregates")]
        [InlineData("1")]
        [InlineData("12")]
        [InlineData("a")]
        [InlineData("ab")]
        public void UpdateErrorWhenNameIsLessThan3Characters(string invalidName)
        {
            var category = new DomainEntities.Category("Category Name", "Description");
            var newValues = new { Name = "New Name" };
            Action action = () => category.Update(invalidName, "Description");

            var exception = Assert.Throws<EntityValidationException>(action);

            Assert.Equal("Name should be at least 3 characters long", exception.Message);
        }

        [Fact(DisplayName = nameof(UpdateErrorWhenNameIsGreaterThan255Characters))]
        [Trait("Domain", "Category - Aggregates")]
        public void UpdateErrorWhenNameIsGreaterThan255Characters()
        {
            string invalidName = string.Join(null, Enumerable.Range(1, 256).Select(_ => "a"));
            var category = new DomainEntities.Category("Category Name", "Description");

            Action action = () => category.Update(invalidName, "Category description");

            var exception = Assert.Throws<EntityValidationException>(action);
            Assert.Equal("Name should be less or equal 255 characters long", exception.Message);
        }

        [Fact(DisplayName = nameof(UpdateErrorWhenDescriptionIsGreaterThan10_000Characters))]
        [Trait("Domain", "Category - Aggregates")]
        public void UpdateErrorWhenDescriptionIsGreaterThan10_000Characters()
        {
            string invalidDescription = string.Join(null, Enumerable.Range(1, 10001).Select(_ => "a"));
            var category = new DomainEntities.Category("Category Name", "Description");
            Action action = () => category.Update("Category Name", invalidDescription);

            var exception = Assert.Throws<EntityValidationException>(action);
            Assert.Equal("Description should be less or equal 10000 characters long", exception.Message);
        }
    }
}
