namespace AlbumCollection.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAlbumArt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Albums", "Artist_MbId", "dbo.Artists");
            DropIndex("dbo.Albums", new[] { "Artist_MbId" });
            CreateTable(
                "dbo.AlbumArt",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Type = c.Int(nullable: false),
                        Path = c.String(nullable: false),
                        Album_MbId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Albums", t => t.Album_MbId, cascadeDelete: true)
                .Index(t => t.Album_MbId);
            
            AlterColumn("dbo.Albums", "Artist_MbId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Albums", "Artist_MbId");
            AddForeignKey("dbo.Albums", "Artist_MbId", "dbo.Artists", "MbId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Albums", "Artist_MbId", "dbo.Artists");
            DropForeignKey("dbo.AlbumArt", "Album_MbId", "dbo.Albums");
            DropIndex("dbo.Albums", new[] { "Artist_MbId" });
            DropIndex("dbo.AlbumArt", new[] { "Album_MbId" });
            AlterColumn("dbo.Albums", "Artist_MbId", c => c.String(maxLength: 128));
            DropTable("dbo.AlbumArt");
            CreateIndex("dbo.Albums", "Artist_MbId");
            AddForeignKey("dbo.Albums", "Artist_MbId", "dbo.Artists", "MbId");
        }
    }
}
