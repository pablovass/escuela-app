using System;
namespace EscuelaApp5._0.Entidades
{
    public class Alumno
    {
        public string Nombre { get;  set; }  
        public string UniqueId{ get;private set; }// el get es privado

       
        public Alumno()=>UniqueId = Guid.NewGuid().ToString(); // id aleatorio
            
    }
} 