﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codeflix.Catalog.Domain.SeedWork
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }

        protected Entity() => Id = Guid.NewGuid();
    }
}
