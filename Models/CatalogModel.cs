using Sludinajumi.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SludinajumuPortals.Models
{
    public class CatalogModel
    {
        public List<Item> Items { get; set; }
        public List<Category> categories { get; set; }
    }
}
