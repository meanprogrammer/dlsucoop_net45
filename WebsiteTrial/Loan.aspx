<%@ Page Title="" Language="C#" MasterPageFile="~/Account.Master" AutoEventWireup="True" CodeBehind="Loan.aspx.cs" Inherits="WebsiteTrial.Loan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="css/jquery-ui-1.9.2.custom.min.css" rel="stylesheet" type="text/css" />
    <script src="js/modal/jquery-1.8.3.js" type="text/javascript"></script>
    <script src="js/modal/jquery-ui-1.9.2.custom.min.js" type="text/javascript"></script>
    <style type="text/css">
        .style6 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel runat="server" id="mainupdatepanel">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12">
                    <div class="alert alert-info">
                            The amount that will show on allowed amount will be filtered to the amount you are only eligible based on you share capital.</div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <asp:CustomValidator ID="CustomValidator1" OnServerValidate="ValidateLoanAmount" runat="server" ErrorMessage="CustomValidator" CssClass="validation-message"></asp:CustomValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <label>Type of Loan</label><strong style="color:#FF0000;"> *</strong>
                    <asp:DropDownList ID="DDType" runat="server" AppendDataBoundItems="True" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="DDType_SelectedIndexChanged">
                            <asp:ListItem Text="--SELECT--" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="* select type of loan." ControlToValidate="DDType" CssClass="validation-message"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6">
                    <label>Share Capital</label>
                    <asp:TextBox ID="ShareCapitalTextBox" ReadOnly="true" CssClass="form-control input-md" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <label>Allowed amount</label><strong style="color:#FF0000;"> *</strong>
                    <asp:DropDownList ID="AllowedAmountDropDownList" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="AllowedAmountDropDownList_SelectedIndexChanged">
                        <asp:ListItem Value="" Text="--SELECT--"></asp:ListItem>
                    </asp:DropDownList>

                </div>
                <div class="col-md-6">
                    <label visible="false" runat="server" id="amtlabel" clientidmode="Static">Amount<strong style="color:#FF0000;"> *</strong></label>
                    <asp:TextBox ID="tbAmount" runat="server" placeholder="REQUIRED - Amount of loan." CssClass="form-control input-md"
                             Visible="False"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <label>Reason</label><strong style="color:#FF0000;"> *</strong>
                    <asp:TextBox ID="tbReason" runat="server" Height="137px" placeholder="REQUIRED - Reason for loan." class="form-control input-md" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="tbReason" Display="Dynamic"
                            ErrorMessage="* reason is required." ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6">
                    <label>Months to pay</label>
                    <asp:TextBox ID="MonthsToPayLabel" ReadOnly="true" CssClass="form-control input-md" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <label>Co-maker Employee # 1</label><strong style="color:#FF0000;"> *</strong>
                    <asp:DropDownList ID="Comaker1DropDownList" CssClass="form-control input-md" AppendDataBoundItems="true" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* select co-maker." ControlToValidate="Comaker1DropDownList" CssClass="validation-message" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6">
                    <label>Co-maker Employee # 2</label><strong style="color:#FF0000;"> *</strong>
                    <asp:DropDownList ID="Comaker2DropDownList" CssClass="form-control input-md" AppendDataBoundItems="true" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="* select co-maker." ControlToValidate="Comaker2DropDownList" CssClass="validation-message" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="Comaker1DropDownList" ControlToValidate="Comaker2DropDownList" CssClass="validation-message" ErrorMessage="* comaker cannot be same." Operator="NotEqual" Display="Dynamic"></asp:CompareValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <label>Processing Fee</label>
                    <asp:TextBox ID="ProcessingFeeTextBox" ReadOnly="true" CssClass="form-control input-md" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    &nbsp;
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-12">
                    <asp:Button ID="Button1" runat="server" Text="Submit Loan" CssClass="btn btn-success btn-md" OnClick="Button1_Click" />
                </div>
            </div>
            <!--
            <div runat="server" visible="false" clientidmode="Static" id="agreementModal">
                <div runat="server" visible="false" clientidmode="Static"  id="agreementContent" style="overflow-y: scroll; overflow: auto; height: 450px; width: 650px;">
                    The standard Lorem Ipsum passage, used since the 1500s


       
       
                </div>
            </div>
            -->

        <asp:Panel ID="Panel1" Visible="false" CssClass="agreement" runat="server">

                "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." Section 1.10.32 of "de Finibus Bonorum et Malorum", written by Cicero in 45 BC "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?" 1914 translation by H. Rackham "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system, and expound the actual teachings of the great explorer of the truth, the master-builder of human happiness. No one rejects, dislikes, or avoids pleasure itself, because it is pleasure, but because those who do not know how to pursue pleasure rationally encounter consequences that are extremely painful. Nor again is there anyone who loves or pursues or desires to obtain pain of itself, because it is pain, but because occasionally circumstances occur in which toil and pain can procure him some great pleasure. To take a trivial example, which of us ever undertakes laborious physical exercise, except to obtain some advantage from it? But who has any right to find fault with a man who chooses to enjoy a pleasure that has no annoying consequences, or one who avoids a pain that produces no resultant pleasure?" Section 1.10.33 of "de Finibus Bonorum et Malorum", written by Cicero in 45 BC "At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae. Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat." 1914 translation by H. Rackham "On the other hand, we denounce with righteous indignation and dislike men who are so beguiled and demoralized by the charms of pleasure of the moment, so blinded by desire, that they cannot foresee the pain and trouble that are bound to ensue; and equal blame belongs to those who fail in their duty through weakness of will, which is the same as saying through shrinking from toil and pain. These cases are perfectly simple and easy to distinguish. In a free hour, when our power of choice is untrammelled and when nothing prevents our being able to do what we like best, every pleasure is to be welcomed and every pain avoided. But in certain circumstances and owing to the claims of duty or the obligations of business it will frequently occur that pleasures have to be repudiated and annoyances accepted. The wise man therefore always holds in these matters to this principle of selection: he rejects pleasures to secure other greater pleasures, or else he endures pains to avoid worse pains."
            <br />
            <br />
            <div class="row">
                <div class="col-md-10">
                    <asp:Button ID="AcceptButton" ClientIDMode="Static" CssClass="btn btn-primary btn-block btn-md" runat="server" Text="Accept" OnClick="AcceptButton_Click" />
                </div>
                <div class="col-md-2">
                    <asp:Button ID="CancelButton" CssClass="btn btn-block btn-default btn-md" runat="server" Text="Button" OnClick="CancelButton_Click" />
                </div>
            </div>
            <br />
            <br />
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" Visible="false" CssClass="agreement-backround"></asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
