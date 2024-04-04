<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OcularHistory.aspx.cs" Inherits="POPUPSCREENS_OcularHistory" %>

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

			<h1 class="txtcnter"> OCULAR HISTORY </h1>
			<hr />
			<br />
			<br />
			<div class="row">
									<div class="left-part">
										<asp:Label ID="Label20" runat="server" Text="Injury"></asp:Label>
									</div>
									<div class="right-part">
										<asp:RadioButtonList ID="Injury_drop" runat="server" RepeatDirection="Horizontal">
												<asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
												<asp:ListItem Value="No" Text="No"></asp:ListItem>
											</asp:RadioButtonList>
									</div>
								</div>
									<div class="row">
										<div class="left-part">
											<asp:Label ID="Label21" runat="server" Text="Type of injury (Cracker/Pen/Needle/Stick/Stone/RTA/Chemical)"></asp:Label>
										</div>
										<div class="right-part">
											<asp:TextBox ID="cracker_pen" runat="server" TextMode="MultiLine"></asp:TextBox>
										</div>

									</div>
									<div class="row">
										<div class="left-part">
											<asp:Label ID="Label22" runat="server" Text="Previous treatment"></asp:Label>
										</div>
										<div class="right-part">
											<asp:TextBox ID="Previous_treat" runat="server" TextMode="MultiLine"></asp:TextBox>
										</div>

									</div>
                        		<div class="row">
										<div class="left-part">
											<asp:Label ID="Label23" runat="server" Text="Ocular surgery"></asp:Label>
										</div>
										<div class="right-part">
											<asp:RadioButtonList ID="Ocular_surgery" runat="server" RepeatDirection="Horizontal">
												<asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
												<asp:ListItem Value="No" Text="No"></asp:ListItem>
											</asp:RadioButtonList>
										</div>

									</div>
									<div class="row">
										<div class="left-part">
											<asp:Label ID="Label24" runat="server" Text="Details of surgery (Ptosis/Cataract/ strabismus)"></asp:Label>
										</div>
										<div class="right-part">
											<asp:TextBox ID="detail_surgery" runat="server" TextMode="MultiLine"></asp:TextBox>
										</div>

									</div>
								<div class="row">
										<div class="left-part">
											<asp:Label ID="Label25" runat="server" Text="Previous consultation"></asp:Label>
										</div>
										<div class="right-part">
											<asp:TextBox ID="Previous_consul" runat="server" TextMode="MultiLine"></asp:TextBox>
										</div>

									</div>
								<div class="row">
										<div class="left-part">
											<asp:Label ID="Label26" runat="server" Text="Currently under treatment"></asp:Label>
										</div>
										<div class="right-part">
											<asp:RadioButtonList ID="under_treatment" runat="server" RepeatDirection="Horizontal">
												<asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
												<asp:ListItem Value="No" Text="No"></asp:ListItem>
											</asp:RadioButtonList>
										</div>

									</div>
								<div class="row">
										<div class="left-part">
											<asp:Label ID="Label27" runat="server" Text="Information collected from"></asp:Label>
										</div>
										
											<div class="right-part" style="width: 248px;">
											<asp:RadioButtonList ID="information_collected_from" runat="server" RepeatDirection="Horizontal">
												<asp:ListItem Value="Parent" Text="Parent"></asp:ListItem>
												<asp:ListItem Value="Student" Text="Student"></asp:ListItem>
												<asp:ListItem Value="Teacher" Text="Teacher"></asp:ListItem>
											</asp:RadioButtonList>
										</div>
									

									</div>
			<div class="txtcnter">
				<asp:Button ID="ocular_save" runat="server" Text="SAVE" OnClick="ocular_save_Click" Visible="false" style="margin-right: 20px;" />

                <asp:Button ID="ocular_modify_btn" runat="server" Text="MODIFY" OnClick="ocular_modify_btn_Click" Visible="false" />
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
