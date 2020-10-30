﻿using Models;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace DAL.Repositories
{
    public interface IPodcastRepository<T> : IRepository<T> where T : Podcast
    {
        void Update(int index, Podcast newPodcast);
        List<T> GetList();
        Podcast GetTitle(string title);

        void Save(List<Podcast> podcasts);
        void DeleteOfCategory(string category);
        void RenameCategoryOfPodcast(string category, string newCategory);
    }
}
