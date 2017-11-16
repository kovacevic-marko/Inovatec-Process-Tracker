using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPTXamarinForms.Models
{
    enum ItemType
    {
        services,
        applications
    }

    class ChoseItemModel
    {
        public string Name { get; set; }
        public ItemType Type { get; set; }

        public ChoseItemModel()
        {

        }

        public ChoseItemModel(string name, ItemType type)
        {
            this.Name = name;
            this.Type = type;          
        }
    }
}
