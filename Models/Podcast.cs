using System;

namespace Models
{
    public class Podcast
    {
        public Category Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        public Podcast(string title, string description, string url)
        {

        }
    }
}
