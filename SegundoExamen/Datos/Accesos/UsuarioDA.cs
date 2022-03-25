using Datos.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Accesos{
    public class UsuarioDA{
        readonly string cadena = "Server=localhost; Port=3306; Database=SegundoExamen; Uid=root; Pwd=2000;";

        MySqlConnection conn;
        MySqlCommand cmd;


        public Usuario Login(string codigo, string contrasena){
            Usuario user = null;

            try{
                string sql = "SELECT * FROM usuario WHERE Codigo = @Codigo AND contrasena = @contrasena;";

                conn = new MySqlConnection(cadena); //instanciamos la conexion a la bd
                conn.Open(); //abrimos la conexion

                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Codigo", codigo);
                cmd.Parameters.AddWithValue("@contrasena", contrasena);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()){
                    user = new Usuario();
                    user.Codigo = reader[0].ToString();
                    user.Nombre = reader[1].ToString();
                    user.Apellido = reader[2].ToString();
                    user.contrasena = reader[3].ToString();

                }//fin ciclo while

                reader.Close();
                conn.Close(); //cerramos la conexion a la BD
            }
            catch (Exception ex){

            }//fin catch

            return user;
        }


        public DataTable ListarUsuarios(){
            DataTable listaUsuariosDT = new DataTable();

            try{
                string sql = "SELECT * FROM usuarios;";
                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                MySqlDataReader reader = cmd.ExecuteReader();
                listaUsuariosDT.Load(reader);
                reader.Close();
                conn.Close();
            }

            catch (Exception ex){
            }

            return listaUsuariosDT;
        }

    }
}
