﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Request
{
    public class ReqUpdateUsuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}