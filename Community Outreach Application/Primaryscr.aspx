<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Primaryscr.aspx.cs" Inherits="Primaryscr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css" />
	
	<script src="https://code.jquery.com/jquery-3.6.0.min.js" integrity="sha256-oTu1Z5KQ88HX+oWUE/hhAXL4a9ZWEA4WKZnJZ4BJ5cI=" crossorigin="anonymous"></script>
	 <script src="https://code.jquery.com/jquery-3.6.0.min.js" integrity="sha256-oPNsK1GR5v47Zjwuv3Zaf7Ll9dM2JAzdGp1adTzggzs=" crossorigin="anonymous"></script>

	    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/jquery@3.6.4/dist/jquery.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

	<link href="css/NormalCase.css" rel="stylesheet" />
	<link href="css/Radiobtnsty.css" rel="stylesheet" />
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

		.ser_btn {
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

		.ser_btnone {
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

		.ser_btnyes {
			background-color: white;
			color: #af4ca9;
		}

		.ser_btnno {
			background-color: white;
			color: #cb0505;
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
	<style>
		.modal {
			display: none;
			position: fixed;
			z-index: 1;
			left: 0;
			top: 0;
			width: 100%;
			height: 100%;
			overflow: auto;
			background-color: rgba(0, 0, 0, 0.5);
		}

		.modal-content {
			background-color: #fefefe;
			margin: 1% auto;
			padding: 20px;
			border: 1px solid #888;
			width: 80%;
		}

		.close {
			color: #aaa;
			float: right;
			font-size: 28px;
			font-weight: bold;
		}

			.close:hover,
			.close:focus {
				color: black;
				text-decoration: none;
				cursor: pointer;
			}

		.left-column {
			float: left;
			width: 50%;
			text-align: center;
			/* Additional styling for the left side */
		}

		.right-column {
			float: left;
			width: 50%;
			/* Additional styling for the right side */
		}
	</style>

	<style>
		.formdesign {
			background-color: #f2f2f2;
		}

		.custom-label {
			color: #ff0000; /* Replace with your desired label text color */
		}
	</style>

	<style>
		.modall {
			display: none;
			position: fixed;
			z-index: 1;
			left: 0;
			top: 0;
			width: 100%;
			height: 100%;
			overflow: auto;
			background-color: rgba(0, 0, 0, 0.4);
		}

		.modal-contentone {
			background-color: #fefefe;
			margin: 10% auto;
			padding: 20px;
			border: 1px solid #888;
			width: 300px;
			max-width: 80%;
			text-align: center;
			border-radius: 5px;
			width: 23%;
			margin-top: 17%;
		}

		.closee {
			color: #aaa;
			float: right;
			font-size: 28px;
			font-weight: bold;
			cursor: pointer;
		}

		.close:hover,
		.close:focus {
			color: black;
			text-decoration: none;
			cursor: pointer;
		}

		.modal-buttons {
			margin-top: 20px;
		}

		.btn-confirm,
		.btn-cancel {
			padding: 10px 20px;
			margin: 0 10px;
			border-radius: 5px;
			cursor: pointer;
		}

		.btn-confirmm {
			background-color: #4caf50;
			color: white;
			width: 40%;
			height: 30px;
			border: 1px solid transparent;
			border-radius: 4px;
		}

		.btn-cancell {
			background-color: #cb0202;
			color: white;
			width: 40%;
			height: 30px;
			border: 1px solid transparent;
			border-radius: 4px;
		}
	</style>

	<style>
    /* Default styles for all screen sizes */
    .threedivsec {
        display: flex;
        justify-content: space-between;
    }

    .left,
    .center,
    .right {
        flex-basis: 33.33%;
    }

    .row {
        display: flex;
        align-items: center;
    }

    /* Media query for screens with a maximum width of 1280x600 */
    @media screen and (max-width: 1280px) and (max-height: 800px) {
        .threedivsec {
            flex-direction: column;
            align-items: center;
        }

        .left,
        .center,
        .right {
            flex-basis: 100%;
            margin-bottom: 10px;
        }

        /* Align labels to the left */
        .row > div:first-child {
            text-align: left;
        }
    }
</style>

	<style>
		.oddesign {
			margin-left: 106px;
			background-color: #1a8bab;
		}

		.osdesign {
			margin-left: 53px;
			/*background-color: #19d1ad;*/
		}

		.osdesignos {
			margin-left: 53px;
			/*background-color: #19d1ad;*/
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
				width: 100%;
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

   



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div class="container"> 
		<h2 class="txtcnter">PRIMARY SCREEN DASHBOARD </h2>
		<hr />
		<br />
		<br />
		<br />
		<div class="container">

			<div id="page2">

				<div class="row" style="margin-left: 231px;">
					<div>
						<asp:DropDownList ID="SEL_SCHOOL" Width="154px" Height="36px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="SEL_SCHOOL_SelectedIndexChanged">
                        </asp:DropDownList>
					</div>

					<div style="margin-left: 50px">
						<asp:DropDownList ID="SEL_CLASS" Width="125px" Height="36px" runat="server">
						</asp:DropDownList>
					</div>

					<div style="margin-left: 50px">
						<asp:DropDownList ID="SEL_SECTION" Width="125px" Height="36px" runat="server">
						</asp:DropDownList>
					</div>

					<div style="margin-left: 50PX">
						<asp:Button ID="STU_SEARCH" runat="server" Text="Search" CssClass="ser_btn" OnClick="STU_SEARCH_Click" />
					</div>
				</div>
				<br />


				  <div class="search-box" style="margin-left: 409px;  width: 172px;">
					<asp:TextBox ID="txtStudentNameSearch" runat="server"  placeholder="Search..." OnTextChanged="txtStudentNameSearch_TextChanged" AutoPostBack="true" />
                   <div class="search-icon"></div>
                 </div>

				<div>
					
				</div>

				<br />
				<div class="row">
					<div style="margin-left: 199px;" >
						<asp:Label ID="studentIdcount" runat="server" Text=""></asp:Label>
				</div>
				<div style="margin-left:50px;">
					<asp:Label ID="yescount" runat="server" Text="" CssClass="ser_btnyes" ></asp:Label> 
					
				</div>  
					<div style="margin-left:50px;">
						<asp:Label ID="nocount" runat="server" Text="" CssClass="ser_btnno"></asp:Label>
					</div>
				</div>
				<br />
				<br />

				<asp:GridView ID="student_data_grid" runat="server" OnRowCommand="student_data_grid_RowCommand"  OnRowDataBound="student_data_grid_RowDataBound" CssClass="gridview" AutoGenerateColumns="false">

					
					<Columns>
						<asp:BoundField DataField="ECSD_SCHOOL_NO" HeaderText="SCHOOL NO" Visible="false"  />
						<asp:BoundField DataField="ECSD_SCHOOL_NAME" HeaderText="SCHOOLNAME"  />
						<asp:BoundField DataField="ECSM_STUDENT_ID" HeaderText="STUDENT ID"  />
						<asp:BoundField DataField="ECSM_STUDENT_FIRST_NAME" HeaderText="STUDENTNAME"  />
						<asp:BoundField DataField="ECSM_STUDENT_CLASS" HeaderText="CLASS"  />
						<asp:BoundField DataField="ECSM_STUDENT_SECTION" HeaderText="SECTION"  />
						<asp:BoundField DataField="ECSM_STUDENT_AGE" HeaderText="AGE"  />
						<asp:BoundField DataField="ECSM_STUDENT_GENDER" HeaderText="GENDER"  />
						
						<asp:BoundField DataField="ECSM_STUDENT_STATUS_FLAG" HeaderText="STATUS FLAG"  />

						<asp:TemplateField HeaderText="MAKE ENTRY'S" HeaderStyle-CssClass="newgrid">
							<ItemTemplate>
								<asp:ImageButton ID="Mkentrybtn" ImageUrl="~/img/MAKE_ENTER.png" runat="server" CommandName="SELECT" CommandArgument="<%# Container.DataItemIndex %>" CssClass="iconcss" OnClick="Mkentrybtn_Click" />
							</ItemTemplate>
						</asp:TemplateField>

						<asp:TemplateField HeaderText="ABSENT" HeaderStyle-CssClass="newgrid">
							<ItemTemplate>
								<asp:ImageButton ID="absentButton" ImageUrl="~/img/absent.png" runat="server" CommandName="ABSENT" CommandArgument="<%# Container.DataItemIndex %>" CssClass="iconcss"  OnClick="absentButton_Click"   />
							</ItemTemplate>
						</asp:TemplateField>

						<asp:TemplateField HeaderText="DELETE" HeaderStyle-CssClass="newgrid">
							<ItemTemplate>
								<asp:ImageButton ID="deletebtn" ImageUrl="~/img/delete.png" runat="server" CssClass="iconcss" OnClick="deletebtn_Click"   />
							</ItemTemplate>
						</asp:TemplateField>

						
					</Columns>
				</asp:GridView>

				<div class="container"> 
                <div class="body">
                <div class="modal fade" "bd-example-modal-lg" id="myModal1" tabindex="-2" role="dialog" 
                    aria-labelledby="myModalLabel" aria-hidden="true">
					
                    <div class="modal-dialog modal-lg modal-dialog modal-dialog-centered">
                        <div class="modal-content">
                            <div class="modal-header">
                               <%-- <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times; </button>--%>
                                <h4 class="modal-title" id="modalTitle1" style="text-align:center"></h4>
								<hr />
								<div class="row">
									<div class="left-column">

										<asp:Label ID="Label6" runat="server" CssClass="custom-label" Text="School Name:"></asp:Label>

										<asp:Label ID="sch_name_lbl" runat="server" Text="Label"></asp:Label>
										<br />
										<asp:Label ID="Label1" runat="server" CssClass="custom-label" Text="Student Name:"></asp:Label>
								        <asp:Label ID="STU_NAME" runat="server" Text=""></asp:Label>

										<asp:HiddenField ID="SCHOOL_NO" runat="server" />
										<asp:HiddenField ID="STU_ID_HID" runat="server" />
									</div>

									<div class="right-column">
										<asp:Label ID="Label3" runat="server" CssClass="custom-label" Text="Student ID:"></asp:Label>
										<asp:Label ID="stu_id" runat="server" Text="Label"></asp:Label>
										<br />

									<asp:Label ID="Label2" runat="server" CssClass="custom-label" Text="Class:"></asp:Label>
								    <asp:Label ID="STU_CLASS" runat="server" Text="Label"></asp:Label>
									<asp:Label ID="stu_sec" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="STU_GEN" runat="server" Text="" Style="margin-left:45px"  ></asp:Label>
									</div>
								</div>
								<br />
					
								<hr />
                            </div>
							<div class="formdesign">

                            <div class="modal-body">
                                <div class="container">

									<div class="row">

										<div class="custom-checkbox" style="margin-left: 7%;">
											<asp:CheckBox ID="Nrl_cs" runat="server" Text="Normal Case" onclick="handleCheckboxClick()" />
											</div>
										
										<div style="margin-left:24%">
												<asp:Button ID="SV_BTN" runat="server" Text="SAVE" CssClass="ser_btnone" OnClick="SV_BTN_Click" Visible="false"  />
										</div>
										
										
										<div style="margin-left:30%">
											<asp:LinkButton ID="modelclose" runat="server" CssClass="closee" OnClick="modelclose_Click">&times;</asp:LinkButton>
										</div>
										
										

										<asp:HiddenField ID="HIDE_VAL" runat="server" />
									</div>
									<br />									
									<div class="row">
										<div >
											<asp:Label ID="spc_lbl" runat="server" Text="USING SPECTACLES"></asp:Label>
										</div>
										<div style="margin-left: 193px">
											<div class="custom-radiobuttonlist-alt">
												<asp:RadioButtonList ID="spcradio" runat="server" RepeatDirection="Horizontal" onchange="changeDetailexam()">
												<asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
												<asp:ListItem Value="No" Text="No"></asp:ListItem>
											    </asp:RadioButtonList>
										   </div>
											
										</div>
									</div>
									<br />									
                                   <div class="row">
									   <div>
										   <asp:Label ID="without_spc_LBL" runat="server" Text="DOES THE CHILD READ 0.20 LOGMAR?"></asp:Label>
									   </div>
									   
									   <div style="margin-left:49px">
										   <asp:Label ID="Label7" runat="server"  Text="OD [ RE ]" CssClass="osdesign" ></asp:Label>
										   <br />

										  <%-- <asp:DropDownList ID="WITHOUT_ODRE" runat="server" Width="300px" Height="36px" onchange="withoutOdreChanged()" >
											 
										   </asp:DropDownList>--%>
									   <div class="custom-radiobuttonlist-alt">
												<asp:RadioButtonList ID="WITHOUT_ODRE" runat="server" RepeatDirection="Horizontal" onchange="withoutOdreChanged()">
													<asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
													<asp:ListItem Value="No" Text="No"></asp:ListItem>
												   </asp:RadioButtonList>
											  </div>
									   </div>
									   <div style="margin-left: 45px">
										   <asp:Label ID="Label8" runat="server" CssClass="osdesignos"  Text="OS  [ LE ]"></asp:Label>
										   <br />
										 <%--  <asp:DropDownList ID="WITHOUT_OSLE" runat="server" Width="300px" Height="36px" onchange="withoutOsleChanged()">
											  
										   </asp:DropDownList>--%>
											 <div class="custom-radiobuttonlist-alt">
												  <asp:RadioButtonList ID="WITHOUT_OSLE" runat="server" RepeatDirection="Horizontal" onchange="withoutOsleChanged()">
													<asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
													<asp:ListItem Value="No" Text="No"></asp:ListItem>
												  </asp:RadioButtonList>
											</div>
									   </div>
                                   </div>
									<br />
									
									<br />
									<div class="row">
										<div>
											<asp:Label ID="VAL_TEST_LBL" runat="server" Text=" DOES THE CHILD READ WITH +1.50DS "></asp:Label>
										</div>
										<div style="margin-left: 55px">
											
											<br />
											
											<div class="custom-radiobuttonlist-alt">
													<asp:RadioButtonList ID="VALTST_ODRE" runat="server" RepeatDirection="Horizontal" onchange="Testodchange()">
														<asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
														<asp:ListItem Value="No" Text="No"></asp:ListItem>
													</asp:RadioButtonList>
											</div>
										</div>
										<div style="margin-left: 45px">
										
											<br />
											
										   <div class="custom-radiobuttonlist-alt">
												<asp:RadioButtonList ID="VALTST_OSLE" runat="server" RepeatDirection="Horizontal" onchange="Testoschange()">
													<asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
													<asp:ListItem Value="No" Text="No"></asp:ListItem>
												</asp:RadioButtonList>
											</div>
										</div>
									</div>
									<br />
									<div class="row">
										<div>
											<asp:Label ID="oc_complain" runat="server" Text="OCULAR COMPLAINT"></asp:Label>
										</div>
										<div style="margin-left: 175px">
											<div class="custom-radiobuttonlist-alt">
												<asp:RadioButtonList ID="occomplain" runat="server" RepeatDirection="Horizontal" onchange="complainChanged()" >
												
												<asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
												<asp:ListItem Value="No" Text="No"></asp:ListItem>
											</asp:RadioButtonList>
											</div>
											
										</div>
									</div>
									<br />
									<div class="row">
										<div>
											<asp:Label ID="tle_exam" runat="server" Text="TORCH LIGHT EXAMINATION"></asp:Label>
										</div>
										<div style="margin-left: 15px">
									
											<br />
										
									    	<div class="custom-radiobuttonlist-alt">
													 <asp:RadioButtonList ID="TLEEXAM_ODRE" runat="server" RepeatDirection="Horizontal" onchange="abnormalODDropdownChanged()" ClientIDMode="Static">
														<asp:ListItem Value="Normal" Text="Normal"></asp:ListItem>
														<asp:ListItem Value="Abnormal" Text="Abnormal"></asp:ListItem>
													 </asp:RadioButtonList>
												</div>
										</div>
										<div style="margin-left: 30px">
										
											<br />
											
												<div class="custom-radiobuttonlist-alt">
														<asp:RadioButtonList ID="TLEEXAM_OSLE" runat="server" RepeatDirection="Horizontal" onchange="abnormalOSDropdownChanged()" ClientIDMode="Static" >
															<asp:ListItem Value="Normal" Text="Normal"></asp:ListItem>
															<asp:ListItem Value="Abnormal" Text="Abnormal"></asp:ListItem>
														</asp:RadioButtonList>
												</div>
										</div>
									</div>
									<br />
									<div class="row">
										<div>
											<asp:Label ID="Label4" runat="server" Text="ABNORMAL REMARKS:"></asp:Label>
										</div>
										<div style="margin-left: 15px; "  id="additionalElements">
										
											<br />
											<asp:DropDownList ID="ABNORMAL_DROPOD" runat="server" Width="150px" Height="36px" ClientIDMode="Static" >
												
											</asp:DropDownList>
										</div>
										<div style="margin-left: 20px; "  id="additionalE" >
								
											<br />
											<asp:DropDownList ID="ABNORMAL_DROPOS" runat="server" Width="150px" Height="36px" ClientIDMode="Static">
												
											</asp:DropDownList>
										</div>
									</div>
									<br />

									<div class="threedivsec">

										<div class="left">
											<div class="row">
										<div>
											<asp:Label ID="Label5" runat="server" Text="COVER TEST"></asp:Label>
										</div>
										<div>
											<asp:DropDownList ID="covertest" runat="server" Width="103px" Height="36px">
												
                                                 
											</asp:DropDownList>
											
										</div>
									
									</div>
									    </div>
										<div class="center">
												<div class="row">
										<div>
											<asp:Label ID="STD_MIM_LBL" runat="server" Text="MIM"></asp:Label>
										</div>
										<div >
											<asp:DropDownList ID="STD_MIM_DROP_DOWN" runat="server" Width="103px" Height="36px">
												
											</asp:DropDownList>
										</div>
									</div>
										</div>
										<div class="right">
													<div class="row" style="margin-left: -65px;">
										<div>
											<asp:Label ID="NPC_LBL" runat="server" Text="NPC"></asp:Label>
										</div >
										<div >
											<asp:DropDownList ID="NPC_DROP_DOWN" runat="server" Width="103px" Height="36px">
												
												
											</asp:DropDownList>
										</div>
										
									</div>
										</div>

										<div class="right">
											<div class="row">
												<div class="row">
										<div style=" margin-left: -92px;">
											<asp:Label ID="STD_ACCOM_FA_LBL" runat="server" Text="ACCOMMODATIVE FACILITY"></asp:Label>
										</div>
										<div >
											<asp:DropDownList ID="STD_ACCOM_FA_DROP_DOWN" runat="server" Width="103px" Height="36px">
												
											</asp:DropDownList>
										</div>
									</div>
											</div>

										</div>
									</div>

									
									<br />

									<div class="threedivsec">

										 <div class="left">
													<div class="row">
										<div>
											<asp:Label ID="STD_SYSP_LBL" runat="server" Text="SYMPTOMS"></asp:Label>
										</div>
										<div style="margin-left: 30px">
											<asp:DropDownList ID="STD_SYSP_DROP_DOWN" runat="server" Width="103px" Height="36px">
												
											</asp:DropDownList>
										</div>
									</div>
										</div>

										<div class="center">
												<div class="row">
										<div>
											<asp:Label ID="STD_CL_VSD_LBL" runat="server" Text="COLOR VISION (DALTON)"></asp:Label>
										</div>
										<div style="margin-left: 30px">
											<asp:DropDownList ID="STD_CL_VSD_DROP_DOWN" runat="server" Width="103px" Height="36px">
												
											</asp:DropDownList>
										</div>
									</div>	
										</div>

										<div class="right">
												<div class="row">
										<div>
											<asp:Label ID="STD_CL_VSI_LBL" runat="server" Text="COLOR VISION (ISHIHARA)"></asp:Label>
										</div>
										<div style="margin-left: 30px">
											<asp:DropDownList ID="STD_CL_VSI_DROP_DOWN" runat="server"  Width="103px" Height="36px">
												
											</asp:DropDownList>
										</div>
									</div>	
									   </div>

									</div>
									<br />
									<div class="threedivsec">
										 <div class="left">
													<div class="row">
										<div>
											<asp:Label ID="Label17" runat="server" Text="DETAILED EXAMINATION REQUIRED"></asp:Label>
										</div>
										<div style="margin-left: 5px">
											<div class="custom-radiobuttonlist">
                                                    <asp:RadioButtonList ID="Detailexam" runat="server" RepeatDirection="Horizontal" >
                                                    <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                                                    <asp:ListItem Value="No" Text="No"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                            </div>
										</div>
									</div>
										</div>

										<div class="center">
												<div class="row">
										<div>
											
										</div>
										<div style="margin-left: 196px">
											<div class="txtcnter">
												<asp:Button ID="STU_CHECKUP_DTLS" runat="server" Text="SAVE" CssClass="ser_btnone" OnClick="STU_CHECKUP_DTLS_Click" />
												<div id="validationMessages" class="text-danger"></div>
											</div>
											<div class="txtcnter" style="margin-left:30px">
												<asp:Button ID="stu_checkup_update" runat="server" Text="update" Visible="false" CssClass="ser_btnone" OnClick="stu_checkup_update_Click" />
											</div>
										</div>
									</div>	
										</div>
										<div class="right">

											</div>

								</div>
									<br />							
											
                                </div>                            
                             </div> 
								</div>
							<br />
							
                           <div class="modal-footer">
							   <div style="text-align:end;">
								    <button type="button" data-dismiss="modal"  class="closbtn">  CLOSE </button>
							   </div>
                            </div>
                        </div>               
                    </div>
                 </div>
                </div>


					<asp:HiddenField ID="preandsbcstuis" runat="server" />

					<div class="modal fade" "bd-example-modal-lg" id="myModal2" tabindex="-2" role="dialog" 
                    aria-labelledby="myModalLabel" aria-hidden="true">
                    <div class="modal-dialog modal-lg modal-dialog modal-dialog-centered">
                              <div class="modal-contentone">
				 <asp:LinkButton ID="closeBtn" runat="server" CssClass="closee" OnClick="closeBtn_Click">&times;</asp:LinkButton>
				<h2>Confirm Action</h2>
				<p>Are you sure you want to mark as absent?</p>
				<div class="modal-buttons">
					<asp:Button ID="cancelBtn" runat="server" Text="Absent" class="btn-cancell" OnClick="cancelBtn_Click" />
					<asp:Button ID="confirmBtn" runat="server" Text="Present" class="btn-confirmm" OnClick="confirmBtn_Click" />

				</div>
			</div>        
                    </div>
                 </div>

					<div>
						<asp:GridView ID="GridView1" runat="server" Visible="false"></asp:GridView>
						<asp:HiddenField ID="savedRowID" runat="server" />
					</div>


					<script>
						function showValidationAlert() {
							var validationMessage = "Please select."; // Replace this with your validation message
							document.getElementById("validationMessages").innerText = validationMessage;
						}

					</script>

					<%--<script>
    function abnormalODDropdownChanged() {
        var radioButtonList = document.getElementById('TLEEXAM_ODRE');
        var dropdownList = document.getElementById('ABNORMAL_DROPOD');

        if (radioButtonList) {
            if (radioButtonList.value === 'Abnormal') {
                dropdownList.disabled = false; // Enable the dropdown
            } else {
                dropdownList.disabled = true; // Disable the dropdown
            }
        }
    }
</script>--%>

					



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
						function closeModal() {
							$('#myModal2').modal('hide');
						}
                  </script>

					 
				<script>
					$(document).ready(function () { $("#SEL_SCHOOL").select2(); });
					$(document).ready(function () { $("#SEL_CLASS").select2(); });
					$(document).ready(function () { $("#SEL_SECTION").select2(); });
				</script>

				<!-- JavaScript to handle the modal popup -->
				<script>
					// Function to show the modal popup
					function showModal(event) {
						var modal = document.getElementById("myModal");
						modal.style.display = "block";
						return false;
					}

					// Function to close the modal popup
					function closeModal() {
						var modal = document.getElementById("myModal");
						modal.style.display = "none";
					}

				</script>

					<script type="text/javascript">
						function handleCheckboxClick() {

							var checkbox = document.getElementById('<%= Nrl_cs.ClientID %>');

							var radioButtonList = document.getElementById('<%= spcradio.ClientID %>');

							var OCCOMP = document.getElementById('<%= occomplain.ClientID %>');

							var Detailsexam = document.getElementById('<%= Detailexam.ClientID %>');



							var withoutspeod = document.getElementById('<%= WITHOUT_ODRE.ClientID %>');
							var withoutspeos = document.getElementById('<%= WITHOUT_OSLE.ClientID %>');

							<%--var withspcod = document.getElementById('<%= WITH_ODRE.ClientID %>');
							var withspcos = document.getElementById('<%= WITH_OSLE.ClientID %>');--%>


							var pltestod = document.getElementById('<%= VALTST_ODRE.ClientID %>');
							var pltestos = document.getElementById('<%= VALTST_OSLE.ClientID %>');

							var tleod = document.getElementById('<%= TLEEXAM_ODRE.ClientID %>');

							var tleos = document.getElementById('<%= TLEEXAM_OSLE.ClientID %>');

							var abnormalod = document.getElementById('<%= ABNORMAL_DROPOD.ClientID %>');

							var abnormalos = document.getElementById('<%= ABNORMAL_DROPOS.ClientID %>');

							var covtst = document.getElementById('<%= covertest.ClientID %>');

							var stddro = document.getElementById('<%= STD_MIM_DROP_DOWN.ClientID %>');

							var npcdro = document.getElementById('<%= NPC_DROP_DOWN.ClientID %>');

							var accofadrp = document.getElementById('<%= STD_ACCOM_FA_DROP_DOWN.ClientID %>');

							var clvsysptom = document.getElementById('<%= STD_SYSP_DROP_DOWN.ClientID %>');

							var clvsiDalton = document.getElementById('<%= STD_CL_VSD_DROP_DOWN.ClientID %>');

							var clvsiIshihara = document.getElementById('<%= STD_CL_VSI_DROP_DOWN.ClientID %>');

							



							if (checkbox.checked) {

								abnormalod.disabled = true;

								abnormalos.setAttribute('disabled', 'disabled');

								var yesRadioButton = radioButtonList.querySelector("input[value='No']");
								yesRadioButton.checked = checkbox.checked;

								var OCCOMPVAR = OCCOMP.querySelector("input[value='No']");
								OCCOMPVAR.checked = checkbox.checked;


								var detailsexamval = Detailsexam.querySelector("input[value='No']");
								detailsexamval.checked = checkbox.checked;

								var withoutod = withoutspeod.querySelector("input[value='Yes']");
								withoutod.checked = checkbox.checked;

								var withoutos = withoutspeos.querySelector("input[value='Yes']");
								withoutos.checked = checkbox.checked;

								var potestvalod = pltestod.querySelector("input[value='No']");
								potestvalod.checked = checkbox.checked;

								var potestvalos = pltestos.querySelector("input[value='No']");
								potestvalos.checked = checkbox.checked;

								var abremorkod = tleod.querySelector("input[value='Normal']");
								abremorkod.checked = checkbox.checked;

								var abremorkos = tleos.querySelector("input[value='Normal']");
								abremorkos.checked = checkbox.checked;

								//withoutspeod.value = "Yes";
								//withoutspeos.value = "Yes";

								//withspcod.value = "Inactive";
								//withspcos.value = "Inactive";

								//pltestod.value = "No";
								//pltestos.value = "No";

								//tleod.value = "Normal";
								//tleos.value = "Normal";

								abnormalod.value = "Inactive"
								abnormalos.value = "Inactive"

								covtst.value = "Ortho";

								stddro.value = "0";

								npcdro.value = "TTN";

								accofadrp.value = "Not done";

								clvsysptom.value = "No Symptoms";

								clvsiDalton.value = "4/4"
								clvsiIshihara.value = "NA";

								//Detailsexam.value = "No";
								
							}



							else {

								abnormalod.disabled = false;

								abnormalos.removeAttribute('disabled');

								var yesRadioButton = radioButtonList.querySelector("input[value='Yes']");
								yesRadioButton.checked = !checkbox.checked;

								var OCCOMPVAR = OCCOMP.querySelector("input[value='Yes']");
								OCCOMPVAR.checked = !checkbox.checked;

								var detailsexamval = Detailsexam.querySelector("input[value='Yes']");
								detailsexamval.checked = !checkbox.checked;

								var withoutod = withoutspeod.querySelector("input[value='No']");
								withoutod.checked = !checkbox.checked;

								var withoutos = withoutspeos.querySelector("input[value='No']");
								withoutos.checked = !checkbox.checked;

								var potestvalod = pltestod.querySelector("input[value='No']");
								potestvalod.checked = !checkbox.checked;

								var potestvalos = pltestos.querySelector("input[value='No']");
								potestvalos.checked = !checkbox.checked;

								var abremorkod = tleod.querySelector("input[value='Abnormal']");
								abremorkod.checked = !checkbox.checked;

								var abremorkos = tleos.querySelector("input[value='Abnormal']");
								abremorkos.checked = !checkbox.checked;

								//withoutspeod.value = "";
								//withoutspeos.value = "";

								//withspcod.value = "0";
								//withspcos.value = "0";

								//pltestod.value = "";
								//pltestos.value = "";

								//tleod.value = "";
								//tleos.value = "";

								abnormalod.value = ""
								abnormalos.value = ""

								covtst.value = "";

								stddro.value = "";

								npcdro.value = "";

								accofadrp.value = "";

								clvsysptom.value = "";

								clvsiDalton.value = ""
								clvsiIshihara.value = "";

								//Detailsexam.value = "";
								
							}
						}

					</script>

					    <script>
							function changeDetailexam() {
								var spcRadioValue = document.querySelector('[id$="spcradio"] input[name$="spcradio"]:checked').value;
								var detailexamRadios = document.querySelectorAll('[id$="Detailexam"] input[name$="Detailexam"]');

								if (spcRadioValue === "Yes") {
									detailexamRadios[0].checked = true; // Select "Yes" option
								} else {
									detailexamRadios[1].checked = true; // Select "No" option
								}
							}
						</script>

					 <script>
						 function complainChanged() {
							 var comRadioValue = document.querySelector('[id$="occomplain"] input[name$="occomplain"]:checked').value;
							 var comdetailexamRadios = document.querySelectorAll('[id$="Detailexam"] input[name$="Detailexam"]');

							 if (comRadioValue === "Yes") {
								 comdetailexamRadios[0].checked = true; // Select "Yes" option
							 } else {
								 comdetailexamRadios[1].checked = true; // Select "No" option
							 }
						 }
						</script>

					<script>
						function withoutOdreChanged() {
							var odwithoutValue = $("input[name$='WITHOUT_ODRE']:checked").val();
							var withoutdetailexamRadiod = $("input[name$='Detailexam']");

							if (odwithoutValue === "No") {
								withoutdetailexamRadiod.filter("[value='Yes']").prop("checked", true);
							} else {
								withoutdetailexamRadiod.filter("[value='No']").prop("checked", true);
							}
						}

						function withoutOsleChanged() {
							var oswithoutleValue = $("input[name$='WITHOUT_OSLE']:checked").val();
							var withoutosdetailexamRadios = $("input[name$='Detailexam']");

							if (oswithoutleValue === "No") {
								withoutosdetailexamRadios.filter("[value='Yes']").prop("checked", true);
							} else {
								withoutosdetailexamRadios.filter("[value='No']").prop("checked", true);
							}
						}

					</script>

					<script>
						function Testodchange() {
							var odtestValue = $("input[name$='VALTST_ODRE']:checked").val();
							var testdetailexamRadiod = $("input[name$='Detailexam']");

							if (odtestValue === "Yes") {
								testdetailexamRadiod.filter("[value='Yes']").prop("checked", true);
							} else {
								testdetailexamRadiod.filter("[value='No']").prop("checked", true);
							}
						}

						function Testoschange() {
							var ostestValue = $("input[name$='VALTST_OSLE']:checked").val();
							var testdetailexamRadios = $("input[name$='Detailexam']");

							if (ostestValue === "Yes") {
								testdetailexamRadios.filter("[value='Yes']").prop("checked", true);
							} else {
								testdetailexamRadios.filter("[value='No']").prop("checked", true);
							}
						}

					</script>


						<script>
							function abnormalODDropdownChanged() {
								var odreValue = $("input[name$='TLEEXAM_ODRE']:checked").val();
								var detailexamRadiod = $("input[name$='Detailexam']");

								if (odreValue === "Abnormal") {
									detailexamRadiod.filter("[value='Yes']").prop("checked", true);
								} else {
									detailexamRadiod.filter("[value='No']").prop("checked", true);
								}

								var radioButtonList = document.getElementById('TLEEXAM_ODRE');
								var dropdownListdisable = document.getElementById('ABNORMAL_DROPOD');

								if (radioButtonList) {
									if (radioButtonList.querySelector('input:checked').value === 'Abnormal') {
										dropdownListdisable.disabled = false;
									} else {
										dropdownListdisable.disabled = true;
									}
								}
							}

							function abnormalOSDropdownChanged() {
								var osleValue = $("input[name$='TLEEXAM_OSLE']:checked").val();
								var detailexamRadios = $("input[name$='Detailexam']");

								if (osleValue === "Abnormal") {
									detailexamRadios.filter("[value='Yes']").prop("checked", true);
								} else {
									detailexamRadios.filter("[value='No']").prop("checked", true);
								}

								var radioButtonListos = document.getElementById('TLEEXAM_OSLE');
								var dropdownListdisableos = document.getElementById('ABNORMAL_DROPOS');

								if (radioButtonListos) {
									if (radioButtonListos.querySelector('input:checked').value === 'Abnormal') {
										dropdownListdisableos.disabled = false;
									} else {
										dropdownListdisableos.disabled = true;
									}
								}
							}

					</script>



					<%--<script>
						function radioButtonChanged() {
							var radioList = document.getElementById('<%= spcradio.ClientID %>');
							var DetailexamDropdown = document.getElementById('<%= Detailexam.ClientID %>');

							var selectedValue = radioList.querySelector('input[type="radio"]:checked').value;

							if (selectedValue === "Yes") {
								// Change the selected value of the Detailexam dropdown
								// You can set the desired value based on your scenario
								DetailexamDropdown.value = "Yes";
							} else {
								// Change the selected value to something else if needed
								DetailexamDropdown.value = "No";
							}
						}

						function complainChanged() {
							var complainbtn = document.getElementById('<%= occomplain.ClientID %>');
							var DetailexamDropdown = document.getElementById('<%= Detailexam.ClientID %>');

							var selectedValue = complainbtn.querySelector('input[type="radio"]:checked').value;

							if (selectedValue === "Yes") {
								// Change the selected value of the Detailexam dropdown
								// You can set the desired value based on your scenario
								DetailexamDropdown.value = "Yes";
							} else {
								// Change the selected value to something else if needed
								DetailexamDropdown.value = "No";
							}
						}


					</script>
					<script>
						function withoutOdreChanged() {
							var withoutOdreDropdown = document.getElementById('<%= WITHOUT_ODRE.ClientID %>');
							var withoutOsleDropdown = document.getElementById('<%= WITHOUT_OSLE.ClientID %>');
							var DetailexamDropdown = document.getElementById('<%= Detailexam.ClientID %>');

							var selectedValue = withoutOdreDropdown.value;

							updateDetailexamDropdown(selectedValue);
						}

						function withoutOsleChanged() {
							var withoutOdreDropdown = document.getElementById('<%= WITHOUT_ODRE.ClientID %>');
							var withoutOsleDropdown = document.getElementById('<%= WITHOUT_OSLE.ClientID %>');
							var DetailexamDropdown = document.getElementById('<%= Detailexam.ClientID %>');

							var selectedValue = withoutOsleDropdown.value;

							updateDetailexamDropdown(selectedValue);
						}

						function updateDetailexamDropdown(selectedValue) {
							var DetailexamDropdown = document.getElementById('<%= Detailexam.ClientID %>');

							if (selectedValue === "No") {
								// Change the options of the Detailexam dropdown to "Yes" and "No"
								DetailexamDropdown.innerHTML = '<option value="Yes">Yes</option><option value="No">No</option>';
							} else {
								// Restore the default options of the Detailexam dropdown
								DetailexamDropdown.innerHTML = '<option value="No">No</option><option value="Yes">Yes</option>';
							}
						}
                        </script>

					<script>
						function Testodchange() {
							var VALTST_ODRE_Dropdown = document.getElementById('<%= VALTST_ODRE.ClientID %>');
							var VALTST_OSLE_Dropdown = document.getElementById('<%= VALTST_OSLE.ClientID %>');
							var DetailexamDropdowntest = document.getElementById('<%= Detailexam.ClientID %>');

							var selectedValuetestone = VALTST_ODRE_Dropdown.value;

							updateDetailexamDropdowntest(selectedValuetestone);


						}

						function Testoschange() {
							var VALTST_ODRE_Dropdown = document.getElementById('<%= VALTST_ODRE.ClientID %>');
							var VALTST_OSLE_Dropdown = document.getElementById('<%= VALTST_OSLE.ClientID %>');
							var DetailexamDropdowntest = document.getElementById('<%= Detailexam.ClientID %>');

							var selectedValuetestone = VALTST_OSLE_Dropdown.value;

							updateDetailexamDropdowntest(selectedValuetestone);

						}

						function updateDetailexamDropdowntest(selectedValuetestone) {
							var DetailexamDropdownte = document.getElementById('<%= Detailexam.ClientID %>');

							if (selectedValuetestone === "Yes") {
								// Change the options of the Detailexam dropdown to "Yes" and "No"
								DetailexamDropdownte.innerHTML = '<option value="Yes">Yes</option><option value="No">No</option>';
							} else {
								// Restore the default options of the Detailexam dropdown
								DetailexamDropdownte.innerHTML = '<option value="No">No</option><option value="Yes">Yes</option>';
							}
						}

						</script>

					<script>
						function abnormalODDropdownChanged() {




							var firstDropdown = document.getElementById('<%= TLEEXAM_ODRE.ClientID %>');
							var secondDropdown = document.getElementById('<%= Detailexam.ClientID %>');

							// Clear existing options from the second dropdown
							secondDropdown.innerHTML = '';

							// Depending on the selected value in the first dropdown, add new options to the second dropdown
							var selectedValue = firstDropdown.value;
							if (selectedValue === 'Abnormal') {
								// Add options for abnormal value 1
								var option1 = document.createElement('option');
								option1.value = 'Yes';
								option1.textContent = 'Yes';
								secondDropdown.appendChild(option1);

								// Add more options as needed
							} else if (selectedValue === 'Normal') {
								// Add options for abnormal value 2
								var option2 = document.createElement('option');
								option2.value = 'No';
								option2.textContent = 'No';
								secondDropdown.appendChild(option2);

								// Add more options as needed
							}

							// Add default option or handle other cases
						}

						function abnormalOSDropdownChanged() {

							var TLEEXAMOS = document.getElementById('<%= TLEEXAM_OSLE.ClientID %>');
							var Detailtleval = document.getElementById('<%= Detailexam.ClientID %>');

							Detailtleval.innerHTML = '';

							var selectedValueos = TLEEXAMOS.value;

							if (selectedValueos === 'Abnormal') {
								// Add options for abnormal value 1
								var option3 = document.createElement('option');
								option3.value = 'Yes';
								option3.textContent = 'Yes';
								Detailtleval.appendChild(option3);

								// Add more options as needed
							} else if (selectedValueos === 'Normal') {
								// Add options for abnormal value 2
								var option4 = document.createElement('option');
								option4.value = 'No';
								option4.textContent = 'No';
								Detailtleval.appendChild(option4);

								// Add more options as needed
							}

						}

                         </script>--%>


			</div>

		</div>

	</div>
		</div>
</asp:Content>

