namespace Muppets.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PerformerAndMovieImagesToData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movie", "MovieImage", c => c.String());
            AddColumn("dbo.Performer", "PerformerImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Performer", "PerformerImage");
            DropColumn("dbo.Movie", "MovieImage");
        }
    }
}
