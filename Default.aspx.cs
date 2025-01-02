using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
using System.Configuration;


namespace Test_Inventory
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnlogin_Click(object sender, EventArgs e)
        {
           
            Users user = new Users();
            user.username = txtuser.Text;
            user.password = txtpassword.Text;

            if (ValidateUser(user.username, user.password))
            {
                Session["UserName"] = user.username;
                Response.Redirect("~/Forms/Dashboard.aspx");

                //var strSessionKey = Guid.NewGuid().ToString();
                //Session.Add("SESSION_KEY", strSessionKey);
                //Response.Cookies["sessionKey"].Value = strSessionKey;
                //Response.Cookies["sessionKey"].Expires = DateTime.Now.AddDays(1);

                //Session.Add("LogIn", txtuser.Text.ToLower());
                //Session.Add("FName", GetADName);
                //Session.Add("LName", GetADLastName);
            }
            else
            {

                lblMessage.Text = "Invalid username or password!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private bool ValidateUser(string username, string password)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
            string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                try
                {
                    conn.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    return count > 0;
                }
                catch (Exception ex)
                { 
                    lblMessage.Text = "Error: " + ex.Message;
                    return false;
                }
            }
        }

    }
}