// LocalCache.cs is a part of Autosys project in BDSA-2015. Created: 15, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System.Collections.Generic;
using StudyConfigurationUI.Model.PhaseModels;

namespace StudyConfigurationUI.Model
{
    /// <summary>
    /// Stores all retrieved data from server
    /// </summary>
    public class LocalCache
    {
         IList<Datafield> CachedDatafields { get; set; }
        IList<User> CachedUsers { get; set; } 
             
    }
}