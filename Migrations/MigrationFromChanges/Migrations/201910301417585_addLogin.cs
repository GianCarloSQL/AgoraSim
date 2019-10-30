namespace MigrationFromChanges.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addLogin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "Login", c => c.String());
            AddColumn("dbo.Usuarios", "Senha", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "Senha");
            DropColumn("dbo.Usuarios", "Login");
        }
    }
}
