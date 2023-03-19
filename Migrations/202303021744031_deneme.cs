namespace ErpUyg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deneme : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kategoris",
                c => new
                    {
                        KategoriId = c.Int(nullable: false, identity: true),
                        KategoriAdi = c.String(),
                    })
                .PrimaryKey(t => t.KategoriId);
            
            CreateTable(
                "dbo.Uruns",
                c => new
                    {
                        UrunId = c.Int(nullable: false, identity: true),
                        UrunAd = c.String(),
                        UrunStok = c.Int(nullable: false),
                        UrunFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        KategoriId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UrunId)
                .ForeignKey("dbo.Kategoris", t => t.KategoriId, cascadeDelete: true)
                .Index(t => t.KategoriId);
            
            CreateTable(
                "dbo.Satis",
                c => new
                    {
                        SatisId = c.Int(nullable: false, identity: true),
                        SatisAdeti = c.Int(nullable: false),
                        ToplamFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UrunId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SatisId)
                .ForeignKey("dbo.Uruns", t => t.UrunId, cascadeDelete: true)
                .Index(t => t.UrunId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Satis", "UrunId", "dbo.Uruns");
            DropForeignKey("dbo.Uruns", "KategoriId", "dbo.Kategoris");
            DropIndex("dbo.Satis", new[] { "UrunId" });
            DropIndex("dbo.Uruns", new[] { "KategoriId" });
            DropTable("dbo.Satis");
            DropTable("dbo.Uruns");
            DropTable("dbo.Kategoris");
        }
    }
}
