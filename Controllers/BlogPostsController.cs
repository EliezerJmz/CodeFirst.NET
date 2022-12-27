using CodeFirst.Models;
using CodeFirst.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirst.Controllers
{
    public class BlogPostsController : Controller
    {
        //Creamos una propiedad de tipo BlogpostRepository, Services
        //contiene el listado de registros
        private BlogPostRepository repo;

        //creamos un constructor del controller para inicializar las prpiedades
        public BlogPostsController()
        {
            //contiene el listado de registros del  BlogPostRepository
            repo = new BlogPostRepository();
        }



        // GET: BlogPosts
        public ActionResult Index()
        {
            //obtenemos todos los registros 
            var model = repo.ObtenerTodos();
           // var comentario = model[0].Comentarios[0];
           
            //enviamos a la vista todos los registros pormedio de la variable model
            return View(model);
        }

        // GET: BlogPosts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BlogPosts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlogPosts/Create
        [HttpPost]
        public ActionResult Create(BlogPost model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Ctrl * . 
                    //Para crear el método crear
                   //Lo crea en el servicio BlogPostRepository
                   //es el metodo que crea y guarda un registro en la bd
                    repo.crear(model);
                    return RedirectToAction("Index");
                }
             
            }
            catch(Exception ex)
            {
              //log exp
            }
            return View(model);
        }

        // GET: BlogPosts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BlogPosts/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BlogPosts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BlogPosts/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
