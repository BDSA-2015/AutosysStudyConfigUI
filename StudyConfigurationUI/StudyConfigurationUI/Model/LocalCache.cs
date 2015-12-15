// LocalCache.cs is a part of Autosys project in BDSA-2015. Created: 15, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System.Collections.Generic;
using StudyConfigurationUI.Model.PhaseModels;

namespace StudyConfigurationUI.Model
{
    /// <summary>
    /// Stores all retrieved data from server. Uses singleton pattern 
    /// to avoid creation of additional caches
    /// </summary>
    public class LocalCache
    {
        IList<Datafield> CachedDatafields { get; set; }
        IList<User> CachedUsers { get; set; }

        private static LocalCache _localCache;


        private LocalCache()
        {
            RefreshData();
        }

        /// <summary>
        /// Returns a local cach object
        /// </summary>
        /// <returns></returns>
        public static LocalCache GetCache()
        {
            return _localCache ?? (_localCache = new LocalCache());
        }

        /// <summary>
        /// Populate data with data from server
        /// </summary>
        public void RefreshData()
        {
            //Todo call webAPI to store data
        }
    }
}