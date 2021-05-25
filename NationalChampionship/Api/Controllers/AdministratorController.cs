using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NationalChampionship.Data.Models;
using NationalChampionship.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("{controller}")]
    public class AdministratorController : ControllerBase
    {
        IAdministratorLogic administratorLogic;

        public AdministratorController(IAdministratorLogic administratorLogic)
        {
            this.administratorLogic = administratorLogic;
        }

        [HttpPost("AddClub")]
        public void AddClub([FromBody] Club club)
        {
            this.administratorLogic.AddClub(club);
        }

        [HttpPost("AddManager/{clubId}")]
        public void AddManagerToClub([FromBody] Manager manager, int clubId)
        {
            this.administratorLogic.AddManagerToClub(manager, clubId);
        }

        [HttpPost("AddPlayer/{clubId}")]
        public void AddPlayerToClub([FromBody] Player player, int clubId)
        {
            this.administratorLogic.AddPlayerToClub(player, clubId);
        }

        [HttpDelete("DeleteClub/{clubId}")]
        public void DeleteClub(int clubId)
        {
            this.administratorLogic.DeleteClub(clubId);
        }

        [HttpDelete("DeleteManager/{managerId}")]
        public void DeleteManager(int managerId)
        {
            this.administratorLogic.DeleteManager(managerId);
        }

        [HttpDelete("DeletePlayer/{playerId}")]
        public void DeletePlayer(int playerId)
        {
            this.administratorLogic.DeletePlayer(playerId);
        }

        [HttpPut("UpdateClub/{clubId}")]
        public void UpdateClub(int clubId, [FromBody] Club updatedClub)
        {
            this.administratorLogic.UpdateClub(clubId, updatedClub);
        }

        [HttpPut("UpdateManager/{managerId}")]
        public void UpdateManager(int managerId, [FromBody] Manager updatedManager)
        {
            this.administratorLogic.UpdateManager(managerId, updatedManager);
        }

        [HttpPut("UpdatePlayer/{playerId}")]
        public void UpdatePlayer(int playerId, [FromBody] Player updatedPlayer)
        {
            this.administratorLogic.UpdatePlayer(playerId, updatedPlayer);
        }
    }
}
