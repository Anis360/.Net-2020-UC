using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GestionEtudiants
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void lblIntro_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection("server = localhost;user id=root;database=students");
                int i = 0;
                cn.Open();
                MySqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from users where Login ='" + txtLogin.Text + "' and Password ='" + txtPwd.Text + "';";
                cmd.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                if (i == 0)
                {
                    MessageBox.Show("Invaild login or password");
                }
                else
                {
                    this.Hide();
                    Form2 f2 = new Form2();
                    f2.ShowDialog(); 
                }
                cn.Close();

            }
            catch (OleDbException ex)
            {
                MessageBox.Show("Database connection error" + ex.Message);
            }


        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtLogin.Clear();
            txtPwd.Clear();
        }

        private void pwd_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
