<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InterMediateVision.aspx.cs" Inherits="POPUPSCREENS_InterMediateVision" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>

	<style>
		.container {
			width: 100%;
			max-width: 1200px;
			margin: 0 auto;
			padding: 20px;
			box-sizing: border-box;
		}

		.txtcnter {
			text-align: center;
		}

		.row {
			margin-left: 80px;
			margin-right: -15px;
			display: flex;
			flex-wrap: wrap;
		}

		.left-part {
			width: 50%;
			float: left;
			box-sizing: border-box;
			padding: 10px;
		}

		.right-part {
			width: 50%;
			float: left;
			box-sizing: border-box;
			padding: 10px;
			margin-left: 313px;
		}

		.BTNSTYLE {
			background-color: #4CAF50;
			border: none;
			color: white;
			padding: 10px 20px;
			text-align: center;
			text-decoration: none;
			display: inline-block;
			font-size: 16px;
			cursor: pointer;
			border-radius: 13px;
		}

		#gobtnclcick {
			height: 55px
		}
	</style>
	<style>
		.spacing {
			width: 150px;
		}
	</style>

	<style>
		.spacing1 {
			width: 100px;
		}
	</style>

	<style>
		.spacing2 {
			width: 220px;
		}
	</style>

	<style>
		.spacing3 {
			width: 180px;
		}
	</style>


	<style>
		.row-spacing {
			margin-bottom: 20px;
		}
	</style>

     <script type="text/javascript">
        window.onload = function () {
            var docCode = '<%= Request.QueryString["studentID"] %>';
        
        };
    </script>


