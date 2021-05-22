// <copyright file="UserMenuMethod.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NationalChampionship
{
    using System;
    using System.Linq;
    using NationalChampionship.Data.Models;
    using NationalChampionship.Logic.Classes;

    /// <summary>
    /// UserMenuMethod static class.
    /// </summary>
    internal static class UserMenuMethod
    {
        /// <summary>
        /// GetAllClub method.
        /// </summary>
        /// <param name="userLogic">UserLogic parameter.</param>
        public static void GetAllClub(UserLogic userLogic)
        {
            Console.Clear();
            Console.WriteLine("--- CLUBS ---");
            Console.WriteLine();
            userLogic.GetAllClub().ToList().ForEach(c => Console.WriteLine($"{c.ClubId} {c.ClubName}"));
            Console.ReadLine();
        }

        /// <summary>
        /// GetAllManager method.
        /// </summary>
        /// <param name="userLogic">UserLogic parameter.</param>
        public static void GetAllManager(UserLogic userLogic)
        {
            Console.Clear();
            Console.WriteLine("--- MANAGERS ---");
            Console.WriteLine();
            userLogic.GetAllManager().ToList().ForEach(m => Console.WriteLine($"{m.ManagerId} {m.ManagerName}"));
            Console.ReadLine();
        }

        /// <summary>
        /// GetAllPlayer method.
        /// </summary>
        /// <param name="userLogic">UserLogic parameter.</param>
        public static void GetAllPlayer(UserLogic userLogic)
        {
            Console.Clear();
            Console.WriteLine("--- PLAYERS ---");
            Console.WriteLine();
            userLogic.GetAllPlayer().ToList().ForEach(p => Console.WriteLine($"{p.PlayerId} {p.PlayerName}"));
            Console.ReadLine();
        }

        /// <summary>
        /// GetAllCaptain method.
        /// </summary>
        /// <param name="userLogic">UserLogic parameter.</param>
        public static void GetAllCaptain(UserLogic userLogic)
        {
            Console.Clear();
            Console.WriteLine("--- CAPTAINS ---");
            Console.WriteLine();
            userLogic.GetAllCaptain().ToList().ForEach(p => Console.WriteLine($"{p.PlayerId} {p.PlayerName}"));
            Console.ReadLine();
        }

        /// <summary>
        /// GetOneClub method.
        /// </summary>
        /// <param name="userLogic">UserLogic parameter.</param>
        public static void GetOneClub(UserLogic userLogic)
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
                Console.WriteLine($"--- {club.ClubName.ToUpper()} ---");
                Console.WriteLine();
                Console.WriteLine(club);

                Console.WriteLine();
                Console.WriteLine("Manager:");

                if (club.Manager != null)
                {
                    Console.WriteLine($" {club.Manager.ManagerName}");
                }
                else
                {
                    Console.WriteLine(club.Manager);
                }

                Console.WriteLine("Players:");

                if (club.Players.Count != 0)
                {
                    club.Players.ToList().ForEach(p => Console.WriteLine($" {p.PlayerName}"));
                    Console.WriteLine();
                    Console.WriteLine($"Value: {userLogic.ClubValue(club.ClubId)} m EUR");
                    Console.WriteLine($"Avarage player value: {userLogic.ClubAveragePlayerValue(club.ClubId)} m EUR");
                    Console.WriteLine($"Avarage player age: {userLogic.ClubAverageAge(club.ClubId)}");
                    Console.WriteLine();

                    Console.WriteLine("Nationalities:");
                    var nationalities = userLogic.GetNationalityOneClub(club.ClubId);
                    foreach (var nationality in nationalities)
                    {
                        Console.WriteLine($" {nationality}");
                    }

                    Console.WriteLine();

                    Console.WriteLine("Positions:");
                    var positions = userLogic.GetPositionOneClub(club.ClubId);
                    foreach (var position in positions)
                    {
                        Console.WriteLine($" {position}");
                    }
                }
            }

            Console.ReadLine();
        }

        /// <summary>
        /// GetOneManager method.
        /// </summary>
        /// <param name="userLogic">UserLogic parameter.</param>
        public static void GetOneManager(UserLogic userLogic)
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
                Console.WriteLine($"--- {manager.ManagerName.ToUpper()} ---");
                Console.WriteLine();
                Console.WriteLine($"{manager.Club.ClubName}");
                Console.WriteLine(manager);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// GetOnePlayer method.
        /// </summary>
        /// <param name="userLogic">UserLogic parameter.</param>
        public static void GetOnePlayer(UserLogic userLogic)
        {
            Console.Write("Enter a player id: ");

            string input = Console.ReadLine();
            bool number = int.TryParse(input, out int id);

            Player player = userLogic.GetOnePlayer(id);

            if (player == null && number != false)
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
                Console.WriteLine($"--- {player.PlayerName.ToUpper()} ---");
                Console.WriteLine();
                Console.WriteLine($"{player.Club.ClubName}");
                Console.WriteLine(player);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Statistics method.
        /// </summary>
        /// <param name="userLogic">UserLogic parameter.</param>
        public static void Statistics(UserLogic userLogic)
        {
            Console.Clear();

            var clubs = userLogic.GetAllClub();

            if (clubs.Count != 0)
            {
                Console.WriteLine("--- STATISTICS ---");

                Console.WriteLine();

                Console.WriteLine($"All value: {userLogic.AllValue()} m EUR");
                Console.WriteLine($"Average player age: {userLogic.AllAverageAge()}");
                Console.WriteLine($"Average club value: {userLogic.AverageClubValue()} m EUR");
                Console.WriteLine($"Average player value: {userLogic.AveragePlayerValue()} m EUR");

                Console.WriteLine();

                Console.WriteLine("Nationalities:");
                var nationalities = userLogic.GetAllNationality();
                foreach (var nationality in nationalities)
                {
                    Console.WriteLine($" {nationality}");
                }

                Console.WriteLine();

                Console.WriteLine("Positions:");
                var positions = userLogic.GetAllPosition();
                foreach (var position in positions)
                {
                    Console.WriteLine($" {position}");
                }
            }

            Console.ReadLine();
        }

        /// <summary>
        /// AverageClubValueAsync method.
        /// </summary>
        /// <param name="userLogic">UserLogic parameter.</param>
        public static void AverageClubValueAsync(UserLogic userLogic)
        {
            Console.Clear();

            Console.WriteLine(userLogic.AverageClubValueAsync().Result);

            Console.ReadLine();
        }

        /// <summary>
        /// GetNationalityOneClubAsync method.
        /// </summary>
        /// <param name="userLogic">UserLogic parameter.</param>
        public static void GetNationalityOneClubAsync(UserLogic userLogic)
        {
            Console.Clear();

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

                var nationalities = userLogic.GetNationalityOneClubAsync(club.ClubId).Result;

                foreach (var nationality in nationalities)
                {
                    Console.WriteLine(nationality);
                }
            }

            Console.ReadLine();
        }

        /// <summary>
        /// GetPositionOneClubAsync method.
        /// </summary>
        /// <param name="userLogic">UserLogic parameter.</param>
        public static void GetPositionOneClubAsync(UserLogic userLogic)
        {
            Console.Clear();

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

                var positions = userLogic.GetPositionOneClubAsync(club.ClubId).Result;

                foreach (var position in positions)
                {
                    Console.WriteLine(position);
                }
            }

            Console.ReadLine();
        }
    }
}
