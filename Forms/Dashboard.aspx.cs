using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Test_Inventory.Forms
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //lblusername.Text = Session["UserName"].ToString();
        }
        protected void btnpop_Click(object sender, EventArgs e)
        {

            //HtmlGenericControl popupModal = (HtmlGenericControl)FindControl("popupModal");

            //// Show the modal by setting its display style to "block"
            //if (popupModal != null)
            //{
            //    popupModal.Style["display"] = "block";
            //} 
            popupModal.Visible = true;

        }
        protected void btnClose_Click(object sender, EventArgs e)
        {
            popupModal.Visible = false; // Hide the modal
        }
    }
}