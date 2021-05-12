namespace Muppets.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Muppet", "MovieId", "dbo.Movie");
            AddColumn("dbo.Muppet", "Movie_MovieId", c => c.Int());
            AddColumn("dbo.Movie", "Muppet_MuppetId", c => c.Int());
            CreateIndex("dbo.Movie", "Muppet_MuppetId");
            CreateIndex("dbo.Muppet", "Movie_MovieId");
            AddForeignKey("dbo.Movie", "Muppet_MuppetId", "dbo.Muppet", "MuppetId");
            AddForeignKey("dbo.Muppet", "Movie_MovieId", "dbo.Movie", "MovieId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Muppet", "Movie_MovieId", "dbo.Movie");
            DropForeignKey("dbo.Movie", "Muppet_MuppetId", "dbo.Muppet");
            DropIndex("dbo.Muppet", new[] { "Movie_MovieId" });
            DropIndex("dbo.Movie", new[] { "Muppet_MuppetId" });
            DropColumn("dbo.Movie", "Muppet_MuppetId");
            DropColumn("dbo.Muppet", "Movie_MovieId");
            AddForeignKey("dbo.Muppet", "MovieId", "dbo.Movie", "MovieId", cascadeDelete: true);
        }
    }
}
