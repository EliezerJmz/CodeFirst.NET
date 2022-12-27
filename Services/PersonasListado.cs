using CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CodeFirst.Services
{
    public class PersonasListado
    {
        //LIST
        //metodo que devuelva una lista de tipo model BlogPost
        public List<Persona> listaPersonas()
        {
            //instanceamos nuestro DbContext llamado BlogContext
            //lo hacemos dentro de un using para que se liberen los recursos usados
            using (var db = new BlogContext())
            {
                //devolvemos un listado de todos los registros. Personas es el DbSet que definimos en el BlogContext.cs
                 return db.Personas.ToList();

            }

        }

        //CREATE
        //metodo que no sevuleve ningun valor 
        public void crear(Persona model)
        {
            //Crear el registro y gurdarlo en la base de datos
            using (var db = new BlogContext())
            {
                db.Personas.Add(model);
                db.SaveChanges();
            }
        }

        //DETALLE
        //Metodo retorna un objeto Persona con el id encontrado
        public Persona detalle(int id)
        {
            using (var db = new BlogContext())
            {
                Persona persona = db.Personas.Find(id);
                return persona;
            }
             
        }

        //DELETE BUSQUEDA
        //Metodo que BUSCA el registro a eliminar por medio de su id
        public Persona eliminar(int id)
        {
            using(var db = new BlogContext())
            {
                Persona persona = db.Personas.Find(id);
                return persona;
            }
        }

        //DELETE
        public void eliminarConfirmar(int id)
        {
            using (var db = new BlogContext())
            {
                var persona = db.Personas.Find(id);
                db.Personas.Remove(persona);
                db.SaveChanges();
            }
        }

        //EDIT BUSQUEDA
        public Persona Edit(int id)
        {
            using (var db = new BlogContext())
            {
                Persona persona = db.Personas.Find(id);
                return persona;
            }
        }

        //EDIT
        public void editConfirmar(Persona persona)
        {
            using (var db = new BlogContext())
            {
                db.Entry(persona).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}