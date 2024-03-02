using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codeflix.Catalog.Domain.SeedWork
{
    public abstract class AggregateRoot : Entity
    {
        protected AggregateRoot() : base() { }
    }
}
