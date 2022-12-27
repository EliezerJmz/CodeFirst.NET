using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeFirst.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Contenido { get; set; }    
        public string Autor { get; set; }
        //creamos un campo para que contenga el BlogPostId para relacionar la tabla es la llave foranea
        public int BlogPostId { get; set; }
        [ForeignKey("BlogPostId")]
        //propiedad navegacional propia de entityframework
        //si hay un comentario permite ir hacia el BlogPost que lo contiene
        //y traer todos los campos del BlogPost
        public BlogPost BlogPost { get; set; }
    }
}