</head>
<body>
	<form id="form1" runat="server">
		<div class="container">
			<h1 class="txtcnter"> Intermediate Vision </h1>
			<hr />
			<br />
			<br />
			<div class="row">
				<div class="left-part">
					
				</div>
				<div class="right-part">
					<asp:Label ID="Label28" runat="server" Text="Type of Chart"></asp:Label>
					<asp:DropDownList ID="DD_IV_Type_of_chart" TabIndex="34" CssClass="generalcbo" runat="server" Width="25%">
					</asp:DropDownList>
				</div>
			</div>
			<br />
			
			<div class="row row-spacing">

				<asp:Label ID="Label29" runat="server" Text="Eyes"></asp:Label>
				<div class="spacing"></div>
				<asp:Label ID="Label33" runat="server" Text="WithoutGlass"></asp:Label>
				<div class="spacing3"></div>
				<asp:Label ID="Label34" runat="server" Text="WithGlass"></asp:Label>
				<div class="spacing2"></div>
				<asp:Label ID="Label35" runat="server" Text="Contact Lens"></asp:Label>


			</div>



			<div class="row row-spacing">

				<asp:Label ID="Label30" runat="server" Text="OD"></asp:Label>
				<div class="spacing1"></div>
				<asp:DropDownList ID="DD_IV_OD_WithoutGlass" TabIndex="34" CssClass="generalcbo" runat="server" Width="10%">
				</asp:DropDownList>
				<asp:Label ID="Label37" runat="server" Text="Cm"></asp:Label>
				<asp:TextBox ID="txt_IV_OD_WithoutGlass" runat="server" Width="5%"></asp:TextBox>

				<div class="spacing1"></div>
				<asp:DropDownList ID="DD_IV_OD_WithGlass" TabIndex="34" CssClass="generalcbo" runat="server" Width="10%">
				</asp:DropDownList>
				<asp:Label ID="Label38" runat="server" Text="Cm"></asp:Label>
				<asp:TextBox ID="txt_IV_OD_WithGlass" runat="server" Width="5%"></asp:TextBox>

				<div class="spacing1"></div>
				<asp:DropDownList ID="DD_IV_OD_Contact_lens" TabIndex="34" CssClass="generalcbo" runat="server" Width="10%">
				</asp:DropDownList>
				<asp:Label ID="Label39" runat="server" Text="Cm"></asp:Label>
				<asp:TextBox ID="txt_IV_OD_Contact_lens" runat="server" Width="5%"></asp:TextBox>

			</div>




			<div class="row row-spacing">

				<asp:Label ID="Label31" runat="server" Text="OS"></asp:Label>
				<div class="spacing1"></div>
				<asp:DropDownList ID="DD_IV_OS_WithoutGlass" TabIndex="34" CssClass="generalcbo" runat="server" Width="10%">
				</asp:DropDownList>
				<asp:Label ID="Label40" runat="server" Text="Cm"></asp:Label>
				<asp:TextBox ID="txt_IV_OS_WithoutGlass" runat="server" Width="5%"></asp:TextBox>

				<div class="spacing1"></div>
				<asp:DropDownList ID="DD_IV_OS_WithGlass" TabIndex="34" CssClass="generalcbo" runat="server" Width="10%">
				</asp:DropDownList>
				<asp:Label ID="Label41" runat="server" Text="Cm"></asp:Label>
				<asp:TextBox ID="txt_IV_OS_WithGlass" runat="server" Width="5%"></asp:TextBox>

				<div class="spacing1"></div>
				<asp:DropDownList ID="DD_IV_OS_Contact_lens" TabIndex="34" CssClass="generalcbo" runat="server" Width="10%">
				</asp:DropDownList>
				<asp:Label ID="Label42" runat="server" Text="Cm"></asp:Label>
				<asp:TextBox ID="txt_IV_OS_Contact_lens" runat="server" Width="5%"></asp:TextBox>


			</div>


			<div class="row row-spacing">

				<asp:Label ID="Label36" runat="server" Text="OU"></asp:Label>
				<div class="spacing1"></div>
				<asp:DropDownList ID="DD_IV_OU_WithoutGlass" TabIndex="34" CssClass="generalcbo" runat="server" Width="10%">
				</asp:DropDownList>
				<asp:Label ID="Label43" runat="server" Text="Cm"></asp:Label>
				<asp:TextBox ID="txt_IV_OU_WithoutGlass" runat="server" Width="5%"></asp:TextBox>

				<div class="spacing1"></div>
				<asp:DropDownList ID="DD_IV_OU_WithGlass" TabIndex="34" CssClass="generalcbo" runat="server" Width="10%">
				</asp:DropDownList>
				<asp:Label ID="Label44" runat="server" Text="Cm"></asp:Label>
				<asp:TextBox ID="txt_IV_OU_WithGlass" runat="server" Width="5%"></asp:TextBox>

				<div class="spacing1"></div>
				<asp:DropDownList ID="DD_IV_OU_Contact_lens" TabIndex="34" CssClass="generalcbo" runat="server" Width="10%">
				</asp:DropDownList>
				<asp:Label ID="Label45" runat="server" Text="Cm"></asp:Label>
				<asp:TextBox ID="txt_IV_OU_Contact_lens" runat="server" Width="5%"></asp:TextBox>


			</div>


			<div class="row">
				<div class="txtcnter">
					<asp:Label ID="Label32" runat="server" Text="Remarks"></asp:Label>
				
					<asp:TextBox ID="InterMediateTet" runat="server" TextMode="MultiLine"></asp:TextBox>
				</div>

			</div>
			<div class="txtcnter">
				<asp:Button  ID="SAVE_BTN" runat="server" Text="SAVE" OnClick="SAVE_BTN_Click" Visible="false" style="margin-right: 20px;" />

                 <asp:Button ID="modify_btn" runat="server" Text="MODIFY" OnClick="modify_btn_Click" Visible="false" />

			</div>
			 <br />
		     <br />


		<div class="txtcnter" style="margin-left:23%;width:135%;">
			<asp:Literal ID="SummaryLiteral" runat="server"></asp:Literal>
		</div>

		</div>
	</form>
</body>
</html>
