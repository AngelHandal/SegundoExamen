using Datos.Accesos;
using Datos.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SegundoExamen
{
    public partial class PedidosForm : Form
    {
        public PedidosForm()
        {
            InitializeComponent();
        }
        UsuarioDA usuarioDA = new UsuarioDA();
        ProductoDA productoDA = new ProductoDA();
        private void PedidosForm_Load(object sender, EventArgs e)
        {
            ListarUsuarios();
            ListarProductos();
        }

        private void ListarUsuarios()
        {
            dataGridView1.DataSource = usuarioDA.ListarUsuarios();
        }

        private void ListarProductos()
        {
            dataGridView2.DataSource = productoDA.ListarProductos();
        }
    }
}
