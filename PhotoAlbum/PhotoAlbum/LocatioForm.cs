using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace PhotoAlbum
{
    public partial class LocatioForm : Form
    {
        public string selectedID = "";
        public LocatioForm()
        {
            InitializeComponent();
            LoadLocationToGrid();
        }

        public void LoadLocationToGrid()
        {
            string str = "SELECT * FROM Location";
            OleDbDataAdapter dr = new
            OleDbDataAdapter(str, Properties.Settings.Default.Con);
            DataSet ds = new DataSet();
            dr.Fill(ds, "Location");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Location";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(Properties.Settings.Default.Con);
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Location([LocationTitle]) VALUES(?)";

            cmd.Connection = con;
            con.Open();
            cmd.Parameters.AddWithValue("@LocationTitle", textBox1.Text); /* ? values */

            cmd.ExecuteNonQuery();

            con.Close();
            LoadLocationToGrid();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = dataGridView1.CurrentCell.RowIndex;
            selectedID = dataGridView1.Rows[selectedIndex].Cells["ID"].Value.ToString(); /*gets the id of the selected row*/

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Del")
            {
                OleDbConnection myCon = new OleDbConnection(Properties.Settings.Default.Con);
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "DELETE FROM [Location] WHERE ID="
                + Convert.ToInt32(selectedID) + ""; /*converts to int because it is saved in the table in int */
                cmd.Connection = myCon;
                myCon.Open();
                int n = cmd.ExecuteNonQuery(); /* how many rows affected */
                myCon.Close();
                if (n > 0)
                {
                    MessageBox.Show("record in row :" + selectedIndex.ToString() + " is Deleted");

                }
                else
                    MessageBox.Show("DELETE failed");
                myCon.Close();

            }

            /*IF the Update button was selected in the gridview table*/
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Update")
            {

                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();

            }

            LoadLocationToGrid();
        }

        private void Update1_Click(object sender, EventArgs e)
        {
            OleDbConnection myCon = new OleDbConnection(Properties.Settings.Default.Con);
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;


            cmd.CommandText = @"UPDATE Location  SET LocationTitle = @LocationTitle  WHERE ID="
            + Convert.ToInt32(selectedID) + "";
            cmd.Parameters.AddWithValue("@LocationTitle", textBox1.Text);
            cmd.Connection = myCon;
            myCon.Open();
            int n = cmd.ExecuteNonQuery();
            myCon.Close();
            LoadLocationToGrid();
        }/*end of Delete and Update function using the delete button*/

    }
}