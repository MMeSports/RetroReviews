namespace RetroReview.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "dbo.GameCovers",
                c => new
                    {
                        GameCoverId = c.Int(nullable: false, identity: true),
                        GameCoverUrl = c.String(),
                    })
                .PrimaryKey(t => t.GameCoverId);
            
            CreateTable(
                "dbo.GameRatings",
                c => new
                    {
                        GameRatingId = c.Int(nullable: false, identity: true),
                        GameRatingName = c.String(),
                    })
                .PrimaryKey(t => t.GameRatingId);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        GameId = c.Int(nullable: false, identity: true),
                        GameTitle = c.String(),
                        ReleaseYear = c.String(),
                        GameRatingId = c.Int(nullable: false),
                        PlatformId = c.Int(nullable: false),
                        GameCoverId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GameId)
                .ForeignKey("dbo.GameCovers", t => t.GameCoverId, cascadeDelete: true)
                .ForeignKey("dbo.GameRatings", t => t.GameRatingId, cascadeDelete: true)
                .ForeignKey("dbo.Platforms", t => t.PlatformId, cascadeDelete: true)
                .Index(t => t.GameRatingId)
                .Index(t => t.PlatformId)
                .Index(t => t.GameCoverId);
            
            CreateTable(
                "dbo.Platforms",
                c => new
                    {
                        PlatformId = c.Int(nullable: false, identity: true),
                        PlatformName = c.String(),
                    })
                .PrimaryKey(t => t.PlatformId);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        ProfileId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ProfileId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        ReviewTitle = c.String(),
                        AuthorId = c.Int(nullable: false),
                        ReviewBody = c.String(),
                        ReviewDate = c.DateTime(nullable: false),
                        Rating = c.Int(nullable: false),
                        GameId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewId)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.StaticPages",
                c => new
                    {
                        StaticPageId = c.Int(nullable: false, identity: true),
                        PageName = c.String(),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.StaticPageId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        ProfileId = c.Int(nullable: false),
                        AuthorId = c.Int(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.AuthorId)
                .ForeignKey("dbo.Profiles", t => t.ProfileId, cascadeDelete: true)
                .Index(t => t.ProfileId)
                .Index(t => t.AuthorId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Reviews", "GameId", "dbo.Games");
            DropForeignKey("dbo.Reviews", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.Games", "PlatformId", "dbo.Platforms");
            DropForeignKey("dbo.Games", "GameRatingId", "dbo.GameRatings");
            DropForeignKey("dbo.Games", "GameCoverId", "dbo.GameCovers");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "AuthorId" });
            DropIndex("dbo.AspNetUsers", new[] { "ProfileId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Reviews", new[] { "GameId" });
            DropIndex("dbo.Reviews", new[] { "AuthorId" });
            DropIndex("dbo.Games", new[] { "GameCoverId" });
            DropIndex("dbo.Games", new[] { "PlatformId" });
            DropIndex("dbo.Games", new[] { "GameRatingId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.StaticPages");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Reviews");
            DropTable("dbo.Profiles");
            DropTable("dbo.Platforms");
            DropTable("dbo.Games");
            DropTable("dbo.GameRatings");
            DropTable("dbo.GameCovers");
            DropTable("dbo.Authors");
        }
    }
}
