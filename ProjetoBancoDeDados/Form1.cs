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

namespace ProjetoBancoDeDados
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.CST;

            try
            {
                con.Open();

                //Criando comando SQL
                SqlCommand cmm = new SqlCommand();
                cmm.CommandText = "select * from tb_clientes";
                cmm.CommandType = CommandType.Text;
                cmm.Connection = con;                
                SqlDataReader dr;
                dr = cmm.ExecuteReader();

                //Carregar dados para dataGrid
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();


                con.Close();
                MessageBox.Show("A conexão foi realizada com sucesso! ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Falha na conexao: (0)", ex.Message));
            }

        }
    }
}
