using Microsoft.AspNetCore.Mvc;
using NationalChampionship.Data.Models;
using NationalChampionship.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class AdministratorController : ControllerBase
    {
        IAdministratorLogic administratorLogic;

        public AdministratorController(IAdministratorLogic administratorLogic)
        {
            this.administratorLogic = administratorLogic;
        }

        [HttpPost("AddManager")]
        public void AddClub([FromBody] Club club)
        {
            this.administratorLogic.AddClub(club);
        }

        [HttpPost("AddManager/{managerId}")]
        public void AddManagerToClub([FromBody] Manager manager, int managerId)
        {
            this.administratorLogic.AddManagerToClub(manager, managerId);
        }

        [HttpPost("AddPlayer/{playerId}")]
        public void AddPlayerToClub([FromBody] Player player, int playerId)
        {
            this.administratorLogic.AddPlayerToClub(player, playerId);
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

        [HttpDelete("DeleteClub/{playerId}")]
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
