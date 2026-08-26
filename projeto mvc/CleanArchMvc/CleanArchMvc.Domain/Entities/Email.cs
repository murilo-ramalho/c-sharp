using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CleanArchMvc.Domain.Entities
{
    public class Email
    {
        private string Value { get; set; } = "no-replay@email.com";

        private static readonly Regex EmailRegex = new(
            @"^[^@\s\\]+@(?:localhost|[^@\s\\]+(?:\.[^@\s\\]+)+)$",
            RegexOptions.Compiled | 
            RegexOptions.IgnoreCase
        );

        public Email(string endereco)
        {
            if (string.IsNullOrWhiteSpace(endereco))
                throw new ArgumentNullException("Email address cannot be empty: " + nameof(endereco));

            string trimmedValue = endereco.Trim().ToLowerInvariant();

            if (!EmailRegex.IsMatch(trimmedValue))
            {
                throw new ArgumentException($"'{endereco}' is not a valid email address.");
            }

            this.Value = endereco;
        }

        public override string ToString() => Value;
    }
}
