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
    public partial class Exercise08CRUD : System.Web.UI.Page
    {
        static string pagenum = "";
        static string pid = "";
        static string add = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                pagenum = Request.QueryString["page"];
                pid = Request.QueryString["pid"];
                add = Request.QueryString["add"];
                BindTeamList();
                BindGuardianList();
                if (string.IsNullOrEmpty(pid))
                {
                    Response.Redirect("~/Default.aspx");
                }
                else if (add == "yes")
                {
                    UpdateButton.Enabled = false;
                    DeleteButton.Enabled = false;
                   
                }
                else
                {
                    AddButton.Enabled = false;
                    PlayerController sysmgr = new PlayerController();
                    Player info = null;
                    info = sysmgr.FindByPKID(int.Parse(pid));
                    if (info == null)
                    {
                        ShowMessage("Record is not in Database.", "alert alert-info");
                        Clear(sender, e);
                    }
                    else
                    {
                        PlayerID.Text = info.PlayerID.ToString(); //NOT NULL in Database
                        FirstName.Text = info.FirstName;
                        LastName.Text = info.LastName;//NOT NULL in Database
                        TeamList.SelectedValue = info.TeamID.ToString();
                        GuardianList.SelectedValue = info.GuardianID.ToString();
                        Age.Text = info.Age.ToString();
                        Gender.Text = info.Gender;
                        AlbertaHealthCareNumber.Text = info.AlbertaHealthCareNumber.ToString();
                        MedicalAlertDetails.Text = info.MedicalAlertDetails;                    
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
        protected void BindTeamList()
        {
            try
            {
                TeamController sysmgr = new TeamController();
                List<Team> info = null;
                info = sysmgr.List();
                info.Sort((x, y) => x.TeamName.CompareTo(y.TeamName));
                TeamList.DataSource = info;
                TeamList.DataTextField = nameof(Team.TeamName);
                TeamList.DataValueField = nameof(Team.TeamID);
                TeamList.DataBind();
                ListItem myitem = new ListItem();
                myitem.Value = "0";
                myitem.Text = "select...";
                TeamList.Items.Insert(0, myitem);
                

            }
            catch (Exception ex)
            {
                ShowMessage(GetInnerException(ex).ToString(), "alert alert-danger");
            }
        }
        protected void BindGuardianList()
        {
            try
            {
                GuardianController sysmgr = new GuardianController();
                List<Guardian> info = null;
                info = sysmgr.List();
                info.Sort((x, y) => x.GuardianName.CompareTo(y.GuardianName));
                GuardianList.DataSource = info;
                GuardianList.DataTextField = nameof(Guardian.GuardianName);
                GuardianList.DataValueField = nameof(Guardian.GuardianID);
                GuardianList.DataBind();
                ListItem myitem = new ListItem();
                myitem.Value = "0";
                myitem.Text = "select...";
                GuardianList.Items.Insert(0, myitem);                

            }
            catch (Exception ex)
            {
                ShowMessage(GetInnerException(ex).ToString(), "alert alert-danger");
            }
        }
        protected bool Validation(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(FirstName.Text))
            {
                ShowMessage("First Name is required", "alert alert-info");
                return false;
            }
            else if (string.IsNullOrEmpty(LastName.Text))
            {
                ShowMessage("Last Name is required", "alert alert-info");
                return false;
            }
            else if (GuardianList.SelectedValue == "0")
            {
                ShowMessage("Guardian is required", "alert alert-info");
                return false;
            }
            else if (TeamList.SelectedValue == "0")
            {
                ShowMessage("Team is required", "alert alert-info");
                return false;
            }
            else if (string.IsNullOrEmpty(Age.Text))
            {
                ShowMessage("Age is required", "alert alert-info");
                return false;
            }
            else if (int.Parse(Age.Text) < 6 || int.Parse(Age.Text) > 14)
            {
                ShowMessage("Age is required to be between 6 and 14", "alert alert-info");
                return false;
            }
            else if (string.IsNullOrEmpty(Gender.Text))
            {
                ShowMessage("Gender is required", "alert alert-info");
                return false;
            }
            else if (string.IsNullOrEmpty(AlbertaHealthCareNumber.Text))
            {
                ShowMessage("AlbertaHealthcareNumber is required", "alert alert-info");
                return false;
            }            
            
            string input1 = AlbertaHealthCareNumber.Text;
            Match match1 = Regex.Match(input1, @"^[1-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]$");
            if (!match1.Success)
            {
                ShowMessage("ID Number is 10 digits, first digit must start with 1-9 ", "alert alert-info");
                return false;
            }

            return true;
        }
        protected void Back_Click(object sender, EventArgs e)
        {
            if (pagenum == "08")
            {
                Response.Redirect("Exercise08.aspx");
            }
            else if (pagenum == "60")
            {
                Response.Redirect("60ASPControlsMultiRecDropToCustGridViewToSingleRec.aspx");
            }
            else if (pagenum == "70")
            {
                Response.Redirect("70ASPControlsMultiRecDropToDropToSingleRec.aspx");
            }
            else if (pagenum == "80")
            {
                Response.Redirect("80ASPControlsPartialStringSearchToCustGridViewToSingleRec.aspx");
            }
            else if (pagenum == "90")
            {
                Response.Redirect("90ASPControlsPartialStringSearchToDropToSingleRec.aspx");
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        protected void Clear(object sender, EventArgs e)
        {
            PlayerID.Text = "";
            FirstName.Text = "";
            LastName.Text = "";
            Age.Text = "";
            Gender.Text = "";
            AlbertaHealthCareNumber.Text = "";
            MedicalAlertDetails.Text = "";
            TeamList.ClearSelection();
            GuardianList.ClearSelection();
        }
        protected void Add_Click(object sender, EventArgs e)
        {
            var isValid = Validation(sender, e);
            if (isValid)
            {
                try
                {
                    PlayerController sysmgr = new PlayerController();
                    Player item = new Player();
                    //No ProductID here as the database will give a new one back when we add
                    item.FirstName = FirstName.Text.Trim(); //NOT NULL in Database
                    item.FirstName = FirstName.Text.Trim();
                    item.LastName = LastName.Text.Trim();
                    item.GuardianID = int.Parse(GuardianList.SelectedValue);
                    item.TeamID = int.Parse(TeamList.SelectedValue);
                    item.Gender = Gender.Text.Trim();
                    item.Age = int.Parse(Age.Text);
                    item.AlbertaHealthCareNumber = AlbertaHealthCareNumber.Text;
                    item.MedicalAlertDetails = MedicalAlertDetails.Text;
                    //if (SupplierList.SelectedValue == "0") //NULL in Database
                    //{
                    //    item.SupplierID = null;
                    //}
                    //else
                    //{
                    //    item.SupplierID = int.Parse(SupplierList.SelectedValue);
                    //}
                    ////CategoryID can be NULL in Database but NOT NULL when record is added in this CRUD page
                    //item.CategoryID = int.Parse(CategoryList.SelectedValue);
                    ////UnitPrice can be NULL in Database but NOT NULL when record is added in this CRUD page
                    //item.UnitPrice = decimal.Parse(UnitPrice.Text);
                    //item.Discontinued = Discontinued.Checked; //NOT NULL in Database
                    int newID = sysmgr.Add(item);
                    PlayerID.Text = newID.ToString();
                    
                    ShowMessage("Player has been ADDED", "alert alert-success");
                    AddButton.Enabled = false;
                    UpdateButton.Enabled = true;
                    DeleteButton.Enabled = true;
                    
                }
                catch (Exception ex)
                {
                    ShowMessage(GetInnerException(ex).ToString(), "alert alert-danger");
                }
            }
        }
        protected void Update_Click(object sender, EventArgs e)
        {
            var isValid = Validation(sender, e);
            if (isValid)
            {
                try
                {
                    PlayerController sysmgr = new PlayerController();
                    Player item = new Player();
                    item.PlayerID = int.Parse(PlayerID.Text);
                    item.FirstName = FirstName.Text.Trim();
                    item.LastName = LastName.Text.Trim();
                    item.GuardianID = int.Parse(GuardianList.SelectedValue);
                    item.TeamID = int.Parse(TeamList.SelectedValue);
                    item.Gender = Gender.Text.Trim();
                    item.Age = int.Parse(Age.Text);
                    item.AlbertaHealthCareNumber = AlbertaHealthCareNumber.Text;
                    item.MedicalAlertDetails = MedicalAlertDetails.Text;
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
                    PlayerController sysmgr = new PlayerController();
                    int rowsaffected = sysmgr.Delete(int.Parse(PlayerID.Text));
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
                    AddButton.Enabled = true;
                }
                catch (Exception ex)
                {
                    ShowMessage(GetInnerException(ex).ToString(), "alert alert-danger");
                }
            }
        }
    }
}