using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirst.Models.Validaciones
{
    public class DivisibleEntreAttribute : ValidationAttribute
    {
        private int _dividento;

        //inicializamos la varible usando el constructor e indicamos un mensaje base
        public DivisibleEntreAttribute(int dividendo) : base("El campo {0} no es valido")
        {
            _dividento = dividendo;
        }

        //sobre escribimos el metodo IsValid, el cual retorna un ValidationResult
        //objec value, es el valor que estamos ingresando el object porque no podemos intuir se que tipo será si es un entero una fecha o string
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //si el valor es diferente de nulo hacemos la validacion
            //si es nulo indicamos que es correcto y retornamos success
            if(value != null)
            {
                //pasamos el value a entero y decimos si el resultado de la divicion, el _dividendo debe ser diferente de 0 
                if((int)value % _dividento != 0)
                {
                    //en el mensaje base(" El campo {0} = es el validationContext.DisplayName
                    var mensajeDeError = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(mensajeDeError);
                }
            }

            return ValidationResult.Success;
        }


    }
}