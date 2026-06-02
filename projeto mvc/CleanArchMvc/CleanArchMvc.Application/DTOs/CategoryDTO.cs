using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CleanArchMvc.Application.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
