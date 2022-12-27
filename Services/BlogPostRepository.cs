using CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//para usar Include en el Db context
using System.Data.Entity;

namespace CodeFirst.Services
{
    public class BlogPostRepository
    {
        //creamos un metodo que devuelva una lista de tipo model BlogPost
        public List<BlogPost> ObtenerTodos()
        {
            //instanceamos nuestro DbContext BlogContext
            //lo hacemos dentro de un using para que se liberen los recursos usados
            using (var db = new BlogContext())
            {
                //devolvemos un listado de todos los registros. BlogPosts es el DbSet que definimos en el BlogContext.cs
                // return db.BlogPosts.ToList();

                
                //aqui estamos devolvinedo los comentarios Del campo Comentarios
                //que esta realcionado con la tabla BlogPosts
                return db.BlogPosts.Include(x => x.Comentarios).ToList();
            }

        }

        public void crear(BlogPost model)
        {
            //Crear el registro y gurdarlo en la base de datos
            using (var db = new BlogContext())
            {
                db.BlogPosts.Add(model);
                db.SaveChanges();
            }
        }
    }
}