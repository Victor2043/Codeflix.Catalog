using Bogus;
using Codeflix.Catalog.Domain.Exceptions;
using Codeflix.Catalog.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Codeflix.Catalog.UnitTests.Domain.Validation
{
    public class DomainValidationTest
    {
        public Faker Faker { get; set; }


        [Fact(DisplayName = nameof(NotNullThrowWhenNull))]
        [Trait("Domain", "DomainValidation - Validation")]
        public void NotNullThrowWhenNull()
        {
            string? value = null;
            Action action = () => DomainValidation.NotNull(value, "FieldName");

            var exception = Assert.Throws<EntityValidationException>(action);
            Assert.Equal("FieldName should not be null", exception.Message);

        }
        
    }
}
