namespace ImoveisSystems.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ImoveisSystems.Models.ContextDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ImoveisSystems.Models.ContextDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var Proprietario = new Models.Owner
                ("Gian", DateTime.Now.AddYears(-30), "giang@gmail.com");

            context.Owners.AddOrUpdate(Proprietario);
            context.Properties.AddOrUpdate(new Models.Property(
                "89030070", "Casa", "Centro", "Blumenau", 234, "Frente a padaria", Proprietario));
            context.SaveChanges();
        }
    }
}
