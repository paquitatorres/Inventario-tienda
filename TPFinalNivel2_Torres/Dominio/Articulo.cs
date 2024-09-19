using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulo
    {
        //saque Id 

        public string Nombre { get; set; }

        public Tipo Categoria { get; set; }

        public Tipo Marca { get; set; }

        public string UrlImagen { get; set; }

        public double Precio {  get; set; }

        public string Codigo {  get; set; }

        public string Descripcion { get; set; }

    }
}
