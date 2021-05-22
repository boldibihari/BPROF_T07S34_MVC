using Microsoft.AspNetCore.Identity;
using NationalChampionship.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalChampionship.Logic.Interfaces
{
    public interface IAuthLogic
    {
        IEnumerable<IdentityUser> GetAllUser();

        Task<string> RegisterUser(RegisterViewModel model);

        Task<TokenViewModel> LoginUser(LoginViewModel model);
    }
}
