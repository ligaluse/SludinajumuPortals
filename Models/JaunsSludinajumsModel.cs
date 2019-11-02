using Sludinajumi.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SludinajumuPortals.Models
{
    public class JaunsSludinajumsModel
    {
        [Required]
        public decimal Price { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Location { get; set; }
        [Required]
        public int Phone { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        public int Id { get; set; }

        public string Photo { get; set; }
        [Required]
        public int CategoryId { get; set; }




        public List<Category> categories { get; set; }
    }
    
}
