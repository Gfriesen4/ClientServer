using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBSystem.BLL;
using DBSystem.ENTITIES;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core;
using System.Text.RegularExpressions;


namespace WebApp.Exercises
{
    public partial class ProjectCRUD : System.Web.UI.Page
    {
        static string pagenum = "";
        static string pid = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                pagenum = Request.QueryString["page"];
                pid = Request.QueryString["pid"];
                BindSchoolsList();
                if (string.IsNullOrEmpty(pid))
                {
                    Response.Redirect("~/Default.aspx");
                }                
                else
                {
                    
                    ProgramsController sysmgr = new ProgramsController();
                    Programs info = null;
                    info = sysmgr.FindByPKID(int.Parse(pid));
                    if (info == null)
                    {
                        ShowMessage("Record is not in Database.", "alert alert-info");
                        Clear(sender, e);
                    }
                    else
                    {
                        ProgramID.Text = info.ProgramID.ToString();
                        ProgramName.Text = info.ProgramName;
                        DiplomaName.Text = info.DiplomaName; //NULL in Database
                        SchoolCode.SelectedValue = info.SchoolCode;
                        Tuition.Text = string.Format("{0:0.00}", info.Tuition.ToString());
                        InternationalTuition.Text = string.Format("{0:0.00}", info.InternationalTuition.ToString());

                    }
                }
            }
        }
        protected Exception GetInnerException(Exception ex)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }
        protected void ShowMessage(string message, string cssclass)
        {
            MessageLabel.Attributes.Add("class", cssclass);
            MessageLabel.InnerHtml = message;
        }
        protected void BindSchoolsList()
        {
            try
            {
                SchoolsController sysmgr = new SchoolsController();
                List<Schools> info = null;
                info = sysmgr.List();
                info.Sort((x, y) => x.SchoolName.CompareTo(y.SchoolName));
                SchoolCode.DataSource = info;
                SchoolCode.DataTextField = nameof(Schools.SchoolName);
                SchoolCode.DataValueField = nameof(Schools.SchoolCode);
                SchoolCode.DataBind();
                ListItem myitem = new ListItem();
                myitem.Value = "0";
                myitem.Text = "select...";
                SchoolCode.Items.Insert(0, myitem);


            }
            catch (Exception ex)
            {
                ShowMessage(GetInnerException(ex).ToString(), "alert alert-danger");
            }
        }
        protected bool Validation(object sender, EventArgs e)
        {
            double tuition = 0;
            double internationalTuition = 0;
            if (string.IsNullOrEmpty(ProgramName.Text))
            {
                ShowMessage("Program Name is required", "alert alert-info");
                return false;
            }
            else if (SchoolCode.SelectedValue == "0")
            {
                ShowMessage("School is required", "alert alert-info");
                return false;
            }
            else if (string.IsNullOrEmpty(Tuition.Text))
            {
                ShowMessage("Tuition is required", "alert alert-info");
                return false;
            }
            else if (double.TryParse(Tuition.Text, out tuition))
            {
                if (tuition < 0.00 || tuition > 10000.00)
                {
                    ShowMessage("Tuition must be between $0.00 and $10,000.00", "alert alert-info");
                    return false;
                }
            }
            else if (double.TryParse(InternationalTuition.Text, out internationalTuition))
            {
                if (internationalTuition < 0.00 || internationalTuition > 20000.00)
                {
                    ShowMessage("Tuition must be between $0.00 and $20,000.00", "alert alert-info");
                    return false;
                }
            }
            else
            {
                ShowMessage("Tuition must be a real number", "alert alert-info");
                return false;
            }
            return true;
        }
        protected void Back_Click(object sender, EventArgs e)
        {
            if (pagenum == "P1")
            {
                Response.Redirect("Project.aspx");
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        protected void Clear(object sender, EventArgs e)
        {
            ProgramID.Text = "";
            ProgramName.Text = "";
            DiplomaName.Text = "";
            SchoolCode.ClearSelection();
            Tuition.Text = "";
            InternationalTuition.Text = "";

        }
        //protected void Add_Click(object sender, EventArgs e)
        //{
        //    var isValid = Validation(sender, e);
        //    if (isValid)
        //    {
        //        try
        //        {
        //            ProgramsController sysmgr = new ProgramsController();
        //            Programs item = new Programs();
        //            item.ProgramID = int.Parse(ProgramID.Text);
        //            item.ProgramName = ProgramName.Text.Trim();                    
        //            if (DiplomaName.Text.Trim() == "0") //NULL in Database
        //            {
        //                item.DiplomaName = null;
        //            }
        //            else
        //            {
        //                item.DiplomaName = DiplomaName.Text.Trim();
        //            }
        //            item.SchoolCode = SchoolCode.Text.Trim();
        //            item.Tuition = decimal.Parse(Tuition.Text);
        //            item.InternationalTuition = decimal.Parse(InternationalTuition.Text);
                    
        //            int newID = sysmgr.Add(item);
        //            ProgramID.Text = newID.ToString();

        //            ShowMessage("Program has been ADDED", "alert alert-success");
        //            AddButton.Enabled = false;
        //            UpdateButton.Enabled = true;
        //            DeleteButton.Enabled = true;

        //        }
        //        catch (Exception ex)
        //        {
        //            ShowMessage(GetInnerException(ex).ToString(), "alert alert-danger");
        //        }
        //    }
        //}
        protected void Update_Click(object sender, EventArgs e)
        {
            var isValid = Validation(sender, e);
            if (isValid)
            {
                try
                {
                    ProgramsController sysmgr = new ProgramsController();
                    Programs item = new Programs();
                    item.ProgramID = int.Parse(ProgramID.Text);
                    item.ProgramName = ProgramName.Text.Trim();
                    item.DiplomaName = DiplomaName.Text.Trim();
                    item.SchoolCode = SchoolCode.Text.Trim();
                    item.Tuition = decimal.Parse(Tuition.Text);
                    item.InternationalTuition = decimal.Parse(InternationalTuition.Text);
                    int rowsaffected = sysmgr.Update(item);
                    if (rowsaffected > 0)
                    {
                        ShowMessage("Record has been UPDATED", "alert alert-success");
                    }
                    else
                    {
                        ShowMessage("Record was not found", "alert alert-warning");
                    }
                }
                catch (Exception ex)
                {
                    ShowMessage(GetInnerException(ex).ToString(), "alert alert-danger");
                }
            }
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            var isValid = true;
            if (isValid)
            {
                try
                {
                    ProgramsController sysmgr = new ProgramsController();
                    int rowsaffected = sysmgr.Delete(int.Parse(ProgramID.Text));
                    if (rowsaffected > 0)
                    {
                        ShowMessage("Record has been DELETED", "alert alert-success");
                        Clear(sender, e);
                    }
                    else
                    {
                        ShowMessage("Record was not found", "alert alert-warning");
                    }
                    UpdateButton.Enabled = false;
                    DeleteButton.Enabled = false;
                }
                catch (Exception ex)
                {
                    ShowMessage(GetInnerException(ex).ToString(), "alert alert-danger");
                }
            }
        }
    }
}

