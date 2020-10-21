using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public abstract class Entity
    {
        public virtual string EntityType()
        {
            return "Type";
        }

        public Entity()
        {

        }
    }
}
