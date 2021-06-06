// <copyright file="NationalChampionshipDbContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NationalChampionship.Data.Models
{
    using System;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// NationalChampionshipDbContext class.
    /// </summary>
    public class NationalChampionshipDbContext : IdentityDbContext<IdentityUser>
    {
        /// <summary>
        /// Clubs table.
        /// </summary>
        public DbSet<Club> Clubs { get; set; }

        /// <summary>
        /// Managers table.
        /// </summary>
        public DbSet<Manager> Managers { get; set; }

        /// <summary>
        /// Players table.
        /// </summary>
        public DbSet<Player> Players { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NationalChampionshipDbContext"/> class.
        /// NationalChampionshipDbContext constructor.
        /// </summary>
        public NationalChampionshipDbContext()
        {
            this.Database.EnsureCreated();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NationalChampionshipDbContext"/> class.
        /// NationalChampionshipDbContext base constructor.
        /// </summary>
        /// <param name="opt">DbContextOptions implementation.</param>
        public NationalChampionshipDbContext(DbContextOptions<NationalChampionshipDbContext> opt)
            : base(opt)
        {
        }

        /// <summary>
        /// OnConfiguring.
        /// </summary>
        /// <param name="optionsBuilder">DbContextOptionsBuilder implementation.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.
                    UseLazyLoadingProxies().
                    //UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\NationalChampionshipDb.mdf;Integrated Security=True");
                    UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NationalChampionshipDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        /// <summary>
        /// OnModelCreating entity connection and dates.
        /// </summary>
        /// <param name="modelBuilder">ModelBuilder implementation.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(
                new { Id = "341743f0-asd2–42de-afbf-59kmkkmk72cf6", Name = "Admin", NormalizedName = "ADMIN" },
                new { Id = "341743f0-dee2–42de-bbbb-59kmkkmk72cf6", Name = "User", NormalizedName = "USER" });

            var admin = new IdentityUser
            {
                Id = "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                Email = "admin@mail.com",
                NormalizedEmail = "ADMIN@MAIL.COM",
                EmailConfirmed = true,
                UserName = "admin@mail.com",
                NormalizedUserName = "ADMIN@MAIL.COM",
                SecurityStamp = string.Empty,
            };

            var boldi = new IdentityUser
            {
                Id = "e2174cf0–9999–4cfe-afbf-59f706d72cf6",
                Email = "boldibihari@nik.uni-obuda.hu",
                NormalizedEmail = "BOLDIBIHARI@NIK.UNI-OBUDA.HU",
                EmailConfirmed = true,
                UserName = "boldibihari@nik.uni-obuda.hu",
                NormalizedUserName = "BOLDIBIHARI@NIK.UNI-OBUDA.HU",
                SecurityStamp = string.Empty,
            };

            var andris = new IdentityUser
            {
                Id = "e2174cf0–9412–4cfe-afbf-59f706d72cf6",
                Email = "kovacs.andras@nik.uni-obuda.hu",
                NormalizedEmail = "KOVACS.ANDRAS@NIK.UNI-OBUDA.HU",
                EmailConfirmed = true,
                UserName = "kovacs.andras@nik.uni-obuda.hu",
                NormalizedUserName = "KOVACS.ANDRAS@NIK.UNI-OBUDA.HU",
                SecurityStamp = string.Empty,
            };

            admin.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "admin");
            boldi.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "boldi");
            andris.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "andris");

            modelBuilder.Entity<IdentityUser>().HasData(admin);
            modelBuilder.Entity<IdentityUser>().HasData(boldi);
            modelBuilder.Entity<IdentityUser>().HasData(andris);

            // Admin
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                UserId = admin.Id,
            });

            // User
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "341743f0-dee2–42de-bbbb-59kmkkmk72cf6",
                UserId = boldi.Id,
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "341743f0-dee2–42de-bbbb-59kmkkmk72cf6",
                UserId = andris.Id,
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity
                .HasOne(player => player.Club)
                .WithMany(club => club.Players)
                .HasForeignKey(player => player.ClubId);
            });
            modelBuilder.Entity<Manager>(entity =>
            {
                entity
                .HasOne(manager => manager.Club)
                .WithOne(club => club.Manager)
                .HasForeignKey<Manager>(manager => manager.ClubId);
            });

            #region FillDatabase
            Club c1 = new()
            {
                ClubId = 1,
                ClubName = "Ferencvárosi TC",
                ClubCity = "Budapest",
                ClubColour = "green-white",
                ClubFounded = 1899,
                Stadium = "Groupama Aréna",
            };
            Club c2 = new()
            {
                ClubId = 2,
                ClubName = "MOL Fehérvár",
                ClubCity = "Székesfehérvár",
                ClubColour = "red-blue",
                ClubFounded = 1914,
                Stadium = "MOL Aréna Sóstó",
            };
            Club c3 = new()
            {
                ClubId = 3,
                ClubName = "Puskás Akadémia FC",
                ClubCity = "Felcsút",
                ClubColour = "blue-yellow",
                ClubFounded = 2012,
                Stadium = "Pancho Aréna",
            };
            Club c4 = new()
            {
                ClubId = 4,
                ClubName = "Mezőkövesd Zsóry FC",
                ClubCity = "Mezőkövesd",
                ClubColour = "blue-yellow",
                ClubFounded = 1975,
                Stadium = "Mezőkövesdi Stadion",
            };
            Club c5 = new()
            {
                ClubId = 5,
                ClubName = "Budapest Honvéd FC",
                ClubCity = "Budapest",
                ClubColour = "red-black",
                ClubFounded = 1909,
                Stadium = "Bozsik József Stadion",
            };
            Club c6 = new()
            {
                ClubId = 6,
                ClubName = "Újpest FC",
                ClubCity = "Budapest",
                ClubColour = "purple-white",
                ClubFounded = 1885,
                Stadium = "Szusza Ferenc Stadion",
            };

            Manager m1 = new()
            {
                ManagerId = 1,
                ManagerName = "Szerhij Rebrov",
                ManagerNationality = "Ukrainian",
                ManagerBirthDate = new DateTime(1974, 06, 03),
                ManagerStartYear = 2018,
                WonChampionship = true,
                ClubId = c1.ClubId,
            };
            Manager m2 = new()
            {
                ManagerId = 2,
                ManagerName = "Gábor Márton",
                ManagerNationality = "Hungarian",
                ManagerBirthDate = new DateTime(1966, 10, 15),
                ManagerStartYear = 2020,
                WonChampionship = false,
                ClubId = c2.ClubId,
            };
            Manager m3 = new()
            {
                ManagerId = 3,
                ManagerName = "Zsolt Hornyák",
                ManagerNationality = "Slovakian",
                ManagerBirthDate = new DateTime(1973, 05, 01),
                ManagerStartYear = 2019,
                WonChampionship = false,
                ClubId = c3.ClubId,
            };
            Manager m4 = new()
            {
                ManagerId = 4,
                ManagerName = "Attila Kuttor",
                ManagerNationality = "Hungarian",
                ManagerBirthDate = new DateTime(1970, 05, 29),
                ManagerStartYear = 2017,
                WonChampionship = false,
                ClubId = c4.ClubId,
            };
            Manager m5 = new()
            {
                ManagerId = 5,
                ManagerName = "Tamás Bódog",
                ManagerNationality = "Hungarian",
                ManagerBirthDate = new DateTime(1970, 09, 27),
                ManagerStartYear = 2020,
                WonChampionship = false,
                ClubId = c5.ClubId,
            };
            Manager m6 = new()
            {
                ManagerId = 6,
                ManagerName = "Pedrag Rogan",
                ManagerNationality = "Serbian",
                ManagerBirthDate = new DateTime(1974, 08, 02),
                ManagerStartYear = 2020,
                WonChampionship = false,
                ClubId = c6.ClubId,
            };

            Player p1 = new()
            {
                PlayerId = 1,
                PlayerName = "Dénes Dibusz",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1990, 11, 16),
                PlayerPosition = PlayerPosition.Goalkeeper,
                PlayerValue = 2.20,
                ClubId = c1.ClubId,
            };
            Player p2 = new()
            {
                PlayerId = 2,
                PlayerName = "Ádám Bogdán",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1987, 09, 27),
                PlayerPosition = PlayerPosition.Goalkeeper,
                PlayerValue = 0.350,
                ClubId = c1.ClubId,
            };
            Player p3 = new()
            {
                PlayerId = 3,
                PlayerName = "Miha Blazic",
                PlayerNationality = "Slovenian",
                PlayerBirthDate = new DateTime(1993, 05, 08),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 2.00,
                ClubId = c1.ClubId,
            };
            Player p4 = new()
            {
                PlayerId = 4,
                PlayerName = "Adnan Kovacevic",
                PlayerNationality = "Bosniaks",
                PlayerBirthDate = new DateTime(1993, 09, 09),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 1.20,
                ClubId = c1.ClubId,
            };
            Player p5 = new()
            {
                PlayerId = 5,
                PlayerName = "Eldar Civic",
                PlayerNationality = "Bosniaks",
                PlayerBirthDate = new DateTime(1996, 05, 28),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 1.50,
                ClubId = c1.ClubId,
            };
            Player p6 = new()
            {
                PlayerId = 6,
                PlayerName = "Endre Botka",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1994, 08, 25),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 1.00,
                ClubId = c1.ClubId,
            };
            Player p7 = new()
            {
                PlayerId = 7,
                PlayerName = "Gergő Lovrencsics C",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1988, 11, 01),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.800,
                ClubId = c1.ClubId,
            };
            Player p8 = new()
            {
                PlayerId = 8,
                PlayerName = "Igor Kharatin",
                PlayerNationality = "Ukrainian",
                PlayerBirthDate = new DateTime(1995, 02, 02),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 2.50,
                ClubId = c1.ClubId,
            };
            Player p9 = new()
            {
                PlayerId = 9,
                PlayerName = "Somália",
                PlayerNationality = "Brazilian",
                PlayerBirthDate = new DateTime(1988, 09, 28),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 1.30,
                ClubId = c1.ClubId,
            };
            Player p10 = new()
            {
                PlayerId = 10,
                PlayerName = "Dávid Sigér",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1990, 11, 30),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 1.00,
                ClubId = c1.ClubId,
            };
            Player p11 = new()
            {
                PlayerId = 11,
                PlayerName = "Isael",
                PlayerNationality = "Brazilian",
                PlayerBirthDate = new DateTime(1988, 05, 13),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 1.50,
                ClubId = c1.ClubId,
            };
            Player p12 = new()
            {
                PlayerId = 12,
                PlayerName = "Tokmac Nguen",
                PlayerNationality = "Norvegian",
                PlayerBirthDate = new DateTime(1993, 10, 20),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 2.80,
                ClubId = c1.ClubId,
            };
            Player p13 = new()
            {
                PlayerId = 13,
                PlayerName = "Myrto Uzuni",
                PlayerNationality = "Albanian",
                PlayerBirthDate = new DateTime(1995, 05, 31),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 2.20,
                ClubId = c1.ClubId,
            };
            Player p14 = new()
            {
                PlayerId = 14,
                PlayerName = "Oleksandr Zubkov",
                PlayerNationality = "Ukrainian",
                PlayerBirthDate = new DateTime(1996, 08, 03),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 2.00,
                ClubId = c1.ClubId,
            };
            Player p15 = new()
            {
                PlayerId = 15,
                PlayerName = "Franck Boli",
                PlayerNationality = "Ivorian",
                PlayerBirthDate = new DateTime(1993, 12, 07),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 1.00,
                ClubId = c1.ClubId,
            };
            Player p16 = new()
            {
                PlayerId = 16,
                PlayerName = "Ádám Kovácsik",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1991, 04, 04),
                PlayerPosition = PlayerPosition.Goalkeeper,
                PlayerValue = 0.900,
                ClubId = c2.ClubId,
            };
            Player p17 = new()
            {
                PlayerId = 17,
                PlayerName = "Emil Rockov",
                PlayerNationality = "Serbian",
                PlayerBirthDate = new DateTime(1995, 01, 27),
                PlayerPosition = PlayerPosition.Goalkeeper,
                PlayerValue = 0.900,
                ClubId = c2.ClubId,
            };
            Player p18 = new()
            {
                PlayerId = 18,
                PlayerName = "Visar Musliu",
                PlayerNationality = "Northern Macedonia",
                PlayerBirthDate = new DateTime(1994, 11, 13),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 1.00,
                ClubId = c2.ClubId,
            };
            Player p19 = new()
            {
                PlayerId = 19,
                PlayerName = "Stopira",
                PlayerNationality = "Cape Verde",
                PlayerBirthDate = new DateTime(1988, 05, 20),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.500,
                ClubId = c2.ClubId,
            };
            Player p20 = new()
            {
                PlayerId = 20,
                PlayerName = "Hangya Szilveszter",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1994, 01, 02),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.450,
                ClubId = c2.ClubId,
            };
            Player p21 = new()
            {
                PlayerId = 21,
                PlayerName = "Loic Nego",
                PlayerNationality = "French",
                PlayerBirthDate = new DateTime(1991, 01, 15),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 2.20,
                ClubId = c2.ClubId,
            };
            Player p22 = new()
            {
                PlayerId = 22,
                PlayerName = "Bendegúz Bolla",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1999, 11, 22),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.400,
                ClubId = c2.ClubId,
            };
            Player p23 = new()
            {
                PlayerId = 23,
                PlayerName = "Rúben Pinto",
                PlayerNationality = "Portuguese",
                PlayerBirthDate = new DateTime(1992, 04, 24),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 1.00,
                ClubId = c2.ClubId,
            };
            Player p24 = new()
            {
                PlayerId = 24,
                PlayerName = "Lyes Houri",
                PlayerNationality = "French",
                PlayerBirthDate = new DateTime(1996, 01, 19),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 1.10,
                ClubId = c2.ClubId,
            };
            Player p25 = new()
            {
                PlayerId = 25,
                PlayerName = "Boban Nikolov",
                PlayerNationality = "Northern Macedonia",
                PlayerBirthDate = new DateTime(1994, 07, 28),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 0.750,
                ClubId = c2.ClubId,
            };
            Player p26 = new()
            {
                PlayerId = 26,
                PlayerName = "István Kovács",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1992, 03, 27),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 0.550,
                ClubId = c2.ClubId,
            };
            Player p27 = new()
            {
                PlayerId = 27,
                PlayerName = "Ivan Petryak",
                PlayerNationality = "Ukrainian",
                PlayerBirthDate = new DateTime(1994, 03, 13),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 1.60,
                ClubId = c2.ClubId,
            };
            Player p28 = new()
            {
                PlayerId = 28,
                PlayerName = "Evandro",
                PlayerNationality = "Brazilian",
                PlayerBirthDate = new DateTime(1997, 01, 14),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 1.20,
                ClubId = c2.ClubId,
            };
            Player p29 = new()
            {
                PlayerId = 29,
                PlayerName = "Nemanja Nikolics C",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1987, 12, 31),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 1.50,
                ClubId = c2.ClubId,
            };
            Player p30 = new()
            {
                PlayerId = 30,
                PlayerName = "Armin Hodzic",
                PlayerNationality = "Bosniaks",
                PlayerBirthDate = new DateTime(1994, 11, 17),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 1.00,
                ClubId = c2.ClubId,
            };
            Player p31 = new()
            {
                PlayerId = 31,
                PlayerName = "Balázs Tóth",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1997, 09, 04),
                PlayerPosition = PlayerPosition.Goalkeeper,
                PlayerValue = 0.250,
                ClubId = c3.ClubId,
            };
            Player p32 = new()
            {
                PlayerId = 32,
                PlayerName = "Ágoston Kiss",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(2001, 03, 14),
                PlayerPosition = PlayerPosition.Goalkeeper,
                PlayerValue = 0.100,
                ClubId = c3.ClubId,
            };
            Player p33 = new()
            {
                PlayerId = 33,
                PlayerName = "Thomas Meißner",
                PlayerNationality = "German",
                PlayerBirthDate = new DateTime(1991, 03, 26),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.600,
                ClubId = c3.ClubId,
            };
            Player p34 = new()
            {
                PlayerId = 34,
                PlayerName = "João Nunes",
                PlayerNationality = "Portuguese",
                PlayerBirthDate = new DateTime(1995, 11, 19),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.400,
                ClubId = c3.ClubId,
            };
            Player p35 = new()
            {
                PlayerId = 35,
                PlayerName = "Kamen Hadzhiev",
                PlayerNationality = "Bulgarian",
                PlayerBirthDate = new DateTime(1991, 09, 22),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.400,
                ClubId = c3.ClubId,
            };
            Player p36 = new()
            {
                PlayerId = 36,
                PlayerName = "Zsolt Nagy",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1993, 05, 25),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.300,
                ClubId = c3.ClubId,
            };
            Player p37 = new()
            {
                PlayerId = 37,
                PlayerName = "Roland Szolnoki C",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1992, 01, 21),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.300,
                ClubId = c3.ClubId,
            };
            Player p38 = new()
            {
                PlayerId = 38,
                PlayerName = "Yoëll van Nieff",
                PlayerNationality = "Dutch",
                PlayerBirthDate = new DateTime(1993, 06, 17),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 0.600,
                ClubId = c3.ClubId,
            };
            Player p39 = new()
            {
                PlayerId = 39,
                PlayerName = "Jakub Plsek",
                PlayerNationality = "Czech",
                PlayerBirthDate = new DateTime(1993, 12, 13),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 0.500,
                ClubId = c3.ClubId,
            };
            Player p40 = new()
            {
                PlayerId = 40,
                PlayerName = "Jozef Urblik",
                PlayerNationality = "Slovakian",
                PlayerBirthDate = new DateTime(1996, 08, 22),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 0.400,
                ClubId = c3.ClubId,
            };
            Player p41 = new()
            {
                PlayerId = 41,
                PlayerName = "Josip Knezevic",
                PlayerNationality = "Croatian",
                PlayerBirthDate = new DateTime(1988, 10, 03),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 0.500,
                ClubId = c3.ClubId,
            };
            Player p42 = new()
            {
                PlayerId = 42,
                PlayerName = "Tamás Kiss",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(2000, 11, 24),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 0.400,
                ClubId = c3.ClubId,
            };
            Player p43 = new()
            {
                PlayerId = 43,
                PlayerName = "Alexandru Baluta",
                PlayerNationality = "Romanian",
                PlayerBirthDate = new DateTime(1993, 09, 13),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 2.00,
                ClubId = c3.ClubId,
            };
            Player p44 = new()
            {
                PlayerId = 44,
                PlayerName = "Antonio Mance",
                PlayerNationality = "Croatian",
                PlayerBirthDate = new DateTime(1995, 08, 07),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 1.30,
                ClubId = c3.ClubId,
            };
            Player p45 = new()
            {
                PlayerId = 45,
                PlayerName = "David Vanecek",
                PlayerNationality = "Czech",
                PlayerBirthDate = new DateTime(1991, 03, 09),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 0.650,
                ClubId = c3.ClubId,
            };
            Player p46 = new()
            {
                PlayerId = 46,
                PlayerName = "Péter Szappanos",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1990, 11, 14),
                PlayerPosition = PlayerPosition.Goalkeeper,
                PlayerValue = 0.350,
                ClubId = c4.ClubId,
            };
            Player p47 = new()
            {
                PlayerId = 47,
                PlayerName = "Danylo Ryabenko",
                PlayerNationality = "Ukrainian",
                PlayerBirthDate = new DateTime(1998, 10, 09),
                PlayerPosition = PlayerPosition.Goalkeeper,
                PlayerValue = 0.100,
                ClubId = c4.ClubId,
            };
            Player p48 = new()
            {
                PlayerId = 48,
                PlayerName = "Andriy Nesterov",
                PlayerNationality = "Ukrainian",
                PlayerBirthDate = new DateTime(1990, 07, 02),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.350,
                ClubId = c4.ClubId,
            };
            Player p49 = new()
            {
                PlayerId = 49,
                PlayerName = "Róbert Pillár",
                PlayerNationality = "Slovakian",
                PlayerBirthDate = new DateTime(1991, 05, 27),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.300,
                ClubId = c4.ClubId,
            };
            Player p50 = new()
            {
                PlayerId = 50,
                PlayerName = "Richárd Guzmics",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1987, 04, 16),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.200,
                ClubId = c4.ClubId,
            };
            Player p51 = new()
            {
                PlayerId = 51,
                PlayerName = "Luka Lakvekheliani",
                PlayerNationality = "Georgian",
                PlayerBirthDate = new DateTime(1998, 10, 20),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.450,
                ClubId = c4.ClubId,
            };
            Player p52 = new()
            {
                PlayerId = 52,
                PlayerName = "Dániel Farkas",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1993, 01, 13),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.300,
                ClubId = c4.ClubId,
            };
            Player p53 = new()
            {
                PlayerId = 53,
                PlayerName = "Aleksandr Karnitskiy",
                PlayerNationality = "Belarusian",
                PlayerBirthDate = new DateTime(1989, 02, 14),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 0.400,
                ClubId = c4.ClubId,
            };
            Player p54 = new()
            {
                PlayerId = 54,
                PlayerName = "Zsombor Berecz",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1995, 12, 13),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 0.550,
                ClubId = c4.ClubId,
            };
            Player p55 = new()
            {
                PlayerId = 55,
                PlayerName = "Dino Berisovic",
                PlayerNationality = "Bosniaks",
                PlayerBirthDate = new DateTime(1994, 01, 31),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 0.400,
                ClubId = c4.ClubId,
            };
            Player p56 = new()
            {
                PlayerId = 56,
                PlayerName = "Antonio Vutov",
                PlayerNationality = "Bulgarian",
                PlayerBirthDate = new DateTime(1996, 06, 06),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 0.600,
                ClubId = c4.ClubId,
            };
            Player p57 = new()
            {
                PlayerId = 57,
                PlayerName = "Tamás Cseri C",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1988, 01, 15),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 0.400,
                ClubId = c4.ClubId,
            };
            Player p58 = new()
            {
                PlayerId = 58,
                PlayerName = "Serder Serderov",
                PlayerNationality = "Russian",
                PlayerBirthDate = new DateTime(1994, 03, 10),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 0.600,
                ClubId = c4.ClubId,
            };
            Player p59 = new()
            {
                PlayerId = 59,
                PlayerName = "Andriy Boryachuk",
                PlayerNationality = "Ukrainian",
                PlayerBirthDate = new DateTime(1996, 04, 23),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 0.450,
                ClubId = c4.ClubId,
            };
            Player p60 = new()
            {
                PlayerId = 60,
                PlayerName = "Marin Jurina",
                PlayerNationality = "Bosniaks",
                PlayerBirthDate = new DateTime(1993, 11, 26),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 0.300,
                ClubId = c4.ClubId,
            };
            Player p61 = new()
            {
                PlayerId = 61,
                PlayerName = "Tomas Tujvel",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1983, 09, 19),
                PlayerPosition = PlayerPosition.Goalkeeper,
                PlayerValue = 0.150,
                ClubId = c5.ClubId,
            };
            Player p62 = new()
            {
                PlayerId = 62,
                PlayerName = "Oleksandr Nad",
                PlayerNationality = "Ukrainian",
                PlayerBirthDate = new DateTime(1985, 09, 02),
                PlayerPosition = PlayerPosition.Goalkeeper,
                PlayerValue = 0.150,
                ClubId = c5.ClubId,
            };
            Player p63 = new()
            {
                PlayerId = 63,
                PlayerName = "Botond Baráth",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1992, 04, 21),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.500,
                ClubId = c5.ClubId,
            };
            Player p64 = new()
            {
                PlayerId = 64,
                PlayerName = "Bence Batik",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1993, 11, 08),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.400,
                ClubId = c5.ClubId,
            };
            Player p65 = new()
            {
                PlayerId = 65,
                PlayerName = "Djordje Kamber",
                PlayerNationality = "Bosniaks",
                PlayerBirthDate = new DateTime(1983, 11, 20),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.100,
                ClubId = c5.ClubId,
            };
            Player p66 = new()
            {
                PlayerId = 66,
                PlayerName = "Krisztián Tamás",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1995, 04, 18),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.400,
                ClubId = c5.ClubId,
            };
            Player p67 = new()
            {
                PlayerId = 67,
                PlayerName = "Eke Uzoma",
                PlayerNationality = "Nigerian",
                PlayerBirthDate = new DateTime(1989, 08, 11),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.300,
                ClubId = c5.ClubId,
            };
            Player p68 = new()
            {
                PlayerId = 68,
                PlayerName = "Mohamed Mezghrani",
                PlayerNationality = "Algerian",
                PlayerBirthDate = new DateTime(1994, 06, 02),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.350,
                ClubId = c5.ClubId,
            };
            Player p69 = new()
            {
                PlayerId = 69,
                PlayerName = "Patrik Hidi C",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1990, 11, 27),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 0.500,
                ClubId = c5.ClubId,
            };
            Player p70 = new()
            {
                PlayerId = 70,
                PlayerName = "Dániel Gazdag",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1996, 03, 02),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 1.00,
                ClubId = c5.ClubId,
            };
            Player p71 = new()
            {
                PlayerId = 71,
                PlayerName = "Gergő Nagy",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1993, 01, 07),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 0.400,
                ClubId = c5.ClubId,
            };
            Player p72 = new()
            {
                PlayerId = 72,
                PlayerName = "Donát Zsótér",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1996, 01, 06),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 0.450,
                ClubId = c5.ClubId,
            };
            Player p73 = new()
            {
                PlayerId = 73,
                PlayerName = "Márton Eppel",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1991, 10, 26),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 1.40,
                ClubId = c5.ClubId,
            };
            Player p74 = new()
            {
                PlayerId = 74,
                PlayerName = "Norbert Balogh",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1996, 02, 21),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 0.450,
                ClubId = c5.ClubId,
            };
            Player p75 = new()
            {
                PlayerId = 75,
                PlayerName = "Roland Ugrai",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1992, 11, 13),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 0.450,
                ClubId = c5.ClubId,
            };
            Player p76 = new()
            {
                PlayerId = 76,
                PlayerName = "Filip Pajovic",
                PlayerNationality = "Serbian",
                PlayerBirthDate = new DateTime(1993, 07, 30),
                PlayerPosition = PlayerPosition.Goalkeeper,
                PlayerValue = 0.200,
                ClubId = c6.ClubId,
            };
            Player p77 = new()
            {
                PlayerId = 77,
                PlayerName = "Dávid Banai",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1994, 05, 09),
                PlayerPosition = PlayerPosition.Goalkeeper,
                PlayerValue = 0.250,
                ClubId = c6.ClubId,
            };
            Player p78 = new()
            {
                PlayerId = 78,
                PlayerName = "Kire Ristevski",
                PlayerNationality = "Northern Macedonia",
                PlayerBirthDate = new DateTime(1990, 10, 22),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.400,
                ClubId = c6.ClubId,
            };
            Player p79 = new()
            {
                PlayerId = 79,
                PlayerName = "Georgios Koutroumpis",
                PlayerNationality = "Greek",
                PlayerBirthDate = new DateTime(1991, 02, 10),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.400,
                ClubId = c6.ClubId,
            };
            Player p80 = new()
            {
                PlayerId = 80,
                PlayerName = "Zsolt Máté",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1997, 09, 14),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.250,
                ClubId = c6.ClubId,
            };
            Player p81 = new()
            {
                PlayerId = 81,
                PlayerName = "Nemanja Antonov",
                PlayerNationality = "Serbian",
                PlayerBirthDate = new DateTime(1995, 05, 06),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.550,
                ClubId = c6.ClubId,
            };
            Player p82 = new()
            {
                PlayerId = 82,
                PlayerName = "Branko Pauljevic",
                PlayerNationality = "Serbian",
                PlayerBirthDate = new DateTime(1989, 06, 12),
                PlayerPosition = PlayerPosition.Defender,
                PlayerValue = 0.200,
                ClubId = c6.ClubId,
            };
            Player p83 = new()
            {
                PlayerId = 83,
                PlayerName = "Miroslav Bjelos",
                PlayerNationality = "Serbian",
                PlayerBirthDate = new DateTime(1990, 10, 29),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 0.350,
                ClubId = c6.ClubId,
            };
            Player p84 = new()
            {
                PlayerId = 84,
                PlayerName = "Vincent Onovo",
                PlayerNationality = "Nigerian",
                PlayerBirthDate = new DateTime(1995, 12, 10),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 0.350,
                ClubId = c6.ClubId,
            };
            Player p85 = new()
            {
                PlayerId = 85,
                PlayerName = "Nikola Mitrovic",
                PlayerNationality = "Serbian",
                PlayerBirthDate = new DateTime(1987, 01, 02),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 0.250,
                ClubId = c6.ClubId,
            };
            Player p86 = new()
            {
                PlayerId = 86,
                PlayerName = "Barnabás Rázc",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1996, 04, 26),
                PlayerPosition = PlayerPosition.Midfielder,
                PlayerValue = 0.200,
                ClubId = c6.ClubId,
            };
            Player p87 = new()
            {
                PlayerId = 87,
                PlayerName = "Giorgi Beridze",
                PlayerNationality = "Georgian",
                PlayerBirthDate = new DateTime(1997, 05, 12),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 0.400,
                ClubId = c6.ClubId,
            };
            Player p88 = new()
            {
                PlayerId = 88,
                PlayerName = "Zoltán Stieber",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1988, 10, 16),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 0.400,
                ClubId = c6.ClubId,
            };
            Player p89 = new()
            {
                PlayerId = 89,
                PlayerName = "Krisztián Simon C",
                PlayerNationality = "Hungarian",
                PlayerBirthDate = new DateTime(1991, 06, 10),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 0.400,
                ClubId = c6.ClubId,
            };
            Player p90 = new()
            {
                PlayerId = 90,
                PlayerName = "Junior Tallo",
                PlayerNationality = "Ivorian",
                PlayerBirthDate = new DateTime(1992, 12, 21),
                PlayerPosition = PlayerPosition.Forward,
                PlayerValue = 0.300,
                ClubId = c6.ClubId,
            };

            modelBuilder.Entity<Club>().HasData(c1, c2, c3, c4, c5, c6);
            modelBuilder.Entity<Manager>().HasData(m1, m2, m3, m4, m5, m6);
            modelBuilder.Entity<Player>().HasData(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20, p21, p22, p23, p24, p25, p26, p27, p28, p29, p30, p31, p32, p33, p34, p35, p36, p37, p38, p39, p40, p41, p42, p43, p44, p45, p46, p47, p48, p49, p50, p51, p52, p53, p54, p55, p56, p57, p58, p59, p60, p61, p62, p63, p64, p65, p66, p67, p68, p69, p70, p71, p72, p73, p74, p75, p76, p77, p78, p79, p80, p81, p82, p83, p84, p85, p86, p87, p88, p89, p90);
            #endregion
        }
    }
}
