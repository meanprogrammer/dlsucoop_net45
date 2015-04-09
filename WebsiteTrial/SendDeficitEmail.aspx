<%@ Page Title="" Language="C#" MasterPageFile="~/Administration.Master" AutoEventWireup="true" CodeBehind="SendDeficitEmail.aspx.cs" Inherits="WebsiteTrial.SendDeficitEmail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title></title>
    <link href="css/jquery-ui-1.9.2.custom.min.css" rel="stylesheet" type="text/css" />
    <script src="js/modal/jquery-1.8.3.js" type="text/javascript"></script>
    <script src="js/modal/jquery-ui-1.9.2.custom.min.js" type="text/javascript"></script>
    <script>
        $(document).ready(function () {
            $('#AsOfDateTextBox').datepicker({ dateFormat: "mm/dd/yy" });
            $('#DeadlineTextBox').datepicker();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <a href="AdminPage.aspx">Return to Main</a>
    <h1 class="no-padding">Send Deficit Email</h1>
    <div class="row">
        <div class="col-md-11">
            <label>Select User</label>
            <asp:DropDownList ID="UserDropDownList" class="form-control" runat="server">
            </asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-md-11">
            <label>Amount in Words</label>
            <asp:TextBox ID="AmountWordsTextBox" CssClass="form-control input-md" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-11">
            <label>Amount</label>
            <asp:TextBox ID="AmountTextBox" CssClass="form-control input-md" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-11">
            <label>Deduction For</label>
            <asp:TextBox ID="DeductionForTextbox" CssClass="form-control input-md" runat="server"></asp:TextBox>

        </div>
        <div class="col-md-1">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                ControlToValidate="DeductionForTextbox" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-md-11">
            <label>As Of Date</label>
            <asp:TextBox ID="AsOfDateTextBox" CssClass="form-control input-md" runat="server" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div class="col-md-1">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                ControlToValidate="AsOfDateTextBox" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-md-11">
            <label>Deadline</label>
            <asp:TextBox ID="DeadlineTextBox" CssClass="form-control input-md" runat="server" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div class="col-md-1">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                ControlToValidate="DeadlineTextBox" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <asp:Button ID="PreviewButton" runat="server" class="btn btn-success btn-size" Text="Preview"
        OnClick="PreviewButton_Click" />
    &nbsp;<asp:Button ID="SendButton" runat="server" class="btn btn-success btn-size" OnClick="SendButton_Click"
        Text="Send" />
    <br />
    <br />
    <div style="width: 600px;">
        <asp:Literal ID="PreviewLiteral" runat="server"></asp:Literal>
    </div>
    <br />
    

</asp:Content>
