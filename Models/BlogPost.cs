using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirst.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        [Required] //cuando se ejecuta el mensaje muestra el mensaje por default 
        [StringLength(200)]
        public string Titulo { get; set; }
        [Required(ErrorMessage ="Debe agregar {0}")] //personalizamos el mensaje y usamos el nombre del campo Contenido udando {0}
        public string Contenido { get; set; }
        [StringLength(100)]
        public string Autor { get; set; }
        [Required(ErrorMessage ="Debe ingresar una Fecha de Publicación")] // mensaje personalizdo totalmente
        public DateTime Publicacion { get; set; }
        //Si existen Comentarios de en la tabla Comentario, podemos acceder al listado 
        //por medio del campo Comentarios
        //esto lo hace entityFramewor de forma automática.
        public List<Comentario> Comentarios { get; set; }
    }
    
}