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
    public partial class ProductoForm : Form
    {
        public ProductoForm()
        {
            InitializeComponent();
        }

        string operacion = string.Empty;

        ProductoDA productoDA = new ProductoDA();
        private void NuevoBtn_Click(object sender, EventArgs e)
        {
            operacion = "Nuevo";
            HabilitarControles();
        }

        private void HabilitarControles()
        {
            CodigoTxt.Enabled = true;
            DescripcionTxt.Enabled = true;
            PrecioTxt.Enabled = true;
            InventarioTxt.Enabled = true;
            GuardarBtn.Enabled = true;
            CancelarBtn.Enabled = true;
            NuevoBtn.Enabled = false;
            ModificarBtn.Enabled = false;

        }

        private void DesabilitarControles()
        {
            CodigoTxt.Enabled = false;
            DescripcionTxt.Enabled = true;
            PrecioTxt.Enabled = false;
            InventarioTxt.Enabled = false;
            GuardarBtn.Enabled = false;
            CancelarBtn.Enabled = false;
            NuevoBtn.Enabled = true;
            ModificarBtn.Enabled = true;

        }

        private void LimpiarControles()
        {
            CodigoTxt.Clear();
            DescripcionTxt.Clear();
            PrecioTxt.Clear();
            InventarioTxt.Clear();


        }

        private void GuardarBtn_Click(object sender, EventArgs e){

            try
            {
                if (string.IsNullOrEmpty(CodigoTxt.Text))
                {
                    errorProvider1.SetError(CodigoTxt, "Ingrese el código");
                    CodigoTxt.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(DescripcionTxt.Text))
                {
                    errorProvider1.SetError(DescripcionTxt, "Ingrese una descripción");
                    DescripcionTxt.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(PrecioTxt.Text))
                {
                    errorProvider1.SetError(PrecioTxt, "Ingrese un precio");
                    PrecioTxt.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(InventarioTxt.Text))
                {
                    errorProvider1.SetError(InventarioTxt, "Ingrese una existencia");
                    InventarioTxt.Focus();
                    return;
                }

                Producto producto = new Producto();
                producto.Codigo = CodigoTxt.Text;
                producto.Descripcion = DescripcionTxt.Text;
                producto.Precio = Convert.ToDecimal(PrecioTxt.Text);
                producto.Inventario = Convert.ToInt32(InventarioTxt.Text);


                if (operacion == "Nuevo")
                {
                    bool inserto = productoDA.InsertarProducto(producto);

                    if (inserto)
                    {
                        DesabilitarControles();
                        LimpiarControles();
                        ListarProductos();
                        MessageBox.Show("Producto insertado");
                    }
                }
                else if (operacion == "Modificar")
                {
                    bool modifico = productoDA.ModificarProducto(producto);
                    if (modifico)
                    {
                        LimpiarControles();
                        DesabilitarControles();
                        ListarProductos();
                        MessageBox.Show("Producto Modificado");
                        
                    }
                }
            }
            catch (Exception)
            {
            }

        }

        private void ProductoForm_Load(object sender, EventArgs e)
        {
            ListarProductos();

        }

        private void ListarProductos()
        {
            ProductosdataGridView.DataSource = productoDA.ListarProductos();
        }

        private void ModificarBtn_Click(object sender, EventArgs e){
            operacion = "Modificar";

            if (ProductosdataGridView.SelectedRows.Count > 0){
                CodigoTxt.Text = ProductosdataGridView.CurrentRow.Cells["Codigo"].Value.ToString();
                DescripcionTxt.Text = ProductosdataGridView.CurrentRow.Cells["Descripcion"].Value.ToString();
                PrecioTxt.Text = ProductosdataGridView.CurrentRow.Cells["Precio"].Value.ToString();
                InventarioTxt.Text = ProductosdataGridView.CurrentRow.Cells["Inventario"].Value.ToString();

                HabilitarControles();
                CodigoTxt.Focus();
            }
            else{
                MessageBox.Show("Debe seleccionar un producto");
            }

        }

        private void EliminarBtn_Click(object sender, EventArgs e)
        {
            if (ProductosdataGridView.SelectedRows.Count > 0)
            {
                bool elimino = productoDA.EliminarProducto(ProductosdataGridView.CurrentRow.Cells["Codigo"].Value.ToString());

                if (elimino)
                {
                    ListarProductos();
                    MessageBox.Show("Producto Eliminado Exitosamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al eliminar el Producto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Porfavor seleccione un Producto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
    

