namespace StreamingVideos.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Episode",
                c => new
                    {
                        EpisodeId = c.Int(nullable: false, identity: true),
                        TVShowId = c.Int(nullable: false),
                        EpisodeTitle = c.String(nullable: false),
                        EpisodeRuntime = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EpisodeId)
                .ForeignKey("dbo.TVShow", t => t.TVShowId, cascadeDelete: true)
                .Index(t => t.TVShowId);
            
            CreateTable(
                "dbo.TVShow",
                c => new
                    {
                        TVShowId = c.Int(nullable: false, identity: true),
                        TVShowTitle = c.String(nullable: false),
                        TVShowEpisodes = c.Int(nullable: false),
                        TVShowSeasons = c.Int(nullable: false),
                        TVShowGenre = c.String(nullable: false),
                        TVShowLicenseEndDate = c.DateTimeOffset(nullable: false, precision: 7),
                        TVShowViews = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TVShowId);
            
            CreateTable(
                "dbo.MovieRating",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        StarRating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        MovieTitle = c.String(nullable: false),
                        MovieRuntime = c.Int(nullable: false),
                        MovieGenre = c.String(nullable: false),
                        MovieLicenseEndDate = c.DateTimeOffset(nullable: false, precision: 7),
                        MovieViews = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MovieId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.TVShowRating",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TVShowId = c.Int(nullable: false),
                        StarRating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TVShow", t => t.TVShowId, cascadeDelete: true)
                .Index(t => t.TVShowId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        UserEmail = c.String(nullable: false),
                        UserAge = c.String(nullable: false),
                        MemberSince = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.TVShowRating", "TVShowId", "dbo.TVShow");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.MovieRating", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.Episode", "TVShowId", "dbo.TVShow");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.TVShowRating", new[] { "TVShowId" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.MovieRating", new[] { "MovieId" });
            DropIndex("dbo.Episode", new[] { "TVShowId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.User");
            DropTable("dbo.TVShowRating");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Movie");
            DropTable("dbo.MovieRating");
            DropTable("dbo.TVShow");
            DropTable("dbo.Episode");
        }
    }
}
