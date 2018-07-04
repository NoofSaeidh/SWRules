using noofs.SWRules.Helpers;
using System;
using System.IO;
using System.Linq;

namespace noofs.SWRules.Web
{
    /// <summary>
    /// This class is used to find root path of the web project in;
    /// unit tests (to find views) and entity framework core command line commands (to find conn string).
    /// </summary>
    public static class WebContentDirectoryFinder
    {
        public static string CalculateContentRootFolder()
        {
            return Path.Combine(DirectoryHelper.GetBaseFolder(), $"src{Path.DirectorySeparatorChar}noofs.SWRules.Web");
        }
    }
}
