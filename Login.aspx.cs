using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ITSG_Inventory.Class;

namespace ITSG_Inventory
{
    public partial class Login : System.Web.UI.Page
    {
        private string GetADName;
        private string GetADLastName;

        ClassInventory obj = new ClassInventory();
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoServerCaching();
            HttpContext.Current.Response.Cache.SetNoStore();

            Session.RemoveAll();
            Session.Clear();
        }
        protected void btnlogin_Click(object sender, EventArgs e)
        {
            if (validateforms() == true)
            {
                Session.RemoveAll();
                Session.Clear();

                if (AuthenticateWORDTEXTDomain(USERID: txtuser.Text.ToLower(), Password: txtpass.Text))
                {
                    Session["MyDomain"] = txtuser.Text;

                    var strSessionKey = Guid.NewGuid().ToString();
                    Session.Add("SESSION_KEY", strSessionKey);
                    Response.Cookies["sessionKey"].Value = strSessionKey;
                    Response.Cookies["sessionKey"].Expires = DateTime.Now.AddDays(1);

                    Session.Add("LogIn", txtuser.Text.ToLower());
                    Session.Add("FName", GetADName);
                    Session.Add("LName", GetADLastName);

                    Response.Redirect("~/Forms/Home.aspx?id=" + strSessionKey.ToString(), true);


                    //clsService checker = new clsService();
                    //Boolean chk;
                    //chk = checker.Chck(txtuser.Text);
                    //if (chk == true)
                    //{
                    //    Response.Redirect("~/Service.aspx?id=" + strSessionKey.ToString(), true);
                    //}
                    //else
                    //{
                    //    lblerror.Visible = true;
                    //    lblerror.Text = "Invalid Credentials!";
                    //    txtuser.Text = "";
                    //    txtpass.Text = "";
                    //}
                }
            }
            else
            {
                lblerror.Visible = true;
                lblerror.Text = "Invalid Credentials!";
            }
        }
        public bool AuthenticateWORDTEXTDomain(string USERID, string Password)
        {
            string Status;
            string DOMAIN_NAME = "wordtext.ph";
            DirectoryEntry dirEntry;

            DirectorySearcher dirSearcher;
            Status = "Validating User Account";
            try
            {
                dirEntry = new DirectoryEntry("LDAP://" + DOMAIN_NAME, USERID, Password);
                dirSearcher = new System.DirectoryServices.DirectorySearcher(dirEntry)
                {
                    Filter = "(samAccountName=" + USERID + ")"
                };
                // The PropertiesToLoad.Add method will be useful when retrieving only the selected properties. 
                // In this example I have retrieved only GivenName and sn 
                // There are many other properties are available 
                dirSearcher.PropertiesToLoad.Add("GivenName");// Users First Name           
                dirSearcher.PropertiesToLoad.Add("sn");// Users last name 
                SearchResult sr = dirSearcher.FindOne();
                if (sr == null)
                {
                    // Dim Status As String
                    Status = "Invalid UserID";
                    return false;
                }
                // Retrieve the user's First Name, e-mail and Last Name and assigns them to text boxes 
                DirectoryEntry de = sr.GetDirectoryEntry();

                if (de.Properties["GivenName"].Value != null/* TODO Change to default(_) if this is not a reference type */ )
                    GetADName = de.Properties["GivenName"].Value.ToString();
                if (de.Properties["sn"].Value != null/* TODO Change to default(_) if this is not a reference type */ )
                    GetADLastName = de.Properties["sn"].Value.ToString();

                //strGetDomainName = "wordtext";

                return true;
            }
            // Valid user 
            catch (Exception e)
            {
                return false;
            }
        }
        public bool validateforms()
        {
            bool ValidateField = false;
            if (txtuser.Text == "")
            {
                txtuser.Focus();
                return ValidateField;
            }
            else if (txtpass.Text == "")
            {
                txtpass.Focus();
                return ValidateField;
            }

            ValidateField = true;

            return ValidateField;
        }
    }
}