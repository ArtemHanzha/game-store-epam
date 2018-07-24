using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Task.Contracts.Modes;

namespace Task.DAL.Context
{
    public class DbInitializer : DropCreateDatabaseAlways<GameStoreContext>
    {
        protected override void Seed(GameStoreContext context)
        {
            #region genres

            context.Genres.Add(new Genre()
            {
                Name = "Strategy",
                Parrent = null
            });
            context.Genres.Add(new Genre()
            {
                Name = "RPG",
                Parrent = null
            });
            context.Genres.Add(new Genre()
            {
                Name = "Sport",
                Parrent = null
            });
            context.Genres.Add(new Genre()
            {
                Name = "Races",
                Parrent = null
            });
            context.Genres.Add(new Genre()
            {
                Name = "Action",
                Parrent = null
            });
            context.Genres.Add(new Genre()
            {
                Name = "Adventure",
                Parrent = null
            });
            context.Genres.Add(new Genre()
            {
                Name = "Puzzle & Skill",
                Parrent = null
            });
            context.Genres.Add(new Genre()
            {
                Name = "Misc",
                Parrent = null
            });

            context.SaveChanges();

            context.Genres.Add(new Genre()
            {
                Name = "RTS",
                Parrent = context.Genres.ToList()[0]
            });
            context.Genres.Add(new Genre()
            {
                Name = "TBS",
                Parrent = context.Genres.ToList()[0]
            });
            context.Genres.Add(new Genre()
            {
                Name = "RTS",
                Parrent = context.Genres.ToList()[0]
            });
            context.Genres.Add(new Genre()
            {
                Name = "Rally",
                Parrent = context.Genres.ToList()[3]
            });
            context.Genres.Add(new Genre()
            {
                Name = "Arcade",
                Parrent = context.Genres.ToList()[3]
            });
            context.Genres.Add(new Genre()
            {
                Name = "Formula",
                Parrent = context.Genres.ToList()[3]
            });
            context.Genres.Add(new Genre()
            {
                Name = "Off-road",
                Parrent = context.Genres.ToList()[3]
            });
            context.Genres.Add(new Genre()
            {
                Name = "FPS",
                Parrent = context.Genres.ToList()[4]
            });
            context.Genres.Add(new Genre()
            {
                Name = "TPS",
                Parrent = context.Genres.ToList()[4]
            });
            context.Genres.Add(new Genre()
            {
                Name = "Misc",
                Parrent = context.Genres.ToList()[4]
            });
            context.SaveChanges();

            #endregion

            #region PlatformTypes

            context.PlatformTypes.Add(new PlatformType()
            {
                Type = "Android"
            });
            context.PlatformTypes.Add(new PlatformType()
            {
                Type = "Windows Desctop"
            });
            context.PlatformTypes.Add(new PlatformType()
            {
                Type = "Linux Desctop"
            });
            context.PlatformTypes.Add(new PlatformType()
            {
                Type = "XBox"
            });
            context.PlatformTypes.Add(new PlatformType()
            {
                Type = "MacOS Desctop"
            });

            context.SaveChanges();

            #endregion

            #region Games

            context.Games.Add(new Game()
            {
                Comments = null,
                Description = "Live a week in the life of \"The Postal Dude\"; a hapless everyman just trying to check off some chores. Buying milk, returning an overdue library book, getting Gary Coleman's autograph, what could possibly go wrong? Blast,chop and piss your way through a freakshow of American caricatures in this darkly humorous first - person adventure.Meet Krotchy: the toy mascot gone bad, visit your Uncle Dave at his besieged religious cult compound and battle sewer - dwelling Taliban when you least expect them!Endure the sphincter - clenching challenge of cannibal rednecks, corrupt cops and berserker elephants.Accompanied by Champ, the Dude's semi-loyal pitbull, battle your way through open environments populated with amazingly unpredictable AI. Utilize an arsenal of weapons ranging from a humble shovel to a uniquely hilarious rocket launcher. Collect a pack of attack dogs!Use cats as silencers!Piss and pour gasoline on anything and everyone!YOU KNOW YOU WANT TO!",
                Key = "postal2",
                Name = "Postal II",
                Platforms = new List<PlatformType>()
                {
                context.PlatformTypes.ToList()[0],
                context.PlatformTypes.ToList()[2],
                context.PlatformTypes.ToList()[3],
                },
                Genres = new List<Genre>()
                {
                    context.Genres.ToList()[2],
                    context.Genres.ToList()[10],
                    context.Genres.ToList()[15],
                    context.Genres.ToList()[13]
                }
            });

            context.Games.Add(new Game()
            {
                Comments = null,
                Description = "Fallout 2: A Post Nuclear Role Playing Game is a turn-based role-playing open world video game developed by Black Isle Studios and published by Interplay Productions in September 1998. While featuring a considerably larger game world and a far more extensive storyline, it largely uses similar graphics and game mechanics to those of Fallout.",
                Key = "fallout2",
                Name = "Fallout 2",
                Platforms = new List<PlatformType>()
                {
                    context.PlatformTypes.ToList()[0],
                    context.PlatformTypes.ToList()[2],
                    context.PlatformTypes.ToList()[3],
                },
                Genres = new List<Genre>()
                {
                    context.Genres.ToList()[2],
                    context.Genres.ToList()[8],
                    context.Genres.ToList()[5],
                }
            });

            context.Games.Add(new Game()
            {
                Comments = null,
                Description = "FlatOut 2 is a racing video game developed by Bugbear Entertainment and published by Empire Interactive. It is the sequel to the 2004 game FlatOut. This game is themed more on the street racing/import tuner scene than its predecessor. A notable change is the tire grip; players can take more control of their car, worrying less about skidding in tight turns. The game has three car classes: derby, race, and street.",
                Key = "flatout2",
                Name = "FlatOut 2",
                Platforms = new List<PlatformType>()
                {
                    context.PlatformTypes.ToList()[1],
                    context.PlatformTypes.ToList()[0],
                    context.PlatformTypes.ToList()[2],
                },
                Genres = new List<Genre>()
                {
                    context.Genres.ToList()[12],
                    context.Genres.ToList()[10],
                    context.Genres.ToList()[3],
                }
            });

            context.Games.Add(new Game()
            {
                Comments = null,
                Description = "Doom is a 1993 first-person shooter video game by id Software. It is considered one of the most significant and influential titles in video game history, for having helped to pioneer the now-ubiquitous first-person shooter. The original game was divided into three nine-level episodes and was distributed via shareware and mail order. The Ultimate Doom, an updated release of the original game featuring a fourth episode, was released in 1995 and sold at retail.",
                Key = "doom",
                Name = "Doom",
                Platforms = new List<PlatformType>()
                {
                    context.PlatformTypes.ToList()[1],
                    context.PlatformTypes.ToList()[0],
                    context.PlatformTypes.ToList()[2],
                },
                Genres = new List<Genre>()
                {
                    context.Genres.ToList()[1],
                    context.Genres.ToList()[0],
                    context.Genres.ToList()[2],
                }
            });

            context.Games.Add(new Game()
            {
                Comments = null,
                Description = "Moorhuhn is a German casual game franchise for PCs and various other platforms. It consists of more than 30 games, the first of which – a shoot 'em up – was Germany's most popular computer game in the early 2000s.",
                Key = "moorhuhn",
                Name = "Moorhuhn",
                Platforms = new List<PlatformType>()
                {
                    context.PlatformTypes.ToList()[1],
                    context.PlatformTypes.ToList()[0],
                    context.PlatformTypes.ToList()[2],
                },
                Genres = new List<Genre>()
                {
                    context.Genres.ToList()[1],
                    context.Genres.ToList()[0],
                    context.Genres.ToList()[2],
                }
            });

            context.Games.Add(new Game()
            {
                Comments = null,
                Description = "The Sims 3 is the third major title in the life simulation video game developed by The Sims Studio and published by Electronic Arts. It is the sequel to The Sims 2. It was announced that it was in development for PlayStation 3 and Wii in November 2006, and later announced for OS X and Microsoft Windows. It was first released on June 2, 2009 simultaneously for OS X and Microsoft Windows – both versions on the same disc. Smartphone versions were also released on June 2, 2009. Console versions were released for PlayStation 3, Xbox 360, and Nintendo DS in October 2010 and a month later for the Wii. The Windows Phone version was made available on the Windows Phone Store on October 15, 2010. A Nintendo 3DS version, released on March 27, 2011, was one of its launch titles.",
                Key = "sims3",
                Name = "Sims 3",
                Platforms = new List<PlatformType>()
                {
                    context.PlatformTypes.ToList()[1],
                    context.PlatformTypes.ToList()[0],
                    context.PlatformTypes.ToList()[2],
                },
                Genres = new List<Genre>()
                {
                    context.Genres.ToList()[1],
                    context.Genres.ToList()[0],
                    context.Genres.ToList()[2],
                }
            });

            context.Games.Add(new Game()
            {
                Comments = null,
                Description = "The Sims 2 is a 2004 strategic life simulation video game developed by Maxis and published by Electronic Arts. It is the sequel to The Sims. The game has the same concept as its predecessor: players control their Sims in various activities and form relationships in a manner similar to real life. The Sims 2, like its predecessor, does not have a defined final goal; gameplay is open-ended. Sims have life goals, wants and fears, the fulfillment of which can produce both positive or negative outcomes. All Sims age, and can live to 90 sim days depending on the degree to which their aspirations are fulfilled. The Sims 2 builds on its predecessor by allowing Sims to age through six stages of life and incorporating a 3D graphics engine. Although gameplay is not linear, storylines exist in the game's pre-built neighborhoods. Pleasantview is based 25 years after the town in the original The Sims. Strangetown's storyline is based on the supernatural, and is loosely connected with Pleasantview. Veronaville's characters are based on Shakespearean characters. ",
                Key = "sims2",
                Name = "Sims 2",
                Platforms = new List<PlatformType>()
                {
                    context.PlatformTypes.ToList()[1],
                    context.PlatformTypes.ToList()[0],
                    context.PlatformTypes.ToList()[2],
                },
                Genres = new List<Genre>()
                {
                    context.Genres.ToList()[1],
                    context.Genres.ToList()[0],
                    context.Genres.ToList()[2],
                }
            });

            context.Games.Add(new Game()
            {
                Comments = null,
                Description = "Painkiller is a first-person shooter video game released on April 12, 2004. It was developed by Polish game studio People Can Fly and published by DreamCatcher Interactive. It is notable for using the Havok 2.0 physics engine extensively. The single player campaign gameplay involves killing large numbers of monsters. The game was particularly well received for its multiplayer experience. Painkiller was featured for two seasons on the Cyberathlete Professional League's World Tour. ",
                Key = "painkiller",
                Name = "Painkiller",
                Platforms = new List<PlatformType>()
                {
                    context.PlatformTypes.ToList()[1],
                    context.PlatformTypes.ToList()[0],
                    context.PlatformTypes.ToList()[2],
                },
                Genres = new List<Genre>()
                {
                    context.Genres.ToList()[1],
                    context.Genres.ToList()[0],
                    context.Genres.ToList()[2],
                }
            });

            context.Games.Add(new Game()
            {
                Comments = null,
                Description = "Star Wars Battlefront II is an action shooter video game based on the Star Wars film franchise. It is the fourth major installment of the Star Wars: Battlefront series and seventh overall, and a sequel to the 2015 reboot of the series. It was developed by EA DICE, in collaboration with Criterion Games and Motive Studios, and published by Electronic Arts. The game was released worldwide on November 17, 2017 for PlayStation 4, Xbox One, and Microsoft Windows.",
                Key = "star-wars-buttlefront-2",
                Name = "Star Wars Battlefront II",
                Platforms = new List<PlatformType>()
                {
                    context.PlatformTypes.ToList()[1],
                    context.PlatformTypes.ToList()[0],
                    context.PlatformTypes.ToList()[2],
                },
                Genres = new List<Genre>()
                {
                    context.Genres.ToList()[1],
                    context.Genres.ToList()[0],
                    context.Genres.ToList()[2],
                }
            });

            context.SaveChanges();

            #endregion

            #region Comments

            context.Comments.Add(new Comment()
            {
                Game = context.Games.ToList()[0],
                Name = "Great! Best game ever!!!!11",
                AuthorName = "vitalya",
                Body = "r clubs throughout North America. AAA is a privately held member service business with over 58 million members in the United States and Canada. AAA provides services to its me"
            });
            context.Comments.Add(new Comment()
            {
                Game = context.Games.ToList()[1],
                Name = "not really so good...",
                AuthorName = "misha",
                Body = "n focused on advancing marketplace trust, consisting of 106 independently incorporated local BBB organizations in the United States and Canada, coordinated under the Council of Better Business Bureaus in Arlington, Vir"
            });
            context.Comments.Add(new Comment()
            {
                Game = context.Games.ToList()[2],
                Name = "S***est s**t of the top of s**t rock!",
                AuthorName = "nastya",
                Body = "ommunity College is a two-year public college with three campuses, in Columbus, Grand Island and Hastings. In addition the college has learning centers in Holdrege, Kearney, and Lexington. Under the terms of a 1971 Nebraska st"
            });

            context.SaveChanges();

            context.Comments.Add(new Comment()
            {
                Game = context.Games.ToList()[2],
                Name = "S***est s**t of the top of s**t rock!",
                AuthorName = "dinis",
                Body = "main-driven design is an approach to software development for complex needs by connecting the implementation to an evolving model. The term was coined by Eric Evans in his book of the same tit",
                Parrent = context.Comments.ToList()[2]
            });

            context.Comments.Add(new Comment()
            {
                Game = context.Games.ToList()[2],
                Name = "11123123123213",
                AuthorName = "valya",
                Body = "main-driven design is an approach to software development for complex needs by connecting the implementation to an evolving model. The term was coined by Eric Evans in his book of the same tit",
                Parrent = context.Comments.ToList()[1]
            });

            context.Comments.Add(new Comment()
            {
                Game = context.Games.ToList()[2],
                Name = "kjvbkrwvbrk ajvbwr kawejv br",
                AuthorName = "Ivan Petrovich",
                Body = "main-driven design is an approach to software development for complex needs by connecting the implementation to an evolving model. The term was coined by Eric Evans in his book of the same tit",
                Parrent = context.Comments.ToList()[2]
            });

            context.SaveChanges();

            #endregion
        }
    }
}