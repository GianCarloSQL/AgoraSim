namespace ImoveisSystems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Config : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Birth_Date = c.DateTime(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cep = c.String(),
                        Logradouro = c.String(),
                        Bairro = c.String(),
                        Municipio = c.String(),
                        Numero = c.Int(nullable: false),
                        Complemento = c.String(),
                        PropertyOwner_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Owners", t => t.PropertyOwner_Id)
                .Index(t => t.PropertyOwner_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Properties", "PropertyOwner_Id", "dbo.Owners");
            DropIndex("dbo.Properties", new[] { "PropertyOwner_Id" });
            DropTable("dbo.Properties");
            DropTable("dbo.Owners");
        }
    }
}
