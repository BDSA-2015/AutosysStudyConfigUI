// PhaseHandler.cs is a part of Autosys project in BDSA-2015. Created: 15, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

#region

using System;
using System.Collections.Generic;
using System.Linq;
using StudyConfigurationUI.Model.PhaseModels;

#endregion

namespace StudyConfigurationUI.Model.Handlers
{
    /// <summary>
    ///     This class is responsible for handling phases and their respected dtos
    /// </summary>
    public class PhaseHandler
    {
        /// <summary>
        ///     Gets a DTO object that are to be transfered between studyview and phaseview
        /// </summary>
        /// <param name="phase">phase that are to create</param>
        /// <param name="datafields"></param>
        /// <param name="users"></param>
        /// <returns>phase creation dto</returns>
        public PhaseCreationDto GetPhaseCreationDto(Phase phase, IList<Datafield> datafields, IList<User> users)
        {
            var dto = new PhaseCreationDto()
            {
                Datafields = datafields,
                Phase = phase,
                Members = ConvertUsersToPhaseMembers(users)
            };

            return dto;
        }

        /// <summary>
        ///     Converts all users to members so one can add roles
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        private IList<PhaseMember> ConvertUsersToPhaseMembers(IList<User> users)
        {
            if (users != null)
            {
                return users.Select(user => new PhaseMember() {UserId = user.Id, Name = user.Name}).ToList();
            }
            throw new NullReferenceException("List with users were null");
        }
    }
}