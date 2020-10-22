using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace Models
{
    public class Podcast : Entity
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Category { get; set; }
        public int UpdateInterval { get; set; }
        //public List<Episode> Episodes { get; set; }

        public override string EntityType()
        {
            return "Podcast";
        }

        public Podcast(string title, string url, string category, int updateInterval /* , List<Episode> episodes */)
        {
            Title = title;
            Url = url;
            Category = category;
            UpdateInterval = updateInterval;
            //Episodes = episodes;
        }

            public Podcast()
            {

            }

    }
}
