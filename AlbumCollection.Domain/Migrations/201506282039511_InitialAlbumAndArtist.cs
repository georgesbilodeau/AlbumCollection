namespace AlbumCollection.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialAlbumAndArtist : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        MbId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        ReleaseDate = c.DateTime(),
                        Artist_MbId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MbId)
                .ForeignKey("dbo.Artists", t => t.Artist_MbId)
                .Index(t => t.Artist_MbId);
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        MbId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MbId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Albums", "Artist_MbId", "dbo.Artists");
            DropIndex("dbo.Albums", new[] { "Artist_MbId" });
            DropTable("dbo.Artists");
            DropTable("dbo.Albums");
        }
    }
}
