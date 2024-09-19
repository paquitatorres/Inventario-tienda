using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using ConexionDB;

namespace Inventario_de_Articulos_de_Tienda
{
    public partial class Form1 : Form
    {

        private List<Articulo> listaArticulos;

        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ArticulosNegocio negocio = new ArticulosNegocio();

            dgvLista.DataSource=negocio.Listar();
            listaArticulos = negocio.Listar(); 
            dgvLista.DataSource = listaArticulos;
            dgvLista.Columns["UrlImagen"].Visible = false;

            cargarImagen(listaArticulos[0].UrlImagen);
            

        }

        private void dgvLista_SelectionChanged(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvLista.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.UrlImagen);
        }


        private void cargarImagen(string imagen)
        {
            try
            {
                pBoxImagen.Load(imagen);

            }
            catch (Exception ex)
            {
                pBoxImagen.Load("https://img.freepik.com/free-vector/illustration-gallery-icon_53876-27002.jpg");
               
            }


        }



    }
}
