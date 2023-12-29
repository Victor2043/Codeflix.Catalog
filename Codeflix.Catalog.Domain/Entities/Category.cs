using Codeflix.Catalog.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codeflix.Catalog.Domain.Entities
{
    public class Category
    {
        public Category(string name, string description, bool isActive = true)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            IsActive = isActive;
            CreatedAt = DateTime.Now;

            Validate();
        }

        private void Validate()
        {
            if (string.IsNullOrEmpty(Name))
                throw new EntityValidationException($"{nameof(Name)} should not be empty or null");

            if (Name.Length < 3)
                throw new EntityValidationException($"{nameof(Name)} should be at least 3 characters long");

            if (Name.Length > 255)
                throw new EntityValidationException($"{nameof(Name)} should be less or equal 255 characters long");

            if (string.IsNullOrEmpty(Description))
                throw new EntityValidationException($"{nameof(Description)} should not be empty or null");

            if (Description.Length > 10000)
                throw new EntityValidationException($"{nameof(Description)} should be less or equal 10000 characters long");

        }

        public void Activate()
        {
            IsActive = true;
            Validate();
        }

        public void Deactivate()
        {
            IsActive = false;
            Validate();
        }

        public void Update(string name, string? description = null)
        {
            Name = name;
            Description = description ?? Description;

            Validate();
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; private set; }
    }
}
