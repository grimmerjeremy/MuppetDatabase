namespace Muppets.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adjusted : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Muppet", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.Movie", "Muppet_MuppetId", "dbo.Muppet");
            DropForeignKey("dbo.Muppet", "Movie_MovieId", "dbo.Movie");
            DropIndex("dbo.Movie", new[] { "Muppet_MuppetId" });
            DropIndex("dbo.Muppet", new[] { "MovieId" });
            DropIndex("dbo.Muppet", new[] { "Movie_MovieId" });
            CreateTable(
                "dbo.MuppetMovie",
                c => new
                    {
                        Muppet_MuppetId = c.Int(nullable: false),
                        Movie_MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Muppet_MuppetId, t.Movie_MovieId })
                .ForeignKey("dbo.Muppet", t => t.Muppet_MuppetId, cascadeDelete: true)
                .ForeignKey("dbo.Movie", t => t.Movie_MovieId, cascadeDelete: true)
                .Index(t => t.Muppet_MuppetId)
                .Index(t => t.Movie_MovieId);
            
            DropColumn("dbo.Movie", "Muppet_MuppetId");
            DropColumn("dbo.Muppet", "MovieId");
            DropColumn("dbo.Muppet", "Movie_MovieId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Muppet", "Movie_MovieId", c => c.Int());
            AddColumn("dbo.Muppet", "MovieId", c => c.Int(nullable: false));
            AddColumn("dbo.Movie", "Muppet_MuppetId", c => c.Int());
            DropForeignKey("dbo.MuppetMovie", "Movie_MovieId", "dbo.Movie");
            DropForeignKey("dbo.MuppetMovie", "Muppet_MuppetId", "dbo.Muppet");
            DropIndex("dbo.MuppetMovie", new[] { "Movie_MovieId" });
            DropIndex("dbo.MuppetMovie", new[] { "Muppet_MuppetId" });
            DropTable("dbo.MuppetMovie");
            CreateIndex("dbo.Muppet", "Movie_MovieId");
            CreateIndex("dbo.Muppet", "MovieId");
            CreateIndex("dbo.Movie", "Muppet_MuppetId");
            AddForeignKey("dbo.Muppet", "Movie_MovieId", "dbo.Movie", "MovieId");
            AddForeignKey("dbo.Movie", "Muppet_MuppetId", "dbo.Muppet", "MuppetId");
            AddForeignKey("dbo.Muppet", "MovieId", "dbo.Movie", "MovieId", cascadeDelete: true);
        }
    }
}
