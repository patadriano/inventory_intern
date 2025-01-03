using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Test_Inventory
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Url.AbsolutePath.Contains("Default"))
            {
                // Hide buttons when the user is on dashboard.aspx
                Button1.Visible = false;
                Button2.Visible = false;
                
            }
            else
            {
                // Make sure buttons are visible on other pages
                Button1.Visible = true;
                Button2.Visible = true;
                
            }
        }
        // Site.Master.cs
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("~/SomeOtherPage");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            // Find the content page (make sure it's the right content page)
            ContentPlaceHolder contentPlaceHolder = (ContentPlaceHolder)Page.Master.FindControl("MainContent");

            if (contentPlaceHolder != null)
            {
                // Find the control 'first' in the content page
                Control contentPageControl = contentPlaceHolder.FindControl("first");

                if (contentPageControl is WebControl webControl)
                {
                    webControl.Visible = true; // Set visibility to true
                }
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            // Find the content page (make sure it's the right content page)
            ContentPlaceHolder contentPlaceHolder = (ContentPlaceHolder)Page.Master.FindControl("MainContent");

            if (contentPlaceHolder != null)
            {
                // Find the control 'first' in the content page
                Control contentPageControl = contentPlaceHolder.FindControl("second");

                if (contentPageControl is WebControl webControl)
                {
                    webControl.Visible = true; // Set visibility to true
                }
            }
        }

    }
}