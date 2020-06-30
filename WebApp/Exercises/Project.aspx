<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Project.aspx.cs" Inherits="WebApp.Exercises.Project" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Project Page 01</h1>
<div class="row">
        <div class="col-md-4 text-right">
            <asp:Label ID="Label1" runat="server" Text="Select a School "></asp:Label>
        </div>
        <div class="col-md-4 text-left">
            <asp:DropDownList ID="List01" runat="server"></asp:DropDownList>&nbsp;&nbsp;
            <asp:Button ID="Fetch01" runat="server" Text="Fetch" 
                 CausesValidation="false" OnClick="Fetch_Click01"/>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4 text-right">
            <asp:Label ID="Label2" runat="server" Text="Select a Program "></asp:Label>
        </div>
        <div class="col-md-4 text-left">
            <asp:DropDownList ID="List02" runat="server"></asp:DropDownList>&nbsp;&nbsp;
            <asp:Button ID="Fetch02" runat="server" Text="Fetch" 
                 CausesValidation="false" OnClick="Fetch_Click02"/>
        </div>
    </div>
    <div>
        <br /><br />
        <asp:Label ID="MessageLabel" runat="server" ></asp:Label>
    </div>
</asp:Content>