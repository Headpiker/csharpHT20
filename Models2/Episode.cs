﻿
namespace Models
{
    public class Episode : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public override string EntityType()
        {
            return "Episode";
        }

        public Episode()
        {

        }
    }
}
