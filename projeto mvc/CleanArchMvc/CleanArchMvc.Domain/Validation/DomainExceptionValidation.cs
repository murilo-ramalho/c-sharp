using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchMvc.Domain.Validation
{
    internal class DomainExceptionValidation : Exception
    {
        public DomainExceptionValidation(string erro) : base(erro) { }

        public static void When(bool hasError, string erro)
        {
            if (hasError)
            {
                throw new DomainExceptionValidation(erro);
            }
        }
    }
}
