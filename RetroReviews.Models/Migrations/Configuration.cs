namespace RetroReview.Models.Migrations
{
	using Microsoft.AspNet.Identity;
	using Microsoft.AspNet.Identity.EntityFramework;
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;
	using RetroReview.Models.Models;
    using System.Collections.Generic;


    internal sealed class Configuration : DbMigrationsConfiguration<RetroReview.Models.RetroReviewEntities>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(RetroReview.Models.RetroReviewEntities context)
		{
            //if( !System.Diagnostics.Debugger.IsAttached )
            //{
            //    System.Diagnostics.Debugger.Launch();
            //}


            var tables = new List<string>() {

                "Authors",
                "GameCovers",
                "GameRatings",
                "Games",
                "Platforms",
                "Reviews",
                "StaticPages",
				"Profiles"

            };

            var platforms = new List<string>
            {
                "E",
                "T",
                "M"
            };

            foreach (var item in tables)
            {
                  context.Database.ExecuteSqlCommand("DELETE FROM " + item + " WHERE " + item + '.' + item.Remove(item.Count() - 1, 1) + "id >= 0");
                  context.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('" + item + "', RESEED, 0);");
              
            }
			context.GameRatings.AddOrUpdate(
				new GameRating() { GameRatingName = "E" },
				new GameRating() { GameRatingName = "T" },
				new GameRating() { GameRatingName = "M" }
				);
			context.SaveChanges();

			context.Platforms.AddOrUpdate(
				new Platform() { PlatformName = "Atari" },
				new Platform() { PlatformName = "Nintendo" },
				new Platform() { PlatformName = "Super Nintendo" },
				new Platform() { PlatformName = "N64" },
				new Platform() { PlatformName = "Gameboy" }
				);
			context.SaveChanges();

            context.Reviews.AddOrUpdate(r => r.ReviewId,
				new Review()
				{
					Author = new Author() { Name = "Bob Ross" },
					Game = new Game() { GameCover= new GameCover() { GameCoverUrl = "imgs/btoads.jpg" }, GameRatingId = context.GameRatings.Single(g => g.GameRatingName == "E").GameRatingId, GameTitle = "BattleToads", PlatformId = context.Platforms.Single(p => p.PlatformName == "Nintendo").PlatformId, ReleaseYear = "1991" },
					Rating = 6,
					ReviewBody = "Battletoads is a beat'em up/platform video game developed by Rare and published by Tradewest. It is the first installment of the Battletoads series and was originally released on 1 June 1991 for the Nintendo Entertainment System. It was subsequently ported to the Mega Drive, Game Gear and Amiga CD32. In the game, three space humanoid toad warriors known as the Battletoads, Rash and Zitz, embark on a mission to defeat the evil Dark Queen on her planet and rescue their kidnapped friends; Pimple and Princess Angelica.The game was developed in response to the interest in the Teenage Mutant Ninja Turtles franchise. It has received mostly positive reviews upon release, with critics praising the graphics and variations of gameplay, however many critics were divided over the difficulty. It won six awards from the 1991 Nintendo Power Awards, and has since been renowned as one of the most difficult video games ever created. It was later included in Rares 2015 Xbox One retrospective compilation, Rare Replay." +
								 "Battletoads has long haunted our memories as one of the most frustrating, and difficult, platform-style game. It has a Unique way of bringing entertainment to the player, and despite it's lack of perfection, it is a great time-sink that will provide endless hours of entertainment. Overall it is worth a playthrough (if you can make it through XD).",
					ReviewDate = DateTime.Now,
					ReviewTitle = "BattleToads Review"
				});

            context.Reviews.AddOrUpdate(r => r.ReviewId,
            new Review()
            {
                Author = new Author() { Name = "Rob Boss" },
                Game = new Game() { GameCover = new GameCover() { GameCoverUrl = "imgs/Mortal.png" }, GameRatingId = context.GameRatings.Single(g => g.GameRatingName == "M").GameRatingId, GameTitle = "Mortal Kombat", PlatformId = context.Platforms.Single(p => p.PlatformName == "Nintendo").PlatformId, ReleaseYear = "1992" },
                Rating = 9,
                ReviewBody = "Mortal Kombat is a video game franchise originally developed by Midway Games Chicago studio in 1992. Following Midway's bankruptcy, the Mortal Kombat development team was acquired by Warner Bros. and turned into NetherRealm Studios. Warner Bros. Interactive Entertainment currently owns the rights of the franchise and rebooted it in 2011. The development of the first game was originally based on an idea that Ed Boon and John Tobias had of making a video game starring Jean-Claude Van Damme, but as that idea fell through, a fantasy-horror themed fighting game titled Mortal Kombat was created instead. The original game has spawned many sequels and has spun a media franchise consisting of several action-adventure games, films (animated and live-action with its own sequel), and television series (animated and live-action). Other spin-offs include comic book series, a card game and a live-action tour. Along with Capcom's Street Fighter and Bandai Namco's Tekken, Mortal Kombat has become one of the most successful fighting franchises in the history of video games. As of June 2000, the franchise had generated $5 billion in revenue, making it one of the highest-grossing media franchises of all time. Being that this game has been a staple of my Childhood, I can not reccomend it enough, it holds a place in my heart. It's not as technical as street fighter, but the satisfaction of blowing people to bits with an uppercut is un-matched.",
                ReviewDate = DateTime.Now,
                ReviewTitle = "Mortal Kombat Review"
            });


            context.Reviews.AddOrUpdate(r => r.ReviewId,
                new Review()
                {
                    Author = new Author() { Name = "MattDamon1337" },
                    Game = new Game() { GameCover = new GameCover() { GameCoverUrl = "imgs/SuperMario.png" }, GameRatingId = context.GameRatings.Single(g => g.GameRatingName == "E").GameRatingId, GameTitle = "Super Mario Bros.", PlatformId = context.Platforms.Single(p => p.PlatformName == "Nintendo").PlatformId, ReleaseYear = "1985" },
                    Rating = 10,
                    ReviewBody = "Super Mario Bros. is a platform video game developed and published by Nintendo for the Nintendo Entertainment System home console. Released as a sequel to the 1983 game Mario Bros., Super Mario Bros. was released in Japan and North America in 1985, and in Europe and Australia two years later. In Super Mario Bros., the player controls Mario and in a two-player game, a second player controls Mario's brother Luigi as he travels through the Mushroom Kingdom in order to rescue Princess Toadstool from the antagonist Bowser.The player takes on the role of the main protagonist of the series, Mario. Mario's younger brother, Luigi, is only playable by the second player in the game's multiplayer mode and assumes the same plot role and functionality as Mario. The objective is to race through the Mushroom Kingdom, survive the main antagonist Bowser's forces, and save Princess Toadstool. The player moves from the left side of the screen to the right side in order to reach the flag pole at the end of each level. Most children now days will not get to experience this game in all it's glory. It pathed the way for all platform-style games and is the best in it's class for it's time. A historic relic that continues to live on throughout the generations with new revisions of the mario franchise.",
                    ReviewDate = DateTime.Now,
                    ReviewTitle = "Super Mario Bros. Review"
				});


            context.Reviews.AddOrUpdate(r => r.ReviewId,
			new Review()
			{
				Author = new Author() { Name = "SchwarmaMan" },
				Game = new Game() { GameCover= new GameCover() { GameCoverUrl = "imgs/DK.png" }, GameRatingId = context.GameRatings.Single(g => g.GameRatingName == "E").GameRatingId, GameTitle = "Donkey Kong", PlatformId = context.Platforms.Single(p => p.PlatformName == "Atari").PlatformId, ReleaseYear = "1981" },
				Rating = 6,
				ReviewBody = "Donkey Kong, is a series of video games featuring the adventures of an ape-like character called Donkey Kong, conceived by Shigeru Miyamoto in 1981. The franchise mainly comprises two different game genres, plus spin-off titles of various genres. Donkey Kong first appeared in the eponymous arcade game in 1981 as an antagonist.The original arcade Donkey Kong game was created when Shigeru Miyamoto was assigned by Nintendo to convert Radar Scope, a game that had been released to test audiences with poor results, into a game that would appeal more to Americans. The result was a major breakthrough for Nintendo and for the videogame industry. Sales of the machine were brisk, with the game becoming one of the best-selling arcade machines of the early 1980s. The gameplay itself was a large improvement over other games of its time, and with the growing base of arcades to sell to, it was able to gain huge distribution. In the game, 'Jumpman' (the character would later become Mario) must ascend a construction site while avoiding obstacles such as barrels and fireballs to rescue Pauline, his girlfriend, from Donkey Kong. Miyamoto created a greatly simplified version for the Game & Watch multiscreen. Other ports include the Atari 2600, Colecovision, Amiga 500, Apple II, Atari 7800, Intellivision, Commodore 64, Commodore VIC-20, Famicom Disk System, IBM PC booter, ZX Spectrum, Amstrad CPC, MSX, Atari 8-bit family and Mini-Arcade versions.",
				ReviewDate = DateTime.Now,
				ReviewTitle = "Donkey Kong Review"
			});

			context.Reviews.AddOrUpdate(r => r.ReviewId,
			new Review()
			{
				Author = new Author() { Name = "Chewbacca" },
				Game = new Game() { GameCover = new GameCover() { GameCoverUrl = "imgs/007.jpg" }, GameRatingId = context.GameRatings.Single(g => g.GameRatingName == "T").GameRatingId, GameTitle = "GoldenEye 007", PlatformId = context.Platforms.Single(p => p.PlatformName == "N64").PlatformId, ReleaseYear = "1997" },
				Rating = 9,
				ReviewBody = "GoldenEye 007 is a first - person shooter video game developed by Rare and based on the 1995 James Bond film GoldenEye.It was released for the Nintendo 64 video game console in August 1997.The game features a single - player campaign in which players assume the role of British Secret Intelligence Service agent James Bond as he fights to prevent a criminal syndicate from using a satellite weapon against London to cause a global financial meltdown.The game includes a split - screen multiplayer mode in which two, three, or four players can compete in different types of deathmatch games.GoldenEye 007 is a first - person shooter that features both single and multiplayer modes. In the single - player mode, the player takes the role of James Bond through a series of free - roaming 3D levels.Each level requires the player to complete a certain set of objectives – such as collecting or destroying specified items, rescuing hostages, or meeting with friendly non - player characters(NPCs) – and then exit the stage.Some gadgets from the James Bond film series are featured in the game and are often used to complete particular mission objectives; for example, in one level the electromagnetic watch from Live and Let Die is used to acquire a jail cell key.",
				ReviewDate = DateTime.Now,
				ReviewTitle = "GoldenEye 007 Review"
			});
			context.SaveChanges();

            context.StaticPages.AddOrUpdate(
                s => s.StaticPageId,
                new StaticPage() { PageName = "About", Body = "" });
            context.SaveChanges();
			
			var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(context));
			var roleMgr = new RoleManager<AppRole>(new RoleStore<AppRole>(context));

			if (roleMgr.RoleExists("admin") || roleMgr.RoleExists("contributor"))
			{
				roleMgr.Delete(roleMgr.Roles.SingleOrDefault(r => r.Name == "admin"));
				roleMgr.Delete(roleMgr.Roles.SingleOrDefault(r => r.Name == "contributor"));
			}

			if (userMgr.Users.Count() > 0)
			{
				userMgr.Delete(userMgr.Users.SingleOrDefault(u => u.UserName == "admin"));
				userMgr.Delete(userMgr.Users.SingleOrDefault(u => u.UserName == "matt"));
			}

			roleMgr.Create(new AppRole() { Name = "admin" });
			roleMgr.Create(new AppRole() { Name = "contributor" });

			var user = new AppUser()
			{
				UserName = "admin"
			};
            user.Profile = new Profile() { FirstName = "GuildGuys", LastName="SoftwareGuild", City="Minneapolis", State="MN", Description = "Admins of the #1 Retro Game Review Website in the World!.", UserName = user.UserName };
            user.Author = new Author() { Name = "Admin" };
            

            var user2 = new AppUser()
            {
                UserName = "matt",
                
            };
            user2.Profile = new Profile() { FirstName = "Matt", LastName= "Damon", City="LA", State="California", Description="The first of many A-Class celebrities to manage the most  ", UserName = user2.UserName };
            user2.Author = new Author() { Name = "Herb" };



            userMgr.Create(user, "testing123");
			userMgr.Create(user2, "mattiscool");

			userMgr.AddToRole(user.Id, "admin");
			userMgr.AddToRole(user2.Id, "contributor");
		}
	}
}
