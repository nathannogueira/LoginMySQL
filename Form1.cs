using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Net.Security;

namespace Login
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        //Criando conexão com o banco de dados MySql
            string server = "localhost";
            string database = "teste";
            string uid = "root";
            string password = "";
            string cs = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            var con = new MySqlConnection(cs);
                
            try
            {
                string sql = "select count(*) from users where userName='" + txtUsuario.Text + "' and userPass='" + txtSenha.Text + "'";
                MySqlCommand cmd = new MySqlCommand(sql, con);

                con.Open();

                object result = cmd.ExecuteScalar();

                if (Convert.ToInt16(result) > 0)
                {
                    MessageBox.Show("Login efetuado com sucesso!");
                }
                else
                {
                    MessageBox.Show("Usuário ou senha incorreto!");
                    txtUsuario.Text = "";
                    txtSenha.Text = "";
                }    
            }
            finally
            {
                con.Close();
            }
            
        }
    }
}