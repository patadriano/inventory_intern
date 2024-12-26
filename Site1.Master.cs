using ITSG_Inventory.Class;
using ITSG_Inventory.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ITSG_Inventory
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        ClassInventory obj = new ClassInventory();
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoServerCaching();
            HttpContext.Current.Response.Cache.SetNoStore();

            Home.ServerClick += Navigation_Click;
            Accountability.ServerClick += Navigation_Click;
            RFT.ServerClick += Navigation_Click;
            Repair.ServerClick += Navigation_Click;
            History.ServerClick += Navigation_Click;

            NavActiveSelection();

            if (!Page.IsPostBack)
            {
                if (Session["MyDomain"] == null)
                {
                    Response.Redirect("~/Login.aspx");
                }
                GetUserInfo();
            }
        }
        protected void Navigation_Click(object sender, EventArgs e)
        {
            HtmlAnchor clickedItem = (HtmlAnchor)sender;
            string pageUrl = clickedItem.HRef;
            Response.Redirect(pageUrl);
        }
        protected void NavActiveSelection()
        {
            string currentPage = Path.GetFileName(Request.Url.AbsolutePath);

            switch (currentPage)
            {
                case "Home.aspx":
                    Home.Attributes["class"] = "nav-link py-3 border-bottom rounded-0 active";
                    Accountability.Attributes["class"] = "nav-link py-3 border-bottom rounded-0 ";
                    RFT.Attributes["class"] = "nav-link py-3 border-bottom rounded-0 ";
                    Repair.Attributes["class"] = "nav-link py-3 border-bottom rounded-0 ";
                    History.Attributes["class"] = "nav-link py-3 border-bottom rounded-0 ";
                    break;
                case "Accountability.aspx":
                    Accountability.Attributes["class"] = "nav-link py-3 border-bottom rounded-0 active";
                    Home.Attributes["class"] = "nav-link py-3 border-bottom rounded-0 ";
                    RFT.Attributes["class"] = "nav-link py-3 border-bottom rounded-0 ";
                    Repair.Attributes["class"] = "nav-link py-3 border-bottom rounded-0 ";
                    History.Attributes["class"] = "nav-link py-3 border-bottom rounded-0 ";
                    break;
                case "RFT.aspx":
                    RFT.Attributes["class"] = "nav-link py-3 border-bottom rounded-0 active";
                    Home.Attributes["class"] = "nav-link py-3 border-bottom rounded-0 ";
                    Accountability.Attributes["class"] = "nav-link py-3 border-bottom rounded-0 ";
                    Repair.Attributes["class"] = "nav-link py-3 border-bottom rounded-0 ";
                    History.Attributes["class"] = "nav-link py-3 border-bottom rounded-0 ";
                    break;
                case "Repair.aspx":
                    Repair.Attributes["class"] = "nav-link py-3 border-bottom rounded-0 active";
                    Home.Attributes["class"] = "nav-link py-3 border-bottom rounded-0 ";
                    Accountability.Attributes["class"] = "nav-link py-3 border-bottom rounded-0 ";
                    RFT.Attributes["class"] = "nav-link py-3 border-bottom rounded-0 ";
                    History.Attributes["class"] = "nav-link py-3 border-bottom rounded-0 ";
                    break;
                case "History.aspx":
                    History.Attributes["class"] = "nav-link py-3 border-bottom rounded-0 active";
                    Home.Attributes["class"] = "nav-link py-3 border-bottom rounded-0 ";
                    Accountability.Attributes["class"] = "nav-link py-3 border-bottom rounded-0 ";
                    RFT.Attributes["class"] = "nav-link py-3 border-bottom rounded-0 ";
                    Repair.Attributes["class"] = "nav-link py-3 border-bottom rounded-0 ";
                    break;
            }
        }
        protected void GetUserInfo()
        {
            if (Session["MyDomain"].ToString() != null || Session["MyDomain"].ToString() != "")
            {
                var lData = obj.GetUserInformation(Session["MyDomain"].ToString());
                lblfname.Text = lData[0].FullName.ToString();
                lblposition.Text = lData[0].Position.ToString();
                lbldept.Text = lData[0].Dept.ToString();
                byte[] ProfilePicture = lData[0].data;

                if (ProfilePicture != null && ProfilePicture.Length > 0)
                {
                    string base64Image = Convert.ToBase64String(ProfilePicture);
                    ImgProfilePicture.ImageUrl = "data:+'" + lData[0].data.ToString() + "';base64," + base64Image;
                }
                else
                {
                    ImgProfilePicture.ImageUrl = "~/Content1/Img/No_Image_Available.jpg";
                }
            }
        }
        public void ShowModalNotification(string Notification)
        {
            modalbody.InnerText = Notification;
        }
        protected void loguout_ServerClick(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Clear();

            Response.Redirect("~/Login.aspx");
        }
    }
}