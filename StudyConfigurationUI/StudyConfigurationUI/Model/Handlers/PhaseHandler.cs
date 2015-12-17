// PhaseHandler.cs is a part of Autosys project in BDSA-2015. Created: 16, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

#region

using System;
using System.Collections.Generic;
using System.Linq;
using StudyConfigurationUI.Model.PhaseModels;
using StudyConfigurationUI.View.ViewDTO;

#endregion

namespace StudyConfigurationUI.Model.Handlers
{
    /// <summary>
    ///     This class is responsible for handling phases and their respected dtos
    /// </summary>
    public class PhaseHandler
    {
        /// <summary>
        ///     returns a phase DTO object that are to be transfered between studyview and phaseview
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


        /// <summary>
        ///     Sets a phase with a given phase object and phase informations
        /// </summary>
        /// <param name="phase">phase to set</param>
        /// <param name="phaseInformation">informations of a phase</param>
        /// <returns>boolean whether the phase was created</returns>
        public bool SetPhase(Phase phase, ViewPhaseDto phaseInformation)
        {
            if (string.IsNullOrWhiteSpace(phaseInformation.Name) ||
                string.IsNullOrWhiteSpace(phaseInformation.Description))
                throw new ArgumentException("Name and description must not be null or whitespace");
            if (phaseInformation.Members.Count == 0 || phaseInformation.VisibleDatafields.Count == 0 ||
                phaseInformation.RequestedDatafields.Count == 0)
                throw new ArgumentException("users, requested- and visible fields must not be empty");
            if (!IsMemberRolesValid(phaseInformation.Members))
                throw new ArgumentException("Member roles are invalid");

            phase.Name = phaseInformation.Name;
            phase.Description = phaseInformation.Description;
            phase.PhaseMembers = phaseInformation.Members;
            phase.VisibleDataField = phaseInformation.VisibleDatafields;
            phase.RequestedDatafield = phaseInformation.RequestedDatafields;

            return true;
        }

        /// <summary>
        ///     Checking if member roles a correct
        /// </summary>
        /// <param name="members"></param>
        /// <returns></returns>
        private bool IsMemberRolesValid(IList<PhaseMember> members)
        {
            //Check if there is any reviewers
            var counter = 0;
            foreach (var phaseMember in members)
            {
                if (phaseMember.IsReviewer)
                {
                    counter++;
                    break;
                }
            }
            if (counter == 0) return false;

            //Check if there is only one validator
            counter = 0;
            foreach (var member in members)
            {
                if (member.IsValidator) counter++;
                if (counter > 1) return false;
            }
            return counter == 1;
        }
    }
}