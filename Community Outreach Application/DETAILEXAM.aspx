<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DETAILEXAM.aspx.cs" Inherits="DETAILEXAM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
	
	<script src="ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
	<link href="Select/select2.css" rel="stylesheet" />
	<script src="Select/select2.js"></script>
	
	<style>
		body {
			font: 11px verdana;
		}
	</style>
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
	<style>
		/* Gridview CSS */
		.gridview {
			width: 100%;
			border-collapse: collapse;
		}

			.gridview th,
			.gridview td {
				padding: 8px;
				text-align: left;
				border: 1px solid #ccc;
			}

			.gridview th {
				background-color: #f2f2f2;
			}

			.gridview tr:nth-child(even) {
				background-color: #f9f9f9;
			}

			.gridview tr:hover {
				background-color: #e5e5e5;
			}

		.custom-image {
			height: 70px;
           margin-left: 50px;
		}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

	<div class="container">
		<br />
		<br />
		<h1 class="txtcnter">DETAILED EXAMINATION  DASHBOARD  </h1>
		<hr />
		<br />
		<br />
		<div class="left-part">
			<asp:DropDownList ID="DETAIL_EXAM_DROP" Width="300px" Height="36px" runat="server">
			</asp:DropDownList>
		</div>
		<div class="right-part">
			<asp:Button ID="details_exam_search" runat="server" Text="Search" CssClass="BTNSTYLE" OnClick="details_exam_search_Click" />
		</div>

		<br />
		<br />
		<asp:GridView ID="detail_exam_load" runat="server" CssClass="gridview" AutoGenerateColumns="false">

			<Columns>
				<asp:BoundField DataField="ECSD_SCHOOL_NO" HeaderText="SCHOOL NO" Visible="false" />
				<asp:BoundField DataField="ECSM_STUDENT_ID" HeaderText="STUDENT ID" />
				<asp:BoundField DataField="ECSD_SCHOOL_NAME" HeaderText="SCHOOL NAME" />
				<asp:BoundField DataField="ECSM_STUDENT_FIRST_NAME" HeaderText="STUDENT NAME" />
				<asp:BoundField DataField="ECSM_STUDENT_CLASS" HeaderText="CLASS" />
				<asp:BoundField DataField="ECSM_STUDENT_SECTION" HeaderText="SECTION" />
				<asp:BoundField DataField="ECSM_STUDENT_AGE" HeaderText="AGE" />
				<asp:BoundField DataField="ECSM_STUDENT_GENDER" HeaderText="GENDER" />

				<asp:TemplateField HeaderText="VISUAL ACUITY REFACTION " HeaderStyle-CssClass="newgrid">
					<ItemTemplate>
						<asp:ImageButton ID="gobtnclcick" ImageUrl="~/img/Go-Logo_Blue.png" runat="server" CssClass="custom-image" OnClientClick='<%# Eval("ECSM_STUDENT_ID", "OpenVA(\"{0}\"); return false;") %>' />
					</ItemTemplate>
				</asp:TemplateField>
			</Columns>

		</asp:GridView>

<script type="text/javascript">
  function OpenVA(studentID) {
    var strUrl = '../COMMUNITY_OUTREACH/VISUAL_ACUITY_SCREEN.aspx?studentID=' + studentID;
    var width = 1400;
    var height = 900;
    var left = (screen.width - width) / 2;
    var top = (screen.height - height) / 2;
    var strFeatures = 'height=' + height + ',width=' + width + ',left=' + left + ',top=' + top + ',center=yes,edge=raised,resizable=no,scrollbars=yes,status=yes,unadorned=no';

    window.open(strUrl, 'VisualAcuityScreen', strFeatures);
  }
</script>


	</div>

</asp:Content>

