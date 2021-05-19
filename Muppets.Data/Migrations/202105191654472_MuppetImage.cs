namespace Muppets.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MuppetImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Muppet", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Muppet", "Image");
        }
    }
}
