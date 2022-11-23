using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WebApplication14
{
  
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("in", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = TextBox1.Text;
                cmd.Parameters.AddWithValue("@Name", SqlDbType.Int).Value = TextBox2.Text;
                cmd.Parameters.AddWithValue("@Surname", SqlDbType.Int).Value = TextBox3.Text;
                cmd.Parameters.AddWithValue("@Weight", SqlDbType.Int).Value = TextBox4.Text;
                cmd.Parameters.AddWithValue("@Height", SqlDbType.Int).Value = TextBox5.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                Label1.Text = "Data has been inserted";
            } catch (System.Data.SqlClient.SqlException i)
            {
                Label1.Text = "make sure id,weight,height are int ";

            }
        }
        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Patients.aspx");
        }
    }
}