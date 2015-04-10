<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="True" CodeBehind="Default.aspx.cs" Inherits="WebsiteTrial.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--
    <div id="slider" class="aligncenter">
			<ul>				
				<li><a href=""><img src="images/imga.jpg" height="250" alt="dlsu_d_gallery" /></a></li>
				<li><a href=""><img src="images/imgb.jpg" height="250" width="620" alt="dlsu_d_gallery" /></a></li>
				<li><a href=""><img src="images/imgc.jpg" height="250" width="620" alt="dlsu_d_gallery" /></a></li>
				<li><a href=""><img src="images/imgd.jpg" height="250" width="620" alt="dlsu_d_gallery"/></a></li>
				<li><a href=""><img src="images/imge.jpg" height="250" alt="dlsu_d_gallery"/></a></li>
                <li><a href=""><img src="images/imgf.jpg" height="250" width="620" alt="dlsu_d_gallery"/></a></li>
				<li><a href=""><img src="images/imgh.jpg" height="250" width="620" alt="dlsu_d_gallery"/></a></li>
                <li><a href=""><img src="images/imgi.jpg" height="250" width="620" alt="dlsu_d_gallery"/></a></li>			
			</ul>
	</div>
    -->



    <div id="carousel-example-captions" class="carousel slide" data-ride="carousel" style="width:620px;">
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

    <br /><br />
    <div class="well"
     <center style="background-color: #CCFFCC;">
         <br />
        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Arial" 
            Font-Size="X-Large" Text="News and Announcements!"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Font-Names="Century Gothic" 
            
             Text="The Luntiang Parangal 2012 recently toasted outstanding members of the student body, faculty advisers, and those who excelled in the fields of art and sports at the Ugnayang La Salle..."></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server" Font-Names="Century Gothic" 
            
             Text="Heraldo Filipino scribes from De La Salle University-Dasmariñas brought back new accolades for the university at the 11th Luzonwide Higher Education..."></asp:Label>
        <br />
        <br />
    </center>	
    </div>
    <br />
    <a href="SMSHowto.aspx" class="btn btn-primary btn-md">How to register to SMS Application</a>
    <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    </asp:Content>
