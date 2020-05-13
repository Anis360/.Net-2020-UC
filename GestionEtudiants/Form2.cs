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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtID.Text != "" && listNewClass.Text != "")
            {
                MySqlConnection cn = new MySqlConnection("server = localhost;user id=root;database=students");
                cn.Open();
                MySqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into students values ('" + txtID.Text + "', '" + txtName.Text + "', '" + listNewClass.Text + "');";
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Record inserted successfully");
                //dataGridView1.Update();
                //dataGridView1.Refresh();
                this.Hide();
                Form2 f2 = new Form2();
                f2.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please provide all the details!");
            }

            // txtID.Clear();
            // txtName.Clear();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'studentsDataSet.students'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.studentsTableAdapter.Fill(this.studentsDataSet.students);

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.studentsTableAdapter.FillBy(this.studentsDataSet.students);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                string name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                MySqlConnection cn = new MySqlConnection("server = localhost;user id=root;database=students");
                cn.Open();
                MySqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from students where Name = '" + name +"'";
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Record deleted successfully");
                //dataGridView1.Update();
                //dataGridView1.Refresh();
                this.Hide();
                Form2 f2 = new Form2();
                f2.ShowDialog();
            }

        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.studentsTableAdapter.FillBy1(this.studentsDataSet.students);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillBy2ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.studentsTableAdapter.FillBy2(this.studentsDataSet.students);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }


    }
}
