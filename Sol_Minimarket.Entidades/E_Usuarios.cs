﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol_Minimarket.Entidades
{
    public class E_Usuarios
    {
        public int Codigo_us { get; set; }
        public string Login_us { get; set; }
        public string Password_us { get; set; }
        public string Nombres_us { get; set; }
        public string Cargo_us { get; set; }
        public bool Es_admin { get; set; }
    }
}
