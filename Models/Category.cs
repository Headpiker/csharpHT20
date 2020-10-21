using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Category : Entity
    {
        public string Name { get; set; }

        public override string EntityType()
        {
            return "Category";
        }

        public Category (string name)
        {
            Name = name;
        }
    }
}
