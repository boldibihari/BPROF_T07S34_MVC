// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NationalChampionship
{
    using System;
    using ConsoleTools;

    /// <summary>
    /// Program class.
    /// </summary>
    internal class Program
    {
        private static void Main()
        {
            Factory factory = new Factory();

            Console.Title = "NationalChampionship";

            var menu = new ConsoleMenu()
                .Add("Clubs", clubs => UserMenuMethod.GetAllClub(factory.UserLogic))
                .Add("Managers", managers => UserMenuMethod.GetAllManager(factory.UserLogic))
                .Add("Players", players => UserMenuMethod.GetAllPlayer(factory.UserLogic))
                .Add("Captains", captains => UserMenuMethod.GetAllCaptain(factory.UserLogic))
                .Add("Get club", club => UserMenuMethod.GetOneClub(factory.UserLogic))
                .Add("Get manager", manager => UserMenuMethod.GetOneManager(factory.UserLogic))
                .Add("Get player", player => UserMenuMethod.GetOnePlayer(factory.UserLogic))
                .Add("Add club", club => AdministratorMenuMethod.AddClub(factory.AdministratorLogic))
                .Add("Add manager", manager => AdministratorMenuMethod.AddManager(factory.AdministratorLogic, factory.UserLogic))
                .Add("Add player", player => AdministratorMenuMethod.AddPlayer(factory.AdministratorLogic, factory.UserLogic))
                .Add("Delete club", club => AdministratorMenuMethod.DeleteClub(factory.AdministratorLogic, factory.UserLogic))
                .Add("Delete manager", manager => AdministratorMenuMethod.DeleteManager(factory.AdministratorLogic, factory.UserLogic))
                .Add("Delete player", player => AdministratorMenuMethod.DeletePlayer(factory.AdministratorLogic, factory.UserLogic))
                .Add("Update club", club => AdministratorMenuMethod.UpdateClub(factory.AdministratorLogic, factory.UserLogic))
                .Add("Update manager", manager => AdministratorMenuMethod.UpdateManager(factory.AdministratorLogic, factory.UserLogic))
                .Add("Update player", player => AdministratorMenuMethod.UpdatePlayer(factory.AdministratorLogic, factory.UserLogic))
                .Add("Statistics", statistics => UserMenuMethod.Statistics(factory.UserLogic))
                .Add("Task1", task => UserMenuMethod.AverageClubValueAsync(factory.UserLogic))
                .Add("Task2", task => UserMenuMethod.GetNationalityOneClubAsync(factory.UserLogic))
                .Add("Task3", task => UserMenuMethod.GetPositionOneClubAsync(factory.UserLogic))
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
