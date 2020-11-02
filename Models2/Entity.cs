
namespace Models
{
    public abstract class Entity
    {
        public virtual string EntityType()
        {
            return "Entity";
        }

        public Entity()
        {

        }
    }
}
