//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoFinalASP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Licencias
    {
        public int ID { get; set; }
        public Nullable<int> FK_Empleado { get; set; }
        public Nullable<System.DateTime> Desde { get; set; }
        public Nullable<System.DateTime> Hasta { get; set; }
        public string Motivo { get; set; }
        public string Comentario { get; set; }
    
        public virtual Empleados Empleados { get; set; }
    }
}