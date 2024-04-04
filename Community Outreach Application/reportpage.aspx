<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="reportpage.aspx.cs" Inherits="reportpage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="container">

        <br />
        <br />
        <h1 class="txtcnter"> REPORT  DASHBOARD  </h1>
        <hr />
        <br />
        <br />

        <div class="row">
            <div >
                <asp:DropDownList ID="sch_pro_rpt" Width="154px" Height="36px" runat="server"></asp:DropDownList>
                
            </div>
            <div style="margin-left: 6%;">
                <asp:DropDownList ID="sch_no_rpt" Width="154px" Height="36px" runat="server"></asp:DropDownList>
            </div>
            <div style="margin-left: 6%;">
                <asp:Button ID="FETCH_BTN" runat="server" Text="FETCH" CssClass="BTNSTYLE" OnClick="FETCH_BTN_Click" />
            </div>

            <div style="margin-left: 6%;">
                <asp:Button ID="ECPORT_XL" runat="server" Text="EXPORT TO EXCEL " CssClass="BTNSTYLE" OnClick="ECPORT_XL_Click"  />
            </div>
        </div>

        <br />
        <br />
         <asp:Panel ID="PNL1" runat="server">
                <table>

                    <tr >
                       
                        
                        <td>


                             <asp:GridView ID="GridView1" runat="server" CssClass="gridview" Width="80%"  >


                             </asp:GridView>
                        </td>
                    </tr>


                </table>

            </asp:Panel>
      
    </div>
</asp:Content>

