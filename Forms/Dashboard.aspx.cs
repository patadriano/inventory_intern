using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Reflection.Emit;

namespace Test_Inventory.Forms
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //lblusername.Text = Session["UserName"].ToString();
            if (!IsPostBack)

            {

                BindFileNames();

            }
        }
        protected void btnpop_Click(object sender, EventArgs e)
        {

            popupModal.Visible = true;

        }
        protected void btnClose_Click(object sender, EventArgs e)
        {
            popupModal.Visible = false; // Hide the modal
        }
        private void StartUpLoad()

        {

            //get the image file that was posted (binary format)

            byte[] theImage = new byte[FileUpload1.PostedFile.ContentLength];

            HttpPostedFile Image = FileUpload1.PostedFile;

            Image.InputStream.Read(theImage, 0, (int)FileUpload1.PostedFile.ContentLength);

            int length = theImage.Length; //get the length of the image

            string fileName = FileUpload1.FileName.ToString(); //get the file name of the posted image

            string type = FileUpload1.PostedFile.ContentType; //get the type of the posted image

            int size = FileUpload1.PostedFile.ContentLength; //get the size in bytes that

            if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.FileName != "")

            {

                //Call the method to execute Insertion of data to the Database

                ExecuteInsert(theImage, type, size, fileName, length);

                Response.Write("Save Successfully!");

            }

        }

        public string GetConnectionString()

        {

            //sets the connection string from your web config file "ConnString" is the name of your Connection String

            return System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

        }



        private void ExecuteInsert(byte[] Image, string Type, Int64 Size, string Name, int length)

        {

            SqlConnection conn = new SqlConnection(GetConnectionString());



            string sql = "INSERT INTO TblImages (Image, ImageType, ImageSize, ImageName) VALUES "

                        + " (@img,@type,@imgsize,@imgname)";

            try

            {

                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlParameter[] param = new SqlParameter[4];



                //param[0] = new SqlParameter("@id", SqlDbType.Int, 20);

                param[0] = new SqlParameter("@img", SqlDbType.Image, length);

                param[1] = new SqlParameter("@type", SqlDbType.NVarChar, 50);

                param[2] = new SqlParameter("@imgsize", SqlDbType.BigInt, 9999);

                param[3] = new SqlParameter("@imgname", SqlDbType.NVarChar, 50);



                param[0].Value = Image;

                param[1].Value = Type;

                param[2].Value = Size;

                param[3].Value = Name;



                for (int i = 0; i < param.Length; i++)

                {

                    cmd.Parameters.Add(param[i]);

                }



                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();

            }

            catch (System.Data.SqlClient.SqlException ex)

            {

                string msg = "Insert Error:";

                msg += ex.Message;

                throw new Exception(msg);



            }

            finally

            {

                conn.Close();

            }

        }

        

        protected void Button1_Click(object sender, EventArgs e)

        {

            StartUpLoad();

        }

        private void BindFileNames()

        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(GetConnectionString());



            try

            {

                connection.Open();

                string sqlStatement = "SELECT * FROM TblImages";

                SqlCommand sqlCmd = new SqlCommand(sqlStatement, connection);

                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);



                sqlDa.Fill(dt);

                if (dt.Rows.Count > 0)

                {

                    DropDownList1.DataSource = dt;

                    DropDownList1.DataTextField = "ImageName"; // the items to be displayed in the list items

                    DropDownList1.DataValueField = "ImageID"; // the id of the items displayed

                    DropDownList1.DataBind();

                }



            }

            catch (System.Data.SqlClient.SqlException ex)

            {

                string msg = "Fetch Error:";

                msg += ex.Message;

                throw new Exception(msg);

            }

            finally

            {

                connection.Close();

            }

        }
        private void GetImageInfo(string id)

        {

            SqlConnection connection = new SqlConnection(GetConnectionString());

            string sql = "SELECT * FROM TblImages WHERE ImageID = @id";



            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", id);

            connection.Open();



            SqlDataReader reader = cmd.ExecuteReader();

            reader.Read();



            //Get Image Information

            Label1.Text = reader["ImageName"].ToString();

            Label2.Text = reader["ImageType"].ToString();

            Label3.Text = reader["ImageSize"].ToString() + " (bytes)";



            reader.Close();

            connection.Close();

        }



        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)

        {

            if (DropDownList1.SelectedIndex > 0)

            {

                //Set the ImageUrl to the path of the handler with the querystring value

                Image1.ImageUrl = "Handler1.ashx?id=" + DropDownList1.SelectedItem.Value;

                //call the method to get the image information and display it in Label Control

                GetImageInfo(DropDownList1.SelectedItem.Value);
                Up.Update();

            }

        }






    }
}