using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;
using Datos.Accesos;
using Datos.Entidades;

namespace SegundoExamen
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e){
            UsuarioDA usuarioDA = new UsuarioDA(); //este usuario es quien accede a la BD
            Usuario usuario = new Usuario();

            usuario = usuarioDA.Login(UserTxt.Text, PassTxt.Text);


            MenuForm menuForm = new MenuForm();
            menuForm.Show();
            this.Hide();

            //UsuariosForm usuariosForm = new UsuariosForm();
            //usuariosForm.Show();


            //if (usuario == null){
            //    MessageBox.Show("Usuario inexistente!!");

            //}



        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
