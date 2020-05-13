using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GestionEtudiants
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'studentsDataSet.students'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.studentsTableAdapter.Fill(this.studentsDataSet.students);

        }

        private void fillBy3ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.studentsTableAdapter.FillBy3(this.studentsDataSet.students);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection cn = new MySqlConnection("server = localhost;user id=root;database=students");
            cn.Open();
            MySqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from students where Name like '" + txtName.Text + "%'";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter a = new MySqlDataAdapter(cmd);
            DataTable dt;
            dt = new DataTable();
            a.Fill(dt);
            dataGridView1.DataSource = dt;
            cn.Close();
        }

        private void listClass_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }
    }
}
