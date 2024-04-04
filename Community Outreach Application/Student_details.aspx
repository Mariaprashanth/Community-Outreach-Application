<%@ Page  Title="" Language="C#"  MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Student_details.aspx.cs" Inherits="Student_details" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

   
    <script src="ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>

    	<script src="https://code.jquery.com/jquery-3.6.0.min.js" integrity="sha256-oTu1Z5KQ88HX+oWUE/hhAXL4a9ZWEA4WKZnJZ4BJ5cI=" crossorigin="anonymous"></script>

	    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/jquery@3.6.4/dist/jquery.slim.min.js"></script>
	
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
		/* Gridview CSS */
		.gridview {
			width: 100%;
			border-collapse: collapse;
		}

			.gridview th,
			.gridview td {
				padding: 8px;
				text-align: left;
				border: 2px solid black;
                border-width: 2px; 
			}

			.gridview th {
				background-color: #4c99af;
			}

			.gridview tr:nth-child(even) {
				background-color: #addbea;
			}

			.gridview tr:hover {
				background-color: #4c99af;
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
            background-color: #4CAF50;
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
            right: 200px;
        }

        .button-style_view {
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
            width: 157%;
        }

       .txtstyle {
    width: 332px;
    border: 2px solid #333;
    height: 41px;
    padding: 8px;
    font-size: 13px;
    border-radius: 5px;
    outline: none;
    transition: border-color 0.3s ease-in-out;
}

.txtstyle:focus {
    border-color: #4c99af;
}


    </style>


    <style>
        .label-style {
    font-size: 14px;
    font-weight: bold;
    
}
    </style>

  <style>
    .std-image {
        display: none;
    }
</style>

    <style>
    .delete-button {
        background-color: red;
        color: white;
    }
</style>
    <style>
		.btnn {
			display: inline-block;
			padding: 6px 12px;
			margin-bottom: 0;
			font-size: 14px;
			font-weight: normal;
			line-height: 1.42857143;
			text-align: center;
			white-space: nowrap;
			vertical-align: middle;
			-ms-touch-action: manipulation;
			touch-action: manipulation;
			cursor: pointer;
			-webkit-user-select: none;
			-moz-user-select: none;
			-ms-user-select: none;
			user-select: none;
			background-image: none;
			border: 1px solid transparent;
			border-radius: 4px;
		}

		.btn-dangerr {
			color: #fff;
			background-color: #d9534f;
			border-color: #d43f3a;
		}

		.btn-smm {
			padding: 5px 10px;
			font-size: 12px;
			line-height: 1.5;
			border-radius: 3px;
		}

		.iconcss {
			height: 35px;
			width: 39px;
			margin-left: 18px;
		}
	</style>

    <script>
        function showPopup() {
            var popupScreen = document.getElementById('popupScreen');
            popupScreen.style.display = 'block';
        }
    </script>


    <style>
    #popupScreen {
        position: fixed;
        top: 0;
        left: 0;
        right: 0;
        bottom: 0;
        background-color: rgba(0, 0, 0, 0.5); /* Semi-transparent background */
        z-index: 9999; /* Ensure the popup is on top of other elements */
        display: flex;
        align-items: center;
        justify-content: center;
    }

    #popupScreen h2 {
        color: white;
        font-size: 24px;
        text-align: center;
        margin-bottom: 20px;
    }

    #popupScreen form {
        background-color: white;
        padding: 20px;
        border-radius: 4px;
    }

    #popupScreen label {
        display: block;
        margin-bottom: 10px;
    }

    #popupScreen input[type="text"] {
        width: 100%;
        padding: 8px;
        border-radius: 4px;
        border: 1px solid #ccc;
        box-sizing: border-box;
        margin-bottom: 10px;
    }

    #popupScreen button {
        padding: 8px 16px;
        border-radius: 4px;
        background-color: #4CAF50;
        color: white;
        border: none;
        cursor: pointer;
        margin-right: 10px;
    }

    #popupScreen button:last-child {
        margin-right: 0;
    }
