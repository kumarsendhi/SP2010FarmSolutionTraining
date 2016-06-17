<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VWP_MyRegistrationsUserControl.ascx.cs" Inherits="Training_WebParts.VWP_MyRegistrations.VWP_MyRegistrationsUserControl" %>

<script type="text/javascript">
    var dialogConfirmDelete;
    var openDialog;
    function showDialog() {
        var selectedId = document.getElementById('<%=lbClasses.ClientID %>').value;
        var divConfirmDelete = document.getElementById("confirmDelete");
        divConfirmDelete.style.display = "block";
        dialogConfirmDelete ={html: divConfirmDelete,title:'Confirm Registration Deletion', allowMaximize:true, showClose:true,width:400,height:150};
        openDialog = SP.UI.ModalDialog.showModalDialog(dialogConfirmDelete);
    }
    function deleteRegistration() {
        this.itemId = document.getElementById('<%=lbClasses.ClientID %>').value;
        var clientContext = new SP.ClientContext();
        var regList = clientContext.get_web().get_lists().getByTitle('Registrations');
        this.reg = regList.getItemById(itemId);
        reg.deleteObject();
        clientContext.executeQueryAsync(Function.createDelegate(this,this.Success),Function.createDelegate(this,this.Failure));
    }
    function Success() {
        alert("Your registration with ID " + itemId + ' has been deleted.');
        hideDialog();
    }
    function Failure() {
        alert("Error: Your registration could not be deleted. Please ensure your have selected a registration."+'\n\n'+args.get_message());
        hideDialog();
    }
    function onCancel() {
        hideDialog();
    }
    function hideDialog() {
        openDialog.close();
        window.location.reload(true);
    }
</script>

<asp:ListBox ID="lbClasses" runat="server" SelectionMode="Single" AutoPostBack="false" Rows="5" Width="100%" ></asp:ListBox>
<input id="bDelete" type="button" runat="server" onclick="javascript:showDialog()" value="Delete Selected Registration" />

<!-- The following DIV defines our hidden modal dialgo -->
<div id="confirmDelete" style="display:none;">
    <table style="width:400px;" cellpadding="3" cellspacing="3">
        <tr>
            <td colspan="2">
                Are you sure?<br /><br />If so, please click the "Confirm" button below. If not, please click "Cancel" button below.
            </td>
            
        </tr>
        <tr><td>&nbsp;</td></tr>
        <tr>
            <td align="center" style="width:150px;">
                <input type="button" value="Confirm" style="width:125px;" onclick="deleteRegistration()" />
            </td>
             <td align="center" style="width:150px;">
                <input type="button" value="Cancel" style="width:125px;" onclick="onCancel()" />
            </td>
        </tr>
    </table>
</div>

