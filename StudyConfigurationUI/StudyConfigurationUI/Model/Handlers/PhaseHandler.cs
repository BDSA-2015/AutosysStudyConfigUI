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

        public bool SetPhase(Phase phase,string name, string description, IList<PhaseMember> members, IList<Datafield> visibleDatafields, IList<Datafield> requestedDatafields)
        {
            if(string.IsNullOrWhiteSpace(name)||string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Name and description must not be null or whitespace");
            if(members.Count == 0 || visibleDatafields.Count == 0 || requestedDatafields.Count == 0)
                throw new ArgumentException("users, requested- and visible fields must not be empty");
            if(!IsMemberRolesValid(members))
                throw new ArgumentException("Member roles are invalid");

            phase.Name = name;
            phase.Description = description;
            phase.PhaseMembers = members;
            phase.VisibleDataField = visibleDatafields;
            phase.RequestedDatafield = requestedDatafields;

            return true;



        }

        /// <summary>
        /// Checking if member roles a correct
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
            foreach ( var member in members)
            {
                if (member.IsValidator) counter++;
                if (counter > 1) return false;
            }
            return counter == 1;
        }
    }
}