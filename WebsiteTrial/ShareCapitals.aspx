<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShareCapitals.aspx.cs" Inherits="WebsiteTrial.ShareCapitals" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="row">
        <div class="col-md-4">
            <label for="EmployeeDropDownList">Employee</label>
            <asp:DropDownList CssClass="form-control" ID="EmployeeDropDownList" runat="server"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" CssClass="validation-message"  runat="server" ErrorMessage="Employee is Required." ControlToValidate="EmployeeDropDownList"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-4">
            <label for="ShareCapitalTextBox">Share Capital Amount</label>
            <asp:TextBox ID="ShareCapitalTextBox" CssClass="form-control input-md" ClientIDMode="Static" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Share is required." ControlToValidate="ShareCapitalTextBox" CssClass="validation-message" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ShareCapitalTextBox" CssClass="validation-message" Display="Dynamic" ErrorMessage="Value must be money." Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
        </div>
        <div class="col-md-4">
            &nbsp;
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <asp:Button ID="SaveShareCapitalButton" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="SaveShareCapitalButton_Click" />
            <a href="AdminPage.aspx" class="btn btn-default btn-md">Return to Admin</a>
        </div>
        <div class="col-md-8">
            &nbsp;
        </div>
    </div>
    </form>
</body>
</html>
