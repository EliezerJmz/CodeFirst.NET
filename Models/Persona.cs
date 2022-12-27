using CodeFirst.Models.Validaciones;
using Recursos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirst.Models
{
    //implementamos la interface IValidatableObject para realizar validaciones complejas
    public class Persona: IValidatableObject
    {
        public int Id { get; set; }
        //Mensaje de error normal
        //[Required(ErrorMessage = "El Campo {0} es Obligatorio")]
        //Mensaje de error segun Recurso cambia de idioma segun el navegador este en ingles o español
        //ErrorMessageResourceName = el nombre que idicamos en el Recurso
        [Required(ErrorMessageResourceType = typeof(Recurso), ErrorMessageResourceName = "MensajeErrorRequired")]
        //Cambiar el idioma a Nombre usamos de Recursos Recurso. using Recursos;
        //Name = lo toma del Recurso, si el navegador esta en español o ingles usa el Recurso Reclurso.en-US
        [Display(ResourceType = typeof(Recurso),Name = "ModelPersonaNombreTextoLabel")]
        public string Nombre { get; set; }

        [Display(Name = "Código Postal")]
        [StringLength(5, MinimumLength =3, ErrorMessage ="El Campo {0}, Debe tener una longitud Minima de {2} y una longitud maxima de {1}")]
        public string CodigoPostal { get; set; }

        [Range(18,100, ErrorMessage ="El campo {0} debe ser un número entre {1} y {2}")]
        public int Edad { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [NotMapped] //evita que se cree el campo en la DB
        [Display(Name = "Confirmar Email")]
        /**
         * compare si realiza la comparacion entre los dos Email, pero al crear la vista Edit no funciona, bloquea la edicion.
         *  [System.ComponentModel.DataAnnotations.Compare("Email", ErrorMessage ="El Email debe ser el mismo")]
         * **/
        public string ConfirmarEmail { get; set; }

        
        [CreditCard(ErrorMessage ="Tarjeta Invalida")]
        [Display(Name ="Tarjeta de Credito")]
        public string TarjetaDeCredito { get; set; }

        //le indicamos el nombre del metodo, el nombre del controlador 
        //Remote valida del lado del cliente
        [Remote("DivisibleEntre2", "Personas", ErrorMessage ="El número debe ser divisible entre 2")]
        //usamos la validacion personalizada para el lado del servidor viene de using CodeFirst.Models.Validaciones;
        //como heredemos de  ValidationAttribute tenemos acceso a los mensajes de error
        [DivisibleEntre(2, ErrorMessage ="El valor de {0} no es divisible ente 2")]
        [Display(Name = "Número divisible entre 2")]
        public int NumeroDivisibleEntre2 { get; set; }


        //Validaciones complejas
        //se realizar aqui en el modelo.
        public decimal Salario { get; set; }

        //los labels toman el nombre que indicamos en Display
        [Display(Name ="Monto Solicitud De Prestamo")]
        public decimal MontoSolicitudPrestamo { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //podemos realizar cuantas validaciones necesitemos y el metodo retorna un list de los errores
            //que se produzcan
            
            //creamos un listado de validaciones
            var errores = new List<ValidationResult>();
            if(Salario * 4 < MontoSolicitudPrestamo)
            {
                //recibe dos parametros el mensaje y un arreglo con las pripiedades que dieron el error
                errores.Add(new ValidationResult("El monto solicitud prestamo no debe exceder 4 veces el Salario",
                   new string[] { "MontoSolicitudPrestamo"}));
                //si hubieran mas validaciones las seguimos agregando aqui
            }

            /**
             * la comparacion funciona pero bloque el editar
            if (Email != ConfirmarEmail)
            {
                errores.Add(new ValidationResult("El Email debe ser el mismo",
                    new string[] { "ConfirmarEmail" }));
            }
            **/

            /**
             * otra forma de comparar pero tanpoco funcona el editar
             * posibles solucionaes
             * https://www.iteramos.com/pregunta/28719/desactivar-el-atributo-de-validacion-obligatoria-en-determinadas-circunstancias
            if (Email != ConfirmarEmail) 
            {
                yield return new ValidationResult("Los correos deben ser Iguales", new[] { "ConfirmarEmail" }); 
            }
            yield break;
            **/

            //retornamos el listado de errores
            //si no hubo errores retorna un listado vacio que indica que no hubo errores
            return errores;
        }


        [NotMapped] //evita que se cree el campo en la DB
        [ScaffoldColumn(false)] // el CampoOculto no se crea en la vista
        public String CampoOculto { get; set; }

        //Crea un textAre
        [DataType(DataType.MultilineText)]
        public string Resumen {  get; set; }

        //Crea un campo Password
        [Required(ErrorMessage = "Debe ingresar su Clave")]
        [DataType(DataType.Password)]
        public string Clave { get; set; }

        public DateTime Nacimiento { get; set; }

       

    }
}