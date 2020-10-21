using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace Models
{
    public class Podcast : Entity
    {
        public string Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public int UpdateInterval { get; set; }
        public int NumberOfEpisodes { get; set; }

        public override string EntityType()
        {
            return "Podcast";
        }

        public Podcast(string title, string description, string url, string category)
        {
            Title = title;
            Description = description;
            Url = url;
            Category = category;
        }

        public class PodcastList : List<Podcast>
        {
            public PodcastList()
            {

            }
        }

    }
}
