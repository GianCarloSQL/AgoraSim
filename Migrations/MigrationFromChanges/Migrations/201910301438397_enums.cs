namespace MigrationFromChanges.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enums : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "Level", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "Level");
        }
    }
}
