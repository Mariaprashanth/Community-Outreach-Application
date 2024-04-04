<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="datamigration.aspx.cs" Inherits="datamigration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <div class="container">
       
        <br />
        <br />
        <h1 class="txtcnter"> DATA MAIGRATION  DASHBOARD  </h1>
        <hr />
        <br />
        <br />

         <div class="row">
             <div>
                  <asp:DropDownList ID="server_drop" Width="154px" Height="36px" runat="server"></asp:DropDownList>
             </div>
              <div style="margin-left:40px">
                  <asp:DropDownList ID="document_drop" Width="154px" Height="36px" runat="server"></asp:DropDownList>
             </div>
              <div style="margin-left:40px">
                  <asp:DropDownList ID="school_drop" Width="154px" Height="36px" runat="server"></asp:DropDownList>
             </div>
              <div style="margin-left:40px">
                  <asp:Button ID="migration" runat="server" Text="MAIGRATE" CssClass="BTNSTYLE" OnClick="migration_Click"  />
             </div>
              <%--<div>
                  <asp:TextBox ID="T_DATE" runat="server" TextMode="Date" Width="154px" Height="36px" ></asp:TextBox>
             </div>--%>
         </div>

     </div>
</asp:Content>

