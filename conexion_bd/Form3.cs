using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace conexion_bd
{
    public partial class Form3 : Form
    {
        SqlConnection conexion = new SqlConnection("server=WF-H3PHF12;database=administracion;integrated security=true");
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                MessageBox.Show("Conexion exitosa");

            }
            catch
            {

                MessageBox.Show("Conexion fallida");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO productos(id,producto,precio) values(@ID,@PRODUCTO,@PRECIO)";
            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@ID", textBox1.Text);
            comando.Parameters.AddWithValue("@PRODUCTO", textBox2.Text);
            comando.Parameters.AddWithValue("@PRECIO", textBox3.Text);
            comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("Datos ingresados correctamente");
            textBox1.Text="";
            textBox2.Text="";
            textBox3.Text="";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand comando = new SqlCommand("select * from productos", conexion);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridView1.DataSource = tabla;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM productos WHERE id= @ID";
            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@ID", textBox1.Text);
            comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("Registros eliminados correctamente");
        }

        private void button5_Click(object sender, EventArgs e)
        {

            string query = "UPDATE productos SET producto=@PRODUCTO, precio=@PRECIO WHERE id=@ID";
            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@ID", textBox1.Text);
            comando.Parameters.AddWithValue("@PRODUCTO", textBox2.Text);
            comando.Parameters.AddWithValue("@PRECIO", textBox3.Text);
            comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("Registros actualizados correctamente");
            textBox1.Text="";
            textBox2.Text="";
            textBox3.Text="";
        }
    }
}
