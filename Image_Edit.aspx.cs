using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Image_Edit : System.Web.UI.Page
{
    DataClassesDataContext lnq_obj = new DataClassesDataContext();
    static string filename;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        fill_data();
    }
    private void fill_data()
    {
        var id = (from a in lnq_obj.temp_imags
                  where a.sirealno == Convert.ToInt32(Session["imgcode"].ToString())
                  select new
                  {
                      code = a.intglcode,
                      imgname = "~//upload//" + a.tem_img

                  }).ToList();
        GridView1.DataSource = id;
        GridView1.DataBind();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
         try
        {
            int code = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex].Values.ToString());
            ViewState["code"] = code;
            var id = (from a in lnq_obj.temp_imags
                      where a.intglcode == code
                      select a).Single();
            filename = id.tem_img;
            Label1.Text = filename.ToString();
        }
        catch (Exception ex)
        {

        }

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        lnq_obj.delete_temp_img(Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()));
        lnq_obj.SubmitChanges();
        fill_data();
        ScriptManager.RegisterStartupScript(this, GetType(), "onload", "alert('Image Deleted Successfully')", true);
    }
    protected void btn_update_Click(object sender, EventArgs e)
    {
        try
        {
            if (FileUpload1.PostedFile.FileName != "")
            {
                FileUpload1.SaveAs(Request.PhysicalApplicationPath + "/upload/" + FileUpload1.FileName);
                filename = FileUpload1.FileName;
            }

            lnq_obj.update_temp_img(Convert.ToInt32(ViewState["code"].ToString()), filename);
            lnq_obj.SubmitChanges();
            Label1.Text = "Update Successfully";
            fill_data();
            ScriptManager.RegisterStartupScript(this, GetType(), "onload", "alert('Image Update Successfully')", true);
        }
        catch (Exception ex)
        {

        }


    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        try
        {
            string imgname;
            if (FileUpload1.PostedFile.FileName != "")
            {
                FileUpload1.SaveAs(Request.PhysicalApplicationPath + "/upload/" + FileUpload1.FileName);
                imgname = FileUpload1.FileName;
            }
            else
            {
                imgname = "No_image_found.jpg";
            }
            lnq_obj.insert_temp_photo(imgname, Convert.ToInt32(Session["imgcode"].ToString()));
            lnq_obj.SubmitChanges();
            Label1.Text = "Insert Successfully";
            fill_data();
            ScriptManager.RegisterStartupScript(this, GetType(), "onload", "alert('Image Insert Successfully')", true);
        }
        catch (Exception ex)
        {

        }

    }
}