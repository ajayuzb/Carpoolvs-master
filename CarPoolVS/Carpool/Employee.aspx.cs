using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;


namespace Carpool
{
    public partial class Employee : System.Web.UI.Page
    {
        private SqlConnection con = new SqlConnection("Data Source=poolride.sdf;Persist Security Info=False;");
        protected void Page_Load(object sender, EventArgs e)
        {
            loadStores();
        }
        protected void loadStores()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from EmployeeDetails", con);
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
            string Empid = gridView.DataKeys[e.RowIndex].Values["Empid"].ToString();

            TextBox EmployeeName = (TextBox)gridView.Rows[e.RowIndex].FindControl("txtEmployeeName");
            TextBox EmployeePhone = (TextBox)gridView.Rows[e.RowIndex].FindControl("txtEmployeePhone");
            TextBox EmployeeEmail = (TextBox)gridView.Rows[e.RowIndex].FindControl("txtEmployeeEmail");
            con.Open();
            SqlCommand cmd = new SqlCommand("update EmployeeDetails set EmployeeName='" + EmployeeName.Text + "', EmployeePhone='" + EmployeePhone.Text + "', EmployeeEmail='" + EmployeeEmail.Text + "' where Empid=" + Empid, con);
            cmd.ExecuteNonQuery();
            con.Close();
            lblmsg.BackColor = Color.Blue;
            lblmsg.ForeColor = Color.White;
            lblmsg.Text = "Employee Id " + Empid + "        Updated successfully........    ";
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
            string Empid = gridView.DataKeys[e.RowIndex].Values["Empid"].ToString();

            con.Open();
            SqlCommand cmd = new SqlCommand("delete from EmployeeDetails where Empid=" + Empid, con);
            int result = cmd.ExecuteNonQuery();
            con.Close();
            if (result == 1)
            {
                loadStores();
                lblmsg.BackColor = Color.Red;
                lblmsg.ForeColor = Color.White;
                lblmsg.Text = "Employee Id " + Empid + "      Deleted successfully.......    ";
            }
        }
        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string Empid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Empid"));
                Button lnkbtnresult = (Button)e.Row.FindControl("ButtonDelete");
                if (lnkbtnresult != null)
                {
                    lnkbtnresult.Attributes.Add("onclick", "javascript:return deleteConfirm('" + Empid + "')");
                }
            }
        }
        protected void gridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                TextBox inEmpName = (TextBox)gridView.FooterRow.FindControl("txtInsterEmpName");
                TextBox inEmpphone = (TextBox)gridView.FooterRow.FindControl("txtInsterEmpphone");
                TextBox inEmpEmail = (TextBox)gridView.FooterRow.FindControl("txtInsterEmpEmail");

                con.Open();
                SqlCommand cmd =
                    new SqlCommand(
                        "insert into EmployeeDetails(EmployeeName,EmployeePhone,EmployeeEmail) values('" +
                        inEmpName.Text + "','" + inEmpphone.Text + "','" + inEmpEmail.Text + "')", con);
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

}