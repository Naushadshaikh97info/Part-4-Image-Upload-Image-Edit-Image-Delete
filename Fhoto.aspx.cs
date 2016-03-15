using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Fhoto : System.Web.UI.Page
{
    DataClassesDataContext lnq_obj = new DataClassesDataContext();
    static string fhoto_nm;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        fill_fhoto();   
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        if (FileUpload1.FileName != null)
        {
            FileUpload1.SaveAs(Request.PhysicalApplicationPath + "/upload/" + FileUpload1.FileName);
            fhoto_nm = FileUpload1.FileName;
        }
        lnq_obj.insert_fhoto(fhoto_nm);
        lnq_obj.SubmitChanges();
        fill_fhoto();
    }
    private void fill_fhoto()
    {
        var id = (from a in lnq_obj.fhoto_msts
                  select new
                  {
                      code=a.intglcode,
                      fhoto_nm = "~/upload/" + a.fhoto
                  }).ToList();
        GridView1.DataSource = id;
        GridView1.DataBind();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int code = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex].Value.ToString());
        ViewState["id"] = code;
        var id = (from a in lnq_obj.fhoto_msts
                  where a.intglcode == code
                  select a).Single();

        fhoto_nm = id.fhoto;
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        lnq_obj.delete_fhoto(Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()));
        lnq_obj.SubmitChanges();
        fill_fhoto();

    }
    protected void btn_update_Click1(object sender, EventArgs e)
    {

        if (FileUpload1.FileName != "")
        {
            FileUpload1.SaveAs(Request.PhysicalApplicationPath + "/upload/" + FileUpload1.FileName);
            fhoto_nm = FileUpload1.FileName;
        }
        lnq_obj.update_fhoto(Convert.ToInt32(ViewState["id"]), fhoto_nm);
        lnq_obj.SubmitChanges();
        fill_fhoto();
        Response.Redirect("Fhoto.aspx");
    }
    //protected void lnk_img_edit_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        LinkButton lnk = (LinkButton)sender;
    //        int code = Convert.ToInt32(lnk.CommandArgument.ToString());
    //        Session["imgcode"] = code;
    //        Response.Redirect("Image.aspx.aspx");
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //}
}