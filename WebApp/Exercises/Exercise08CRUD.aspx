<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Exercise08CRUD.aspx.cs" Inherits="WebApp.Exercises.Exercise08CRUD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Exercise 08 CRUD</h1>
    <div class="row">
        <div class="col-4 text-right">
                <asp:Label ID="Label1" runat="server" Text="PlayerID"
                     AssociatedControlID="PlayerID">
                </asp:Label>
        </div>
        <div class="col-8 text-left">
                <asp:TextBox ID="PlayerID" runat="server" ReadOnly="true">
                </asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-4 text-right">
                  <asp:Label ID="Label2" runat="server" Text="FirstName"
                     AssociatedControlID="FirstName"></asp:Label>
        </div>
        <div class="col-8 text-left">
                <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-4 text-right">
                  <asp:Label ID="Label3" runat="server" Text="LastName"
                     AssociatedControlID="LastName"></asp:Label>
        </div>
        <div class="col-8 text-left">
                <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-4 text-right">
                <asp:Label ID="Label4" runat="server" Text="GuardianList"
                     AssociatedControlID="GuardianList">
                </asp:Label>
        </div>
        <div class="col-8 text-left">
                <asp:DropDownList ID="GuardianList" runat="server" Width="300px">
                </asp:DropDownList> 
        </div>
    </div>
    <div class="row">
        <div class="col-4 text-right">
                <asp:Label ID="Label5" runat="server" Text="Team"
                     AssociatedControlID="TeamList">
                </asp:Label>
        </div>
        <div class="col-8 text-left">
                <asp:DropDownList ID="TeamList" runat="server" Width="300px">
                </asp:DropDownList> 
        </div>
    </div>    
    <div class="row">
        <div class="col-4 text-right">
                  <asp:Label ID="Label6" runat="server" Text="Age"
                     AssociatedControlID="Age">
                  </asp:Label>
        </div>
        <div class="col-8 text-left">
                <asp:TextBox ID="Age" runat="server"> 
                </asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-4 text-right">
                  <asp:Label ID="Label7" runat="server" Text="Gender"
                     AssociatedControlID="Gender"></asp:Label>
        </div>
        <div class="col-8 text-left">
                <asp:TextBox ID="Gender" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-4 text-right">
                  <asp:Label ID="Label8" runat="server" Text="AlbertaHealthCareNumber"
                     AssociatedControlID="AlbertaHealthCareNumber">
                  </asp:Label>
        </div>
        <div class="col-8 text-left">
                <asp:TextBox ID="AlbertaHealthCareNumber" runat="server"> 
                </asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-4 text-right">
                  <asp:Label ID="Label9" runat="server" Text="MedicalAlertDetails"
                     AssociatedControlID="MedicalAlertDetails"></asp:Label>
        </div>
        <div class="col-8 text-left">
                <asp:TextBox ID="MedicalAlertDetails" runat="server"></asp:TextBox>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-4"></div>
        <div class="col-8 text-left">
            <asp:Button ID="BackButton" runat="server" Text="Back" OnClick="Back_Click" />&nbsp;
            <asp:Button ID="AddButton" runat="server" OnClick="Add_Click" Text="Add"/>&nbsp;
            <asp:Button ID="UpdateButton" runat="server" OnClick="Update_Click" Text="Update"/>&nbsp;
            <asp:Button ID="DeleteButton" runat="server" OnClick="Delete_Click" Text="Delete"
              OnClientClick="return CallFunction();"/>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-4"></div>
        <div class="col-8">
            <label ID="MessageLabel" runat="server" />
        </div>
    </div>
    <script type="text/javascript">
        function CallFunction() {
            return confirm("Are you sure you wish to delete this record?");
       }
   </script>
</asp:Content>
