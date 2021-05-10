namespace Muppets.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdteDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Muppet",
                c => new
                    {
                        MuppetId = c.Int(nullable: false, identity: true),
                        MuppetName = c.String(nullable: false, maxLength: 50),
                        Origin = c.String(),
                        PerformerId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                        MuppetBirthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MuppetId)
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Performer", t => t.PerformerId, cascadeDelete: true)
                .Index(t => t.PerformerId)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        MovieName = c.String(nullable: false),
                        DateReleased = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MovieId);
            
            CreateTable(
                "dbo.Performer",
                c => new
                    {
                        PerformerId = c.Int(nullable: false, identity: true),
                        PerformerName = c.String(nullable: false),
                        PerformerBirthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PerformerId);
            
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
            
            CreateTable(
                "dbo.PerformerMovie",
                c => new
                    {
                        Performer_PerformerId = c.Int(nullable: false),
                        Movie_MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Performer_PerformerId, t.Movie_MovieId })
                .ForeignKey("dbo.Performer", t => t.Performer_PerformerId, cascadeDelete: true)
                .ForeignKey("dbo.Movie", t => t.Movie_MovieId, cascadeDelete: true)
                .Index(t => t.Performer_PerformerId)
                .Index(t => t.Movie_MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Muppet", "PerformerId", "dbo.Performer");
            DropForeignKey("dbo.Muppet", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.PerformerMovie", "Movie_MovieId", "dbo.Movie");
            DropForeignKey("dbo.PerformerMovie", "Performer_PerformerId", "dbo.Performer");
            DropIndex("dbo.PerformerMovie", new[] { "Movie_MovieId" });
            DropIndex("dbo.PerformerMovie", new[] { "Performer_PerformerId" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Muppet", new[] { "MovieId" });
            DropIndex("dbo.Muppet", new[] { "PerformerId" });
            DropTable("dbo.PerformerMovie");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Performer");
            DropTable("dbo.Movie");
            DropTable("dbo.Muppet");
        }
    }
}
