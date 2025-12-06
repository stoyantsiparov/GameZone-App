using Microsoft.EntityFrameworkCore;
using GameZone.Data;

namespace GameZone.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Games.Any())
                {
                    return;
                }

                var rpg = new Genre { Name = "RPG" };
                var action = new Genre { Name = "Action" };
                var strategy = new Genre { Name = "Strategy" };
                var sport = new Genre { Name = "Sport" };
                var horror = new Genre { Name = "Horror" };

                context.Genres.AddRange(rpg, action, strategy, sport, horror);

                var pc = new Platform { Name = "PC" };
                var ps5 = new Platform { Name = "PlayStation 5" };
                var xbox = new Platform { Name = "Xbox Series X" };
                var switchConsole = new Platform { Name = "Nintendo Switch" };

                context.Platforms.AddRange(pc, ps5, xbox, switchConsole);

                var cdpr = new Developer { Name = "CD Projekt Red", Website = "https://cdprojektred.com" };
                var rockstar = new Developer { Name = "Rockstar Games", Website = "https://rockstargames.com" };
                var blizzard = new Developer { Name = "Blizzard", Website = "https://blizzard.com" };
                var ea = new Developer { Name = "EA Sports", Website = "https://ea.com" };
                var ubisoft = new Developer { Name = "Ubisoft", Website = "https://ubisoft.com" };
                var fromSoft = new Developer { Name = "FromSoftware", Website = "https://fromsoftware.jp" };
                var firaxis = new Developer { Name = "Firaxis Games", Website = "https://firaxis.com" };

                context.Developers.AddRange(cdpr, rockstar, blizzard, ea, ubisoft, fromSoft, firaxis);

                context.SaveChanges();

                var games = new List<Game>
                {
                    new Game {
                        Title = "The Witcher 3: Wild Hunt",
                        Description = "Ловецът на чудовища Гералт търси осиновената си дъщеря.",
                        ReleaseDate = DateTime.Parse("2015-05-19"),
                        Price = 59.99M,
                        ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/292030/library_600x900.jpg",
                        Genre = rpg, Platform = pc, Developer = cdpr
                    },
                    new Game {
                        Title = "Cyberpunk 2077",
                        Description = "Отворен свят в бъдещето, пълен с кибернетика и престъпност.",
                        ReleaseDate = DateTime.Parse("2020-12-10"),
                        Price = 89.99M,
                        ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/1091500/library_600x900.jpg",
                        Genre = rpg, Platform = ps5, Developer = cdpr
                    },
                    new Game {
                        Title = "Grand Theft Auto V",
                        Description = "Трима престъпници рискуват всичко в серия от дръзки обири.",
                        ReleaseDate = DateTime.Parse("2013-09-17"),
                        Price = 29.99M,
                        ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/271590/library_600x900.jpg",
                        Genre = action, Platform = ps5, Developer = rockstar
                    },
                    new Game {
                        Title = "Red Dead Redemption 2",
                        Description = "Епичен уестърн за лоялността и предателството в Америка.",
                        ReleaseDate = DateTime.Parse("2018-10-26"),
                        Price = 119.00M,
                        ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/1174180/library_600x900.jpg",
                        Genre = action, Platform = xbox, Developer = rockstar
                    },
                    new Game {
                        Title = "Sid Meier's Civilization VI",
                        Description = "Постройте империя, която да устои на изпитанията на времето.",
                        ReleaseDate = DateTime.Parse("2016-10-21"),
                        Price = 59.99M,
                        ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/289070/library_600x900.jpg",
                        Genre = strategy, Platform = pc, Developer = firaxis
                    },
                    new Game {
                        Title = "Diablo IV",
                        Description = "Вечната битка между Рая и Ада продължава.",
                        ReleaseDate = DateTime.Parse("2023-06-05"),
                        Price = 139.00M,
                        ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/2344520/library_600x900.jpg",
                        Genre = rpg, Platform = pc, Developer = blizzard
                    },
                    new Game {
                        Title = "EA Sports FC 24",
                        Description = "Нова ера за световния футбол.",
                        ReleaseDate = DateTime.Parse("2023-09-29"),
                        Price = 119.00M,
                        ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/2195250/library_600x900.jpg",
                        Genre = sport, Platform = ps5, Developer = ea
                    },
                    new Game {
                        Title = "Assassin's Creed Origins",
                        Description = "Пътуване до Древен Египет и началото на Братството.",
                        ReleaseDate = DateTime.Parse("2017-10-27"),
                        Price = 59.99M,
                        ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/582160/library_600x900.jpg",
                        Genre = action, Platform = xbox, Developer = ubisoft
                    },
                    new Game {
                        Title = "Elden Ring",
                        Description = "Огромен фентъзи свят, създаден от Hidetaka Miyazaki и George R.R. Martin.",
                        ReleaseDate = DateTime.Parse("2022-02-25"),
                        Price = 119.00M,
                        ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/1245620/library_600x900.jpg",
                        Genre = rpg, Platform = pc, Developer = fromSoft
                    },
                    new Game {
                        Title = "Resident Evil Village",
                        Description = "Оцеляване в село, пълно с върколаци и вампири.",
                        ReleaseDate = DateTime.Parse("2021-05-07"),
                        Price = 59.00M,
                        ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/1196590/library_600x900.jpg",
                        Genre = horror, Platform = ps5, Developer = fromSoft
                    }
                };

                context.Games.AddRange(games);

                context.Reviews.AddRange(
                    new Review { Game = games[0], UserName = "GeraltLover", Rating = 10, Content = "Най-добрата игра правена някога!", CreatedAt = DateTime.Now.AddDays(-100) },
                    new Review { Game = games[0], UserName = "RpgFan", Rating = 10, Content = "Историята е уникална.", CreatedAt = DateTime.Now.AddDays(-50) },

                    new Review { Game = games[1], UserName = "CyberNinja", Rating = 9, Content = "Бъговете са оправени, играта е топ.", CreatedAt = DateTime.Now.AddDays(-5) },
                    new Review { Game = games[1], UserName = "Hater123", Rating = 6, Content = "Очаквах повече от града.", CreatedAt = DateTime.Now.AddDays(-20) },

                    new Review { Game = games[2], UserName = "Trevor", Rating = 10, Content = "Chaos and destruction!", CreatedAt = DateTime.Now.AddDays(-300) },

                    new Review { Game = games[3], UserName = "CowboyBebop", Rating = 10, Content = "Графиката е фотореалистична. Плаках на финала.", CreatedAt = DateTime.Now.AddDays(-10) },
                    new Review { Game = games[3], UserName = "ArthurM", Rating = 10, Content = "Шедьовър.", CreatedAt = DateTime.Now.AddDays(-2) },

                    new Review { Game = games[4], UserName = "HistoryBuff", Rating = 10, Content = "Само още един ход... и стана 5 сутринта.", CreatedAt = DateTime.Now.AddDays(-1000) },

                    new Review { Game = games[5], UserName = "DeckardCain", Rating = 8, Content = "Атмосферата е добра, но е скъпа.", CreatedAt = DateTime.Now.AddHours(-5) },

                    new Review { Game = games[6], UserName = "SoccerMom", Rating = 7, Content = "Всяка година едно и също.", CreatedAt = DateTime.Now.AddDays(-40) },
                    new Review { Game = games[6], UserName = "Ronaldo7", Rating = 9, Content = "Геймплеят е по-добър от миналата година.", CreatedAt = DateTime.Now.AddDays(-1) },

                    new Review { Game = games[7], UserName = "BayekFan", Rating = 9, Content = "Египет е пресъздаден невероятно красиво.", CreatedAt = DateTime.Now.AddDays(-200) },

                    new Review { Game = games[8], UserName = "SoulsVeteran", Rating = 10, Content = "Трудна е, но си заслужава всяка секунда.", CreatedAt = DateTime.Now.AddHours(-1) },
                    new Review { Game = games[8], UserName = "CasualGamer", Rating = 4, Content = "Твърде е трудна, не мога да мина първия бос.", CreatedAt = DateTime.Now.AddDays(-6) },
                    new Review { Game = games[8], UserName = "MiyazakiFan", Rating = 10, Content = "GOTY (Game of the Year) без съмнение.", CreatedAt = DateTime.Now.AddMinutes(-30) },

                    new Review { Game = games[9], UserName = "ScaredGuy", Rating = 9, Content = "Лейди Димитреску е страшна!", CreatedAt = DateTime.Now.AddDays(-80) }
                );

                context.SaveChanges();
            }
        }
    }
}