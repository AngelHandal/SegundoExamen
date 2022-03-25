using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SegundoExamen
{
    public partial class MenuForm : Syncfusion.Windows.Forms.Office2010Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        UsuariosForm frmUsuarios = null;
        ProductoForm frmProductos = null;
        PedidosForm frmPedidos = null;

        private void listaDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (frmUsuarios == null)
            {
                frmUsuarios = new UsuariosForm();
                frmUsuarios.MdiParent = this;
                frmUsuarios.Show();

            }
            else
            {
                frmUsuarios.Activate(); //permitir solo un formulario a la vez.

            }

        }

        private void listaDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmProductos == null)
            {
                frmProductos = new ProductoForm();
                frmProductos.MdiParent = this;
                frmProductos.Show();

            }
            else
            {
                frmProductos.Activate(); //permitir solo un formulario a la vez.

            }

        }

        private void listaDePedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmPedidos == null)
            {
                frmPedidos = new PedidosForm();
                frmPedidos.MdiParent = this;
                frmPedidos.Show();

            }
            else
            {
                frmPedidos.Activate(); //permitir solo un formulario a la vez.

            }
        }
    }
}
