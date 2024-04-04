<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="school_dtls.aspx.cs" Inherits="school_dtls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

  <script src="ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
	<link href="Select/select2.css" rel="stylesheet" />
	<script src="Select/select2.js"></script>
	<link href="css/MenuStyleSheet.css" rel="stylesheet" />
	<style>
		body {
			font: 11px verdana;
		}
	</style>
	<style>
		.container {
    width: 100%;
    max-width: 1200px; /* Adjust this max-width as needed */
    margin: 0 auto;
    padding: 20px;
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
	</style>



    <style>
        .label-style {
            font-size: 20px;
            font-weight: bold;
        }
    </style>

    <style>
        .txtstyle {
			width: 290px;
			height: 41px;
		}
    </style>

	<style>

		/* FileUpload CSS */
.file-upload {
  position: relative;
  display: inline-block;
  overflow: hidden;
  font-family: Arial, sans-serif;
  color: #333;
  border: 1px solid #ccc;
  padding: 6px 12px;
  cursor: pointer;
}

.file-input-label {
  display: inline-block;
}

.file-input-label i {
  margin-right: 4px;
}

.file-input-label:hover {
  background-color: #f2f2f2;
}

	</style>
	<style>
		

		.adds-button {
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
			margin-left: 97px;
			WIDTH: 153PX
		}

		.button-style {
			background-color: #4c99af;
			border: none;
			color: white;
			padding: 10px 20px;
			text-align: center;
			text-decoration: none;
			display: inline-block;
			font-size: 16px;
			cursor: pointer;
			border-radius: 13px;
			width: 18%;
		}

		.button-style_view {
			background-color: #4c99af;
			border: none;
			color: white;
			padding: 10px 20px;
			text-align: center;
			text-decoration: none;
			display: inline-block;
			font-size: 14px;
			cursor: pointer;
			border-radius: 13px;
			width: 91%;
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
	</style>

  

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <input id="HDNuserid" type="hidden" runat="server" />
		<br />
		<br />
		<h1 class="txtcnter"> SCHOOL DETAILS DASHBOARD  </h1>
		<hr />
		<br />
		<br />

		<div class="row">
			<div>
				
                <asp:Button ID="SCH_INSERT" runat="server" Text="ADD" CssClass="adds-button" OnClick="SCH_INSERT_Click" />
			</div>
			<div style="margin-left: 80px">
				<asp:Button ID="SCH_VIEW" runat="server" Text="VIEW" CssClass="button-style_view" OnClick="SCH_VIEW_Click"  />
			</div>

			<div style="margin-left: 80px">
				<asp:Button ID="SCH_UPLOAD" runat="server" Text="UPLOAD" CssClass="button-style_view" OnClick="SCH_UPLOAD_Click"  />
			</div>

            <div style="margin-left: 80px">
				<asp:Button ID="SCH_TEMP_UPLOAD" runat="server" Text="CHECK EXCEL UPLOAD" CssClass="button-style_view" OnClick="SCH_TEMP_UPLOAD_Click"/>
			</div>

		</div>
        <br />
        <br />

        <div class="row">
    <asp:Panel ID="pnlAdd" runat="server">
        <div class="row">
                <div >
                    <asp:Label ID="SCH_DOC_ID" runat="server"  Text="SELECT  PROJECT NAME " CssClass="label-style"></asp:Label>
                </div>

                <div style="margin-left: 165px">
                    <asp:DropDownList ID="DOCU_ID" runat="server"  cssClass="txtstyle" ></asp:DropDownList>
                </div>
            </div>
            <br />
            <br />
            <div class="row">
                <div >
                    <asp:Label ID="SCH_NME" runat="server"  Text="SCHOOL NAME" CssClass="label-style"></asp:Label>
                </div>

                <div style="margin-left: 262px">
                    <asp:TextBox ID="SCH_NAME" runat="server"  cssClass="txtstyle" ></asp:TextBox>
                </div>

            </div>

            <br />
            <br />

            <div class="row">
                <div >
                    <asp:Label ID="SCH_HM_LBL" runat="server"  Text="SCHOOL HM NAME " CssClass="label-style"></asp:Label>
                </div>

                <div style="margin-left: 219px">
                    <asp:TextBox ID="SCH_HM_TXT" runat="server"   cssClass="txtstyle" ></asp:TextBox>
                </div>

            </div>
            <br />
            <br />

            <div class="row">

                <div >
                    <asp:Label ID="SCH_CON_LBL" runat="server"  Text="SCHOOL CONTACT NUMBER" CssClass="label-style"></asp:Label>
                </div>
                <div style="margin-left: 117px">
                    <asp:TextBox ID="SCH_CON_NO" runat="server"  cssClass="txtstyle"></asp:TextBox>
                </div>
            </div>
            <br />
            <br />

            <div class="row">
                <div >
                    <asp:Label ID="SCH_EID_LBL" runat="server"  Text="SCHOOL EMAIL ID" CssClass="label-style"></asp:Label>
                </div>
                <div style="margin-left: 219px">
                    <asp:TextBox ID="SCH_EMAIL_ID" runat="server"  cssClass="txtstyle"></asp:TextBox>
                </div>
            </div>
            <br />
            <br />
            <div class="row">

                <div >
                    <asp:Label ID="SCH_DER_LBL" runat="server"  Text="SCHOOL ADDRESS" CssClass="label-style"></asp:Label>
                </div>

                <div style="margin-left: 216px">
                    <asp:TextBox ID="SCH_ADDRESS" runat="server"  cssClass="txtstyle"></asp:TextBox>
                </div>

            </div>

            <br />
            <br />
               
        <div class="row">

            <div>
                <asp:Label ID="SCH_DISTRICT" runat="server" Text="DISTRICT" CssClass="label-style"></asp:Label>
            </div>
            <div style="margin-left: 309px">
                <asp:TextBox ID="TEXT_SCH_DISTRICT" runat="server" cssClass="txtstyle"></asp:TextBox>
            </div>

        </div>
        <br />
        <br />
        <div class="row">
            <div>
                <asp:Label ID="SCL_STATE" runat="server" Text="STATE" CssClass="label-style"></asp:Label>
            </div>
            <div style="margin-left: 348px">
                <asp:TextBox ID="TEXT_SCL_STATE" runat="server" cssClass="txtstyle"></asp:TextBox>
            </div>

        </div>
         <br />
         <br />

            <div class="row">

                <div >
                    <asp:Label ID="SCH_FL_LBL" runat="server"  Text="SCHOOL DOCUMENT" CssClass="label-style"></asp:Label>
                </div>

                <div style="margin-left: 255px">
                    <asp:FileUpload ID="SCH_MEMO_UPL" runat="server"   cssClass="txtstyle"/>
                </div>

            </div>


            <br />
            <br />

            <div class="txtcnter">
                <asp:Button ID="SCH_DTL_SAVE" runat="server" Text="SAVE"  CssClass="button-style" OnClick="SCH_DTL_SAVE_Click"  />
            </div>

        <br />
        <br />
        <div style="margin-left: 334px">
            <asp:Label ID="Label2" runat="server"   style="color: red; font-size: 20px;font-weight: bold;" ></asp:Label>
        </div>


    </asp:Panel>

    <asp:Panel ID="pnlView" runat="server" >
    
        <div style="margin-left: 124px;">
             <asp:GridView ID="sch_detail_grd" runat="server"  CssClass="gridview"></asp:GridView>
        </div>
        

    </asp:Panel>

    <asp:Panel ID="pnlUpload" runat="server" >
       <div class="row">
              
				<div>
					<asp:Label ID="Label1" runat="server"  Text="SELECT SCHOOL NAME "  CssClass="label-style"></asp:Label>
				</div>
				<div style="margin-left: 100px">
					<asp:DropDownList ID="SCH_DROPLIST" runat="server" AutoPostBack="true" Width="197px" Height="29px" ></asp:DropDownList>
				</div >

				<div style="margin-left: 50px">
						<asp:FileUpload ID="stu_data_upl" runat="server"  />
				</div>
                
			</div>
          <br />
           <br />
                <div class="txtcnter" style="margin-left: 135px;" >
                    <asp:Button ID="stu_detail_upload" runat="server" Text="UPLOAD" CssClass="button-style" OnClick="stu_detail_upload_Click"  />
                </div>
    </asp:Panel>

    <asp:Panel ID="pnlTempUpload" runat="server" >
      <div class="row">
              
				<div>
					<asp:Label ID="TEMP_SCL_NAME" runat="server"  Text=" TEMP EXCEL UPLOAD "  CssClass="label-style"></asp:Label>
				</div>
				<div style="margin-left: 100px">
					<asp:DropDownList ID="TEMP_SCL_DROPDOWN" runat="server" AutoPostBack="true" Width="197px" Height="29px" ></asp:DropDownList>
				</div >

				<div style="margin-left: 50px">
						<asp:FileUpload ID="TEMP_FILE_UPLOAD" runat="server"  />
				</div>
                
			</div>
            <br />
            <br />
            <div class="txtcnter" style="margin-left: 135px;">
                  <asp:Button ID="temp_stu_detail_upload" runat="server" Text="UPLOAD" CssClass="button-style" OnClick="temp_stu_detail_upload_Click"  />
                </div>
            <br />
            <br />
            <asp:GridView ID="errorGridView" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                <Columns>
                    <asp:BoundField DataField="RowNumber" HeaderText="Row Number" />
                    <asp:BoundField DataField="ErrorMessage" HeaderText="Error Message" />
                </Columns>
            </asp:GridView>
        
    </asp:Panel>
</div>

    </div>
</asp:Content>

