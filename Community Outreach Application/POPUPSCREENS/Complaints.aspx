<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Complaints.aspx.cs" Inherits="POPUPSCREENS_Complaints" %>

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


     <script type="text/javascript">
        window.onload = function () {
            var docCode = '<%= Request.QueryString["studentID"] %>';
        
        };
    </script>

</head>
<body>
	<form id="form1" runat="server">
		<div class="container">

			<h1 class="txtcnter">COMPLAINTS </h1>
			<hr />
			<br />
			<br />
			<div class="row">
				<div class="left-part">
					<asp:Label ID="Label15" runat="server" Text="Diminision of vision"></asp:Label>
				</div>
				<div class="right-part">
					<asp:RadioButtonList ID="Diminision_vision" runat="server" RepeatDirection="Horizontal">
						<asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
						<asp:ListItem Value="No" Text="No"></asp:ListItem>
					</asp:RadioButtonList>
				</div>
			</div>
			<div class="row">
				<div class="left-part">
					<asp:Label ID="Label16" runat="server" Text="Watering of eyes"></asp:Label>
				</div>
				<div class="right-part">
					<asp:RadioButtonList ID="Watering_eye" runat="server" RepeatDirection="Horizontal">
						<asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
						<asp:ListItem Value="No" Text="No"></asp:ListItem>
					</asp:RadioButtonList>
				</div>

			</div>
			<div class="row">
				<div class="left-part">
					<asp:Label ID="Label17" runat="server" Text="Redness/ Itching/ Irritation"></asp:Label>
				</div>
				<div class="right-part">
					<asp:RadioButtonList ID="red_itc_irrita" runat="server" RepeatDirection="Horizontal">
						<asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
						<asp:ListItem Value="No" Text="No"></asp:ListItem>
					</asp:RadioButtonList>
				</div>

			</div>
			<div class="row">
				<div class="left-part">
					<asp:Label ID="Label18" runat="server" Text="Sustained swelling on lids"></asp:Label>
				</div>
				<div class="right-part">
					<asp:RadioButtonList ID="Sustained_swell" runat="server" RepeatDirection="Horizontal">
						<asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
						<asp:ListItem Value="No" Text="No"></asp:ListItem>
					</asp:RadioButtonList>
				</div>

			</div>
			<div class="row">
				<div class="left-part">
					<asp:Label ID="Label19" runat="server" Text="Others"></asp:Label>
				</div>
				<div class="right-part">
					<asp:TextBox ID="complain_other" runat="server" TextMode="MultiLine"></asp:TextBox>
				</div>

			</div>

			<div class="txtcnter">
				<asp:Button ID="complaint_save" runat="server" Text="SAVE" OnClick="complaint_save_Click" Visible="false" style="margin-right: 20px;" />

        <asp:Button ID="modify_btn" runat="server" Text="MODIFY" OnClick="complaint_modify_Click" Visible="false" />
			</div>

			<br />
			<br />


			<div class="txtcnter" style="margin-left: 23%; width: 135%;">
				<asp:Literal ID="SummaryLiteral" runat="server"></asp:Literal>
			</div>

		</div>
	</form>
</body>
</html>
