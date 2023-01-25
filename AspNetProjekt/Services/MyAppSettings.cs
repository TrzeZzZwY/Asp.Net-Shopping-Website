using AspNetProjekt.Models;
using AspNetProjekt.Services.interfaces;

namespace AspNetProjekt.Services
{
    public class MyAppSettings : IMyAppSettings
    {
        public HashSet<string> filteringCategories { get; set ; }
    }
}
