using Codeflix.Catalog.Application.UseCases.Category.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codeflix.Catalog.Application.UseCases.Category.CreateCategory
{
    public interface ICreateCategory :
     IRequestHandler<CreateCategoryInput, CategoryModelOutput>
    { }
}