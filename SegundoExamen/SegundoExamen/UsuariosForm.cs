using Datos.Accesos;
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
    public partial class UsuariosForm : Form
    {
        public UsuariosForm()
        {
            InitializeComponent();
        }

        UsuarioDA usuarioDA = new UsuarioDA();

        private void UsuariosForm_Load(object sender, EventArgs e)
        {
            ListarUsuarios();

        }

        private void ListarUsuarios()
        {
            UsuariosdataGridView.DataSource = usuarioDA.ListarUsuarios();
        }
    }
}
