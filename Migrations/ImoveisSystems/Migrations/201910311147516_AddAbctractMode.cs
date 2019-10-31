namespace ImoveisSystems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAbctractMode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Owners", "Ativo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Owners", "UsuarioCriacao", c => c.Int(nullable: false));
            AddColumn("dbo.Owners", "UsuarioAlteracao", c => c.Int(nullable: false));
            AddColumn("dbo.Owners", "DataCriacao", c => c.DateTime(nullable: false));
            AddColumn("dbo.Owners", "DataAlteracao", c => c.DateTime(nullable: false));
            AddColumn("dbo.Properties", "Ativo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Properties", "UsuarioCriacao", c => c.Int(nullable: false));
            AddColumn("dbo.Properties", "UsuarioAlteracao", c => c.Int(nullable: false));
            AddColumn("dbo.Properties", "DataCriacao", c => c.DateTime(nullable: false));
            AddColumn("dbo.Properties", "DataAlteracao", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Properties", "DataAlteracao");
            DropColumn("dbo.Properties", "DataCriacao");
            DropColumn("dbo.Properties", "UsuarioAlteracao");
            DropColumn("dbo.Properties", "UsuarioCriacao");
            DropColumn("dbo.Properties", "Ativo");
            DropColumn("dbo.Owners", "DataAlteracao");
            DropColumn("dbo.Owners", "DataCriacao");
            DropColumn("dbo.Owners", "UsuarioAlteracao");
            DropColumn("dbo.Owners", "UsuarioCriacao");
            DropColumn("dbo.Owners", "Ativo");
        }
    }
}
