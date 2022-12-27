using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace CodeFirst.Models
{
    //Hereda de DbContext
    public class BlogContext: DbContext
    {
        //si usamos varios conexion string es importante indicar cual estamos usando
        //lo podemos indicar usando el contexto BlogContext e indicando el nombre del conexion string
        //en este caso DefaultConnection
        public BlogContext() : base("DefaultConnection") { }

        //Le indicamos que modelos se usaran y  crearan como tablas
        //DbSet<nombre_del_modelo> Nombre_que_tendra_la_tabal {get; set;}
        public DbSet<BlogPost> BlogPosts { get; set; }

        //Agregamos un nuevo DbSet para la tabla o propiedad Comentario lo llamamos Comentarios
        public DbSet<Comentario> Comentarios { get; set; }

        //Agregamos un nuevo DbSet tipo Persona, para la tabla Personas
        public DbSet<Persona> Personas { get; set; }

        //Agregamos un nuevo DbSet para el modelo Direccion, crea una tabla llamad Direcciones
        public DbSet<Direccion> Direcciones { get; set; }


       //METODO PARA CAMBIAR LOS TIPOS DE DATOS DE UN MODELO
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //un tipo DateTime se convertira un DateTime2
            modelBuilder.Properties<DateTime>().Configure(x => x.HasColumnType("DateTime2"));

            //si hay una propiedad de tipo int y contenga en su nombre Codigo, se convertira en primaryKey
            modelBuilder.Properties<int>().Where(p => p.Name.StartsWith("Codigo"))
                .Configure(p => p.IsKey());

            base.OnModelCreating(modelBuilder);
        }

        /**
                //METODO PARA VALIDAR UNA CONDICION ANTES DE ELIMINAR
                protected override bool ShouldValidateEntity(DbEntityEntry entityEntry)
                {
                    //Indica que operación se esta realizando, de borrado. Retornamos un true.
                    if (entityEntry.State == EntityState.Deleted)
                    {
                        return true;
                    }
                    return base.ShouldValidateEntity(entityEntry);
                }



                //CONDICION QUE NO PERMITE ELILMINAR A UN MENOR DE EDAD
                protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
                {

                    if(entityEntry.Entity is Persona && entityEntry.State == EntityState.Deleted)
                    {
                        var entidad = entityEntry.Entity as Persona;
                        if(entidad.Edad < 18)
                        {
                            return new DbEntityValidationResult(entityEntry, new DbValidationError[]
                                {
                                    new DbValidationError("Edad", "No se puede Elimniar a un menor de Edad.")
                                }
                            );
                        } 
                    }

                    return base.ValidateEntity(entityEntry, items);
                }
        **/


        /**
                public override int SaveChanges()
                {
                    var entidades = ChangeTracker.Entries();

                    if(entidades != null)
                    {
                        foreach (var entidad in entidades.Where(c => c.State != EntityState.Unchanged))
                        {
                            Auditar(entidad);
                        }
                    }
                    return base.SaveChanges();
                }
        **/

    }
}