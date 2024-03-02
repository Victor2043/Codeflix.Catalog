using Codeflix.Catalog.Application.UseCases.Category.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codeflix.Catalog.Application.UseCases.Category.CreateCategory
{
    public class CreateCategoryInput : IRequest<CategoryModelOutput>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public CreateCategoryInput(
            string name,
            string? description = null,
            bool isActive = true)
        {
            Name = name;
            Description = description ?? "";
            IsActive = isActive;
        }
    }
}