</style>

    <style>
		/* Styling for the search box container */
		.search-box {
			position: relative;
			width: 300px;
		}

			/* Styling for the search input */
			.search-box input[type="text"] {
				width: 55%;
				padding: 10px;
				font-size: 16px;
				border: 2px solid #ccc;
				border-radius: 5px;
			}

		/* Styling for the search icon */
		.search-icon {
			position: absolute;
			top: 50%;
			right: 23px;
			transform: translateY(-50%);
			width: 20px;
			height: 20px;
			background-color: #ccc;
			clip-path: polygon(100% 0%, 0 50%, 100% 100%);
			cursor: pointer;
			transition: background-color 0.3s ease;
		}

			/* Animation for the search icon on hover */
			.search-icon:hover {
				background-color: #aaa;
			}

		.search-box input[type="text"]:focus + .search-icon {
			right: 35px;
		}
	</style>

    


    <style>
      
    .radio-container {
       
        display: inline-block;
        margin-right: 20px; 
    
    }

        
    </style>


    <style>
        .radiobtn-style input[type="radio"] {
            display: none;
        }

        .radiobtn-style label {
            display: inline-block;
            padding: 5px 10px;
            margin: 0;
            font-size: 14px;
            background-color: #333;
            color: #fff;
            cursor: pointer;
            border-radius: 4px;
        }


        .radiobtn-style input[type="radio"]:checked + label {
            background-color: green;
            
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <input id="HDNuserid" type="hidden" runat="server" />
        <br />
        <br />
        <h1 class="txtcnter">STUDENT DETAILS  DASHBOARD  </h1>
        <hr />
        <br />
        <br />

        <div class="row" style="margin-left: 200px;">
            <div>
                <asp:Button ID="STD_ADD" runat="server" Text="ADD" CssClass="button-style_view" OnClick="std_detail_add" />
            </div>
            <div style="margin-left: 200px">
                <asp:Button ID="STD_UPDATE" runat="server" Text="EDIT" CssClass="button-style_view" onclick="std_detail_edit"/>
            </div>

            <div style="margin-left: 200px">
                <asp:Button ID="STD_DELETE" runat="server" Text="DELETE" CssClass="button-style_view" OnClick="std_detail_delete" />
            </div>

        </div>
       <br />
            <br />
        <%-------------------------------- studentdetail dashboard DELETE----------------------------------------%>
        <div class="row" style="margin-left: 13%;">
             
            <div>
                <asp:DropDownList ID="SEL_SCHOOL" Visible="false" Width="185px" Height="36px" CssClass="txtstyle" runat="server">
                </asp:DropDownList>
            </div>

            <div style="margin-left: 50px">
                <asp:DropDownList ID="SEL_CLASS" Visible="false" Width="185px" Height="36px" CssClass="txtstyle" runat="server">
                </asp:DropDownList>
            </div>

            <div style="margin-left: 50px">
                <asp:DropDownList ID="SEL_SECTION" Visible="false" Width="185px" Height="36px" CssClass="txtstyle" runat="server">
                </asp:DropDownList>
            </div>

            <div style="margin-left: 50PX">
                <asp:Button ID="STU_SEARCH" Visible="false" runat="server" Text="Search" CssClass="ser_btn" OnClick="STU_SEARCH_Click" />
            </div>

        </div>
        <div class="search-box" style="margin-left: 33%;">
            <asp:TextBox ID="txtStudentNameSearch" runat="server" Visible="false" placeholder="Search..." OnTextChanged="txtStudentNameSearch_TextChanged" AutoPostBack="true" />

        </div>

                <br />
                <br />
        <div class="row" style="float: right;">
            
              <%--  <img id="STD_DELETE_IMGS" runat="server" visible="false" src="img/stu_del.jfif" alt="Image" width="300" height="300" />--%>
            
        </div>
         
        <div class="row" style="display: flex; justify-content: center;">
             <div>
                 
                <asp:GridView ID="student_data_grid" Visible="false" runat="server"  CssClass="gridview"  AutoGenerateColumns="false" DataKeyNames="ECSM_SCHOOL_NO">

                    <Columns>
                        <asp:BoundField DataField="ECSM_SCHOOL_NO" HeaderText="SCHOOL NO" Visible="false" />
                        <asp:BoundField DataField="ECSD_SCHOOL_NAME" HeaderText="SCHOOL NAME" />
                        <asp:BoundField DataField="ECSM_STUDENT_ID" HeaderText="STUDENT ID" />
                        <asp:BoundField DataField="ECSM_STUDENT_FIRST_NAME" HeaderText="STUDENT FIRST NAME" />
                        
                        <asp:BoundField DataField="ECSM_STUDENT_CLASS" HeaderText="CLASS" />
                        <asp:BoundField DataField="ECSM_STUDENT_SECTION" HeaderText="SECTION" />
                        <asp:BoundField DataField="ECSM_STUDENT_AGE" HeaderText="AGE" />
                        <asp:BoundField DataField="ECSM_STUDENT_GENDER" HeaderText="GENDER" />
                        <asp:BoundField DataField="ECSM_STUDENT_PH_NUMBER" HeaderText="PHONENO" />
                       
                        <asp:TemplateField HeaderText="DELETE" HeaderStyle-CssClass="newgrid">
							<ItemTemplate>
								<asp:ImageButton ID="deletebtn" ImageUrl="~/img/delete.png" runat="server" CommandName="DeleteStudent" CommandArgumen='<%# Eval("ECSM_SCHOOL_NO") %>' CssClass="iconcss" OnClick="deletebtn_Click"   />
                                
							</ItemTemplate>
						</asp:TemplateField>
                    </Columns>

                </asp:GridView>
           
                 </div>
</div>

        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="HiddenField2" runat="server" />
        <%-------------------------------- studentdetail dashboard EDIT----------------------------------------%>
     <div class="row" style="margin-left: 13%;">

           <div>
                <asp:DropDownList ID="sch_name_edit" Visible="false" Width="185px" Height="36px" CssClass="txtstyle" runat="server">
                </asp:DropDownList>
            </div>

            <div style="margin-left: 50px">
                <asp:DropDownList ID="std_cls_edit" Visible="false" Width="185px" Height="36px" CssClass="txtstyle" runat="server">
                </asp:DropDownList>
            </div>

            <div style="margin-left: 50px">
                <asp:DropDownList ID="std_sec_edit" Visible="false" Width="185px" Height="36px" CssClass="txtstyle" runat="server">
                </asp:DropDownList>
            </div>

            <div style="margin-left: 50PX">
                <asp:Button ID="std_search_edit" Visible="false" runat="server" Text="Search" CssClass="ser_btn" OnClick="STU_SEARCH_EDIT_Click" />
            </div>

        </div>
         <div class="search-box" style="margin-left: 33%;">
            <asp:TextBox ID="Student_search" runat="server" Visible="false" placeholder="Search..." OnTextChanged="txtTextChanged" AutoPostBack="true" />

        </div>

                <br />
                <br />
     
        <div class="row" style="float: right;">
            
               <%-- <img id="std_edit_imgs" runat="server" visible="false" src="img/std_edi_img.png" alt="Image" width="300" height="300" />--%>
            
        </div>
        <div class="row" style="display: flex; justify-content: center;">
             <div>
                <asp:GridView ID="GridView_Edit" Visible="false" runat="server"  CssClass="gridview"  AutoGenerateColumns="false" OnRowEditing="gridView_RowEditing" OnRowUpdating="gridView_RowUpdating" OnRowCancelingEdit="gridView_RowCancelingEdit" DataKeyNames="ECSM_SCHOOL_NO,ECSM_STUDENT_ID" >

                    <Columns>
                        <asp:BoundField DataField="ECSM_SCHOOL_NO" HeaderText="SCHOOL NO" ReadOnly="true" Visible="false" />
                        
                         <asp:BoundField DataField="ECSD_SCHOOL_NAME" HeaderText="SCHOOL NAME" ReadOnly="true" Visible="true" />
                        
                         <asp:BoundField DataField="ECSM_STUDENT_ID" HeaderText="STUDENT ID" ReadOnly="true" Visible="true" />

                         <asp:TemplateField HeaderText=" STUDENT FIRST NAME ">
                        <ItemTemplate>
                            <asp:Label ID="lblstd_first_name" runat="server" Text='<%# Eval("ECSM_STUDENT_FIRST_NAME") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_first_name" runat="server" Text='<%# Bind("ECSM_STUDENT_FIRST_NAME") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>    


                          

                        <asp:TemplateField HeaderText="CLASS ">
                        <ItemTemplate>
                            <asp:Label ID="lblstd_Class" runat="server" Text='<%# Eval("ECSM_STUDENT_CLASS") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_Class" runat="server" Text='<%# Bind("ECSM_STUDENT_CLASS") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>    


                          <asp:TemplateField HeaderText="SECTION">
                        <ItemTemplate>
                            <asp:Label ID="lblstd_section" runat="server" Text='<%# Eval("ECSM_STUDENT_SECTION") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_section" runat="server" Text='<%# Bind("ECSM_STUDENT_SECTION") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>  

                        <asp:TemplateField HeaderText="AGE">
                        <ItemTemplate>
                            <asp:Label ID="lblstd_age" runat="server" Text='<%# Eval("ECSM_STUDENT_AGE") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_age" runat="server" Text='<%# Bind("ECSM_STUDENT_AGE") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>    


                          <asp:TemplateField HeaderText="GENDER">
                        <ItemTemplate>
                            <asp:Label ID="lblstd_gender" runat="server" Text='<%# Eval("ECSM_STUDENT_GENDER") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_gender" runat="server" Text='<%# Bind("ECSM_STUDENT_GENDER") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>  

                           <asp:TemplateField HeaderText="PHONENO">
                        <ItemTemplate>
                            <asp:Label ID="lblstd_Phno" runat="server" Text='<%# Eval("ECSM_STUDENT_PH_NUMBER") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_Phno" runat="server" Text='<%# Bind("ECSM_STUDENT_PH_NUMBER") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>  
                        
                        <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:ImageButton ID="btnEdit" runat="server" CommandName="Edit" ImageUrl="~/img/std_edit_i.png" ToolTip="Edit" CssClass="iconcss" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <!-- Additional controls for editing, if needed -->
                                <asp:LinkButton ID="btnUpdate" runat="server" CommandName="Update" Text="Update" />
                                <asp:LinkButton ID="btnCancel" runat="server" CommandName="Cancel" Text="Cancel" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                      <%--  <asp:CommandField ShowEditButton="true"  ButtonType="Button"/>--%>

             
                     
                       
                    </Columns>

                </asp:GridView>
         
                 </div>
</div>
         <asp:HiddenField ID="HiddenField3" runat="server" />
        <asp:HiddenField ID="HiddenField4" runat="server" />
</div>

        
     <%-------------------------------- studentdetail dashboard ADD----------------------------------------%>

    <div class="container">
         <div class="row" style="margin-left: 13%;">
            <div >
                <asp:Label ID="SCH_DOC_ID" runat="server" Visible="false" Text="SELECT  SCHOOL NAME " CssClass="label-style"></asp:Label>
            </div>

            <div style="margin-left: 177px">
                <asp:DropDownList ID="SCH_DROPDOWN"  Visible="false" CssClass="txtstyle" runat="server"></asp:DropDownList>
            </div>
        </div>

 <%--   <div class="std_img">
        <div style="float: right;">
            <img id="stdImage" runat="server" visible="false" src="img/std_pic.jpg" alt="Image" width="400" height="400" />
        </div>
    </div>--%>
       
        <br />
        <br />
        <div class="row" style="margin-left: 13%;">
            <div >
                <asp:Label ID="STD_FIRST_NAME_LB" runat="server" Visible="false" Text="STUDENT FIRST NAME" CssClass="label-style"></asp:Label>
            </div>

            <div style="margin-left: 173px">
                <asp:TextBox ID="STD_FIRST_NAME" runat="server" Visible="false" CssClass="txtstyle"></asp:TextBox>
            </div>

        </div>

       

        <br />
        <br />
        <div class="row" style="margin-left: 13%;">

            <div >
                <asp:Label ID="STD_CLASS_LB" runat="server" Visible="false" Text="STUDENT CLASS " CssClass="label-style"></asp:Label>
            </div>
            <div style="margin-left: 221px">
                <asp:TextBox ID="STD_CLASS" runat="server" Visible="false" CssClass="txtstyle"></asp:TextBox>
            </div>
        </div>

        <br />
        <br />

        <div class="row" style="margin-left: 13%;">
            <div >
                <asp:Label ID="STD_SECTION_LB" runat="server" Visible="false" Text="STUDENT SECTION" CssClass="label-style"></asp:Label>
            </div>
            <div style="margin-left: 198px">
                <asp:TextBox ID="STD_SECTION" runat="server" Visible="false" CssClass="txtstyle"></asp:TextBox>
            </div>
        </div>
        <br />
        <br />
        <div class="row" style="margin-left: 13%;">

            <div>
                <asp:Label ID="STD_GENDER_LB" runat="server" Visible="false" Text="STUDENT GENDER" CssClass="label-style"></asp:Label>
            </div>

            <div style="margin-left: 245px">
                <div class="radio-container">
                    <asp:RadioButton ID="STD_GENDER_MALE" runat="server" Visible="false" Text="Male" GroupName="genderGroup" CssClass="radiobtn-style" />
                </div>
                <div class="radio-container">
                    <asp:RadioButton ID="STD_GENDER_FEMALE" runat="server" Visible="false" Text="Female" GroupName="genderGroup" CssClass="radiobtn-style" />
                </div>
            </div>

        </div>

        <br />
        <br />
        <div class="row" style="margin-left: 13%;">

           <div >
                <asp:Label ID="STD_AGE_LB" runat="server" Visible="false" Text="STUDENT AGE" CssClass="label-style"></asp:Label>
            </div>

            <div style="margin-left: 238px">
                <asp:TextBox ID="STD_AGE" runat="server" Visible="false" CssClass="txtstyle"></asp:TextBox>
            </div>

        </div>
        <br />
        <br />
        <div class="row" style="margin-left: 13%;">

            <div>
                <asp:Label ID="STD_PH_NUM_LB" runat="server" Visible="false" Text="STUDENT PHONE NUMBER " CssClass="label-style"></asp:Label>
            </div>

            <div style="margin-left: 142px">
                <asp:TextBox ID="STD_PH_NUM" runat="server" Visible="false" CssClass="txtstyle"></asp:TextBox>
            </div>

        </div>



        <br />
        <br />

        <div class="row"style="margin-left: 240px">

            <asp:Button ID="STD_DETAIL_SAVE" runat="server" Text="SAVE" Visible="false" CssClass="button-style" OnClick="std_detail_save_click" />

        </div>
    </div>
       
       
       
     
   



    
<script src="https://code.jquery.com/jquery-3.6.0.min.js" integrity="sha256-oLS6euCEKXpSTI60p6DZbNV95zNp87OZOr+FO0m61s8=" crossorigin="anonymous"></script>
<script type="text/javascript">
	$(document).ready(function () {
		// Function to filter the GridView based on the entered text
		$("#<%= txtStudentNameSearch.ClientID %>").on("input", function () {
			var searchText = $(this).val().toLowerCase();
			$("#<%= student_data_grid.ClientID %> tr:gt(0)").each(function () {
				var rowText = $(this).text().toLowerCase();
				$(this).toggle(rowText.indexOf(searchText) > -1);
			});
		});
	});
</script>

    <script type="text/javascript">
        $(document).ready(function () {
            // Function to filter the GridView based on the entered text
            $("#<%= Student_search.ClientID %>").on("input", function () {
            var searchText = $(this).val().toLowerCase();
            $("#<%= GridView_Edit.ClientID %> tr:gt(0)").each(function () {
                    var rowText = $(this).text().toLowerCase();
                    $(this).toggle(rowText.indexOf(searchText) > -1);
                });
            });
        });
    </script>
   
   
</asp:Content>


    



