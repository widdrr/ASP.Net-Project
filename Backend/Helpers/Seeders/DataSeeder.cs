using Backend.Data;
using Backend.Models;
using Backend.Models.Associations;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Backend.Helpers.Seeders
{
    public class DataSeeder
    {
        readonly GameStoreContext _context;

        public DataSeeder(GameStoreContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            Game TF2 = new()
            {
                Name = "Team Fortress 2",
                Developer = "Valve Software",
                Price = 0,
                ReleaseDate = new DateTime(2007, 10, 10)
            };
            Game BoI = new()
            {
                Name = "The Binding of Isaac: Repentance",
                Developer = "Nicalis, Inc",
                Price = 50.56,
                ReleaseDate = new DateTime(2021, 3, 31)
            };
            Game MC = new()
            {
                Name = "Minecraft",
                Developer = "Mojang",
                Price = 23.95,
                ReleaseDate = new DateTime(2009, 5, 17)
            };
            Game Brul = new()
            {
                Name = "Brawlhalla",
                Developer = "Blue Mammoth Games",
                Price = 0,
                ReleaseDate = new DateTime(2017, 10, 17)
            };
            Game WC3 = new()
            {
                Name = "The Witcher 3: Wild Hunt",
                Developer = "CD PROJEKT RED",
                Price = 30,
                ReleaseDate = new DateTime(2015, 5, 18)
            };

            User admin = new()
            {
                Username = "Gaben",
                Email = "gaben@notvalvesoftware.com",
                PasswordHash = BCryptNet.HashPassword("halflife3"),
                JoinDate = new DateTime(2022, 12, 17),
                Role = Enums.Role.Admin,
                Library = null,
                Transactions = null
            };
            User widz = new()
            {
                Username = "widz",
                Email = "tavaandrei@gmail.com",
                PasswordHash = BCryptNet.HashPassword("StrongPassword123"),
                JoinDate = new DateTime(2022, 12, 25),
                Role = Enums.Role.User
            };

            if (!_context.Games.Any() && !_context.Users.Any())
            {
                //adding games
                _context.Add(TF2);
                _context.Add(BoI);
                _context.Add(MC);
                _context.Add(Brul);
                _context.Add(WC3);

                //adding users
                _context.Add(widz);
                _context.Add(admin);

                //adding a library
                _context.Add(new Library
                {
                    User = widz,
                    Games = new List<Addition>
                    {
                        new Addition
                        {
                            Game = TF2,
                            DateAdded = new DateTime(2015, 6, 15)
                        },
                        new Addition
                        {
                            Game = BoI,
                            DateAdded = new DateTime(2022,8,26)
                        },
                        new Addition
                        {
                            Game = MC,
                            DateAdded = new DateTime(2013, 11,19)
                        }
                    }
                });

                //adding some transactions
                _context.Add(new Transaction
                {
                    User = widz,
                    Date = new DateTime(2013, 11, 19),
                    Deposit = new Deposit
                    {
                        Sum = 80
                    }
                });
                _context.Add(new Transaction
                {
                    User = widz,
                    Date = new DateTime(2013, 11, 19),
                    Purchase = new Purchase
                    {
                        GamePurchases = new List<GamePurchase>
                        {
                            new GamePurchase
                            {
                                Game = MC,
                                Price = 16.99
                            }
                        }
                    }
                });
                _context.Add(new Transaction
                {
                    User = widz,
                    Date = new DateTime(2015, 6, 15),
                    Purchase = new Purchase
                    {
                        GamePurchases = new List<GamePurchase>
                        {
                            new GamePurchase
                            {
                                Game = TF2,
                                Price = 0
                            }
                        }
                    }
                });
                _context.Add(new Transaction
                {
                    User = widz,
                    Date = new DateTime(2022, 8, 26),
                    Purchase = new Purchase
                    {
                        GamePurchases = new List<GamePurchase>
                        {
                            new GamePurchase
                            {
                                Game = BoI,
                                Price = 50.56
                            }
                        }
                    }
                });

                _context.SaveChanges();
            }
        }
    }
}
