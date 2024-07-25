using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class index : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=REEBSLOKI\\SQLEXPRESS;Initial Catalog=ProgrammingDB;Integrated Security=True");
    SqlCommand cmd = new SqlCommand();
    SqlDataReader dread;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)

        {
            cmd = new SqlCommand("select empno from employee",con);
            con.Open();
            dread = cmd.ExecuteReader();
            DropDownList1.Items.Clear();

            while(dread.Read())
            {
                DropDownList1.Items.Add(dread.GetValue(0).ToString());
            }
            con.Close();
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
            string cmdstr;
        cmd.Connection = con;
        cmdstr = "Insert into employee(name,address,title) values('{0}','{1}','{2}')";
        cmdstr = cmdstr.Replace("{0}", txtname.Text);
        cmdstr = cmdstr.Replace("{1}", txtaddress.Text);
        cmdstr = cmdstr.Replace("{2}", txttitle.Text);
        cmd.CommandText = cmdstr;
        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
            string msg = "alert(\"Employee Registered Successfully\")";
            ScriptManager.RegisterStartupScript(this, GetType(), "Serverscript", msg, true);
            txtname.Text = "";
            txtaddress.Text ="";
            txttitle.Text ="";
        }

        catch (SqlException ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            con.Close();
        }
    }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
{

    Button1.Enabled = false;
    string empno = DropDownList1.Text;
    cmd = new SqlCommand("select * from employee where empno = '" + DropDownList1.Text + "'", con);
    try
    {
        con.Open();
        dread = cmd.ExecuteReader();
        while (dread.Read())
        {
            txtname.Text = dread.GetValue(1).ToString();
            txtaddress.Text = dread.GetValue(2).ToString();
            txttitle.Text = dread.GetValue(3).ToString();

        }
    }
    catch (SqlException ex)
    {
        Response.Write(ex.Message);
        
    }
    finally
    {
        con.Close();
    }

}
    protected void Button2_Click(object sender, EventArgs e)
    {
        string cmdstr;
        cmd.Connection = con;
        cmdstr = "Update employee set name = '{1}',address='{2}',title='{3}' where  empno = '{0}'";
        cmdstr = cmdstr.Replace("{1}", txtname.Text);
        cmdstr = cmdstr.Replace("{2}", txtaddress.Text);
        cmdstr = cmdstr.Replace("{3}", txttitle.Text);
        cmdstr = cmdstr.Replace("{0}", DropDownList1.Text);
        cmd.CommandText = cmdstr;
        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
            string msg = "alert(\"Employee  Updated\")";
            ScriptManager.RegisterStartupScript(this, GetType(), "Serverscript", msg, true);
            txtname.Text = "";
            txtaddress.Text = "";
            txttitle.Text = "";

            DropDownList1.SelectedIndex = -1;
            Button1.Enabled = true;

        }

        catch (SqlException ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            con.Close();
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string cmdstr;
        cmd.Connection = con;
        cmdstr = "Delete from employee  where  empno = '{0}'";
        cmdstr = cmdstr.Replace("{0}", DropDownList1.Text);
        cmd.CommandText = cmdstr;
        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
            string msg = "alert(\"Employee Deleted\")";
            ScriptManager.RegisterStartupScript(this, GetType(), "Serverscript", msg, true);
            txtname.Text = "";
            txtaddress.Text = "";
            txttitle.Text = "";

            DropDownList1.SelectedIndex = -1;
            Button1.Enabled = true;
        }

        catch (SqlException ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            con.Close();
        }
    }
}
