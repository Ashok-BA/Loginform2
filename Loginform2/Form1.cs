using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Loginform2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();                       
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {


                string cs = "Server=ASHOK\\SQLEXPRESS; Database=adonet; Integrated Security=true";
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into logininfo values('" + txtusername.Text + "','" + txtpassword.Text + "')", con);
                cmd.ExecuteNonQuery();
                txtusername.Clear();
                txtpassword.Text = "";
                lbldisplay.Text = "Inserted Successfully";
                lbldisplay.ForeColor = System.Drawing.Color.Green;
                con.Close();
            }
            catch(Exception)
            {
                lbldisplay.Text = "Please valid Input Details";
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string cs = "Server=ASHOK\\SQLEXPRESS; Initial Catalog=adonet; Trusted_Connection=true";
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlCommand cmd = new SqlCommand("update logininfo set password='" + txtpassword.Text + "'where username='" + txtusername.Text + "'", con);
                cmd.ExecuteNonQuery();
                txtusername.Clear();
                txtpassword.Text = "";
                lbldisplay.Text = "Updated Successfully";
                lbldisplay.ForeColor = System.Drawing.Color.Blue;
                con.Close();
            }
            catch(Exception)
            {
                lbldisplay.Text = "Please Enter valid updatable Details";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string cs = "Server=ASHOK\\SQLEXPRESS; Database=adonet; Integrated Security=true";
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                //SqlCommand cmd = new SqlCommand("delete from logininfo", con);
                SqlCommand cmd = new SqlCommand("delete from logininfo where username='" + txtusername.Text + "'", con);
                cmd.ExecuteNonQuery();
                txtusername.Clear();
                txtpassword.Text = "";
                lbldisplay.Text = "Deleted  Successfully";
                lbldisplay.ForeColor = System.Drawing.Color.Red;
                con.Close();
            }
            catch(Exception)
            {
                lbldisplay.Text = "Delation of Data is Invalid";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string cs = "Server=ASHOK\\SQLEXPRESS; Initial Catalog=adonet; Integrated Security=true";
                SqlConnection con = new SqlConnection(cs);
                SqlDataAdapter da = new SqlDataAdapter("select * from logininfo", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                lbldisplay.Text = "Displaying Data in GridView";
                lbldisplay.ForeColor = System.Drawing.Color.Purple;
                datagridview1.DataSource = dt;
            }
            catch(Exception)
            {
                lbldisplay.Text = "Enter proper valid Button";
            }
        }
    }
}
