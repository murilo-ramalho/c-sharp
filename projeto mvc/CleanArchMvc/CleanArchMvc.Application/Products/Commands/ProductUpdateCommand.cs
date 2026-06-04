using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchMvc.Application.Products.Commands
{
    public class ProductUpdateCommand : ProductCommand
    {
        public int Id { get; set; }
    }
}
