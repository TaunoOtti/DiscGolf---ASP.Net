    using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Domain;
using Domain.Identity;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json.Linq;

namespace DAL
{
    //    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DataBaseContext>
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DataBaseContext>
    {
        protected override void Seed(DataBaseContext context)
        {
            var autoDetectChangesEnabled = context.Configuration.AutoDetectChangesEnabled;
            // much-much faster for bulk inserts!!!!
            context.Configuration.AutoDetectChangesEnabled = false;
            SeedArticles(context);
            SeedIdentity(context);
         
         //   SeedContacts(context);


            // restore state
            context.Configuration.AutoDetectChangesEnabled = autoDetectChangesEnabled;

            base.Seed(context);
        }

        private void SeedContacts(DataBaseContext context)
        {
            //context.ContactTypes.Add(new ContactType()
            //{
            //    ContactTypeName = new MultiLangString("Skype", "en", "Skype", "ContactType.0")
            //});
            //context.ContactTypes.Add(new ContactType()
            //{
            //    ContactTypeName = new MultiLangString("Email", "en", "Email", "ContactType.0")
            //});
            //context.ContactTypes.Add(new ContactType()
            //{
            //    ContactTypeName = new MultiLangString("Phone", "en", "Phone", "ContactType.0")
            //});

            //context.SaveChanges();

            // fill database with random names and data

            //undocumented way to get directory
            //var path = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
            //string lastNamesFull = null;
            //string firstNamesFull = null;
            //string middleNamesFull = null;
            //string placesFull = null;
            //string countriesFull = null;
            
            //if (File.Exists(path + "\\names.json"))
            //{
            //    lastNamesFull = File.ReadAllText(path + "\\names.json");
            //}
            //if (File.Exists(path + "\\countries.json"))
            //{
            //    countriesFull = File.ReadAllText(path + "\\countries.json");
            //}
            //if (File.Exists(path + "\\first-names.json"))
            //{
            //    firstNamesFull = File.ReadAllText(path + "\\first-names.json");
            //}
            //if (File.Exists(path + "\\middle-names.json"))
            //{
            //    middleNamesFull = File.ReadAllText(path + "\\middle-names.json");
            //}
            //if (File.Exists(path + "\\places.json"))
            //{
            //    placesFull = File.ReadAllText(path + "\\places.json");
            //}

            //var jsonObjCountries = JObject.Parse(countriesFull);
            //var jsonArrayCountries = (JArray) jsonObjCountries["countries"]["country"];
            //List<string> countryList = jsonArrayCountries.Select(a => (string) a["countryName"]).ToList();

            //List<string> placesList = JArray.Parse(placesFull).ToObject<List<string>>();
            //List<string> lastNamesList = JArray.Parse(lastNamesFull).ToObject<List<string>>();
            //List<string> firstNamesList = JArray.Parse(firstNamesFull).ToObject<List<string>>();
            //List<string> middleNamesList = JArray.Parse(middleNamesFull).ToObject<List<string>>();

            //Random r = new Random();


            //var skypeId = context.ContactTypes.FirstOrDefault(a => a.ContactTypeName.Value == "Skype")?.ContactTypeId ?? 0;
            //var emailId = context.ContactTypes.FirstOrDefault(a => a.ContactTypeName.Value == "Email")?.ContactTypeId ?? 0;
            //var userId = context.UsersInt.FirstOrDefault(a => a.Email == "1@eesti.ee")?.Id ?? 0;

            //var counter = 0;
            //foreach (var lastName in lastNamesList.Take(200))
            //{
            //    var firstName = firstNamesList[r.Next(0, firstNamesList.Count)];

            //    context.Persons.Add(new Person()
            //    {
            //        Firstname = firstName,
            //        Lastname = lastName,
            //        UserId = userId,

            //        Contacts = new List<Contact>()
            //        {
            //            new Contact()
            //            {
            //                ContactTypeId = skypeId, 
            //                ContactValue = middleNamesList[r.Next(0, middleNamesList.Count)]+"."+placesList[r.Next(0, placesList.Count)]
            //            },
            //            new Contact()
            //            {
            //                ContactTypeId = emailId, 
            //                ContactValue = firstName+"."+lastName+"@"+countryList[r.Next(0, countryList.Count)]+".com"
            //            }
            //        },

            //        Date = DateTime.Now.Subtract(TimeSpan.FromDays(r.Next(0,365*50))),
            //        Time = DateTime.Now.Subtract(TimeSpan.FromMinutes(r.Next(0, 12*60))),
            //        DateTime = DateTime.Now.Subtract(TimeSpan.FromDays(r.Next(0, 365 * 50))),
            //        Date2 = DateTime.Now.Subtract(TimeSpan.FromDays(r.Next(0, 365 * 50))),
            //        Time2 = DateTime.Now.Subtract(TimeSpan.FromMinutes(r.Next(0, 12*60))),
            //        DateTime2 = DateTime.Now.Subtract(TimeSpan.FromDays(r.Next(0, 365 * 50))),
            //    });

            //    //Save after every X records
            //    counter++;
            //    if (counter % 100 == 0)
            //        context.SaveChanges();
            //}
            // save the remaining
            //context.SaveChanges();

        }

        private void SeedArticles(DataBaseContext context)
        {
            var articleHeadLine = "<h1>ASP.NET</h1>";
            var articleBody =
                "<p class=\"lead\">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.<br/>" +
                "As a demo, here is simple Contact application - log in and save your contacts!</p>";
            var article = new Article()
            {
                ArticleName = "HomeIndex",
                ArticleHeadline =
                    new MultiLangString(articleHeadLine, "en", articleHeadLine, "Article.HomeIndex.ArticleHeadline"),
                ArticleBody = new MultiLangString(articleBody, "en", articleBody, "Article.HomeIndex.ArticleBody")
            };
            context.Articles.Add(article);
            context.SaveChanges();

            context.Translations.Add(new Translation()
            {
                Value = "<h1>ASP.NET on suurepärane!</h1>",
                Culture = "et",
                MultiLangString = article.ArticleHeadline
            });

            context.Translations.Add(new Translation()
            {
                Value =
                    "<p class=\"lead\">ASP.NET on tasuta veebiraamistik suurepäraste veebide arendamiseks kasutades HTML-i, CSS-i, ja JavaScript-i.<br/>" +
                    "Demona on siin lihtne Kontaktirakendus - logi sisse ja salvesta enda kontakte</p>",
                Culture = "et",
                MultiLangString = article.ArticleBody
            });
            context.SaveChanges();
        }

        private void SeedIdentity(DataBaseContext context)
        {
            var pwdHasher = new PasswordHasher();

            // Roles
            context.RolesInt.Add(new RoleInt()
            {
                Name = "Admin"
            });

            //  context.SaveChanges();

            context.RolesInt.Add(new RoleInt()
            {
                Name = "Regular"
            });

            context.SaveChanges();

            // Users
            context.UsersInt.Add(new UserInt()
            {
                UserName = "1@eesti.ee",
                Email = "1@eesti.ee",
                FirstName = "Super",
                LastName = "User",
                PasswordHash = pwdHasher.HashPassword("a"),
                SecurityStamp = Guid.NewGuid().ToString()
            });
            // context.SaveChanges();
            context.UsersInt.Add(new UserInt()
            {
                UserName = "2@eesti.ee",
                Email = "2@eesti.ee",
                FirstName = "Regular",
                LastName = "User",
                PasswordHash = pwdHasher.HashPassword("a"),
                SecurityStamp = Guid.NewGuid().ToString()
            });

            context.UsersInt.Add(new UserInt()
            {
                UserName = "tauno.otti@gmail.com",
                Email = "tauno.otti@gmail.com",
                FirstName = "Tauno",
                LastName = "Otti",
                PasswordHash = pwdHasher.HashPassword("a"),
                SecurityStamp = Guid.NewGuid().ToString()
            });

            context.UsersInt.Add(new UserInt()
            {
                UserName = "rauno.otti@gmail.com",
                Email = "rauno.otti@gmail.com",
                FirstName = "Rauno",
                LastName = "Otti",
                PasswordHash = pwdHasher.HashPassword("a"),
                SecurityStamp = Guid.NewGuid().ToString()
            });

            context.UsersInt.Add(new UserInt()
            {
                UserName = "ester.tester@gmail.com",
                Email = "ester.tester@gmail.com",
                FirstName = "Ester",
                LastName = "Tester",
                PasswordHash = pwdHasher.HashPassword("a"),
                SecurityStamp = Guid.NewGuid().ToString()
            });

            context.UsersInt.Add(new UserInt()
            {
                UserName = "Peeter.Pakiraam@gmail.com",
                Email = "Peeter.Pakiraam@gmail.com",
                FirstName = "Peeter",
                LastName = "Pakiraam",
                PasswordHash = pwdHasher.HashPassword("a"),
                SecurityStamp = Guid.NewGuid().ToString()
            });

            context.SaveChanges();

            // Users in Roles
            context.UserRolesInt.Add(new UserRoleInt()
            {
                User = context.UsersInt.FirstOrDefault(a => a.UserName == "1@eesti.ee"),
                Role = context.RolesInt.FirstOrDefault(a => a.Name == "Admin")
            });

            //context.SaveChanges();


            context.UserRolesInt.Add(new UserRoleInt()
            {
                User = context.UsersInt.FirstOrDefault(a => a.UserName == "2@eesti.ee"),
                Role = context.RolesInt.FirstOrDefault(a => a.Name == "Regular")

            });

            context.UserRolesInt.Add(new UserRoleInt()
            {
                User = context.UsersInt.FirstOrDefault(a => a.UserName == "tauno.otti@gmail.com"),
                Role = context.RolesInt.FirstOrDefault(a => a.Name == "Regular")

            });

            context.UserRolesInt.Add(new UserRoleInt()
            {
                User = context.UsersInt.FirstOrDefault(a => a.UserName == "rauno.otti@gmail.com"),
                Role = context.RolesInt.FirstOrDefault(a => a.Name == "Regular")

            });

            context.UserRolesInt.Add(new UserRoleInt()
            {
                User = context.UsersInt.FirstOrDefault(a => a.UserName == "ester.tester@gmail.com"),
                Role = context.RolesInt.FirstOrDefault(a => a.Name == "Regular")

            });

            context.UserRolesInt.Add(new UserRoleInt()
            {
                User = context.UsersInt.FirstOrDefault(a => a.UserName == "Peeter.Pakiraam@gmail.com"),
                Role = context.RolesInt.FirstOrDefault(a => a.Name == "Regular")

            });
            context.SaveChanges();
            
            context.Tracks.Add(new Track()
            {
                TrackName = "Nõmme discgolf",
                TrackLocation = "Ehitajate tee 34a"
            });
            //   context.SaveChanges();
            context.Tracks.Add(new Track()
            {
                TrackName = "Keila terviseraja discgolf",
                TrackLocation = "Keila, kooli 15"
            });

            context.Tracks.Add(new Track()
            {
                TrackName = "Tõrva Gümnaasium",
                TrackLocation = "Puiesteee 2"
            });
            context.SaveChanges();

            var nom = context.Tracks.FirstOrDefault(x => x.TrackName == "Nõmme discgolf");
            var kei = context.Tracks.FirstOrDefault(x => x.TrackName == "Keila terviseraja discgolf");
            var tor = context.Tracks.FirstOrDefault(x => x.TrackName == "Tõrva Gümnaasium");


            List<Basket> korvid = new List<Basket>()
            {
                new Basket() {BasketNr = 1, TrackId = nom.TrackId, Track = nom, Distance = 86, Pars = 3},
                 new Basket() {BasketNr = 2,  TrackId = nom.TrackId,Track = nom, Distance = 75, Pars = 3},
                  new Basket() {BasketNr = 3,  TrackId = nom.TrackId,Track = nom, Distance = 76, Pars = 3},
                   new Basket() {BasketNr = 4,  TrackId = nom.TrackId,Track = nom, Distance = 45, Pars = 2},
                    new Basket() {BasketNr = 5,  TrackId = nom.TrackId,Track = nom, Distance = 99, Pars = 3},
                     new Basket() {BasketNr = 6,  TrackId = nom.TrackId,Track = nom, Distance = 153, Pars = 4},
                        new Basket() {BasketNr = 7,  TrackId = nom.TrackId,Track = nom, Distance = 142, Pars = 4},
                           new Basket() {BasketNr = 8,  TrackId = nom.TrackId,Track = nom, Distance = 88, Pars = 3},
                              new Basket() {BasketNr = 9,  TrackId = nom.TrackId,Track = nom, Distance = 176, Pars = 5},
                              new Basket() {BasketNr = 10,  TrackId = nom.TrackId,Track = nom, Distance = 98, Pars = 3},
                              new Basket() {BasketNr = 11,  TrackId = nom.TrackId,Track = nom, Distance = 77, Pars = 3},
            };

            foreach (var korv in korvid)
            {
                context.Baskets.Add(korv);
            }
            context.SaveChanges();

            List<Basket> korvid2 = new List<Basket>()
            {
                new Basket() {BasketNr = 1, TrackId = kei.TrackId, Track = kei, Distance = 86, Pars = 3},
                 new Basket() {BasketNr = 2, TrackId = kei.TrackId, Track = kei, Distance = 75, Pars = 3},
                  new Basket() {BasketNr = 3, TrackId = kei.TrackId, Track = kei, Distance = 76, Pars = 3},
                   new Basket() {BasketNr = 4, TrackId = kei.TrackId, Track = kei, Distance = 45, Pars = 2},
                    new Basket() {BasketNr = 5, TrackId = kei.TrackId, Track = kei, Distance = 99, Pars = 3},
                     new Basket() {BasketNr = 6, TrackId = kei.TrackId, Track = kei, Distance = 153, Pars = 4}
            };

            foreach (var korv in korvid2)
            {
                context.Baskets.Add(korv);
            }

            context.SaveChanges();

            List<Basket> korvid3 = new List<Basket>()
            {
                new Basket() {BasketNr = 1, TrackId = tor.TrackId, Track = tor, Distance = 86, Pars = 3},
                new Basket() {BasketNr = 2, TrackId = tor.TrackId, Track = tor, Distance = 65, Pars = 3},
                new Basket() {BasketNr = 3, TrackId = tor.TrackId, Track = tor, Distance = 77, Pars = 3},
                new Basket() {BasketNr = 4, TrackId = tor.TrackId, Track = tor, Distance = 201, Pars = 4},
                new Basket() {BasketNr = 5, TrackId = tor.TrackId, Track = tor, Distance = 140, Pars = 3},
                new Basket() {BasketNr = 6, TrackId = tor.TrackId, Track = tor, Distance = 78, Pars = 3},
                new Basket() {BasketNr = 7, TrackId = tor.TrackId, Track = tor, Distance = 98, Pars = 3},
                new Basket() {BasketNr = 8, TrackId = tor.TrackId, Track = tor, Distance = 56, Pars = 3},
                new Basket() {BasketNr = 9, TrackId = tor.TrackId, Track = tor, Distance = 76, Pars = 3}
            };

            foreach (var korv in korvid3)
            {
                context.Baskets.Add(korv);
            }

            context.SaveChanges();

            Game game = new Game()
            {
                Date = DateTime.Now,
                GameName = "Testikas",
                Track = nom
            };

            //context.Games.Add(new Game()
            //{
            //    Date = DateTime.Now,
            //    GameName = "Testikas",
            //    Track = nom
            //});

            context.Games.Add(game);
            context.SaveChanges();

            context.PlayerInGames.Add(new PlayerInGame()
            {
                GameId = game.GameId,
                UserId = context.UsersInt.FirstOrDefault(x => x.UserName == "1@eesti.ee").Id,
                Game = game,
                User = context.UsersInt.FirstOrDefault(x => x.UserName == "1@eesti.ee"),

            });
            context.SaveChanges();

            context.PlayerInGames.Add(new PlayerInGame()
            {
                GameId = game.GameId,
                UserId = context.UsersInt.FirstOrDefault(x => x.UserName == "2@eesti.ee").Id,
                Game = game,
                User = context.UsersInt.FirstOrDefault(x => x.UserName == "2@eesti.ee"),
                //PlayerInGameId = game.GameId + context.UsersInt.FirstOrDefault(x => x.UserName == "2@eesti.ee").Id
            });

            context.SaveChanges(); 

            context.Scores.Add(new Score
            {
                BasketId = context.Baskets.FirstOrDefault(x => x.BasketNr == 1).BasketId,
                PlayerInGame = context.PlayerInGames.FirstOrDefault(x => x.GameId == game.GameId && x.UserId == context.UsersInt.FirstOrDefault(y => y.UserName == "1@eesti.ee").Id),
                Throws = 3,
                ThrowStyle = "eestkätt",    
                PlayerInGameId = context.PlayerInGames.FirstOrDefault(x => x.GameId == game.GameId && x.UserId == context.UsersInt.FirstOrDefault(y => y.UserName == "1@eesti.ee").Id).UserId,
                GameId = context.Games.FirstOrDefault(x => x.GameName == "Testikas").GameId

            });
            //     context.SaveChanges();
            context.Scores.Add(new Score
            {
                BasketId = context.Baskets.FirstOrDefault(x => x.BasketNr == 2).BasketId,
                PlayerInGame = context.PlayerInGames.FirstOrDefault(x => x.GameId == game.GameId && x.UserId == context.UsersInt.FirstOrDefault(y => y.UserName == "1@eesti.ee").Id),
                Throws = 5,
                Comment = "Perse läks vise",
                ThrowStyle = "tagantkätt",
                PlayerInGameId = context.PlayerInGames.FirstOrDefault(x => x.GameId == game.GameId && x.UserId == context.UsersInt.FirstOrDefault(y => y.UserName == "1@eesti.ee").Id).UserId,
                 GameId = context.Games.FirstOrDefault(x => x.GameName == "Testikas").GameId
            });
            //    context.SaveChanges();
            context.Scores.Add(new Score
            {
                BasketId = context.Baskets.FirstOrDefault(x => x.BasketNr == 1).BasketId,
                PlayerInGame = context.PlayerInGames.FirstOrDefault(x => x.GameId == game.GameId && x.UserId == context.UsersInt.FirstOrDefault(y => y.UserName == "2@eesti.ee").Id),
                Throws = 3,
                ThrowStyle = "eestkätt",
                PlayerInGameId = context.PlayerInGames.FirstOrDefault(x => x.GameId == game.GameId && x.UserId == context.UsersInt.FirstOrDefault(y => y.UserName == "2@eesti.ee").Id).UserId,
                 GameId = context.Games.FirstOrDefault(x => x.GameName == "Testikas").GameId
            });
            //   context.SaveChanges();
            context.Scores.Add(new Score
            {
                BasketId = context.Baskets.FirstOrDefault(x => x.BasketNr == 2).BasketId,
                PlayerInGame = context.PlayerInGames.FirstOrDefault(x => x.GameId == game.GameId && x.UserId == context.UsersInt.FirstOrDefault(y => y.UserName == "2@eesti.ee").Id),
                Throws = 5,
                Comment = "Perse läks vise",
                ThrowStyle = "tagantkätt",
                PlayerInGameId = context.PlayerInGames.FirstOrDefault(x => x.GameId == game.GameId && x.UserId == context.UsersInt.FirstOrDefault(y => y.UserName == "2@eesti.ee").Id).UserId,
                GameId = context.Games.FirstOrDefault(x => x.GameName == "Testikas").GameId

            });

            context.SaveChanges();
        }
    }
}