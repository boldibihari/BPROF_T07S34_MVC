// <copyright file="AdministratorMenuMethod.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NationalChampionship
{
    using System;
    using NationalChampionship.Data.Models;
    using NationalChampionship.Logic.Classes;

    /// <summary>
    /// AdministratorMenuMethod static class.
    /// </summary>
    internal static class AdministratorMenuMethod
    {
        /// <summary>
        /// AddClub method.
        /// </summary>
        /// <param name="administratorLogic">AdministratorLogic parameter.</param>
        public static void AddClub(AdministratorLogic administratorLogic)
        {
            Console.Clear();

            Club club = new Club();

            Console.Write("Name: ");
            club.ClubName = Console.ReadLine();
            Console.Write("Colour: ");
            club.ClubColour = Console.ReadLine();
            int founded;
            bool number;
            do
            {
                Console.Write("Founded: ");
                string value = Console.ReadLine();
                number = int.TryParse(value, out founded);
            }
            while (number != true || founded >= DateTime.Now.Year);

            club.ClubFounded = founded;

            Console.Write("City: ");
            club.ClubCity = Console.ReadLine();
            Console.Write("Stadium: ");
            club.Stadium = Console.ReadLine();

            administratorLogic.AddClub(club);
            Console.Clear();
            Console.WriteLine("Successful addition!");

            Console.ReadLine();
        }

        /// <summary>
        /// AddManager method.
        /// </summary>
        /// <param name="administratorLogic">AdministratorLogic parameter.</param>
        /// <param name="userLogic">UserLogic parameter.</param>
        public static void AddManager(AdministratorLogic administratorLogic, UserLogic userLogic)
        {
            Console.Write("Enter a Club id: ");

            string input = Console.ReadLine();
            bool number1 = int.TryParse(input, out int id);

            Club club = userLogic.GetOneClub(id);

            if (club == null && number1 != false)
            {
                Console.WriteLine("Club is not found!");
            }
            else if (number1 == false)
            {
                Console.WriteLine("Incorrect id!");
            }
            else
            {
                if (club.Manager == null)
                {
                    Console.Clear();
                    Manager manager = new Manager();
                    Console.Write("Name: ");
                    manager.ManagerName = Console.ReadLine();
                    Console.Write("Nationality: ");
                    manager.ManagerNationality = Console.ReadLine();
                    DateTime birthdate;
                    bool date;
                    do
                    {
                        Console.Write("Birthdate: ");
                        string value = Console.ReadLine();
                        date = DateTime.TryParse(value, out birthdate);
                    }
                    while (date != true);
                    manager.ManagerBirthDate = birthdate;
                    int year;
                    bool number2;
                    do
                    {
                        Console.Write("Start year: ");
                        string value = Console.ReadLine();
                        number2 = int.TryParse(value, out year);
                    }
                    while (number2 != true);
                    manager.ManagerStartYear = year;
                    bool won;
                    bool answer;
                    do
                    {
                        Console.Write("Won a champoinship: ");
                        string value = Console.ReadLine();
                        answer = bool.TryParse(value, out won);
                    }
                    while (answer != true);
                    manager.WonChampionship = won;
                    manager.ClubId = id;
                    administratorLogic.AddManagerToClub(manager, id);
                    Console.Clear();
                    Console.WriteLine("Successful addition!");
                }
                else
                {
                    Console.WriteLine("This club already has a manager!");
                }
            }

            Console.ReadLine();
        }

        /// <summary>
        /// AddPlayer method.
        /// </summary>
        /// <param name="administratorLogic">AdministratorLogic parameter.</param>
        /// <param name="userLogic">UserLogic parameter.</param>
        public static void AddPlayer(AdministratorLogic administratorLogic, UserLogic userLogic)
        {
            Console.Write("Enter a Club id: ");

            string input = Console.ReadLine();
            bool number = int.TryParse(input, out int id);

            Club club = userLogic.GetOneClub(id);

            if (club == null && number != false)
            {
                Console.WriteLine("Club is not found!");
            }
            else if (number == false)
            {
                Console.WriteLine("Incorrect id!");
            }
            else
            {
                Console.Clear();
                Player player = new Player();
                Console.Write("Name: ");
                player.PlayerName = Console.ReadLine();
                Console.Write("Nationality: ");
                player.PlayerNationality = Console.ReadLine();
                DateTime birthdate;
                bool date;
                do
                {
                    Console.Write("Birthdate: ");
                    date = DateTime.TryParse(Console.ReadLine(), out birthdate);
                }
                while (date != true);
                player.PlayerBirthDate = birthdate;
                PlayerPosition position;
                bool post;
                do
                {
                    Console.Write("Position: ");
                    post = Enum.TryParse(Console.ReadLine(), out position);
                }
                while (post != true);
                player.PlayerPosition = position;
                double value;
                bool number2;
                do
                {
                    Console.Write("Value: ");
                    number2 = double.TryParse(Console.ReadLine(), out value);
                }
                while (number2 != true);
                player.PlayerValue = value;
                player.ClubId = id;

                administratorLogic.AddPlayerToClub(player, id);
                Console.Clear();
                Console.WriteLine("Successful addition!");
            }

            Console.ReadLine();
        }

        /// <summary>
        /// DeleteClub method.
        /// </summary>
        /// <param name="administratorLogic">AdministratorLogic parameter.</param>
        /// <param name="userLogic">UserLogic parameter.</param>
        public static void DeleteClub(AdministratorLogic administratorLogic, UserLogic userLogic)
        {
            Console.Write("Enter a club id: ");

            string input = Console.ReadLine();
            bool number = int.TryParse(input, out int id);

            Club club = userLogic.GetOneClub(id);

            if (club == null && number != false)
            {
                Console.WriteLine("Club is not found!");
            }
            else if (number == false)
            {
                Console.WriteLine("Incorrect id!");
            }
            else
            {
                administratorLogic.DeleteClub(club.ClubId);
                Console.WriteLine("Successful delete!");
            }

            Console.ReadLine();
        }

        /// <summary>
        /// DeleteManager method.
        /// </summary>
        /// <param name="administratorLogic">AdministratorLogic parameter.</param>
        /// <param name="userLogic">UserLogic parameter.</param>
        public static void DeleteManager(AdministratorLogic administratorLogic, UserLogic userLogic)
        {
            Console.Write("Enter a manager id: ");

            string input = Console.ReadLine();
            bool number = int.TryParse(input, out int id);

            Manager manager = userLogic.GetOneManager(id);

            if (manager == null && number != false)
            {
                Console.WriteLine("Manager is not found!");
            }
            else if (number == false)
            {
                Console.WriteLine("Incorrect id!");
            }
            else
            {
                administratorLogic.DeleteManager(manager.ManagerId);
                Console.WriteLine("Successful delete!");
            }

            Console.ReadLine();
        }

        /// <summary>
        /// DeletePlayer method.
        /// </summary>
        /// <param name="administratorLogic">AdministratorLogic parameter.</param>
        /// <param name="userLogic">UserLogic parameter.</param>
        public static void DeletePlayer(AdministratorLogic administratorLogic, UserLogic userLogic)
        {
            Console.Write("Enter a player id: ");

            string input = Console.ReadLine();
            bool number = int.TryParse(input, out int id);

            Player player = userLogic.GetOnePlayer(id);

            if (player == null && number != false)
            {
                Console.WriteLine("Player is not found!");
            }
            else if (number == false)
            {
                Console.WriteLine("Incorrect id!");
            }
            else
            {
                administratorLogic.DeletePlayer(player.PlayerId);
                Console.WriteLine("Successful delete!");
            }

            Console.ReadLine();
        }

        /// <summary>
        /// UpdateClub method.
        /// </summary>
        /// <param name="administratorLogic">AdministratorLogic parameter.</param>
        /// <param name="userLogic">UserLogic parameter.</param>
        public static void UpdateClub(AdministratorLogic administratorLogic, UserLogic userLogic)
        {
            Console.Write("Enter a club id: ");

            string input = Console.ReadLine();
            bool number = int.TryParse(input, out int id);

            Club club = userLogic.GetOneClub(id);

            if (club == null && number != false)
            {
                Console.WriteLine("Club is not found!");
            }
            else if (number == false)
            {
                Console.WriteLine("Incorrect id!");
            }
            else
            {
                Console.Clear();

                Club clubModified = new Club();

                Console.Write($"Name: {club.ClubName} --> ");

                string name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name))
                {
                    clubModified.ClubName = name;
                }
                else
                {
                    clubModified.ClubName = club.ClubName;
                }

                Console.Write($"Colour: {club.ClubColour} --> ");

                string colour = Console.ReadLine();
                if (!string.IsNullOrEmpty(colour))
                {
                    clubModified.ClubColour = colour;
                }
                else
                {
                    clubModified.ClubColour = club.ClubColour;
                }

                Console.Write($"City: {club.ClubCity} --> ");

                string city = Console.ReadLine();
                if (!string.IsNullOrEmpty(city))
                {
                    clubModified.ClubCity = city;
                }
                else
                {
                    clubModified.ClubCity = club.ClubCity;
                }

                Console.Write($"Founded: {club.ClubFounded} --> ");

                string founded = Console.ReadLine();
                if (!string.IsNullOrEmpty(founded))
                {
                    clubModified.ClubFounded = int.Parse(founded);
                }
                else
                {
                    clubModified.ClubFounded = club.ClubFounded;
                }

                Console.Write($"Stadium: {club.Stadium} --> ");

                var stadium = Console.ReadLine();
                if (!string.IsNullOrEmpty(stadium))
                {
                    clubModified.Stadium = stadium;
                }
                else
                {
                    clubModified.Stadium = club.Stadium;
                }

                administratorLogic.UpdateClub(id, clubModified);
                Console.Clear();
                Console.WriteLine("Successful modification!");
            }

            Console.ReadLine();
        }

        /// <summary>
        /// UpdateManager method.
        /// </summary>
        /// <param name="administratorLogic">AdministratorLogic parameter.</param>
        /// <param name="userLogic">UserLogic parameter.</param>
        public static void UpdateManager(AdministratorLogic administratorLogic, UserLogic userLogic)
        {
            Console.Write("Enter a manager id: ");

            string input = Console.ReadLine();
            bool number = int.TryParse(input, out int id);

            Manager manager = userLogic.GetOneManager(id);

            if (manager == null && number != false)
            {
                Console.WriteLine("Manager is not found!");
            }
            else if (number == false)
            {
                Console.WriteLine("Incorrect id!");
            }
            else
            {
                Console.Clear();

                Manager managerModified = new Manager();

                Console.Write($"Name: {manager.ManagerName} --> ");

                string name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name))
                {
                    managerModified.ManagerName = name;
                }
                else
                {
                    managerModified.ManagerName = manager.ManagerName;
                }

                Console.Write($"Nationality: {manager.ManagerNationality} --> ");

                string nationality = Console.ReadLine();
                if (!string.IsNullOrEmpty(nationality))
                {
                    managerModified.ManagerNationality = nationality;
                }
                else
                {
                    managerModified.ManagerNationality = manager.ManagerNationality;
                }

                Console.Write($"City: {manager.ManagerBirthDate} --> ");

                string birthdate = Console.ReadLine();
                if (!string.IsNullOrEmpty(birthdate))
                {
                    managerModified.ManagerBirthDate = DateTime.Parse(birthdate);
                }
                else
                {
                    managerModified.ManagerBirthDate = manager.ManagerBirthDate;
                }

                Console.Write($"Start year: {manager.ManagerStartYear} --> ");

                string year = Console.ReadLine();
                if (!string.IsNullOrEmpty(year))
                {
                    managerModified.ManagerStartYear = int.Parse(year);
                }
                else
                {
                    managerModified.ManagerStartYear = manager.ManagerStartYear;
                }

                Console.Write($"Stadium: {manager.WonChampionship} --> ");

                string won = Console.ReadLine();
                if (!string.IsNullOrEmpty(won))
                {
                    managerModified.WonChampionship = bool.Parse(won);
                }
                else
                {
                    managerModified.WonChampionship = manager.WonChampionship;
                }

                administratorLogic.UpdateManager(id, managerModified);
                Console.Clear();
                Console.WriteLine("Successful modification!");
            }

            Console.ReadLine();
        }

        /// <summary>
        /// UpdatePlayer method.
        /// </summary>
        /// <param name="administratorLogic">AdministratorLogic parameter.</param>
        /// <param name="userLogic">UserLogic parameter.</param>
        public static void UpdatePlayer(AdministratorLogic administratorLogic, UserLogic userLogic)
        {
            Console.Write("Enter a player id: ");

            string input = Console.ReadLine();
            bool number = int.TryParse(input, out int id);

            Player player = userLogic.GetOnePlayer(id);

            if (player == null && number != false)
            {
                Console.WriteLine("Player is not found!");
            }
            else if (number == false)
            {
                Console.WriteLine("Incorrect id!");
            }
            else
            {
                Console.Clear();

                Player playerModified = new Player();

                Console.Write($"Name: {player.PlayerName} --> ");

                string name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name))
                {
                    playerModified.PlayerName = name;
                }
                else
                {
                    playerModified.PlayerName = player.PlayerName;
                }

                Console.Write($"Nationality: {player.PlayerNationality} --> ");

                string nationality = Console.ReadLine();
                if (!string.IsNullOrEmpty(nationality))
                {
                    playerModified.PlayerNationality = nationality;
                }
                else
                {
                    playerModified.PlayerNationality = player.PlayerNationality;
                }

                Console.Write($"City: {player.PlayerBirthDate} --> ");

                string birthdate = Console.ReadLine();
                if (!string.IsNullOrEmpty(birthdate))
                {
                    playerModified.PlayerBirthDate = DateTime.Parse(birthdate);
                }
                else
                {
                    playerModified.PlayerBirthDate = player.PlayerBirthDate;
                }

                Console.Write($"Position: {player.PlayerPosition} --> ");

                string position = Console.ReadLine();
                if (!string.IsNullOrEmpty(position))
                {
                    playerModified.PlayerPosition = (PlayerPosition)Enum.Parse(typeof(PlayerPosition), position);
                }
                else
                {
                    playerModified.PlayerPosition = player.PlayerPosition;
                }

                Console.Write($"Value: {player.PlayerValue} --> ");

                string value = Console.ReadLine();
                if (!string.IsNullOrEmpty(value))
                {
                    playerModified.PlayerValue = double.Parse(value);
                }
                else
                {
                    playerModified.PlayerValue = player.PlayerValue;
                }

                administratorLogic.UpdatePlayer(id, playerModified);
                Console.Clear();
                Console.WriteLine("Successful modification!");
            }

            Console.ReadLine();
        }
    }
}
