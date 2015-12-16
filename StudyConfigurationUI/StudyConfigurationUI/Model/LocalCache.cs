// LocalCache.cs is a part of Autosys project in BDSA-2015. Created: 16, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

#region

using System.Collections.Generic;
using System.Threading.Tasks;
using StudyConfigurationUI.Model.PhaseModels;
using StudyConfigurationUI.Model.WebAPI;

#endregion

namespace StudyConfigurationUI.Model
{
    /// <summary>
    ///     Stores all retrieved data from server. Uses singleton pattern
    ///     to avoid creation of additional caches
    /// </summary>
    public class LocalCache
    {
        private static LocalCache _localCache;
        private IList<Datafield> _cachedDatafields;
        private IList<User> _cachedUsers;


        private LocalCache()
        {
            _cachedUsers = new List<User>();
            _cachedDatafields = new List<Datafield>();
            _cachedUsers = GetUsers().Result;
        }

        /// <summary>
        ///     Returns a local cache object
        /// </summary>
        /// <returns></returns>
        public static LocalCache GetCache()
        {
            return _localCache ?? (_localCache = new LocalCache());
        }

        /// <summary>
        ///     Populate data with data from server
        /// </summary>
        public async Task<IList<User>> GetUsers()
        {
            var handler = new WebApiHandler();
            var returnedItem = await handler.GetUsers();
            if (returnedItem != null)
            {
                _cachedUsers = returnedItem;
            }
            return _cachedUsers;
        }

        /// <summary>
        ///     Populate data with data from server
        /// </summary>
        public async Task<IList<Datafield>> GetDatafields(string file)
        {
            if (file == null) return _cachedDatafields;

            var handler = new WebApiHandler();
            var returnedItem = await handler.GetDatafields(file);
            if (returnedItem != null)
            {
                _cachedDatafields = returnedItem;
            }
            return _cachedDatafields;
        }
    }
}