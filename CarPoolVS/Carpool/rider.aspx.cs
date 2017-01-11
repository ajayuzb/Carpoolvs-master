using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Carpool
{
    public partial class rider : System.Web.UI.Page
    {
   private SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=""C:\Users\r.k.pden\Documents\Visual Studio 2010\WebSites\WebSite2\App_Data\Database.mdf"";Integrated Security=True;User Instance=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadStores();
        }
    }
    protected void loadStores()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from RideDetails", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        int count = ds.Tables[0].Rows.Count;
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            gridView.DataSource = ds;
            gridView.DataBind();
        }
        else
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            gridView.DataSource = ds;
            gridView.DataBind();
            int columncount = gridView.Rows[0].Cells.Count;
            //lblmsg.Text = " No data found !!!";
        }
    }
    protected void gridView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gridView.EditIndex = e.NewEditIndex;
        loadStores();
    }
    protected void gridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string id = gridView.DataKeys[e.RowIndex].Values["Empid"].ToString();

        TextBox source = (TextBox)gridView.FooterRow.FindControl("txtSource");
        TextBox destination = (TextBox)gridView.FooterRow.FindControl("txtDestinatione");
        TextBox empid = (TextBox)gridView.FooterRow.FindControl("txtEmaployeeId");
        TextBox date = (TextBox)gridView.FooterRow.FindControl("txtDate");
        TextBox time = (TextBox)gridView.FooterRow.FindControl("txtTime");
        con.Open();

        SqlCommand cmd = new SqlCommand("update RideDetails set Source='" + source.Text + "', Destination='" + destination.Text + "', Date='" + date.Text + "', Time='" + time.Text + "', Empid='" + empid.Text + "' where id=" + id, con);
        cmd.ExecuteNonQuery();
        con.Close();
        lblmsg.BackColor = Color.Blue;
        lblmsg.ForeColor = Color.White;
        lblmsg.Text = "boooking Id " + id + "        Updated successfully........    ";
        gridView.EditIndex = -1;
        loadStores();
    }
    protected void gridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gridView.EditIndex = -1;
        loadStores();
    }
    protected void gridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = gridView.DataKeys[e.RowIndex].Values["id"].ToString();

        con.Open();
        SqlCommand cmd = new SqlCommand("delete from RideDetails where id=" + id, con);
        int result = cmd.ExecuteNonQuery();
        con.Close();
        if (result == 1)
        {
            loadStores();
            lblmsg.BackColor = Color.Red;
            lblmsg.ForeColor = Color.White;
            lblmsg.Text = "boooking Id " + id + "      Deleted successfully.......    ";
        }
    }
    protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string id = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "id"));
            Button lnkbtnresult = (Button)e.Row.FindControl("ButtonDelete");
            if (lnkbtnresult != null)
            {
                lnkbtnresult.Attributes.Add("onclick", "javascript:return deleteConfirm('" + id + "')");
            }
        }
    }
    protected void gridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("AddNew"))
        {
            TextBox insource = (TextBox)gridView.FooterRow.FindControl("txtInsterSource");
            TextBox indestination = (TextBox)gridView.FooterRow.FindControl("txtInsterDestinatione");
            TextBox inempid = (TextBox)gridView.FooterRow.FindControl("txtInsterEmaployeeId");
            TextBox indate = (TextBox)gridView.FooterRow.FindControl("txtInsterDate");
            TextBox intime = (TextBox)gridView.FooterRow.FindControl("txtInsterTime");
            
            con.Open();
            SqlCommand cmd =
                new SqlCommand(
                    "insert into RideDetails(Source,Destination,Date,Time,Empid) values('" +
                    insource.Text + "','" + indestination.Text + "','" + indate.Text + "','" + intime.Text + "','" + inempid.Text + "')", con);
            int result = cmd.ExecuteNonQuery();
            con.Close();
            if (result == 1)
            {
                loadStores();
                lblmsg.BackColor = Color.Green;
                lblmsg.ForeColor = Color.White;
                lblmsg.Text = "      Added successfully......    ";
            }
            else
            {
                lblmsg.BackColor = Color.Red;
                lblmsg.ForeColor = Color.White;
                lblmsg.Text = " Error while adding row.....";
            }
        }
    }
}