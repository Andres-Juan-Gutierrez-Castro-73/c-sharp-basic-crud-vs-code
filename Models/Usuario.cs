using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace c_sharp_mvc_crud_basic.Models
{
    public class Usuario
    {
        public int Id_Usuario { get; set; }
        public string? Nombre { get; set; }
        public int Edad { get; set; }
    }
}