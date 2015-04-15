<%@ Page Title="" Language="C#" MasterPageFile="~/Administration.Master" AutoEventWireup="true" CodeBehind="LoanReport.aspx.cs" Inherits="WebsiteTrial.LoanReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-2">
            <label>User Type</label><br />
                <asp:CheckBox ID="EmployeeCheckBox" runat="server" Text="Employee" /><br />
                <asp:CheckBox ID="NonEmployeeCheckBox" runat="server" Text="Non-Employee" />
            </div>
        <div class="col-md-3">
            
            <label>Start Date</label>
            <asp:Calendar ID="StartDateCalendar" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                <NextPrevStyle VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor="#808080" />
                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                <SelectorStyle BackColor="#CCCCCC" />
                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                <WeekendDayStyle BackColor="#FFFFCC" />
            </asp:Calendar>
        </div>
        <div class="col-md-3">
            <label>End Date</label>
            <asp:Calendar ID="EndDateCalendar" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                <NextPrevStyle VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor="#808080" />
                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                <SelectorStyle BackColor="#CCCCCC" />
                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                <WeekendDayStyle BackColor="#FFFFCC" />
            </asp:Calendar>
        </div>
        <div class="col-md-3">
            &nbsp;
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-12">
            <asp:Button ID="SearchButton" runat="server" Text="Search" CssClass="btn btn-lg btn-primary" OnClick="SearchButton_Click" />
        </div>
        <br />
        <div class="row">
            <div class="col-md-12">

                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="8" ForeColor="#333333" CellSpacing="1" EmptyDataText="No results found.">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="TransactionID" HeaderText="ID" />
                        <asp:BoundField DataField="EmpNo" HeaderText="EmpNo" />
                        <asp:BoundField DataField="UserType" HeaderText="Type" />
                        <asp:BoundField DataField="Lastname" HeaderText="Lastname" />
                        <asp:BoundField DataField="Firstname" HeaderText="Firstname" />
                        <asp:BoundField DataField="MI" HeaderText="MI" />
                        <asp:BoundField DataField="DateFiled" HeaderText="DateFiled" />
                        <asp:BoundField DataField="LoanType" HeaderText="LoanType" />
                        <asp:BoundField DataField="LoanAmount" HeaderText="Amount" />
                        <asp:BoundField DataField="LoanBalance" HeaderText="Balance" />
                        <asp:BoundField DataField="LoanDueDate" HeaderText="Due Date" />
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
    </div>
</asp:Content>
