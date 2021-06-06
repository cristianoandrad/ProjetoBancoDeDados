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

/* 
 * ADO.NET é a tecnologia de acesso a dados da plataforma .NET que permite a manipulação de dados.
 * Os componentes do ADO.NET são:
 * Connection – realiza a conexão com o banco de dados
 * Command – executa comando no banco de dados
 * DataAdapter – preenche o DataSet
 * DataSet e DataReader – armazenam informações do banco de dados – conjunto de tabelas.
 * 
 * O Data Set é uma cópia do banco de dados. Desse modo, a principal característica do Data Set é funcionar em modo desconectado.
 * Esse elemento coleciona objetos Data Table. 
 * A intermediação com o banco de dados é feita por meio do Data Adapter.
 * 
 * O Data Adapter faz a ligação entre o Data Set e o banco de dados SQL Server. Dessa forma, é feita a atualização do Data Set.
 * Os métodos do Data Adapter são:
 * FILL – preenche os DataSet com os dados do banco de dados
 * UPDATE – atualiza o banco de dados com os dados do DataSet.
 * 
 * O SqlConnection é responsável pela conexão com o banco de dados SQL Server. No entanto, também precisamos da ConnectionString para realizar a conexão.
 * A ConnectionString contém informações de acesso ao banco de dados. Vejamos alguns exemplos de conexão:
 * SqlConnection conexão;
 * Conexão=new SqlConnection();
 * Conexao.ConnectionString =”ConnectionString”
 * Ou ainda:
 * SqlConnection conexao =new SqlConnection (ConnectionString)
 * Abrir a Conexão
 * conexao.Open();
 * Fecha a Conexão
 * conexao.Close();
 * 
 * O SqlCommand é responsável por executar um comando SQL. Para funcionar, ele requer uma Query SQL e um objeto Connection. Por exemplo:
 * SqlCommand cmd=new SqlCommand (“querySQL”, conexao);
 * Os métodos do SqlCommand são:
 * ExecuteReader	Retorna os dados da consulta (SqlDataReader). É usado com o comando SELECT.
 * ExecuteNonQuery	Não retorna dados. É usado com os comandos INSERT, UPDATE e DELETE.
 * ExecuteScalar	Retorna um único valor após uma consulta.
 * 
 */
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(); //Criar um objeto deconexão.
            con.ConnectionString = Properties.Settings.Default.CST;

            try
            {
                con.Open(); //Abrir uma conexão com o banco de dados.

                //Criando comando SQL
                SqlCommand cmm = new SqlCommand();
                cmm.CommandText = "select * from tb_clientes"; //Executar o comando SQL e processar o resultado.
                cmm.CommandType = CommandType.Text;
                cmm.Connection = con;                
                SqlDataReader dr;
                dr = cmm.ExecuteReader();

                //Carregar dados para dataGrid
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();


                con.Close(); // Fechar a conexão com o banco de dados
                MessageBox.Show("A conexão foi realizada com sucesso! ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Falha na conexao: (0)", ex.Message));
            }

        }
    }
}
