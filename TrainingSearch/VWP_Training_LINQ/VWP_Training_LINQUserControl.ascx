<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VWP_Training_LINQUserControl.ascx.cs" Inherits="TrainingSearch.VWP_Training_LINQ.VWP_Training_LINQUserControl" %>
Enter part of a Class title and click &quot;Find Classes.&quot; <br />
<br />
<asp:TextBox ID="tbQuery" runat="server" Width="219px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button ID="bSearch" runat="server" Text="Find Classes" 
    onclick="bSearch_Click"  />
&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lResultCount" runat="server" Text=""></asp:Label>
&nbsp;<p>

    <asp:ListBox ID="lbClasses" runat="server" Rows="20" Width="100%"></asp:ListBox>