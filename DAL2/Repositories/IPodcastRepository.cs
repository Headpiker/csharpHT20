using Models;
using System.Collections.Generic;

namespace DAL.Repositories
{
    public interface IPodcastRepository<T> : IRepository<T> where T : Podcast
    {
        void Update(int index, Podcast newPodcast);
        Podcast GetTitle(string title);
        void Save(List<Podcast> podcasts);
        void DeleteOfCategory(string category);
        void RenameCategoryOfPodcast(string category, string newCategory);
    }
}
