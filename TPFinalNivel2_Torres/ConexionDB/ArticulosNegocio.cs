using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient; 

namespace ConexionDB
{
    public class ArticulosNegocio
    {

        public List<Articulo> Listar()
        {
            List<Articulo> lista = new List<Articulo>();

            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server =.\\SQLEXPRESS;  Initial Catalog=CATALOGO_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT A.codigo, A. Nombre, A.Descripcion, A. ImagenUrl, A.Precio, M.Descripcion Marca, C.Descripcion Categoria FROM ARTICULOS A , MARCAS M, CATEGORIAS C WHERE A.IdCategoria=C.Id AND A.IdMarca=M.Id;";
                comando.Connection = conexion;

                conexion.Open();

                lector = comando.ExecuteReader();

                while (lector.Read())
                {


                    Articulo art = new Articulo();


                    art.Codigo = (string)lector["Codigo"];
                    art.Nombre = (string)lector["Nombre"];
                    art.Marca = new Tipo();
                    art.Marca.Descripcion = (string)lector["Marca"];
                    art.Categoria= new Tipo();
                    art.Categoria.Descripcion = (string)lector["Categoria"]; 
                    art.Descripcion = (string)lector["descripcion"];
                    art.UrlImagen = (string)lector["ImagenUrl"];
                    art.Precio = (double)Math.Round((lector.GetDecimal(4)), 2);

                    lista.Add(art);
                }


                conexion.Close();
                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }




        }

     }
}
