namespace AlbumCollection.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlbumYear : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "Year", c => c.Int(nullable: false));
            DropColumn("dbo.Albums", "ReleaseDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Albums", "ReleaseDate", c => c.DateTime());
            DropColumn("dbo.Albums", "Year");
        }
    }
}
