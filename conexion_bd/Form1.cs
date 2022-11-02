using System.Data;
using System.Data.SqlClient;

namespace conexion_bd
{
    public partial class Form1 : Form
    {
        //conexion bd
        SqlConnection conexion = new SqlConnection("server=WF-H3PHF12;database=administracion;integrated security=true"), cone;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("select usuar, pass from usuarios where usuar=('"+ textBox1.Text +"') and pass=('"+ textBox2.Text +"')", conexion);
            com.Parameters.AddWithValue("usuar", textBox1.Text);
            com.Parameters.AddWithValue("pass", textBox2.Text);
            SqlDataAdapter adaptador = new SqlDataAdapter(com);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);

            if (tabla.Rows.Count==1)
            {
                MessageBox.Show("Usuario y contra validos.");
                Form Form2 = new Form2();
                Form2.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuario y/o contrase;a incorrecto ");
            }



        }
    }
}