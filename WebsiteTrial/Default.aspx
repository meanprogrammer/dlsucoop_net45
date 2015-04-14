<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="True" CodeBehind="Default.aspx.cs" Inherits="WebsiteTrial.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-6">
            <div id="carousel-example-captions" class="carousel slide" data-ride="carousel">
                <ol class="carousel-indicators">
                    <li data-target="#carousel-example-captions" data-slide-to="0" class="active"></li>
                    <li data-target="#carousel-example-captions" data-slide-to="1" class=""></li>
                    <li data-target="#carousel-example-captions" data-slide-to="2" class=""></li>
                </ol>
                <div class="carousel-inner" role="listbox">
                    <div class="item active">
                        <img src="images/imga.jpg" class="img-responsive" alt="" />
                    </div>
                    <div class="item">
                        <img src="images/imgb.jpg" class="img-responsive" alt="" />
                    </div>
                    <div class="item">
                        <img src="images/imgc.jpg" class="img-responsive" alt="" />
                    </div>
                    <div class="item">
                        <img src="images/imgd.jpg" class="img-responsive" alt="" />
                    </div>
                    <div class="item">
                        <img src="images/imge.jpg" class="img-responsive" alt="" />
                    </div>
                    <div class="item">
                        <img src="images/COOP/DSC02566.JPG" class="img-responsive" alt="" />
                    </div>
                    <div class="item">
                        <img src="images/COOP/DSC02567.JPG" class="img-responsive" alt="" />
                    </div>
                    <div class="item">
                        <img src="images/COOP/DSC02568.JPG" class="img-responsive" alt="" />
                    </div>
                    <div class="item">
                        <img src="images/COOP/DSC02570.JPG" class="img-responsive" alt="" />
                    </div>
                    <div class="item">
                        <img src="images/COOP/DSC02571.JPG" class="img-responsive" alt="" />
                    </div>
                    <div class="item">
                        <img src="images/COOP/DSC02572.JPG" class="img-responsive" alt="" />
                    </div>
                    <div class="item">
                        <img src="images/COOP/DSC02573.JPG" class="img-responsive" alt="" />
                    </div>
                    <div class="item">
                        <img src="images/COOP/DSC02574.JPG" class="img-responsive" alt="" />
                    </div>
                    <div class="item">
                        <img src="images/COOP/DSC02576.JPG" class="img-responsive" alt="" />
                    </div>
                    <div class="item">
                        <img src="images/COOP/DSC02577.JPG" class="img-responsive" alt="" />
                    </div>
                    <div class="item">
                        <img src="images/COOP/DSC02799.JPG" class="img-responsive" alt="" />
                    </div>
                    <div class="item">
                        <img src="images/COOP/DSC02800.JPG" class="img-responsive" alt="" />
                    </div>
                    <div class="item">
                        <img src="images/COOP/DSC02801.JPG" class="img-responsive" alt="" />
                    </div>
                    <div class="item">
                        <img src="images/COOP/DSC02802.JPG" class="img-responsive" alt="" />
                    </div>
                    <div class="item">
                        <img src="images/COOP/DSC02804.JPG" class="img-responsive" alt="" />
                    </div>
                    <div class="item">
                        <img src="images/COOP/DSC02805.JPG" class="img-responsive" alt="" />
                    </div>
                    <div class="item">
                        <img src="images/COOP/DSC02806.JPG" class="img-responsive" alt="" />
                    </div>
                    <div class="item">
                        <img src="images/COOP/DSC02807.JPG" class="img-responsive" alt="" />
                    </div>
                    <div class="item">
                        <img src="images/COOP/DSC02808.JPG" class="img-responsive" alt="" />
                    </div>
                </div>
                <a class="left carousel-control" href="#carousel-example-captions" role="button" data-slide="prev">
                    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="right carousel-control" href="#carousel-example-captions" role="button" data-slide="next">
                    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>
            </div>
        </div>
        <div class="col-md-6">
            <div class="well">
               
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="False">
                    <Columns>
                        <asp:HyperLinkField HeaderText="News And Announcements" DataNavigateUrlFields="RecordID" DataNavigateUrlFormatString="NewsAnnoucementView.aspx?id={0}" DataTextField="Title" />
                    </Columns>
                </asp:GridView>
               
            </div>
        </div>
    </div>
    <br />
    <a href="SMSHowto.aspx" class="btn btn-primary btn-md">How to register to SMS Application</a>
    <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
