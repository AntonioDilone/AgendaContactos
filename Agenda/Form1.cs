using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.SqlTypes;
using System.Collections;

namespace Agenda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            insertar();
        }

        private void BtnEli_Click(object sender, EventArgs e)
        {
            eliminar();
        }

        private void BtnAct_Click(object sender, EventArgs e)
        {
            consultarTodo();
        }

        private void BtnExit_Click(object sender, EventArgs e) 
        {
            
        }

        private void consultarTodo()
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = "Data Source=LAPTOP-QM5FFGMO\\SQLEXPRESS;Initial Catalog=Agenda;Integrated Security=True;";

            conn.Open();

            string str = "SELECT CEDULA, NOMBRE, TELEFONO,CORREO,GRUPO, DIRECCION FROM CONTACTO";

            SqlCommand cmd = new SqlCommand(str);

            cmd.Connection = conn;

            //Inicio para llenar DataGridView
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dgvContacto.DataSource = dt;
            //Final para llenar DataGridView



            //inicio interar uno a uno
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                string datos = "Cedula: " + dr.GetInt32(0) + " nombre: " + dr.GetString(1);

                MessageBox.Show(datos);

            }
            //Fin para interar uno a uno
            conn.Close();
        }
        private void eliminar()
        {

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = "Data Source=LAPTOP-QM5FFGMO\\SQLEXPRESS;Initial Catalog=Agenda;Integrated Security=True;";

            conn.Open();

            string str = "DELETE CONTACTO WHERE CEDULA = @CEDULA";

            SqlCommand cmd = new SqlCommand(str);

            cmd.Parameters.AddWithValue("@CEDULA", TxtCedula.Text);

            cmd.Connection = conn;

            cmd.ExecuteNonQuery();

            conn.Close();

            consultarTodo();
        }

        private void insertar()
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = "Data Source=LAPTOP-QM5FFGMO\\SQLEXPRESS;Initial Catalog=Agenda;Integrated Security=True;";

            conn.Open();

            string str = "INSERT INTO Contacto (CEDULA,NOMBRE,TELEFONO,CORREO,GRUPO, DIRECCION) VALUES(@CEDULA, @NOMBRE, @TELEFONO, @CORREO, @GRUPO, @DIRECCION)";

            SqlCommand cmd = new SqlCommand(str);

            cmd.Parameters.AddWithValue("@CEDULA", TxtCedula.Text);
            cmd.Parameters.AddWithValue("@NOMBRE", TxtNombre.Text);
            cmd.Parameters.AddWithValue("@TELEFONO", TxtTelefono.Text);
            cmd.Parameters.AddWithValue("@CORREO", TxtCorreo.Text);
            cmd.Parameters.AddWithValue("@GRUPO", TxtGrupo.Text);
            cmd.Parameters.AddWithValue("@DIRECCION", TxtDireccion.Text);

            cmd.Connection = conn;
            cmd.Connection = conn;

            cmd.ExecuteNonQuery();

            conn.Close();

            consultarTodo();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'agendaDataSet.Contacto' Puede moverla o quitarla según sea necesario.
            this.contactoTableAdapter.Fill(this.agendaDataSet.Contacto);

        }
    }


}
