namespace StreamingVideos.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Episode", "TVShowId", "dbo.TVShow");
            DropForeignKey("dbo.MovieRating", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.TVShowRating", "TVShowId", "dbo.TVShow");
            DropIndex("dbo.Episode", new[] { "TVShowId" });
            DropIndex("dbo.MovieRating", new[] { "MovieId" });
            DropIndex("dbo.TVShowRating", new[] { "TVShowId" });
            AddColumn("dbo.User", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.User", "UserAge", c => c.Int(nullable: false));
            DropTable("dbo.Episode");
            DropTable("dbo.TVShow");
            DropTable("dbo.MovieRating");
            DropTable("dbo.Movie");
            DropTable("dbo.TVShowRating");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TVShowRating",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TVShowId = c.Int(nullable: false),
                        StarRating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.MovieRating",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        StarRating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.Episode",
                c => new
                    {
                        EpisodeId = c.Int(nullable: false, identity: true),
                        TVShowId = c.Int(nullable: false),
                        EpisodeTitle = c.String(nullable: false),
                        EpisodeRuntime = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EpisodeId);
            
            AlterColumn("dbo.User", "UserAge", c => c.String(nullable: false));
            DropColumn("dbo.User", "Name");
            CreateIndex("dbo.TVShowRating", "TVShowId");
            CreateIndex("dbo.MovieRating", "MovieId");
            CreateIndex("dbo.Episode", "TVShowId");
            AddForeignKey("dbo.TVShowRating", "TVShowId", "dbo.TVShow", "TVShowId", cascadeDelete: true);
            AddForeignKey("dbo.MovieRating", "MovieId", "dbo.Movie", "MovieId", cascadeDelete: true);
            AddForeignKey("dbo.Episode", "TVShowId", "dbo.TVShow", "TVShowId", cascadeDelete: true);
        }
    }
}
