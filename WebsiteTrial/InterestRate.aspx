<%@ Page Title="" Language="C#" MasterPageFile="~/Administration.Master" AutoEventWireup="true" CodeBehind="InterestRate.aspx.cs" Inherits="WebsiteTrial.InterestRate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <a href="AdminPage.aspx">Return to Main</a>
    <h1 class="no-padding">Interest Rate</h1>
    <div class="row">
        <div class="col-md-6">
            <label>
                Loan Type
            </label>
            <asp:DropDownList ID="LoanTypeDropDownList" AutoPostBack="true" AppendDataBoundItems="true" CssClass="form-control input-md" runat="server" DataTextField="LoanType1" DataValueField="RecordID" OnSelectedIndexChanged="LoanTypeDropDownList_SelectedIndexChanged">
                <asp:ListItem Value="">--SELECT--</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="LoanTypeDropDownList" CssClass="validation-message" Display="Dynamic" ErrorMessage="Select Loan type."></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-6">
            <label>Interest Rate</label>
            <asp:TextBox ID="InterestRateTextBox" runat="server" CssClass="form-control input-md"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="This is required." ControlToValidate="InterestRateTextBox" CssClass="validation-message" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="InterestRateTextBox" CssClass="validation-message" Display="Dynamic" ErrorMessage="Interest rate must be decimal." Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
        </div>
    </div>
     <br />
    <div class="row">
        <div class="col-md-12">
            <asp:Button ID="UpdateButton" runat="server" CssClass="btn btn-md btn-primary" Text="Update" OnClick="UpdateButton_Click" />
        </div>
    </div>
  <br />
    <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="GridView1" runat="server" CellPadding="8" ForeColor="#333333" AutoGenerateColumns="False">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="RecordID" HeaderText="Record ID" />
                    <asp:BoundField DataField="LoanTypeText" HeaderText="Loan Type" />
                    <asp:BoundField DataField="LoanAmount" HeaderText="Amount" />
                    <asp:BoundField DataField="RequiredShareCapital" HeaderText="Required ShareCapital" />
                    <asp:BoundField DataField="Interest" HeaderText="Interest" />
                    <asp:BoundField DataField="MonthsPayable" HeaderText="Months" />
                    <asp:BoundField DataField="ProcessingFee" HeaderText="Fee" />
                </Columns>
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
        </div>
    </div>
  
</asp:Content>
