﻿using AspNetProjekt.Models;

namespace AspNetProjekt.Services.interfaces
{
    public interface IMyAppSettings
    {
        public HashSet<string> filteringCategories { get; set; }
        public HashSet<string> galleryFilteringCategories { get; set; }
    }
}
