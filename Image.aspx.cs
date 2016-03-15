using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Image : System.Web.UI.Page
{
    DataClassesDataContext lnq_obj = new DataClassesDataContext();
    static string image_nm;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        fill_data();

    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        if (FileUpload1.PostedFile.FileName != null)
        {
            FileUpload1.SaveAs(Request.PhysicalApplicationPath + "/upload/" + FileUpload1.FileName);
        }
            lnq_obj.insert_Naushad(txt_name.Text, FileUpload1.FileName);
            lnq_obj.SubmitChanges();
            txt_name.Text = "";
            fill_data();
        
    }
    private void fill_data()
    {
        var id = (from a in lnq_obj.Naushads
                  select new
                  {
                      code=a.UserId,
                      name = a.Name,
                      img_name = "~/upload/" + a.Image
                  }).ToList();
        GridView1.DataSource = id;
        GridView1.DataBind();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int code = (Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex].Value.ToString()));
        ViewState["id"] = code;
        var id = (from a in lnq_obj.Naushads
                  where a.UserId == code 
                  select a).Single();
                
        txt_name.Text = id.Name;
        image_nm = id.Image;
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        lnq_obj.Delete_Naushad(Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()));
        lnq_obj.SubmitChanges();
        //Page.RegisterStartupScript("onload", "<script language='javascript'>alert('** Record Delete successfully **')</script> ");
        // ScriptManager.RegisterStartupScript(this, GetType(), "onload", "alert('Image Deleted Successfully')", true);
        fill_data();
    }
    protected void byn_update_Click(object sender, EventArgs e)
    {
        if (FileUpload1.PostedFile.FileName != null)
        {
            FileUpload1.SaveAs(Request.PhysicalApplicationPath + "/upload/" + FileUpload1.FileName);
            image_nm = FileUpload1.FileName;
        }
        lnq_obj.Update_Naushad(Convert.ToInt32(ViewState["id"].ToString()), txt_name.Text, FileUpload1.FileName);
        lnq_obj.SubmitChanges();
        fill_data();  
    }
}