<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GovernmentDOC_Upload.aspx.cs" Inherits="GovernmentDOC_Upload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

	
	<script src="ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
	<link href="Select/select2.css" rel="stylesheet" />
	<script src="Select/select2.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

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
    </style>
   <style>
		.button-style {
			background-color: #4c99af;
			border: 5px solid black;
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


		.ser_btn {
			background-color: #4CAF50;
             border: 4px solid black;
			color: white;
			padding: 10px 20px;
			text-align: center;
			text-decoration: none;
			display: inline-block;
			font-size: 16px;
			cursor: pointer;
			border-radius: 13px;
		}

		.closbtn {
			background-color: #4c8caf;
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

		.row {
			margin-left: -15px;
			margin-right: -15px;
			display: flex;
			flex-wrap: wrap;
		}

		.useralertcss {
			margin-left: 5%;
			margin-right: 5%;
		}
	</style>


    <style>
        .label-style {
            font-size: 14px;
            font-weight: bold;
        }
    </style>

    <style>
        .file-upload-label {
            display: flex;
            align-items: center;
            justify-content: center;
            padding: 10px 20px;
            background-color: #4CAF50;
            color: #fff;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

			.file-upload-label i {
				margin-right: 5px;
			}

		.file-input {
			display: none;
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
	</style>
	

    <style>

        .gridview-container {
  max-width: 100%;
  overflow-x: auto;
}

.gridview-container table {
  border-collapse: collapse;
  width: 100%;
  margin-bottom: 15px;
}

.gridview-container th,
.gridview-container td {
  padding: 8px;
  text-align: left;
  border-bottom: 1px solid #ddd;
}

.gridview-container th {
  background-color: #f2f2f2;
}

.gridview-container tbody tr:nth-child(even) {
  background-color: #f9f9f9;
}

.gridview-container tbody tr:hover {
  background-color: #f5f5f5;
}
.gridview-container .table .row-dark {
    background-color: #000000; /* Dark color for the row */
}

    </style>



     <style>

.gridview-containers {
  max-width: 107%;
  overflow-x: auto;
}

.gridview-containers table {
  border-collapse: collapse;
  width: 70%;
  margin-bottom: 15px;
}

.gridview-containers th,
.gridview-containers td {
  padding: 8px;
  text-align: left;
  border-bottom: 1px solid #ddd;
}

.gridview-containers th {
  background-color: #f2f2f2;
}

.gridview-containers tbody tr:nth-child(even) {
  background-color: #f9f9f9;
}

.gridview-containers tbody tr:hover {
  background-color: #f5f5f5;
}
.gridview-containers {
        display: flex;
        justify-content: center;
    }
.gridview-containers .table .row-dark {
    background-color: #000000; /* Dark color for the row */
}
    </style>


    <script>
        $(document).ready(function () {
            // Hide the elements initially
            $("#txtName").hide();
            $("#btnSave").hide();

            // Handle click event of the "Add" button
            $(".add-button").click(function () {
                // Show the elements when the "Add" button is clicked
                $("#txtName").show();
                $("#btnSave").show();
            });
        });
    </script>


    <style>
        .status-button {
            padding: 5px 10px;
            border: none;
            cursor: pointer;
            font-weight: bold;
            border-radius: 5px;
        }

        .active-button {
            background-color: green;
            color: white;
        }

        .inactive-button {
            background-color: red;
            color: white;
        }
    </style>


<style>
    /* CSS styles for the dropdown container */
    .dropdown-container {
        position: fixed;
        top: 50%;
        left: 50%;
        transform: translate(-50%, -50%);
    }

    /* CSS styles for the dropdown */
    #DropDownList1 {
        width: 200px;
        height: 30px;
        border: 1px solid #ccc;
        border-radius: 5px;
        padding: 5px;
        font-size: 14px;
        background-color: #f2f2f2;
        color: #333;
    }

    /* CSS styles for the dropdown arrow */
    #DropDownList1::after {
        content: '\25BC'; /* Unicode character for down arrow */
        position: absolute;
        top: 10px;
        right: 10px;
        font-size: 12px;
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
			margin-left:97px;
    }

		.row {
			margin-left: 80px;
			margin-right: -15px;
			display: flex;
			flex-wrap: wrap;
		}

		.txtcnter {
			text-align: center;
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
		}

		.addssave-button {
			background-color: #10998a;
			border: none;
			color: white;
			padding: 10px 20px;
			text-align: center;
			text-decoration: none;
			display: inline-block;
			/*font-size: 16px;*/
			cursor: pointer;
			border-radius: 13px;
			/*margin-left: 97px;*/
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
			font-size: 16px;
			cursor: pointer;
			border-radius: 13px;
			width: 157%;
		}

		.txtstyle {
			width: 332px;
			height: 41px;
		}
	</style>
	


    

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script>
$(document).ready(function () {

               $('.upload-button').click(function () {

                   var row = $(this).closest('tr');


                   row.addClass('row-dark');


                   var currentRow = row;


                   currentRow.removeClass('row-dark');
               });
           });
    </script>


    <style>
        .govtxt {
            text-align: center;
            margin-top: 20px;
        }

        .txtstyle {
            margin-top: 20px;
        }

        .txtcnter {
            margin-top: 10px;
        }

        .button-style {
            padding: 10px 20px;
            background-color: #4c99af;
            color: white;
            border: none;
            cursor: pointer;
            font-size: 16px;
        }

        #GOV_ADD_DOC {
            margin-bottom: 20px;
        }
    </style>






</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <input id="HDNuserid" type="hidden" runat="server" />
        <br />
        <br />
        <h1 class="txtcnter">PROJECT DOCUMENT UPLOAD  DASHBOARD  </h1>
        <hr />
        <br />
        <br />

        <div class="row">

            <div style="margin-left: 250px">
                <asp:Button ID="btnAdd" runat="server" Text="ADD" CssClass="adds-button" OnClick="btnAdd_Click" />
              
            </div>

            <div style="margin-left: 100px">
                  <asp:Button ID="btnView" runat="server" Text="VIEW" CssClass="button-style_view" OnClientClick="return handleDoubleClick();" OnClick="btnView_Click" />
            </div>

        
        </div>


        <br />
        <br />
        <div class="gridview-container">
            <asp:GridView ID="gridViewData" runat="server" Class="table table-striped table-bordered" AutoGenerateColumns="true" OnRowCommand="gridViewData_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="MODIFY">
                        <ItemTemplate>
                          <asp:Button ID="Button1" runat="server" Text="Modify" CommandName="Modify" CommandArgument='<%# Eval("PROJECT CODE") %>' />
                            
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>

        
    </div>
        <br />
        <br />
    <div class="container">
         <div class="row">
            <div >
                <asp:Label ID="LBL_DOC" runat="server" Visible="false" Text="PROJECT DETAILS" CssClass="label-style"></asp:Label>
                </div>
            <div style="margin-left: 276px">
                <asp:TextBox ID="txtInput" runat="server" Visible="false" TextMode="MultiLine" ></asp:TextBox>
           </div>
        </div>
      <br />
        <br />
        <br />

        <div class="row">

            <div >
                <asp:Label ID="LBL_VFD" runat="server" Visible="false" Text="VALID FROM DATE " CssClass="label-style"></asp:Label>
            </div>

            <div style="margin-left: 272px">
                <asp:TextBox ID="txtFromDate" runat="server" TextMode="Date" Visible="false" style="width: 200px;"></asp:TextBox>
            </div>

        </div>
        <br />
        <br />
        <br />
     

        <div class="row">
            <div >
                <asp:Label ID="LBL_VTD" runat="server" Visible="false" Text="VALID TO DATE" CssClass="label-style"></asp:Label>
            </div>

            <div style="margin-left: 294px">
                <asp:TextBox ID="txtToDate" runat="server" TextMode="Date" Visible="false" style="width: 200px;"></asp:TextBox>
            </div>

        </div>


      <br />
        <br />
        <br />

        <div class="row">

            <div >
                <asp:Label ID="LBL_DOC_FL_UP" runat="server" Visible="false" Text="GOVERNMENT DOCUMENT UPLOAD" CssClass="label-style"></asp:Label>
            </div>

            <div style="margin-left: 144px">
                <asp:FileUpload ID="GOV_DOC_FL_UP" runat="server" Visible="false" />
            </div>

        </div>
        <br />
        <br />
      <br />
        <div class="txtcnter">
            <asp:Button ID="btnSave" runat="server" Text="SAVE" Visible="false" CssClass="button-style" OnClick="btnSave_Click" />
        </div>
    </div>

       
        

       




   <script type="text/javascript">
    
       function openPopup(docCode) {
    var strUrl = '../COMMUNITY_OUTREACH/POPUPSCREENS/GovModify.aspx?DocCode=' + docCode;
    var width = 1100;
    var height = 600;
    var left = (screen.width - width) / 2;
    var top = (screen.height - height) / 2;
    var strFeatures = 'height=' + height + ',width=' + width + ',left=' + left + ',top=' + top + ',center=yes,edge=raised,resizable=no,scrollbars=yes,status=yes,unadorned=no';

    window.open(strUrl, 'GovernmentDocumentModify', strFeatures);
}

    
</script>


</asp:Content>
