using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchMvc.Domain.Entities
{
    public class Email
    {
        public string Intentity { get; set; }
        public string Domain { get; set; }

        public Email(string identity, string domain)
        {
            this.Intentity = identity;
            this.Domain = domain;
        }
    }
}
