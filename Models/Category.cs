using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Category : Entity
    {
        public string Title { get; set; }

        public Category(string title)
        {
            Title = title;
        }

        public override string EntityType()
        {
            return "Category";
        }


    }
}
