using CodeFirst.Models;
using CodeFirst.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CodeFirst.Controllers
{
    public class PersonasController : Controller
    {
        //Creamos una propiedad de tipo PeresonasListado, Services
        //contiene el listado de registros
        private PersonasListado listaDePersonas;


        //creamos un constructor del controller para inicializar las prpiedades
        public PersonasController()
        {
            //contiene el listado de registros del PersonasListado() metodo del servicio
            listaDePersonas = new PersonasListado();
        }

        // GET: Personas
        public ActionResult Index()
        {
            //obtenemos todos los registros metodo del servicio
            var model = listaDePersonas.listaPersonas();

            //enviamos a la vista todos los registros pormedio de la variable model
            return View(model);
        }

        // GET: Personas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var persona = listaDePersonas.detalle(id.Value);
            if(persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }


        //Metodo Personalizado Remote
        //metodo personalizado para devolver una validacion personalizada
        public JsonResult DivisibleEntre2(int NumeroDivisibleEntre2)
        {
            var esValido = NumeroDivisibleEntre2 % 2 == 0;
            //AllowGet permite que se pueda consultar un action desde un get.
            return Json(esValido, JsonRequestBehavior.AllowGet);
        }


        // GET: Personas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personas/Create
        [HttpPost]
        public ActionResult Create(Persona model) 
        {
            try
            {


                //cuando creamos un registro se valida aqui          
                //si el estado del modelo se cumple entonces crea el registro
                //sin no retorna la vista con el model.
                //tambien utiliza  jqueryval para validar y mostrar los mensjaes en pantalla
                //usando java sctipt
                // @section Scripts {
                //     @Scripts.Render("~/bundles/jqueryval")  
                // }
                //de la vista Create.cshtml
                if (ModelState.IsValid)
                {  
                    //es el metodo que crea y guarda un registro en la bd
                    listaDePersonas.crear(model);
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                return View(ex);
            }
            return View(model);
        }

        // GET: Personas/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var persona = listaDePersonas.Edit(id.Value);
            if(persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: Personas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,CodigoPostal,Edad,Email,TarjetaDeCredito,NumeroDivisibleEntre2,Salario,MontoSolicitudPrestamo,Resumen,Clave,Nacimiento")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                listaDePersonas.editConfirmar(persona);
                return RedirectToAction("Index");
            }
            return View(persona);
        }

        // GET: Personas/Delete/5
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var persona = listaDePersonas.eliminar(id.Value);
            if(persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            listaDePersonas.eliminarConfirmar(id);
            return RedirectToAction("Index");
           
        }

 
    }
}
