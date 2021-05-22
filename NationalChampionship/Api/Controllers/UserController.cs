using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NationalChampionship.Data.Models;
using NationalChampionship.Logic.Classes;
using NationalChampionship.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Authorize(Roles = "User")]
    [ApiController]
    [Route("{controller}")]
    public class UserController : ControllerBase
    {
        IUserLogic userLogic;

        public UserController(IUserLogic userLogic)
        {
            this.userLogic = userLogic;
        }

        [HttpGet("GetOneClub/{clubId}")]
        public Club GetOneClub(int clubId)
        {
            return userLogic.GetOneClub(clubId);
        }

        [HttpGet("GetOneManager/{managerId}")]
        public Manager GetOneManager(int managerId)
        {
            return userLogic.GetOneManager(managerId);
        }

        [HttpGet("GetOnePlayer/{playerId}")]
        public Player GetOnePlayer(int playerId)
        {
            return userLogic.GetOnePlayer(playerId);
        }

        [HttpGet("GetAllClub")]
        public IQueryable<Club> GetAllClub()
        {
            return userLogic.GetAllClub().AsQueryable();
        }

        [HttpGet("GetAllManager")]
        public IQueryable<Manager> GetAllManager()
        {
            return userLogic.GetAllManager().AsQueryable();
        }

        [HttpGet("GetAllPlayer")]
        public IQueryable<Player> GetAllPlayer()
        {
            return userLogic.GetAllPlayer().AsQueryable();
        }

        [HttpGet("GetAllCaptain")]
        public IQueryable<Player> GetAllCaptain()
        {
            return userLogic.GetAllCaptain().AsQueryable();
        }

        [HttpGet("ClubAverageAge/{clubId}")]
        public int ClubAverageAge(int clubId)
        {
            return userLogic.ClubAverageAge(clubId);
        }

        [HttpGet("AllAverageAge")]
        public int AllAverageAge()
        {
            return userLogic.AllAverageAge();
        }

        [HttpGet("ClubValue/{clubId}")]
        public double ClubValue(int clubId)
        {
            return userLogic.ClubValue(clubId);
        }

        [HttpGet("AllValue")]
        public double AllValue()
        {
            return userLogic.AllValue();
        }

        [HttpGet("AverageClubValue")]
        public double AverageClubValue()
        {
            return userLogic.AverageClubValue();
        }

        [HttpGet("ClubAveragePlayerValue/{clubId}")]
        public double ClubAveragePlayerValue(int clubId)
        {
            return userLogic.ClubAveragePlayerValue(clubId);
        }

        [HttpGet("AveragePlayerValue")]
        public double AveragePlayerValue()
        {
            return userLogic.AveragePlayerValue();
        }

        [HttpGet("GetNationalityOneClub/{clubId}")]
        public IQueryable<Nationality> GetNationalityOneClub(int clubId)
        {
            return userLogic.GetNationalityOneClub(clubId).AsQueryable();
        }

        [HttpGet("GetAllNationality")]
        public IQueryable<Nationality> GetAllNationality()
        {
            return userLogic.GetAllNationality().AsQueryable();
        }

        [HttpGet("GetPositionOneClub/{clubId}")]
        public IQueryable<Position> GetPositionOneClub(int clubId)
        {
            return userLogic.GetPositionOneClub(clubId).AsQueryable();
        }

        [HttpGet("GetAllPosition")]
        public IQueryable<Position> GetAllPosition()
        {
            return userLogic.GetAllPosition().AsQueryable();
        }
    }
}
