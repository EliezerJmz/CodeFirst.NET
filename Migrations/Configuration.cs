namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirst.Models.BlogContext>
    {
        public Configuration()
        {
            //en true, entityFramework realiza de forma automática los cambios que hagamos en el modelo 
            //si en el modelo agregamos una nueva propiedad entityFramework agregara un nuevo campo en la base de datos
            AutomaticMigrationsEnabled = true;

            //permitimos que se permita la perdiada de datos de la bsse de datos
            //NOTA: no es recomenable lo utilizamos solo por cuestiones didacticos
            AutomaticMigrationDataLossAllowed = true;

        }

        protected override void Seed(CodeFirst.Models.BlogContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            //Agregar registros a la tabla Comentarios
            context.Comentarios.AddOrUpdate(x => x.Id, new Models.Comentario()
            {
                Id = 1,
                Autor = "Giovany",
                BlogPostId = 1,
                Contenido = "Comentario 1 de publicación 1.",
            });
            //Agregar un registro a la tabla Comentarios
            context.Comentarios.AddOrUpdate(x => x.Id, new Models.Comentario()
            {
                Id = 2,
                Autor = "Eliezer",
                BlogPostId = 1,
                Contenido = "Comentario 2 de publicación 1."
            });
            context.Comentarios.AddOrUpdate(x => x.Id, new Models.Comentario()
            {
                Id = 3,
                Autor = "Eliezer",
                BlogPostId = 1,
                Contenido = "Comentario 3 de publicación 1."
            });
            context.Comentarios.AddOrUpdate(x => x.Id, new Models.Comentario()
            {
                Id = 4,
                Autor = "Eliezer",
                BlogPostId = 2,
                Contenido = "Comentario 1 de publicación 2."
            });
            context.Comentarios.AddOrUpdate(x => x.Id, new Models.Comentario()
            {
                Id = 5,
                Autor = "Eliezer",
                BlogPostId = 2,
                Contenido = "Comentario 2 de publicación 2."
            });
            context.Comentarios.AddOrUpdate(x => x.Id, new Models.Comentario()
            {
                Id = 6,
                Autor = "Eliezer",
                BlogPostId = 3,
                Contenido = "Comentario 1 de publicación 3."
            });
        }
    }


}
