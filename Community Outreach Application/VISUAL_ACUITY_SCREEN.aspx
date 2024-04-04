<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VISUAL_ACUITY_SCREEN.aspx.cs" Inherits="VISUAL_ACUITY_SCREEN" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/jquery@3.6.4/dist/jquery.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <style>
        .table {
            display: table;
            width: 100%;
            border-collapse: collapse;
        }

        .tr {
            display: table-row;
            background-color: #41A9EE;
        }

        .td {
            display: table-cell;
            border: 1px solid black;
        }

        .row {
            margin-left: -15px;
            margin-right: -15px;
            display: flex;
            flex-wrap: wrap;
        }
    </style>

    <style>
        .prescription-date {
            width: 205px; /* Set the desired width for specific cells here */
        }

        .prescription-small {
            width: 50px;
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


    <style>
        .table {
            display: table;
            width: 100%;
            border-collapse: collapse;
        }

        .tr {
            display: table-row;
            background-color: #DFEEEE;
        }

        .td {
            display: table-cell;
            border: 1px solid black;
            text-align: center;
            height: 27px;
            text-align: center;
            vertical-align: middle;
        }


        @media (max-width: 767px) {
            .tr {
                display: block;
                background-color: #DFEEEE;
            }

            .td {
                height: 27px;
            }
        }


        @media (min-width: 768px) and (max-width: 1023px) {
            .tr {
                display: flex;
                background-color: #DFEEEE;
            }

            .td {
                flex: 1;
                border: 1px solid black;
                text-align: center;
                height: 27px;
                text-align: center;
                vertical-align: middle;
            }
        }


        @media (min-width: 1024px) {
            .tr {
                display: flex;
                background-color: #DFEEEE;
            }

            .td {
                flex: 1;
                border: 2px solid black;
                text-align: center;
                height: 27px;
                text-align: center;
                vertical-align: middle;
            }
        }
    </style>

    <style>
        /* Styles for screens up to 767px wide */
        @media (max-width: 767px) {
            .tr {
                display: block;
                background-color: #DFEEEE;
            }

            .td {
                height: 27px;
            }
        }

        /* Styles for screens between 768px and 1023px wide */
        @media (min-width: 768px) and (max-width: 1023px) {
            .tr {
                display: flex;
                background-color: #DFEEEE;
            }

            .td {
                flex: 1;
                border: 1px solid black;
                text-align: center;
                height: 27px;
                text-align: center;
                vertical-align: middle;
            }
        }

        /* Styles for screens larger than or equal to 1024px wide */
        @media (min-width: 1024px) {
            .tr {
                display: flex;
                background-color: #DFEEEE;
            }

            .td {
                flex: 1;
                border: 2px solid black;
                text-align: center;
                height: 27px;
                text-align: center;
                vertical-align: middle;
            }
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

        .four {
            flex: 1 0 calc(25% - 15px); /* Distribute equally with margin adjustments */
            margin: 7.5px;
            color: #fff;
            text-align: center;
            line-height: 50px;
            font-size: 16px;
            border-radius: 10px;
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
            margin-left: 50%;
        }

        .BTNSTYLERED {
            background-color: #ed2323;
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
        .modal-content {
            background-color: white;
            margin: auto;
            padding: 20px;
            border: 1px solid #888;
            width: 20%;
            position: fixed;
            top: 30%;
            left: 50%;
            transform: translate(-50%, -50%);
        }


        .Complaint-content {
            background-color: white;
            margin: auto;
            padding: 20px;
            border: 1px solid #888;
            width: 60%;
            position: fixed;
            top: 30%;
            left: 50%;
            transform: translate(-50%, -50%);
        }

        .Ocular-content {
            background-color: white;
            margin: auto;
            padding: 20px;
            border: 1px solid #888;
            width: 60%;
            position: fixed;
            top: 42%;
            left: 50%;
            transform: translate(-50%, -50%);
        }

        .modal-open .dropbtn {
            display: none;
        }
    </style>

    <style>
        .modal {
            display: none;
        }
    </style>


    <style>
        .dropdown {
            position: relative;
            display: inline-block;
        }


        .dropbtn {
            background-color: black;
            color: white;
            padding: 10px;
            border: none;
            cursor: pointer;
            max-width: 100px; /* Add this line */
            white-space: nowrap; /* Prevent text wrapping */
            overflow: hidden; /* Hide overflow if text is too long */
            text-overflow: ellipsis;
        }


        .dropdown-content {
            display: none;
            position: absolute;
            background-color: white;
            min-width: 160px;
            box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
            z-index: 1;
        }


        .dropdown:hover .dropdown-content {
            display: block;
        }


        .row1 {
            display: flex;
            align-items: center;
            margin: 5px 0;
        }

            .row1 label {
                margin-right: 10px;
            }
    </style>
    <style>
        .pink-cell {
            background-color: #e7a7da94;
            color: black;
        }

        .black-cell {
            background-color: #ebeeefe0;
            color: black;
        }
    </style>


    <script type="text/javascript">
        window.onload = function () {
            var docCode = '<%= Request.QueryString["studentID"] %>';

        };
    </script>


    <script>
        document.addEventListener("DOMContentLoaded", function () {
            const dropdowns = document.querySelectorAll(".dropdown");
            dropdowns.forEach(function (dropdown) {
                const btn = dropdown.querySelector(".dropbtn");
                const content = dropdown.querySelector(".dropdown-content");
                const checkboxes = content.querySelectorAll("input[type='checkbox']");
                const selectedOptionsField = dropdown.nextElementSibling;
                const remarksOD = dropdown.closest(".prescription-small").querySelector(".Remarks_OD");
                const remarksOS = dropdown.closest(".prescription-small").querySelector(".Remarks_OS");

                checkboxes.forEach(function (checkbox) {
                    checkbox.addEventListener("change", function () {
                        const selectedOptions = Array.from(checkboxes)
                            .filter((cb) => cb.checked)
                            .map((cb) => cb.nextElementSibling.textContent)
                            .join(", ");
                        btn.textContent = selectedOptions || "Select";
                        selectedOptionsField.value = selectedOptions;

                        if (checkbox.id.includes("OD")) {
                            remarksOD.value = selectedOptions;
                        } else if (checkbox.id.includes("OS")) {
                            remarksOS.value = selectedOptions;
                        }
                    });
                });
            });
        });
    </script>

    <style>
        .modal {
            display: none;
        }
    </style>
    <script>
        var targetTextField = "";
        function openModal(textField) {
            closeModal();
            targetTextField = textField;
            document.getElementById("myModal").style.display = "block";
        }

        function closeModal() {
            document.getElementById("myModal").style.display = "none";
        }
        function saveData() {

            var selectedData = [];

            if (document.getElementById("d_bifocals").checked) {
                selectedData.push(document.getElementById("d_bifocals").value);
            }
            if (document.getElementById("Executive").checked) {
                selectedData.push(document.getElementById("Executive").value);
            }
            if (document.getElementById("good").checked) {
                selectedData.push(document.getElementById("good").value);
            }
            if (document.getElementById("broken_frame").checked) {
                selectedData.push(document.getElementById("broken_frame").value);
            }
            if (document.getElementById("broken_lens").checked) {
                selectedData.push(document.getElementById("broken_lens").value);
            }
            if (document.getElementById("decentered_lenses").checked) {
                selectedData.push(document.getElementById("decentered_lenses").value);
            }
            if (document.getElementById("scratches").checked) {
                selectedData.push(document.getElementById("scratches").value);
            }
            if (document.getElementById("misaligned").checked) {
                selectedData.push(document.getElementById("misaligned").value);
            }

            var targetTextBox = document.getElementById(targetTextField);
            if (targetTextBox) {
                targetTextBox.value = selectedData.join(', ');
            }


            closeModal();



        }

    </script>



</head>
<body>
    <form id="form1" runat="server">
        <div id="myModal" class="modal">
            <div class="modal-content">
                <span class="close" onclick="closeModal()">&times;</span>
                <h2>Select the value</h2>
                <div>
                    <input type="checkbox" id="d_bifocals" name="D Bifocals" value="D Bifocals">
                    <label for="d_bifocals">D Bifocals</label>
                </div>
                <div>
                    <input type="checkbox" id="Executive" name="Executive Bifocals" value="Executive Bifocals">
                    <label for="Executive">Executive Bifocals</label>
                </div>
                <div>
                    <input type="checkbox" id="good" name="Good" value="Good">
                    <label for="good">Good</label>
                </div>
                <div>
                    <input type="checkbox" id="broken_frame" name="Broken frame" value="Broken frame">
                    <label for="broken_frame">Broken frame</label>
                </div>
                <div>
                    <input type="checkbox" id="broken_lens" name="Broken lens" value="Broken lens">
                    <label for="broken_lens">Broken lens</label>
                </div>

                <div>
                    <input type="checkbox" id="decentered_lenses" name="Decentered lenses" value="Decentered lenses">
                    <label for="decentered_lenses">Decentered lenses</label>
                </div>

                <div>
                    <input type="checkbox" id="scratches" name="Scratches" value="Scratches">
                    <label for="scratches">Scratches</label>
                </div>

                <div>
                    <input type="checkbox" id="misaligned" name="Misaligned" value="Misaligned">
                    <label for="misaligned">Misaligned</label>
                </div>



                <!-- Save button -->
                <button onclick="saveData()">Save</button>
            </div>
        </div>
        <div class="row">

            <div class="four">
                <asp:Button ID="ComplaintsModel" runat="server" CssClass="BTNSTYLE" Text="Complaints" OnClientClick="Complaints(); return false;" />


            </div>
            <div class="four">

                <asp:Button ID="OcularModel" runat="server" CssClass="BTNSTYLERED" Text="Ocular history" OnClientClick="Ocularhistory(); return false;" />
            </div>



            <div class="four">
                <asp:Button ID="Othertest" runat="server" Text="Other Test" CssClass="BTNSTYLE" OnClientClick="othertest(); return false;" />
            </div>
            <div class="four">
                <asp:Button ID="Management" runat="server" Text="Management" CssClass="BTNSTYLERED" OnClientClick="Managementpop(); return false;" />
            </div>


        </div>

        <hr />

        <div class="table">

            <div class="row">

                <div style="margin-left: 20%">

                    <asp:Button ID="btnSave8" runat="server" CssClass="BTNSTYLE" Text="Save" OnClick="btnSave2_Click" Visible="false" />
                </div>
                <div style="margin-left: 10%">

                    <asp:Button ID="btnmod" runat="server" CssClass="BTNSTYLE" Text="Update" OnClick="btnmodify_Click" Visible="false" />
                </div>
            </div>

        </div>
        <br />


        <div class="table" id="preGlassPrescr1">
			<div class="tr" style="background-color: #41A9EE">
				<div style="display: table-cell; width: 5%;">
					
				</div>
				<div class="td" style="width: 90%; colspan: 10; text-align: center;">
					<label id="Label14" class="BoldLbl" style="color: #ffffff" runat="server">Previous Glass Prescription</label>
                    
				</div>
				
			</div>
		</div>
        <div class="tr" style="background-color: white; display: flex;">
            <div class="td" style="width: 10%; flex: 1;">Serial Number</div>
            <div class="td" style="width: 12%; flex: 1.5; text-align: center;">
                <label id="Label19" class="BoldLbl" runat="server">Prescription Date</label>
            </div>
            <div class="td" style="width: 12%; flex: 0.1; text-align: center;">
                <label id="Label20" class="BoldLbl" runat="server">Eye</label>
            </div>
            <div class="td" style="width: 12%; flex: 1; text-align: center;">
                <label id="Label21" class="BoldLbl" runat="server">Spherical</label>
            </div>
            <div class="td" style="width: 15%; text-align: center;">
                <label id="Label22" class="BoldLbl" runat="server">Cylindrical</label>
            </div>
            <div class="td" style="width: 15%; text-align: center;">
                <label id="Label15" class="BoldLbl" runat="server">Axis</label>
            </div>
            <div class="td" style="width: 15%; text-align: center;">
                <label id="Label16" class="BoldLbl" runat="server">Add</label>
            </div>
            <div class="td" style="width: 15%; text-align: center;">
                <label id="Label17" class="BoldLbl" runat="server">Prism</label>
            </div>
            <div class="td" style="width: 15%; text-align: center;">
                <label id="Label18" class="BoldLbl" runat="server">Base Direction</label>
            </div>
            <div class="td" style="width: 15%; text-align: center;">
                <label id="Label23" class="BoldLbl" runat="server">Lens Type</label>
            </div>
            <div class="td" style="width: 15%; text-align: center;">
                <label id="Label24" class="BoldLbl" runat="server">Glass Status	</label>
            </div>
            <div class="td" style="width: 15%; text-align: center;">
                <label id="Label25" class="BoldLbl" runat="server">Search</label>
            </div>
            <div class="td" style="width: 15%; text-align: center;">
                <label id="Label26" class="BoldLbl" runat="server">Remarks</label>
            </div>
        </div>
        
        <div class="tr" style="background-color: white; display: flex;">
            <div class="td" style="width: 10%; flex: 1;">1</div>
            <div class="td" style="width: 12%; flex: 1.5; text-align: center;">
             
							<tr>
								<td>
									<asp:DropDownList ID="DayDropdown_OD" runat="server">
										<asp:ListItem value="00">--</asp:ListItem>
										<asp:ListItem value="01">01</asp:ListItem>
										<asp:ListItem value="02">02</asp:ListItem>
										<asp:ListItem value="03">03</asp:ListItem>
										<asp:ListItem value="04">04</asp:ListItem>
										<asp:ListItem value="05">05</asp:ListItem>
										<asp:ListItem value="06">06</asp:ListItem>
										<asp:ListItem value="07">07</asp:ListItem>
										<asp:ListItem value="08">08</asp:ListItem>
										<asp:ListItem value="09">09</asp:ListItem>
										<asp:ListItem value="10">10</asp:ListItem>
										<asp:ListItem value="11">11</asp:ListItem>
										<asp:ListItem value="12">12</asp:ListItem>
										<asp:ListItem value="13">13</asp:ListItem>
										<asp:ListItem value="14">14</asp:ListItem>
										<asp:ListItem value="15">15</asp:ListItem>
										<asp:ListItem value="16">16</asp:ListItem>
										<asp:ListItem value="17">17</asp:ListItem>
										<asp:ListItem value="18">18</asp:ListItem>
										<asp:ListItem value="19">19</asp:ListItem>
										<asp:ListItem value="20">20</asp:ListItem>
										<asp:ListItem value="21">21</asp:ListItem>
										<asp:ListItem value="22">22</asp:ListItem>
										<asp:ListItem value="23">23</asp:ListItem>
										<asp:ListItem value="24">24</asp:ListItem>
										<asp:ListItem value="25">25</asp:ListItem>
										<asp:ListItem value="26">26</asp:ListItem>
										<asp:ListItem value="27">27</asp:ListItem>
										<asp:ListItem value="28">28</asp:ListItem>
										<asp:ListItem value="29">29</asp:ListItem>
										<asp:ListItem value="30">30</asp:ListItem>
										<asp:ListItem value="31">31</asp:ListItem>
									

                                    </asp:DropDownList>

                                    <asp:DropDownList ID="monthDropdown_OD" runat="server">
                                        <asp:ListItem Value="00">--</asp:ListItem>
                                        <asp:ListItem Value="Jan">Jan</asp:ListItem>
                                        <asp:ListItem Value="Feb">Feb</asp:ListItem>
                                        <asp:ListItem Value="Mar">Mar</asp:ListItem>
                                        <asp:ListItem Value="Apr">Apr</asp:ListItem>
                                        <asp:ListItem Value="May">May</asp:ListItem>
                                        <asp:ListItem Value="Jun">Jun</asp:ListItem>
                                        <asp:ListItem Value="Jul">Jul</asp:ListItem>
                                        <asp:ListItem Value="Aug">Aug</asp:ListItem>
                                        <asp:ListItem Value="Sep">Sep</asp:ListItem>
                                        <asp:ListItem Value="Oct">Oct</asp:ListItem>
                                        <asp:ListItem Value="Nov">Nov</asp:ListItem>
                                        <asp:ListItem Value="Dec">Dec</asp:ListItem>

                                    </asp:DropDownList>

									<asp:TextBox ID="yearOD" runat="server" Width="36px"></asp:TextBox>
								</td>
							</tr>
          
                
            </div>

             <%--onblur="javascript:validatecontrol('Spherical_OD');"--%>

            <div class="td" style="width: 12%; flex: 0.22; text-align: center;">
          			<asp:Label ID="lblEyeOD" runat="server" Text="OD"></asp:Label>
            </div>
            <div class="td" style="width: 12%; flex: 1; text-align: center;">
                <asp:TextBox ID="Spherical_OD" runat="server" Width="50px" ></asp:TextBox>
            </div>
            <div class="td" style="width: 15%; text-align: center;">
               <asp:TextBox ID="Cylindrical_OD" runat="server" Width="50px"  ></asp:TextBox>
            </div>
            <div class="td" style="width: 15%; text-align: center;">
               <asp:TextBox ID="Axis_OD" runat="server" Width="50px"  ></asp:TextBox>
            </div>
            <div class="td" style="width: 15%; text-align: center;">
                <asp:TextBox ID="Add_OD" runat="server" Width="50px"   ></asp:TextBox>
            </div>
            <div class="td" style="width: 15%; text-align: center;">
              <asp:TextBox ID="Prism_OD" runat="server" Width="50px" ></asp:TextBox>
            </div>
            <div class="td" style="width: 15%;  text-align: center;">
                <asp:DropDownList ID="BaseDirectionOD" TabIndex="34" CssClass="generalcbo" runat="server" Width="100%"></asp:DropDownList>
              
            </div>
            <div class="td" style="width: 15%; text-align: center;">
               <asp:DropDownList ID="LensType_OD" TabIndex="34" CssClass="generalcbo" runat="server" Width="100%"></asp:DropDownList>
            </div>
            <div class="td" style="width: 15%; text-align: center;">
               <asp:TextBox ID="GlassStatus_OD" runat="server"  Width="94px" Height="21px" TextMode="MultiLine" ClientIDMode="Static"></asp:TextBox>
            </div>
            <div class="td" style="width: 15%; text-align: center;">
                 <asp:ImageButton ID="SearchButton" OnClientClick="openModal('GlassStatus_OD'); return false;" src="img/SEARCH_IMG.png"    runat="server"  style="max-width: 40px; max-height: 40px;" />
            </div>
            <div class="td" style="width: 15%;height: 21px; text-align: center;">
               <asp:TextBox ID="Remarks_OD" runat="server" TextMode="MultiLine" Width="97px" Height="21px"></asp:TextBox>
            </div>
        </div>

    


        <div class="tr" style="background-color: white; display: flex;">
            <div class="td" style="width: 10%; flex: 1;">1</div>
            <div class="td" style="width: 12%; flex: 1.5; text-align: center;">
                <tr>
                    <td>
                        <asp:DropDownList ID="DayDropdown_OS" runat="server">
                            <asp:ListItem Value="00">--</asp:ListItem>
                            <asp:ListItem Value="01">01</asp:ListItem>
                            <asp:ListItem Value="02">02</asp:ListItem>
                            <asp:ListItem Value="03">03</asp:ListItem>
                            <asp:ListItem Value="04">04</asp:ListItem>
                            <asp:ListItem Value="05">05</asp:ListItem>
                            <asp:ListItem Value="06">06</asp:ListItem>
                            <asp:ListItem Value="07">07</asp:ListItem>
                            <asp:ListItem Value="08">08</asp:ListItem>
                            <asp:ListItem Value="09">09</asp:ListItem>
                            <asp:ListItem Value="10">10</asp:ListItem>
                            <asp:ListItem Value="11">11</asp:ListItem>
                            <asp:ListItem Value="12">12</asp:ListItem>
                            <asp:ListItem Value="13">13</asp:ListItem>
                            <asp:ListItem Value="14">14</asp:ListItem>
                            <asp:ListItem Value="15">15</asp:ListItem>
                            <asp:ListItem Value="16">16</asp:ListItem>
                            <asp:ListItem Value="17">17</asp:ListItem>
                            <asp:ListItem Value="18">18</asp:ListItem>
                            <asp:ListItem Value="19">19</asp:ListItem>
                            <asp:ListItem Value="20">20</asp:ListItem>
                            <asp:ListItem Value="21">21</asp:ListItem>
                            <asp:ListItem Value="22">22</asp:ListItem>
                            <asp:ListItem Value="23">23</asp:ListItem>
                            <asp:ListItem Value="24">24</asp:ListItem>
                            <asp:ListItem Value="25">25</asp:ListItem>
                            <asp:ListItem Value="26">26</asp:ListItem>
                            <asp:ListItem Value="27">27</asp:ListItem>
                            <asp:ListItem Value="28">28</asp:ListItem>
                            <asp:ListItem Value="29">29</asp:ListItem>
                            <asp:ListItem Value="30">30</asp:ListItem>
                            <asp:ListItem Value="31">31</asp:ListItem>
                        </asp:DropDownList>

                                    <asp:DropDownList ID="MonthDropdown_OS" runat="server">
                                        <asp:ListItem Value="00">--</asp:ListItem>
                                        <asp:ListItem Value="Jan">Jan</asp:ListItem>
                                        <asp:ListItem Value="Feb">Feb</asp:ListItem>
                                        <asp:ListItem Value="Mar">Mar</asp:ListItem>
                                        <asp:ListItem Value="Apr">Apr</asp:ListItem>
                                        <asp:ListItem Value="May">May</asp:ListItem>
                                        <asp:ListItem Value="Jun">Jun</asp:ListItem>
                                        <asp:ListItem Value="Jul">Jul</asp:ListItem>
                                        <asp:ListItem Value="Aug">Aug</asp:ListItem>
                                        <asp:ListItem Value="Sep">Sep</asp:ListItem>
                                        <asp:ListItem Value="Oct">Oct</asp:ListItem>
                                        <asp:ListItem Value="Nov">Nov</asp:ListItem>
                                        <asp:ListItem Value="Dec">Dec</asp:ListItem>
                                    </asp:DropDownList>

                        <asp:TextBox ID="yearOS" runat="server"  Width="36px"></asp:TextBox>
                    </td>
                </tr>
            </div>
            <div class="td" style="width: 12%; flex: 0.22; text-align: center;">
               <asp:Label ID="lbl_os" runat="server" Text="OS"></asp:Label>
            </div>
            <div class="td" style="width: 12%; flex: 1; text-align: center;">
                <asp:TextBox ID="Spherical_OS" runat="server" Width="50px"></asp:TextBox>
            </div>
            <div class="td" style="width: 15%; text-align: center;">
            <asp:TextBox ID="Cylindrical_OS" runat="server" Width="50px"></asp:TextBox>
            </div>
            <div class="td" style="width: 15%; text-align: center;">
                	<asp:TextBox ID="Axis_OS" runat="server" Width="50px"></asp:TextBox>
            </div>
            <div class="td" style="width: 15%; text-align: center;">
                <asp:TextBox ID="Add_OS" runat="server" Width="50px"></asp:TextBox>
            </div>
            <div class="td" style="width: 15%; text-align: center;">
               <asp:TextBox ID="Prism_OS" runat="server" Width="50px"></asp:TextBox>
            </div>
            <div class="td" style="width: 15%; text-align: center;">
          
                <asp:DropDownList ID="BaseDirectionOS" TabIndex="34" CssClass="generalcbo" runat="server" Width="100%"></asp:DropDownList>
            </div>
            <div class="td" style="width: 15%; text-align: center;">
                <asp:DropDownList ID="LensType_OS" TabIndex="34" CssClass="generalcbo" runat="server" Width="100%"></asp:DropDownList>
            </div>
            <div class="td" style="width: 15%; text-align: center;">
                <asp:TextBox ID="GlassStatus_OS" runat="server" Width="94px" Height="21px" TextMode="MultiLine"  ClientIDMode="Static"></asp:TextBox>
            </div>
            <div class="td" style="width: 15%; text-align: center;">
                <asp:ImageButton ID="SearchButton1" OnClientClick="openModal('GlassStatus_OS'); return false;" src="img/SEARCH_IMG.png" runat="server" Style="max-width: 40px; max-height: 40px;" />

            </div>
            <div class="td" style="width: 15%; text-align: center;">
               <asp:TextBox ID="Remarks_OS" runat="server" TextMode="MultiLine" Width="97px" Height="21px"></asp:TextBox>
            </div>
        </div>






        <br />
        <br />
        <div class="table" id="TableVisionCheckDiv">
            <div class="tr" style="background-color: #41A9EE">
                <div style="display: table-cell; width: 5%;">
                    <input id="btVisual" style="width: 22px; height: 15px" onclick="javascript: hideandseeek('divVisual');" type="button" value="-">
                </div>
                <div class="td" style="width: 90%; colspan: 11; text-align: center;">
                    <label id="lblVisionCheck" class="BoldLbl" style="color: #ffffff" runat="server">Visual Acuity</label>
                </div>
                <%-- <div class="td" style="width: 10%; text-align: left;">
					<asp:Button ID="btsaveVisualAcuity" runat="server" Text="Save" OnClick="btnSave2_Click" />
            </div>--%>
                <div style="width: 5%; background-color: #41A9EE; text-align: center;">
                    <strong><a href="#top" style="color: white">TOP</a></strong>
                </div>
            </div>
        </div>

        <div id="divVisual" style="table-layout: auto; display: inline; visibility: visible; border-top-style: none; border-right-style: none; border-left-style: none; border-collapse: collapse; border-bottom-style: none">
            <div class="table" id="TableVisualHideDiv">

                <div class="tr" style="background-color: #DFEEEE; display: flex;">
                    <div class="td" style="width: 27%;"></div>
                    <div class="td" style="width: 27%; flex: 4; text-align: center;">
                        <label id="lblWithoutGlass" class="BoldLbl" runat="server">Without Glass</label>
                    </div>
                    <div class="td" style="width: 27%; flex: 4; text-align: center;">
                        <label id="lblWithGlass" class="BoldLbl" runat="server">With Glass</label>
                    </div>
                    <div class="td" style="width: 27%; flex: 4; text-align: center;">
                        <label id="lblContact" class="BoldLbl" runat="server">Contact Lens</label>
                    </div>
                    <div class="td" style="width: 15%; text-align: center;">
                        <label id="lblWithPH" class="BoldLbl" runat="server">With PH</label>
                    </div>
                </div>


                <div class="tr">
                    <div class="td" style="width: 5%">
                        <label id="lblODDVG" class="generallbl" runat="server">OD V/A DV</label>
                    </div>
                    <div class="td" style="width: 10%">
                        <asp:DropDownList ID="cmbVcOdWithoutGlass" TabIndex="14" CssClass="generalcbo" runat="server" Width="100%">
                        </asp:DropDownList>
                    </div>
                    <div class="td" style="width: 3%">
                        <label id="lblOdWONv" class="generallbl" runat="server">NV</label>
                    </div>
                    <div class="td" style="width: 8%">
                        <asp:DropDownList ID="cmbVcOdWithoutNearvision" TabIndex="15" CssClass="generalcbo" runat="server" Width="100%">
                        </asp:DropDownList>
                    </div>
                    <div class="td" style="width: 7%">
                        <asp:TextBox ID="txtVcOdWithoutDistance" MaxLength="10" TabIndex="16" CssClass="numerictxt"
                            runat="server" TextMode="SingleLine" Width="70%" onblur="javascript:clearStatusMsg()"
                            onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtVcOdWithoutDistance','Enter a max. of 10 Characters')"></asp:TextBox>
                        <font size="1">cm</font>
                    </div>
                    <div class="td" style="width: 10%">
                        <asp:DropDownList ID="cmbVcOdWithGlass" TabIndex="17" CssClass="generalcbo" runat="server" Width="100%">
                        </asp:DropDownList>
                    </div>
                    <div class="td" style="width: 3%">
                        <label id="lblOdWNv" class="generallbl" runat="server">NV</label>
                    </div>
                    <div class="td" style="width: 8%">
                        <asp:DropDownList ID="cmbVcOdWithNearvision" TabIndex="18" CssClass="generalcbo" runat="server" Width="100%">
                        </asp:DropDownList>
                    </div>
                    <div class="td" style="width: 6%">
                        <asp:TextBox ID="txtVcOdWithDistance" MaxLength="10" TabIndex="19" CssClass="numerictxt"
                            runat="server" TextMode="SingleLine" Width="70%" onblur="javascript:clearStatusMsg()"
                            onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtVcOdWithDistance','Enter a max. of 10 Characters')"></asp:TextBox>
                        <font size="1">cm</font>
                    </div>
                    <div class="td" style="width: 10%">
                        <asp:DropDownList ID="cmbVcOdWithoutContact" TabIndex="14" CssClass="generalcbo" runat="server" Width="100%">
                        </asp:DropDownList>
                    </div>
                    <div class="td" style="width: 3%">
                        <label id="lblOdWOContact" class="generallbl" runat="server">NV</label>
                    </div>
                    <div class="td" style="width: 8%">
                        <asp:DropDownList ID="cmbVcOdContact" TabIndex="15" CssClass="generalcbo" runat="server" Width="100%">
                        </asp:DropDownList>
                    </div>
                    <div class="td" style="width: 7%">
                        <asp:TextBox ID="txtVcOdContact" MaxLength="10" TabIndex="16" runat="server" TextMode="SingleLine"
                            Width="70%" onblur="javascript:clearStatusMsg()" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtVcOdWithoutDistance','Enter a max. of 10 Characters')"></asp:TextBox>
                        <font size="1">cm</font>
                    </div>
                    <div class="td" style="width: 16%">
                        <asp:DropDownList ID="cmbVcOdPinhole" TabIndex="20" CssClass="generalcbo" runat="server" Width="100%">
                        </asp:DropDownList>
                    </div>
                </div>
                <!-- Add the remaining rows here -->
                <div class="tr">
                    <div class="td" style="width: 8%">
                        <label id="lblOSDVG" class="generallbl" runat="server">OS V/A DV</label>
                    </div>
                    <div class="td" style="width: 10%">
                        <asp:DropDownList ID="cmbVcOsWithoutGlass" TabIndex="21" CssClass="generalcbo" runat="server" Width="100%">
                        </asp:DropDownList>
                    </div>
                    <div class="td" style="width: 3%">
                        <label id="lblOsWONv" class="generallbl" runat="server">NV</label>
                    </div>
                    <div class="td" style="width: 8%">
                        <asp:DropDownList ID="cmbVcOsWithoutNearvision" TabIndex="22" CssClass="generalcbo" runat="server" Width="100%">
                        </asp:DropDownList>
                    </div>
                    <div class="td" style="width: 7%">
                        <asp:TextBox ID="txtVcOsWithoutDistance" MaxLength="10" TabIndex="23" CssClass="numerictxt"
                            runat="server" TextMode="SingleLine" Width="70%" onblur="javascript:clearStatusMsg()"
                            onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtVcOsWithoutDistance','Enter a max. of 10 Characters')"></asp:TextBox>
                        <font size="1">cm</font>
                    </div>
                    <div class="td" style="width: 10%">
                        <asp:DropDownList ID="cmbVcOsWithGlass" TabIndex="24" CssClass="generalcbo" runat="server" Width="100%">
                        </asp:DropDownList>
                    </div>
                    <div class="td" style="width: 3%">
                        <label id="lbloswNv" class="generallbl" runat="server">NV</label>
                    </div>
                    <div class="td" style="width: 8%">
                        <asp:DropDownList ID="cmbVcOsWithNearvision" TabIndex="25" CssClass="generalcbo" runat="server" Width="100%">
                        </asp:DropDownList>
                    </div>
                    <div class="td" style="width: 6%">
                        <asp:TextBox ID="txtVcOsWithDistace" MaxLength="10" TabIndex="26" CssClass="numerictxt"
                            runat="server" TextMode="SingleLine" Width="70%" onblur="javascript:clearStatusMsg()"
                            onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtVcOsWithDistace','Enter a max. of 10 Characters')"></asp:TextBox>
                        <font size="1">cm</font>
                    </div>
                    <div class="td" style="width: 10%">
                        <asp:DropDownList ID="cmbVcOsWithoutContact" TabIndex="14" CssClass="generalcbo" runat="server" Width="100%">
                        </asp:DropDownList>
                    </div>
                    <div class="td" style="width: 3%">
                        <label id="lblOsWOContact" class="generallbl" runat="server">NV</label>
                    </div>
                    <div class="td" style="width: 8%">
                        <asp:DropDownList ID="cmbVcOsContact" TabIndex="15" CssClass="generalcbo" runat="server" Width="100%">
                        </asp:DropDownList>
                    </div>
                    <div class="td" style="width: 7%">
                        <asp:TextBox ID="txtVcOsContact" MaxLength="10" TabIndex="16" runat="server" TextMode="SingleLine"
                            Width="70%" onblur="javascript:clearStatusMsg()" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtVcOdWithoutDistance','Enter a max. of 10 Characters')"></asp:TextBox>
                        <font size="1">cm</font>
                    </div>
                    <div class="td" style="width: 16%">
                        <asp:DropDownList ID="cmbVcOsPinhole" TabIndex="27" CssClass="generalcbo" runat="server" Width="100%">
                        </asp:DropDownList>
                    </div>
                </div>
                <!-- Add the remaining rows here -->

                <div class="tr">
                    <div class="td" style="width: 8%">
                        <label id="lblOUDVG" class="generallbl" runat="server">OU V/A DV</label>
                    </div>
                    <div class="td" style="width: 10%">
                        <asp:DropDownList ID="cmbVcOuWithoutGlass" CssClass="generalcbo" runat="server" Width="100%">
                        </asp:DropDownList>
                    </div>
                    <div class="td" style="width: 3%">
                        <label id="lblOuNv" class="generallbl" runat="server">NV</label>
                    </div>
                    <div class="td" style="width: 8%">
                        <asp:DropDownList ID="cmbVcOuWithoutNearvision" CssClass="generalcbo" runat="server" Width="100%">
                        </asp:DropDownList>
                    </div>
                    <div class="td" style="width: 7%">
                        <asp:TextBox ID="txtVcOuWithoutDistance" MaxLength="10" CssClass="numerictxt" runat="server"
                            TextMode="SingleLine" Width="70%" onblur="javascript:clearStatusMsg()" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtVcOuWithoutDistance','Enter a max. of 10 Characters')"></asp:TextBox>
                        <font size="1">cm</font>
                    </div>
                    <div class="td" style="width: 10%">
                        <asp:DropDownList ID="cmbVcOuWithGlass" CssClass="generalcbo" runat="server" Width="100%">
                        </asp:DropDownList>
                    </div>
                    <div class="td" style="width: 3%">
                        <label id="lblOuWNv" class="generallbl" runat="server">NV</label>
                    </div>
                    <div class="td" style="width: 8%">
                        <asp:DropDownList ID="cmbVcOuWithNearvision" CssClass="generalcbo" runat="server" Width="100%">
                        </asp:DropDownList>
                    </div>
                    <div class="td" style="width: 6%">
                        <asp:TextBox ID="txtVcOuWithDistance" MaxLength="10" CssClass="numerictxt" runat="server"
                            TextMode="SingleLine" Width="70%" onblur="javascript:clearStatusMsg()" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtVcOuWithDistance','Enter a max. of 10 Characters')"></asp:TextBox>
                        <font size="1">cm</font>
                    </div>
                    <div class="td" style="width: 10%">
                        <asp:DropDownList ID="cmbVcOuWithoutContact" TabIndex="14" CssClass="generalcbo" runat="server" Width="100%">
                        </asp:DropDownList>
                    </div>
                    <div class="td" style="width: 3%">
                        <label id="lblOuWOContact" class="generallbl" runat="server">NV</label>
                    </div>
                    <div class="td" style="width: 8%">
                        <asp:DropDownList ID="cmbVcOuContact" TabIndex="15" CssClass="generalcbo" runat="server" Width="100%">
                        </asp:DropDownList>
                    </div>
                    <div class="td" style="width: 7%">
                        <asp:TextBox ID="txtVcOuContact" MaxLength="10" TabIndex="16" runat="server" TextMode="SingleLine"
                            Width="70%" onblur="javascript:clearStatusMsg()" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtVcOdWithoutDistance','Enter a max. of 10 Characters')"></asp:TextBox>
                        <font size="1">cm</font>
                    </div>
                    <div class="td" style="width: 16%">
                        <asp:DropDownList ID="cmbVcOuPinhole" CssClass="generalcbo" runat="server" Width="100%">
                        </asp:DropDownList>
                    </div>
                </div>


            </div>
        </div>

        <div class="table" id="tblsample">
            <div class="tr" style="background-color: #DFEEEE;">
                <div class="td" style="width: 10%; text-align: left;">
                    <asp:Button ID="btIntermediate" runat="server" Text="Intermediate Vision" OnClientClick="InterMediate(); return false;" />

                    <asp:Label EnableViewState="False" ID="lb_Type_of_chart" CssClass="BoldLbl" runat="server" Style="text-align: center; margin-left: 50px;" ForeColor="#000000">Type of Chart</asp:Label>
                    <asp:DropDownList ID="DD_Type_of_chart" TabIndex="34" CssClass="generalcbo" runat="server" Width="10%">
                    </asp:DropDownList>
                    <asp:Label EnableViewState="False" ID="lb_Near_vision_chart" CssClass="BoldLbl" runat="server" Style="text-align: center; margin-left: 265px;" ForeColor="#000000">Near Vision Chart</asp:Label>

                    <asp:DropDownList ID="DD_Near_vision_chart" TabIndex="34" CssClass="generalcbo" runat="server" Width="10%">
                    </asp:DropDownList>
                </div>

            </div>
        </div>

        <!-- Refraction -->

        <div class="table" id="tblRefraction">
            <div class="tr" style="background-color: #41A9EE;">
                <div style="width: 5%;">
                    <input id="btRefraction" style="width: 22px; height: 15px;" onclick="javascript: hideandseeek('divRefraction');" type="button" value="-">
                </div>
                <div class="td" style="width: 90%; colspan: 11; text-align: center;">
                    <asp:Button ID="btnpostdillatedrefraction" runat="server" Visible="false" Text="Post Dilated Refraction" OnClientClick="Postdilate(); return false;" Style="margin-right: 410px;" />


                    <asp:Label EnableViewState="False" ID="lblRefraction" CssClass="BoldLbl" runat="server" ForeColor="#ffffff">Refraction</asp:Label>
                </div>
                <div style="text-align: center; width: 5%;">
                    <strong><a href="#top" style="color: white;">TOP</a></strong>
                </div>
            </div>
        </div>

        <div id="divRefraction" style="table-layout: auto; display: inline; visibility: visible; border-top-style: none; border-right-style: none; border-left-style: none; border-collapse: collapse; border-bottom-style: none;">
            <div class="table" id="TableRefractionHide">
                <div class="tr" style="background-color: #DFEEEE;">
                    <div style="width: 5%;" bgcolor="#DFEEEE"></div>
                    <div class="td" style="width: 45%; text-align: center;" bgcolor="#DFEEEE">
                        <asp:Label EnableViewState="False" ID="lblODNew" CssClass="NewLbl" runat="server">
                    <b>RetinoScopy</b>
                        </asp:Label>
                    </div>
                    <div style="width: 10%; text-align: center;" bgcolor="#DFEEEE">
                        <asp:Label EnableViewState="False" ID="lblQuality" CssClass="NewLbl" runat="server">
                    <b>Quality of Reflex</b>
                        </asp:Label>
                    </div>
                    <div style="width: 10%; text-align: center;" bgcolor="#DFEEEE">
                        <asp:Label EnableViewState="False" ID="lblOSNew" CssClass="NewLbl" runat="server">
                    <b>Auto Refraction</b>
                        </asp:Label>
                    </div>
                    <div class="td" style="width: 25%; text-align: center;" bgcolor="#DFEEEE">
                        <asp:Label EnableViewState="False" ID="lblRet" CssClass="NewLbl" runat="server">
                    <b>Auto Refraction</b>
                        </asp:Label>
                    </div>
                </div>
                <div class="tr">
                    <div style="width: 5%;">
                        <asp:Label EnableViewState="False" ID="Label4" CssClass="generallbl" runat="server">  OD
                        </asp:Label>
                    </div>
                    <div class="td" style="width: 45%;">
                        <asp:TextBox ID="txtRfOdSpherical" TabIndex="28" Columns="3" MaxLength="6" CssClass="NumericTxt" runat="server" Width="20%" onblur="updateAndValidate('txtRfOdSpherical', 'txtAcOdDvSphericalOpt', 'txtAcOdDvSpherical', 'txtRfOdSpherical');"
                            onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtRfOdCylindrical','Enter a value between -45.00 and +45.00')"> </asp:TextBox>
                        <asp:Label EnableViewState="False" ID="lblDs2" CssClass="generallbl" runat="server">DS /</asp:Label>
                        <asp:TextBox ID="txtRfOdCylindrical" TabIndex="29" Columns="3" MaxLength="6" CssClass="NumericTxt"
                            runat="server" Width="20%" onblur="updateAndValidateDX('txtRfOdCylindrical', 'txtAcOdDvCylindricalOpt', 'txtAcOdDvCylindrical', 'txtRfOdCylindrical');" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtRfOdCylindrical','Enter a value between -45.00 and +45.00')"></asp:TextBox>
                        <asp:Label EnableViewState="False" ID="lblDc2" CssClass="generallbl" runat="server">DC X</asp:Label>
                        <asp:TextBox ID="txtRfOdAxis" TabIndex="29" Columns="3" MaxLength="3" CssClass="NumericTxt" runat="server" Width="20%"
                            onblur="updateAndValidateAXISOD('txtRfOdAxis', 'txtAcOdDvAxisOpt', 'txtAcOdDvAxis', 'txtRfOdAxis');" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtRfOdCylindrical','Enter a value between -45.00 and +45.00')"></asp:TextBox>
                        <asp:Label EnableViewState="False" ID="lblAxis2" CssClass="generallbl" runat="server">Axis</asp:Label>
                    </div>
                    <div style="width: 10%; text-align: center;">
                        <asp:DropDownList ID="cmbRfOdQuality" TabIndex="34" CssClass="generalcbo" runat="server" Width="100%"></asp:DropDownList>
                    </div>
                    <div style="width: 10%; text-align: center;">
                        <asp:DropDownList ID="cmbRfOdCycloplegic" TabIndex="34" CssClass="generalcbo" runat="server" Width="100%">
                            <asp:ListItem Value="" Text="---- Select ---- "></asp:ListItem>
                            <asp:ListItem Value="Openfield" Text="Open field"></asp:ListItem>
                            <asp:ListItem Value="Closedfield" Text="Closed field"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="td" style="width: 25%;">
                        <asp:TextBox ID="txtWetOdSpherical" TabIndex="36" MaxLength="6" CssClass="NumericTxt"
                            runat="server" Width="20%" onblur="javascript:validatecontrol('txtWetOdSpherical');" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtWetOdSpherical','Enter a value between -45.00 and +45.00')"></asp:TextBox>
                        <asp:Label EnableViewState="False" ID="lblWetOdSpherical" CssClass="generallbl" runat="server">DS /</asp:Label>
                        <asp:TextBox ID="txtWetOdCylindrical" TabIndex="37" MaxLength="6" CssClass="NumericTxt"
                            runat="server" Width="20%" onblur="javascript:validatecontrol('txtWetOdCylindrical');" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtWetOdCylindrical','Enter a value between -45.00 and +45.00')"></asp:TextBox>
                        <asp:Label EnableViewState="False" ID="lblWetOdCylindrical" CssClass="generallbl"
                            runat="server">DC X</asp:Label>
                        <asp:TextBox ID="txtWetOdAxis" TabIndex="38" MaxLength="3" CssClass="NumericTxt"
                            runat="server" Width="20%" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtWetOdAxis','Enter a value between 0 and 180')"></asp:TextBox>
                        <asp:Label EnableViewState="False" ID="lblWetOdAxis" CssClass="generallbl" runat="server">Axis</asp:Label>
                    </div>
                </div>

                <div class="tr">
                    <div style="width: 5%;">
                        <asp:Label EnableViewState="False" ID="Label1" CssClass="generallbl" runat="server">  OS
                        </asp:Label>
                    </div>
                    <div class="td" style="width: 45%;">
                        <asp:TextBox ID="txtRfOsSpherical" TabIndex="29" Columns="3" MaxLength="6" CssClass="NumericTxt" runat="server" Width="20%"
                            onblur="updateAndValidateDSOS('txtRfOsSpherical', 'txtAcOsDvSphericalOpt', 'txtAcOsDvSpherical', 'txtRfOsSpherical');" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtRfOdCylindrical','Enter a value between -45.00 and +45.00')"></asp:TextBox>
                        <asp:Label EnableViewState="False" ID="lblDs3" CssClass="generallbl" runat="server">DS /</asp:Label>
                        <asp:TextBox ID="txtRfOsCylindrical" TabIndex="29" Columns="3" MaxLength="6" CssClass="NumericTxt" runat="server" Width="20%"
                            onblur="updateAndValidateDXOS('txtRfOsCylindrical', 'txtAcOsDvCylindricalOpt', 'txtAcOsDvCylindrical', 'txtRfOsCylindrical');" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtRfOdCylindrical','Enter a value between -45.00 and +45.00')"></asp:TextBox>
                        <asp:Label EnableViewState="False" ID="lblDc3" CssClass="generallbl" runat="server">DC X</asp:Label>
                        <asp:TextBox ID="txtRfOsAxis" TabIndex="33" Columns="3" MaxLength="3" CssClass="NumericTxt"
                            runat="server" Width="20%" onblur="updateAndValidateAXISOS('txtRfOsAxis', 'txtAcOsDvAxisOpt', 'txtAcOsDvAxis', 'txtRfOsAxis');" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtRfOdCylindrical','Enter a value between -45.00 and +45.00')"></asp:TextBox>
                        <asp:Label EnableViewState="False" ID="lblAxis3" CssClass="generallbl" runat="server">Axis</asp:Label>
                    </div>
                    <div style="width: 10%; text-align: center;">
                        <asp:DropDownList ID="cmbRfOsQuality" TabIndex="34" CssClass="generalcbo" runat="server"
                            Width="100%">
                        </asp:DropDownList>
                    </div>

                    <div style="width: 10%; text-align: center;">
                        <asp:DropDownList ID="cmbRfOsCycloplegic" TabIndex="35" CssClass="generalcbo" runat="server"
                            Width="100%">
                            <asp:ListItem Value="" Text="---- Select ---- "></asp:ListItem>
                            <asp:ListItem Value="Openfeild" Text="Open feild"></asp:ListItem>
                            <asp:ListItem Value="Closefeild" Text="Close feild"></asp:ListItem>


                        </asp:DropDownList>
                    </div>
                    <div class="td" style="width: 25%;">
                        <asp:TextBox ID="txtWetOsSpherical" TabIndex="39" MaxLength="6" CssClass="NumericTxt"
                            runat="server" Width="20%" onblur="javascript:validatecontrol('txtWetOsSpherical');" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtWetOsSpherical','Enter a value between -45.00 and +45.00')"></asp:TextBox>
                        <asp:Label EnableViewState="False" ID="lblWetOsSpherical" CssClass="generallbl" runat="server">DS /</asp:Label>
                        <asp:TextBox ID="txtWetOsCylindrical" TabIndex="40" MaxLength="6" CssClass="NumericTxt"
                            runat="server" Width="20%" onblur="javascript:validatecontrol('txtWetOsCylindrical');" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtWetOsCylindrical','Enter a value between -45.00 and +45.00')"></asp:TextBox>
                        <asp:Label EnableViewState="False" ID="lblWetOsCylindrical" CssClass="generallbl"
                            runat="server">DC X</asp:Label>
                        <asp:TextBox ID="txtWetOsAxis" TabIndex="41" MaxLength="3" CssClass="NumericTxt"
                            runat="server" Width="20%" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtWetOsAxis','Enter a value between 0 and 180')"></asp:TextBox>
                        <asp:Label EnableViewState="False" ID="lblWetOsAxis" CssClass="generallbl" runat="server">Axis</asp:Label>
                    </div>
                </div>


            </div>
        </div>


        <!-- Acceptance -->

        <div class="table" id="TableAcceptanceOpt">
            <div class="tr" style="background-color: #41A9EE;">

                <div style="flex: 5%;">
                    <input id="btAcceptanceOpt" style="width: 22px; height: 15px" onclick="javascript: hideandseeek('divAcceptanceOpt');" type="button" value="-" width="100%">
                </div>
                <div class="td" style="flex: 90%;" colspan="6" align="center">
                    <asp:Label EnableViewState="False" ID="lblAcceptanceOpt" CssClass="BoldLbl" runat="server" ForeColor="#ffffff">Acceptance</asp:Label>
                </div>

                <div style="flex: 5%;" align="center">
                    <strong><a href="#top" style="color: white">TOP</a></strong>
                </div>

            </div>
        </div>



        <div id="divAcceptanceOpt" style="border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none; display: inline; visibility: visible;">
            <div class="tr" style="display: flex; background-color: #DFEEEE;">
                <div style="width: 5%;" align="left"></div>
                <div class="td" style="flex: 42%;" align="center" bgcolor="#DFEEEE">
                    <asp:Label EnableViewState="False" ID="lblDVOpt" runat="server" CssClass="boldlbl">Distance Vision</asp:Label>
                </div>
                <div class="td" style="flex: 42%;" align="center" bgcolor="#DFEEEE">
                    <asp:Label EnableViewState="False" ID="lblNVOpt" runat="server" CssClass="boldlbl">Add</asp:Label>
                </div>
                <div style="flex: 10%;" align="center" bgcolor="#DFEEEE">
                    <asp:Label EnableViewState="False" ID="lblPreferenceOpt" runat="server" CssClass="boldlbl">Preference</asp:Label>
                </div>
            </div>

            <div class="tr">
                <div style="width: 5%;">
                    <asp:Label EnableViewState="False" ID="Label1Opt" CssClass="NewLbl" runat="server"><b>OD</b></asp:Label>
                </div>
                <div class="td" style="width: 45%;">
                    <asp:TextBox ID="txtAcOdDvSphericalOpt" TabIndex="42" runat="server" Columns="3" MaxLength="6" Style="width: 10%;" onblur="javascript:clearStatusMsg()"
                        onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtAcOdDvSphericalOpt','Enter a value between -45.00 and +45.00')"></asp:TextBox>
                    <asp:Label EnableViewState="False" ID="lblds0Opt" runat="server" CssClass="generallbl">DS/</asp:Label>
                    <asp:TextBox ID="txtAcOdDvCylindricalOpt" TabIndex="43" runat="server" Columns="3" MaxLength="6" Style="width: 10%;" onblur="javascript:clearStatusMsg()" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtAcOdDvCylindricalOpt','Enter a value between -45.00 and +45.00')"></asp:TextBox>
                    <asp:Label EnableViewState="False" ID="lbldc0Opt" runat="server" CssClass="generallbl">DC X</asp:Label>
                    <asp:TextBox ID="txtAcOdDvAxisOpt" MaxLength="3" TabIndex="44" runat="server" Columns="3" Style="width: 10%;" onblur="javascript:clearStatusMsg()" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtAcOdDvAxisOpt','Enter a value between 0 and 180')"></asp:TextBox>
                    <asp:Label EnableViewState="False" ID="lblODAxisOpt" runat="server" CssClass="generallbl">Axis</asp:Label>
                    &nbsp;
            <asp:Label EnableViewState="False" ID="lblODDistanceOpt" runat="server" CssClass="generallbl">BCVA</asp:Label>
                    <asp:DropDownList ID="cmbAcOdDvBCVAOpt" TabIndex="45" runat="server" CssClass="generalcbo" Style="width: 15%;"></asp:DropDownList>
                </div>
                <div class="td" style="width: 35%;">
                    <asp:TextBox ID="txtAcOdAddSphericalOpt" TabIndex="50" runat="server" MaxLength="6" Style="width: 20%;" onblur="javascript:clearStatusMsg()" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtAcOdAddSphericalOpt','Enter a value between -45.00 and +45.00')"></asp:TextBox>
                    <asp:Label EnableViewState="False" ID="lblds4Opt" runat="server" CssClass="generallbl">DS</asp:Label>
                    &nbsp;
            <asp:Label EnableViewState="False" ID="lblODNearVisionOpt" runat="server" CssClass="generallbl">BCVA NV</asp:Label>
                    <asp:DropDownList ID="cmbAcOdAddBcvaOpt" TabIndex="51" runat="server" CssClass="generalcbo" Style="width: 20%;"></asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtAcOdAddDistanceOpt" MaxLength="10" TabIndex="52" runat="server" TextMode="SingleLine" Style="width: 20%;" onblur="javascript:clearStatusMsg()" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtAcOdAddDistanceOpt','Enter a max. of 10 Characters')"></asp:TextBox>
                    <font size="1">cm</font>
                </div>
                <div style="width: 10%;">
                    <asp:DropDownList ID="cmbAcOdPreferenceOpt" TabIndex="35" CssClass="generalcbo" runat="server" Style="width: 100%;">
                        <asp:ListItem Value="" Text="---- Select ---- "></asp:ListItem>
                        <asp:ListItem Value="NewGlass" Text="New Glass"></asp:ListItem>
                        <asp:ListItem Value="ContinueSameGlass" Text="Continue same glasses"></asp:ListItem>
                        <asp:ListItem Value="NoImprovementFurther" Text="	No improvement further"></asp:ListItem>
                    </asp:DropDownList>

                </div>
            </div>


            <div class="tr">
                <div style="width: 5%;">
                    <asp:Label EnableViewState="False" ID="Label2Opt" CssClass="NewLbl" runat="server"><b>OS</b></asp:Label>
                </div>
                <div class="td" style="width: 30%;">
                    <asp:TextBox ID="txtAcOsDvSphericalOpt" TabIndex="46" runat="server" Columns="3" MaxLength="6" Style="width: 10%;" onblur="javascript:clearStatusMsg()" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtAcOsDvSphericalOpt','Enter a value between -45.00 and +45.00')"></asp:TextBox>
                    <asp:Label EnableViewState="False" ID="lboslds2Opt" runat="server" CssClass="generallbl">DS/</asp:Label>
                    <asp:TextBox ID="txtAcOsDvCylindricalOpt" TabIndex="47" runat="server" Columns="3" MaxLength="6" Style="width: 10%;" onblur="javascript:clearStatusMsg()" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtAcOsDvCylindricalOpt','Enter a value between -45.00 and +45.00')"></asp:TextBox>
                    <asp:Label EnableViewState="False" ID="lbosldc2Opt" runat="server" CssClass="generallbl">DC X</asp:Label>
                    <asp:TextBox ID="txtAcOsDvAxisOpt" TabIndex="48" MaxLength="3" runat="server" Columns="3" Style="width: 10%;" onblur="javascript:clearStatusMsg()" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtAcOsDvAxisOpt','Enter a value between 0 and 180')"></asp:TextBox>
                    <asp:Label EnableViewState="False" ID="lblOSAxisOpt" runat="server" CssClass="generallbl">Axis</asp:Label>
                    <asp:Label EnableViewState="False" ID="lblOSBCVAOpt" runat="server" CssClass="generallbl">BCVA</asp:Label>
                    <asp:DropDownList ID="cmbAcOsDvBCVAOpt" TabIndex="49" runat="server" CssClass="generalcbo" Style="width: 15%;"></asp:DropDownList>
                </div>
                <div class="td" style="width: 35%;">
                    <asp:TextBox ID="txtAcOsAddSphericalOpt" TabIndex="53" runat="server" Columns="3" MaxLength="6" Style="width: 20%;" onblur="javascript:clearStatusMsg()" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtAcOsAddSphericalOpt','Enter a value between -45.00 and +45.00')"></asp:TextBox>
                    <asp:Label EnableViewState="False" ID="lblNVOSDSOpt" runat="server" CssClass="generallbl">DS</asp:Label>
                    &nbsp;
            <asp:Label EnableViewState="False" ID="lblOSNearVisionOpt" runat="server" CssClass="generallbl">BCVA NV</asp:Label>
                    <asp:DropDownList ID="cmbAcOsAddBcvaOpt" TabIndex="54" runat="server" CssClass="generalcbo" Style="width: 20%;"></asp:DropDownList>
                    &nbsp;&nbsp;
            <asp:TextBox ID="txtAcOsAddDistanceOpt" MaxLength="10" TabIndex="55" runat="server" TextMode="SingleLine" Style="width: 20%;" onblur="javascript:clearStatusMsg()" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtAcOsAddDistanceOpt','Enter a max. of 10 Characters')"></asp:TextBox>
                    <font size="1">cm</font>
                </div>
                <div style="width: 10%;">
                    <asp:DropDownList ID="cmbAcOsPreferenceOpt" TabIndex="35" CssClass="generalcbo" runat="server" Style="width: 100%;">
                        <asp:ListItem Value="" Text="---- Select ---- "></asp:ListItem>
                        <asp:ListItem Value="NewGlass" Text="New Glass"></asp:ListItem>
                        <asp:ListItem Value="ContinueSameGlass" Text="Continue same glasses"></asp:ListItem>
                        <asp:ListItem Value="NoImprovementFurther" Text="	No improvement further"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

        </div>





        <!-- Glass Prescription -->
        <div class="table" id="TableAcceptanceDiv">
            <div class="tr" style="background-color: #41A9EE;">
                <div style="width: 5%;">
                    <input id="btAcceptance" style="width: 22px; height: 15px" onclick="javascript: hideandseeek('divAcceptance');" type="button" value="-" width="100%">
                </div>

                <div class="td" style="width: 90%; colspan: 6; text-align: center;">

                    <label id="lblAcceptance" class="BoldLbl" runat="server" style="color: white;">Glass Prescription</label>
                </div>
                <div style="width: 5%; text-align: center;">
                    <strong><a href="#top" style="color: white">TOP</a></strong>
                </div>
            </div>
        </div>
        <div id="divAcceptance" class="table" style="table-layout: auto; display: inline; visibility: visible; border-top-style: none; border-right-style: none; border-left-style: none; border-collapse: collapse; border-bottom-style: none">
            <div class="tr" style="background-color: #DFEEEE;">
                <div style="width: 5%;" align="left"></div>
                <div class="td" style="width: 50%;" align="center" bgcolor="#DFEEEE">
                    <label id="lblDV" runat="server" class="boldlbl">Distance Vision</label>
                </div>
                <div class="td" style="width: 35%;" align="center" bgcolor="#DFEEEE">
                    <label id="lblNV" runat="server" class="boldlbl">Add</label>
                </div>
                <div style="width: 10%;" align="center" bgcolor="#DFEEEE">
                    <label id="lblPreference" runat="server" class="boldlbl">Preference</label>
                </div>
            </div>

            <div class="tr">
                <div style="width: 5%;">
                    <label id="Label3" class="NewLbl" runat="server"><b>OD</b></label>
                </div>
                <div class="td" style="width: 30%;">
                    <asp:TextBox ID="txtAcOdDvSpherical" TabIndex="56" runat="server" CssClass="NumericTxt"
                        Columns="3" MaxLength="6" Width="10%" onblur="javascript:clearStatusMsg()"
                        onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtAcOdDvSpherical','Enter a value between -45.00 and +45.00')">
                    </asp:TextBox>
                    <asp:Label EnableViewState="False" ID="lblds0" runat="server" CssClass="generallbl">DS/</asp:Label>
                    <asp:TextBox ID="txtAcOdDvCylindrical" TabIndex="57" runat="server" CssClass="NumericTxt"
                        Columns="3" MaxLength="6" Width="10%" onblur="javascript:clearStatusMsg()" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtAcOdDvCylindrical','Enter a value between -45.00 and +45.00')"></asp:TextBox>
                    <asp:Label EnableViewState="False" ID="lbldc0" runat="server" CssClass="generallbl">DC X</asp:Label>
                    <asp:TextBox ID="txtAcOdDvAxis" MaxLength="3" TabIndex="58" runat="server" CssClass="NumericTxt"
                        Columns="3" Width="10%" onblur="javascript:clearStatusMsg()" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtAcOdDvAxis','Enter a value between 0 and 180')"></asp:TextBox>
                    <asp:Label EnableViewState="False" ID="lblODAxis" runat="server" CssClass="generallbl">Axis</asp:Label>
                    &nbsp;
                   <asp:Label EnableViewState="False" ID="lblODDistance" runat="server" CssClass="generallbl">BCVA</asp:Label>
                    <asp:DropDownList ID="cmbAcOdDvBCVA" TabIndex="59" runat="server" CssClass="generalcbo"
                        Width="15%">
                    </asp:DropDownList>
                </div>
                <div class="td" style="width: 35%;">
                    <asp:TextBox ID="txtAcOdAddSpherical" TabIndex="64" runat="server" CssClass="NumericTxt"
                        MaxLength="6" Width="20%" onblur="javascript:clearStatusMsg()" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtAcOdAddSpherical','Enter a value between -45.00 and +45.00')"></asp:TextBox>
                    <asp:Label EnableViewState="False" ID="lblds4" runat="server" CssClass="generallbl">DS</asp:Label>
                    &nbsp;
                    <asp:Label EnableViewState="False" ID="lblODNearVision" runat="server" CssClass="generallbl">BCVA NV</asp:Label>
                    <asp:DropDownList ID="cmbAcOdAddBcva" TabIndex="65" runat="server" CssClass="generalcbo"
                        Width="20%">
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtAcOdAddDistance" MaxLength="10" TabIndex="66" CssClass="numerictxt"
                        runat="server" TextMode="SingleLine" Width="20%" onblur="javascript:clearStatusMsg()"
                        onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtAcOdAddDistance','Enter a max. of 10 Characters')"></asp:TextBox>
                    <font
                        size="1">cm</font>
                </div>
                <div style="width: 10%;">
                    <asp:DropDownList ID="cmbAcOdPreference" TabIndex="35" CssClass="generalcbo" runat="server"
                        Width="100%">
                        <asp:ListItem Value="" Text="---- Select ---- "></asp:ListItem>
                        <asp:ListItem Value="NewGlass" Text="New Glass"></asp:ListItem>
                        <asp:ListItem Value="ContinueSameGlass" Text="Continue same glasses"></asp:ListItem>
                        <asp:ListItem Value="NoImprovementFurther" Text="	No improvement further"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>


            <div class="tr">
                <div style="width: 5%;">
                    <label id="Label2" class="NewLbl" runat="server"><b>OS</b></label>
                </div>
                <div class="td" style="width: 30%;">
                    <asp:TextBox ID="txtAcOsDvSpherical" TabIndex="60" runat="server" CssClass="NumericTxt"
                        Columns="3" MaxLength="6" Width="10%" onblur="javascript:clearStatusMsg()" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtAcOsDvSpherical','Enter a value between -45.00 and +45.00')"></asp:TextBox>
                    <asp:Label EnableViewState="False" ID="lboslds2" runat="server" CssClass="generallbl">DS/</asp:Label>
                    <asp:TextBox ID="txtAcOsDvCylindrical" TabIndex="61" runat="server" CssClass="NumericTxt"
                        Columns="3" MaxLength="6" Width="10%" onblur="javascript:clearStatusMsg()" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtAcOsDvCylindrical','Enter a value between -45.00 and +45.00')"></asp:TextBox>
                    <asp:Label EnableViewState="False" ID="lbosldc2" runat="server" CssClass="generallbl">DC X</asp:Label>
                    <asp:TextBox ID="txtAcOsDvAxis" TabIndex="62" MaxLength="3" runat="server" CssClass="NumericTxt"
                        Columns="3" Width="10%" onblur="javascript:clearStatusMsg()" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtAcOsDvAxis','Enter a value between 0 and 180')"></asp:TextBox>
                    <asp:Label EnableViewState="False" ID="lblOSAxis" runat="server" CssClass="generallbl">Axis</asp:Label>
                    <asp:Label EnableViewState="False" ID="lblOSBCVA" runat="server" CssClass="generallbl">BCVA</asp:Label>
                    <asp:DropDownList ID="cmbAcOsDvBCVA" TabIndex="63" runat="server" CssClass="generalcbo"
                        Width="15%">
                    </asp:DropDownList>
                </div>
                <div class="td" style="width: 35%;">
                    <asp:TextBox ID="txtAcOsAddSpherical" TabIndex="67" runat="server" CssClass="NumericTxt"
                        Columns="3" MaxLength="6" Width="20%" onblur="javascript:clearStatusMsg()" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtAcOsAddSpherical','Enter a value between -45.00 and +45.00')"></asp:TextBox>
                    <asp:Label EnableViewState="False" ID="Label9" runat="server" CssClass="generallbl">DS</asp:Label>
                    &nbsp;
                    <asp:Label EnableViewState="False" ID="Label10" runat="server" CssClass="generallbl">BCVA NV</asp:Label>
                    <asp:DropDownList ID="cmbAcOsAddBcva" TabIndex="68" runat="server" CssClass="generalcbo"
                        Width="20%">
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtAcOsAddDistance" MaxLength="10" TabIndex="69" CssClass="numerictxt"
                        runat="server" TextMode="SingleLine" Width="20%" onblur="javascript:clearStatusMsg()"
                        onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtAcOsAddDistance','Enter a max. of 10 Characters')"></asp:TextBox>
                    <font
                        size="1">cm</font>
                </div>
                <div style="width: 10%;">
                    <asp:DropDownList ID="cmbAcOsPreference" TabIndex="35" CssClass="generalcbo" runat="server"
                        Width="100%">
                        <asp:ListItem Value="" Text="---- Select ---- "></asp:ListItem>
                        <asp:ListItem Value="NewGlass" Text="New Glass"></asp:ListItem>
                        <asp:ListItem Value="ContinueSameGlass" Text="Continue same glasses"></asp:ListItem>
                        <asp:ListItem Value="NoImprovementFurther" Text="	No improvement further"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>

        <!-- Proposed Prism -->

        <div style="display: none">
            <div class="table" id="TableProposed" style="display: table; width: 100%; border-collapse: collapse;">
                <div class="tr" style="display: table-row; background-color: #41A9EE;">
                    <div class="td" style="display: table-cell; width: 5%; border: 1px solid black; background-color: #41A9EE;">
                        <input id="btProposed" style="width: 22px; height: 15px;" onclick="javascript: hideandseeek('divComp');" type="button" value="+">
                    </div>

                    <div class="td" style="display: table-cell; width: 90%; border: 1px solid black; background-color: #41A9EE;" colspan="6" align="center">
                        <asp:Label EnableViewState="False" ID="lblProposedPrism" runat="server" CssClass="boldlbl" ForeColor="#ffffff">Proposed Prism</asp:Label>
                    </div>

                    <div class="td" style="display: table-cell; width: 5%; border: 1px solid black; background-color: #41A9EE;" align="center">
                        <strong><a href="#top" style="color: white">TOP</a></strong>
                    </div>
                </div>
            </div>

            <div id="divComp" style="table-layout: auto; display: none; visibility: hidden; border-top-style: none; border-right-style: none; border-left-style: none; border-collapse: collapse; border-bottom-style: none">
                <div class="table" id="TablePart" style="display: table; width: 100%; border-collapse: collapse;">
                    <div class="tr" style="display: table-row;">
                        <div class="td" style="display: table-cell; width: 10%;">
                            <asp:Label EnableViewState="False" ID="Label6" CssClass="NewLbl" runat="server"><b>OD</b></asp:Label>
                        </div>
                        <div class="td" style="display: table-cell; width: 90%;">
                            <asp:TextBox ID="txtAcOdPrism1" Width="10%" TabIndex="70" MaxLength="5" CssClass="Numerictxt"
                                runat="server" onblur="javascript:clearStatusMsg()" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtAcOdPrism1','Enter a value between 0 and 150')"></asp:TextBox>
                            <img id="Img5" title="Triangle" src="~/img/Triangle.gif"
                                border="0" runat="server">
                            <asp:DropDownList ID="cmbAcOdPrism1" TabIndex="71" CssClass="generalcbo" runat="server"
                                Width="20%">
                            </asp:DropDownList>
                            <asp:TextBox ID="txtAcOsPrism1" TabIndex="72" CssClass="NumericTxt" MaxLength="5"
                                runat="server" Width="10%" onblur="javascript:clearStatusMsg()" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtAcOsPrism1','Enter a value between 0 and 150')"></asp:TextBox>
                            <img id="Img6" title="Triangle" src="~/img/Triangle.gif"
                                border="0" runat="server">
                            <asp:DropDownList ID="cmbAcOsPrism1" TabIndex="73" CssClass="generalcbo" runat="server"
                                Width="20%">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="tr" style="display: table-row;">
                        <div class="td" style="display: table-cell; width: 10%;">
                            <asp:Label EnableViewState="False" ID="Label7" CssClass="NewLbl" runat="server"><b>OS</b></asp:Label>
                        </div>
                        <div class="td" style="display: table-cell; width: 90%;">
                            <asp:TextBox ID="txtAcOdPrism2" TabIndex="74" MaxLength="5" CssClass="Numerictxt"
                                runat="server" Width="10%" onblur="javascript:clearStatusMsg()" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtAcOdPrism2','Enter a value between 0 and 150')"></asp:TextBox>
                            <img id="Img7" title="Triangle" src="~/img/Triangle.gif"
                                border="0" runat="server">
                            <asp:DropDownList ID="cmbAcOdPrism2" TabIndex="75" CssClass="generalcbo" runat="server"
                                Width="20%">
                            </asp:DropDownList>
                            <asp:TextBox ID="txtAcOsPrism2" TabIndex="76" CssClass="NumericTxt" MaxLength="5"
                                runat="server" Width="10%" onblur="javascript:clearStatusMsg()" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtAcOsPrism2','Enter a value between 0 and 150')"></asp:TextBox>
                            <img id="Img8" title="Triangle" src="~/img/Triangle.gif"
                                border="0" runat="server">
                            <asp:DropDownList ID="cmbAcOsPrism2" TabIndex="77" CssClass="generalcbo" runat="server"
                                Width="20%">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
        </div>



        <!-- Refining Procedure -->
        <div style="display: none">
            <div class="table" id="TableRadio" style="display: table; width: 100%; border-collapse: collapse;">
                <div class="tr" style="display: table-row; background-color: #41A9EE;">
                    <div class="td" style="display: table-cell; width: 5%;">
                        <input id="btComp" style="width: 22px; height: 15px" onclick="javascript: hideandseeek('divRefining');" type="button" value="+" width="100%">
                    </div>
                    <div class="td" style="display: table-cell; width: 90%;" colspan="10" align="center">
                        <asp:Label EnableViewState="False" ID="lblRP" runat="server" CssClass="boldlbl" ForeColor="#ffffff">Refining Procedure</asp:Label>
                    </div>
                    <div class="td" style="display: table-cell; align: center; width: 5%;">
                        <strong><a href="#top" style="color: white">TOP</a></strong>
                    </div>
                </div>
            </div>

            <div id="divRefining" style="table-layout: auto; display: none; visibility: hidden; border-top-style: none; border-right-style: none; border-left-style: none; border-collapse: collapse; border-bottom-style: none">
                <div class="table" id="TableRefiningHide" style="display: table; width: 100%;">
                    <div class="tr" style="display: table-row;">
                        <div class="td" style="display: table-cell; width: 7%;">
                            <asp:Label EnableViewState="False" ID="Label8" class="NewLbl" runat="server"><b>OD</b></asp:Label>
                        </div>
                        <div class="td" style="display: table-cell; width: 16%;">
                            <asp:DropDownList ID="cmbAcOdRpRefining" TabIndex="78" runat="server" CssClass="generalcbo" Style="width: 100%;"></asp:DropDownList>
                        </div>
                        <div class="td" style="display: table-cell; width: 10%;">
                            <asp:Label EnableViewState="False" ID="lblJCCOD" runat="server" CssClass="generallbl" Style="width: 100%;">JCC</asp:Label>
                        </div>
                        <div class="td" style="display: table-cell; width: 16%;">
                            <asp:RadioButtonList ID="radAcOdRpJCC" TabIndex="79" runat="server" CssClass="GeneralRbt" AutoPostBack="False" RepeatDirection="Horizontal" Style="width: 100%;">
                                <asp:ListItem Value="N">No</asp:ListItem>
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div class="td" style="display: table-cell; width: 10%;">
                            <asp:Label EnableViewState="False" ID="lblODFogging" runat="server" CssClass="generallbl" Style="width: 100%;">Fogging</asp:Label>
                        </div>
                        <div class="td" style="display: table-cell; width: 16%;">
                            <asp:RadioButtonList ID="radAcOdRpFogging" TabIndex="80" runat="server" CssClass="GeneralRbt" AutoPostBack="False" RepeatDirection="Horizontal" Style="width: 100%;">
                                <asp:ListItem Value="N">No</asp:ListItem>
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="tr" style="display: table-row;">
                        <div class="td" style="display: table-cell; width: 7%;">
                            <asp:Label EnableViewState="False" ID="Label5" class="NewLbl" runat="server"><b>OS</b></asp:Label>
                        </div>
                        <div class="td" style="display: table-cell; width: 16%;">
                            <asp:DropDownList ID="cmbAcOsRpRefining" TabIndex="81" runat="server" CssClass="generalcbo" Style="width: 100%;"></asp:DropDownList>
                        </div>
                        <div class="td" style="display: table-cell; width: 10%;">
                            <asp:Label EnableViewState="False" ID="lblOSJCC" runat="server" CssClass="generallbl" Style="width: 100%;">JCC</asp:Label>
                        </div>
                        <div class="td" style="display: table-cell; width: 16%;">
                            <asp:RadioButtonList ID="radAcOsRpJCC" TabIndex="82" runat="server" CssClass="GeneralRbt" AutoPostBack="False" RepeatDirection="Horizontal" Style="width: 100%;">
                                <asp:ListItem Value="N">No</asp:ListItem>
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div class="td" style="display: table-cell; width: 10%;">
                            <asp:Label EnableViewState="False" ID="lblOSFogging" runat="server" CssClass="generallbl" Style="width: 100%;">Fogging</asp:Label>
                        </div>
                        <div class="td" style="display: table-cell; width: 16%;">
                            <asp:RadioButtonList ID="radAcOsRpFogging" TabIndex="83" runat="server" CssClass="GeneralRbt" AutoPostBack="False" RepeatDirection="Horizontal" Style="width: 100%;">
                                <asp:ListItem Value="N">No</asp:ListItem>
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                </div>
            </div>
        </div>



        <!-- Refining Procedure -->
        <div style="display: none">
            <div class="table" id="TableIntermediate" style="display: table; width: 100%;">
                <div class="tr" style="display: table-row; background-color: #41A9EE;">
                    <div class="td" style="display: table-cell; width: 5%;">
                        <input id="btInter" class="CollapseBtn" style="width: 22px; height: 15px" onclick="javascript: hideandseeek('divInter');" type="button" value="+" width="100%">
                    </div>
                    <div class="td" style="display: table-cell; width: 90%;" colspan="6" align="center">
                        <asp:Label EnableViewState="False" ID="lblIV" CssClass="generallbl" runat="server" ForeColor="#ffffff">
                <b>Intermediate Vision</b>
                        </asp:Label>
                    </div>
                    <div class="td" style="display: table-cell; width: 5%;" align="center">
                        <strong><a href="#top" style="color: white">TOP</a></strong>
                    </div>
                </div>
            </div>

            <div id="divInter" style="table-layout: auto; display: none; visibility: hidden; border-top-style: none; border-right-style: none; border-left-style: none; border-collapse: collapse; border-bottom-style: none">
                <div class="table" id="TableHide" style="display: table; width: 100%;">
                    <div class="tr" style="display: table-row;">
                        <div class="td" style="display: table-cell; width: 10%;">
                            <asp:Label EnableViewState="False" ID="Label11" CssClass="NewLbl" runat="server"><b>OD</b></asp:Label>
                        </div>
                        <div class="td" style="display: table-cell; width: 90%;">
                            <asp:TextBox Width="10%" ID="txtAcOdIVision" MaxLength="6" TabIndex="84" CssClass="numerictxt" runat="server" TextMode="SingleLine" onblur="javascript:clearStatusMsg()" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtAcOdIVision','Enter a value between 0.00 and 10.00')"></asp:TextBox>
                            <asp:Label EnableViewState="False" ID="txtAcIvOdDS" runat="server" CssClass="generallbl">DS</asp:Label>
                            <asp:TextBox Width="15%" ID="txtAcOdIVRDistace" MaxLength="10" TabIndex="85" CssClass="numerictxt" runat="server" TextMode="SingleLine" onblur="javascript:clearStatusMsg()" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtAcOdIVRDistace','Enter a max. of 10 Characters')"></asp:TextBox>
                            <font size="1">cm</font>
                            <asp:Label EnableViewState="False" ID="lblAcOdPrism" CssClass="generallbl" runat="server">Prism</asp:Label>
                            <asp:TextBox ID="txtAcOdPrismValue" TabIndex="86" MaxLength="5" Width="10%" CssClass="Numerictxt" runat="server" onblur="javascript:clearStatusMsg()" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtAcOdPrismValue','Enter a value between 0 and 150')"></asp:TextBox>
                            <img id="Img3" title="Triangle" src="~/img/Triangle.gif" border="0" runat="server">
                            <asp:DropDownList ID="cmbAcOdPrismType" TabIndex="87" CssClass="generalcbo" Width="15%" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="tr" style="display: table-row;">
                        <div class="td" style="display: table-cell; width: 10%;">
                            <asp:Label EnableViewState="False" ID="Label12" CssClass="NewLbl" runat="server"><b>OS</b></asp:Label>
                        </div>
                        <div class="td" style="display: table-cell; width: 90%;">
                            <asp:TextBox Width="10%" ID="txtAcOsIVision" MaxLength="6" TabIndex="88" CssClass="numerictxt" runat="server" TextMode="SingleLine" onblur="javascript:clearStatusMsg()" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtAcOsIVision','Enter a value between 0.00 and 10.00')"></asp:TextBox>
                            <asp:Label EnableViewState="False" ID="txtAcIvOsDS" runat="server" CssClass="generallbl">DS</asp:Label>
                            <asp:TextBox Width="15%" ID="txtAcOsIVRDistace" MaxLength="10" TabIndex="89" CssClass="numerictxt" runat="server" TextMode="SingleLine" onblur="javascript:clearStatusMsg()" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtAcOsIVRDistace','Enter a max. of 10 Characters')"></asp:TextBox>
                            <font size="1">cm</font>
                            <asp:Label EnableViewState="False" ID="lblAcOsPrism" CssClass="generallbl" runat="server">Prism</asp:Label>
                            <asp:TextBox ID="txtAcOsPrismValue" TabIndex="90" MaxLength="5" CssClass="Numerictxt" runat="server" Width="10%" onblur="javascript:clearStatusMsg()" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtAcOsPrismValue','Enter a value between 0 and 150')"></asp:TextBox>
                            <img id="Img4" title="Triangle" src="~/img/Triangle.gif" border="0" runat="server">
                            <asp:DropDownList ID="cmbAcOsPrismType" TabIndex="91" CssClass="generalcbo" runat="server" Width="15%"></asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
        </div>


        <%--</div>--%>

        <div style="display: none">
            <table class="table" id="Table2" cellspacing="1" cellpadding="1" border="0" runat="server" width="100%">
                <tr>
                    <td width="100%" colspan="6">
                        <asp:Label EnableViewState="False" ID="lblResult" runat="server" CssClass="generallbl">Diagnosis Result</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="50%">
                        <asp:TextBox ID="txtAcOdDiagnosis" CssClass="GeneralTxtDisable" runat="server" Width="100%"
                            onblur="javascript:clearStatusMsg()"></asp:TextBox>
                    </td>
                    <td width="50%">
                        <asp:TextBox ID="txtAcOsDiagnosis" CssClass="GeneralTxtDisable" runat="server" Width="100%"
                            onblur="javascript:clearStatusMsg()"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>





        <div class="table" id="TableSummary" style="display: table; width: 100%; border-collapse: collapse;">
            <div class="tr" style="display: table-row;">
                <div class="td" style="display: table-cell; width: 10%;">
                    <asp:Label EnableViewState="False" ID="lblSummary" runat="server" CssClass="boldlbl">Summary</asp:Label>
                </div>
                <div class="td" style="display: table-cell; width: 0%;">
                    <asp:TextBox ID="txtSummary" onblur="javascript:clearStatusMsg()" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtSummary','Enter a maximum of 4000 characters')" TabIndex="97" runat="server" CssClass="NumericTxt" Width="0%" Rows="4" TextMode="MultiLine" Visible="true"></asp:TextBox>
                </div>
                <div class="td" style="display: table-cell; width: 70%;">

                   <%-- <asp:Label ID="lblHtmlSummary" runat="server" Text=""></asp:Label>--%>
                    <asp:Label ID="lblHtmlSummary1" runat="server" Text="" ></asp:Label>


                </div>


            </div>
        </div>

        <script type="text/javascript">
            function InterMediate() {

                var currentURL = window.location.href;

                var regex = /[?&]studentID=([^&]+)/;
                var match = regex.exec(currentURL);
                if (match) {
                    var studentID = match[1];
                    var strUrl = '/COMMUNITY_OUTREACH/POPUPSCREENS/InterMediateVision.aspx?studentID=' + studentID;
                    var width = 1000;
                    var height = 500;
                    var left = (screen.width - width) / 2;
                    var top = (screen.height - height) / 2;
                    var strFeatures = 'height=' + height + ',width=' + width + ',left=' + left + ',top=' + top + ',center=yes,edge=raised,resizable=no,scrollbars=yes,status=yes,unadorned=no';

                    window.open(strUrl, 'InterMediateVisionScreen', strFeatures);
                } else {
                    alert('studentID parameter not found in the URL.');
                }
            }

        </script>

        <script type="text/javascript">
            function Postdilate() {
                var currentURL = window.location.href;

                var regex = /[?&]studentID=([^&]+)/;
                var match = regex.exec(currentURL);
                if (match) {
                    var studentID = match[1];
                    var strUrl = '/COMMUNITY_OUTREACH/POPUPSCREENS/PostDilatedRefraction.aspx?studentID=' + studentID;
                    var width = 900;
                    var height = 500;
                    var left = (screen.width - width) / 2;
                    var top = (screen.height - height) / 2;
                    var strFeatures = 'height=' + height + ',width=' + width + ',left=' + left + ',top=' + top + ',center=yes,edge=raised,resizable=no,scrollbars=yes,status=yes,unadorned=no';

                    window.open(strUrl, 'PostDilatedRefractionScreen', strFeatures);
                } else {
                    alert('studentID parameter not found in the URL.');
                }
            }

        </script>



        <script type="text/javascript">
            function Ocularhistory() {

                var currentURL = window.location.href;

                var regex = /[?&]studentID=([^&]+)/;
                var match = regex.exec(currentURL);
                if (match) {
                    var studentID = match[1];
                    var strUrl = '/COMMUNITY_OUTREACH/POPUPSCREENS/OcularHistory.aspx?studentID=' + studentID;
                    var width = 900;
                    var height = 500;
                    var left = (screen.width - width) / 2;
                    var top = (screen.height - height) / 2;
                    var strFeatures = 'height=' + height + ',width=' + width + ',left=' + left + ',top=' + top + ',center=yes,edge=raised,resizable=no,scrollbars=yes,status=yes,unadorned=no';

                    window.open(strUrl, 'Ocularhistory', strFeatures);
                } else {
                    alert('studentID parameter not found in the URL.');
                }
            }

        </script>

        <script type="text/javascript">
            function Complaints() {
                var currentURL = window.location.href;

                var regex = /[?&]studentID=([^&]+)/;
                var match = regex.exec(currentURL);
                if (match) {
                    var studentID = match[1];


                    var strUrl = '/COMMUNITY_OUTREACH/POPUPSCREENS/Complaints.aspx?studentID=' + studentID;
                    var width = 900;
                    var height = 500;
                    var left = (screen.width - width) / 2;
                    var top = (screen.height - height) / 2;
                    var strFeatures = 'height=' + height + ',width=' + width + ',left=' + left + ',top=' + top + ',center=yes,edge=raised,resizable=no,scrollbars=yes,status=yes,unadorned=no';

                    window.open(strUrl, 'Complaints', strFeatures);
                } else {
                    alert('studentID parameter not found in the URL.');
                }
            }

        </script>

        <script type="text/javascript">
            function othertest() {

                var currentURL = window.location.href;

                var regex = /[?&]studentID=([^&]+)/;
                var match = regex.exec(currentURL);
                if (match) {
                    var studentID = match[1];


                    var strUrl = '/COMMUNITY_OUTREACH/POPUPSCREENS/OtherTest.aspx?studentID=' + studentID;
                    var width = 1100;
                    var height = 700;
                    var left = (screen.width - width) / 2;
                    var top = (screen.height - height) / 2;
                    var strFeatures = 'height=' + height + ',width=' + width + ',left=' + left + ',top=' + top + ',center=yes,edge=raised,resizable=no,scrollbars=yes,status=yes,unadorned=no';

                    window.open(strUrl, 'Complaints', strFeatures);
                } else {
                    alert('studentID parameter not found in the URL.');
                }


            }

        </script>

        <script type="text/javascript">
            function Managementpop() {

                 var currentURL = window.location.href;

                var regex = /[?&]studentID=([^&]+)/;
                var match = regex.exec(currentURL);
                if (match) {
                    var studentID = match[1];


                    var strUrl = '/COMMUNITY_OUTREACH/POPUPSCREENS/Management.aspx?studentID=' + studentID;
                    var width = 1100;
                    var height = 700;
                    var left = (screen.width - width) / 2;
                    var top = (screen.height - height) / 2;
                    var strFeatures = 'height=' + height + ',width=' + width + ',left=' + left + ',top=' + top + ',center=yes,edge=raised,resizable=no,scrollbars=yes,status=yes,unadorned=no';

                    window.open(strUrl, 'Complaints', strFeatures);
                } else {
                    alert('studentID parameter not found in the URL.');
                }

                //var strUrl = '/COMMUNITY_OUTREACH/POPUPSCREENS/Management.aspx';
                //var width = 1100;
                //var height = 700;
                //var left = (screen.width - width) / 2;
                //var top = (screen.height - height) / 2;
                //var strFeatures = 'height=' + height + ',width=' + width + ',left=' + left + ',top=' + top + ',center=yes,edge=raised,resizable=no,scrollbars=yes,status=yes,unadorned=no';

                //window.open(strUrl, 'Management', strFeatures);
            }

        </script>



        <script language="javascript" type="text/javascript">
            window.setTimeout("assignValToIframe()", 150)
            var element = document.getElementById("form1")
            element.setAttribute("autocomplete", "off");

            function assignValToIframe() {
                try {
                    var s = document.getElementById("pgContentHolder_pgContent_newText").value;

                    var iFrame = document.getElementById('ifrmeGOPDSummary');

                    if (iFrame.contentDocument) { // FF
                        iFrame.contentDocument.body.innerHTML = s; //getElementsByTagName('body')[0];
                    }
                    else if (iFrame.contentWindow) { // IE
                        iFrame.contentWindow.document.body.innerHTML = s; //document.getElementsByTagName('body')[0];
                    }

                    if (document.getElementById("pgContentHolder_pgContent_hdnTemRemarks").value != "") {
                        document.getElementById("pgContentHolder_pgContent_ApplyTemplate_txtTemplateRemarks").value = document.getElementById("pgContentHolder_pgContent_hdnTemRemarks").value;
                    }
                }
                catch (e) {
                }
            }

        </script>


        <script language="javascript" type="text/javascript">

            function hideandseeek(id) {
                if (document.getElementById(id).style.visibility == "visible") {
                    document.getElementById(id).style.visibility = "hidden";
                    document.getElementById(id).style.display = "none";

                    var btn = event.srcElement;
                    document.getElementById(btn.id).value = "+";
                }
                else {
                    document.getElementById(id).style.visibility = "visible";
                    document.getElementById(id).style.display = "inline";

                    var btn = event.srcElement;
                    document.getElementById(btn.id).value = "-";
                    document.getElementById(id + "Head").scrollIntoView(true);
                }
            }

        </script>

        <script type="text/javascript">
            function updateAndValidateAXISOD(TextBoxIdAXISOSVALOD, TextBoxId1AXISOSVALOD, TextBoxId2AXISOSSVALOD) {
                var TextBoxIdAXISOD = document.getElementById(TextBoxIdAXISOSVALOD);
                var TextBoxId1AXISOD = document.getElementById(TextBoxId1AXISOSVALOD);
                var TextBoxId2AXISOOD = document.getElementById(TextBoxId2AXISOSSVALOD);

                if (TextBoxIdAXISOD && TextBoxId1AXISOD && TextBoxId2AXISOOD) {
                    var value = TextBoxIdAXISOD.value;
                    TextBoxId1AXISOD.value = value;
                    TextBoxId2AXISOOD.value = value;
                }
            }
        </script>

        <script type="text/javascript">
            function updateAndValidateAXISOS(TextBoxIdAXISOSVAL, TextBoxId1AXISOSVAL, TextBoxId2AXISOSSVAL) {
                var TextBoxIdAXISOS = document.getElementById(TextBoxIdAXISOSVAL);
                var TextBoxId1AXISOS = document.getElementById(TextBoxId1AXISOSVAL);
                var TextBoxId2AXISOSS = document.getElementById(TextBoxId2AXISOSSVAL);

                if (TextBoxIdAXISOS && TextBoxId1AXISOS && TextBoxId2AXISOSS) {
                    var value = TextBoxIdAXISOS.value;
                    TextBoxId1AXISOS.value = value;
                    TextBoxId2AXISOSS.value = value;
                }
            }
        </script>

        <script>
            function updateAndValidateDXOS(TextBoxId1DCXOS, TextBoxId111DCXOS, targetTextBoxId222DCXOS, controlNameDCXOS) {
                // Call the updateTextBoxes function
                updateTextBoxesDCXOS(TextBoxId1DCXOS, TextBoxId111DCXOS, targetTextBoxId222DCXOS);

                // Call the validatecontrol function
                validatecontrol(controlNameDCXOS);
            }

            function updateTextBoxesDCXOS(TextBoxDCXOS, TextIDDCXOS1, TextIDDCXXOS2) {
                var TextBoxDCXOS = document.getElementById('<%= txtRfOsCylindrical.ClientID %>');
                var TextIDDCXOS1 = document.getElementById('<%= txtAcOsDvCylindricalOpt.ClientID %>');
                var TextIDDCXXOS2 = document.getElementById('<%= txtAcOsDvCylindrical.ClientID %>');

                if (TextBoxDCXOS && TextIDDCXOS1 && TextIDDCXXOS2) {
                    var value = TextBoxDCXOS.value;
                    TextIDDCXOS1.value = value;
                    TextIDDCXXOS2.value = value;
                }
            }

            // Rest of your JavaScript code here...

            function validatecontrol(strControlName) {
                var bool = validate(strControlName);

                if (bool == false) {
                    setTimeout("Focuset('" + strControlName + "');", 50);
                }
            }

            function Focuset(strControlName) {
                document.getElementById(strControlName).focus();
                return false;
            }

            function validate(strControlName) {
                var strValue = document.getElementById(strControlName).value;

                if (strValue.length != 0) {
                    if (strValue.length != 6) {
                        if (strValue.length != 5) {
                            alert("Improper Format, Proper Format is [+##.## or -##.## or +#.## or -#.##] ");
                            //document.getElementById(strControlName).focus();
                            return false;
                        }
                    }
                }

                if (strValue.length != 0) {
                    if (strValue.substring(0, 1) != "+" && strValue.substring(0, 1) != "-") {
                        alert("Value must start with + or - , Proper Format [+##.## or -##.## or +#.## or -#.##] ");
                        //document.getElementById(strControlName).focus();
                        return false;
                    }
                }

                if (strValue.length != 0) {
                    if (strValue.substring(1, 3) < 0 || strValue.substring(1, 3) > 45) {
                        alert("Value must be between -45.00 to +45.00");
                        //document.getElementById(strControlName).focus();
                        return false;
                    }
                }

                if (strValue.length != 0) {
                    if (strValue.length == 6) {
                        var strNo = strValue.substring(1, 6);
                        var intNum = parseFloat(strNo);
                        if (intNum > 44.75) {
                            alert("invalid number range, not within specified range of 45");
                            //document.getElementById(strControlName).focus();
                            return false;
                        }
                        if ((strValue.substring(4, 6) % 25) != 0) {
                            alert("Invalid Decimal value, must be in steps of 25");
                            //document.getElementById(strControlName).focus();
                            return false;
                        }
                    }
                    else if (strValue.length == 5) {
                        var strNo = strValue.substring(1, 5);
                        var intNum = parseFloat(strNo);
                        if (intNum > 44.75) {
                            alert("invalid number range, not within specified range of 45");
                            //document.getElementById(strControlName).focus();
                        }
                        if ((strValue.substring(3, 5) % 25) != 0) {
                            alert("Invalid Decimal value");
                            //document.getElementById(strControlName).focus();
                            return false;
                        }
                    }
                }
                return true;
            }


        </script>


        <script>
            function updateAndValidateDSOS(TextBoxId1DSOS, TextBoxId111DSOS, targetTextBoxId222DSOS, controlNameDSOS) {
                // Call the updateTextBoxes function
                updateTextBoxesDSOS(TextBoxId1DSOS, TextBoxId111DSOS, targetTextBoxId222DSOS);

                // Call the validatecontrol function
                validatecontrol(controlNameDSOS);
            }

            function updateTextBoxesDSOS(TextBoxDSOS, TextIDDSOS1, TextIDDSOS2) {
                var TextBoxDSOS = document.getElementById('<%= txtRfOsSpherical.ClientID %>');
                var TextIDDSOS1 = document.getElementById('<%= txtAcOsDvSphericalOpt.ClientID %>');
                var TextIDDSOS2 = document.getElementById('<%= txtAcOsDvSpherical.ClientID %>');

                if (TextBoxDSOS && TextIDDSOS1 && TextIDDSOS2) {
                    var value = TextBoxDSOS.value;
                    TextIDDSOS1.value = value;
                    TextIDDSOS2.value = value;
                }
            }

            // Rest of your JavaScript code here...

            function validatecontrol(strControlName) {
                var bool = validate(strControlName);

                if (bool == false) {
                    setTimeout("Focuset('" + strControlName + "');", 50);
                }
            }

            function Focuset(strControlName) {
                document.getElementById(strControlName).focus();
                return false;
            }

            function validate(strControlName) {
                var strValue = document.getElementById(strControlName).value;

                if (strValue.length != 0) {
                    if (strValue.length != 6) {
                        if (strValue.length != 5) {
                            alert("Improper Format, Proper Format is [+##.## or -##.## or +#.## or -#.##] ");
                            //document.getElementById(strControlName).focus();
                            return false;
                        }
                    }
                }

                if (strValue.length != 0) {
                    if (strValue.substring(0, 1) != "+" && strValue.substring(0, 1) != "-") {
                        alert("Value must start with + or - , Proper Format [+##.## or -##.## or +#.## or -#.##] ");
                        //document.getElementById(strControlName).focus();
                        return false;
                    }
                }

                if (strValue.length != 0) {
                    if (strValue.substring(1, 3) < 0 || strValue.substring(1, 3) > 45) {
                        alert("Value must be between -45.00 to +45.00");
                        //document.getElementById(strControlName).focus();
                        return false;
                    }
                }

                if (strValue.length != 0) {
                    if (strValue.length == 6) {
                        var strNo = strValue.substring(1, 6);
                        var intNum = parseFloat(strNo);
                        if (intNum > 44.75) {
                            alert("invalid number range, not within specified range of 45");
                            //document.getElementById(strControlName).focus();
                            return false;
                        }
                        if ((strValue.substring(4, 6) % 25) != 0) {
                            alert("Invalid Decimal value, must be in steps of 25");
                            //document.getElementById(strControlName).focus();
                            return false;
                        }
                    }
                    else if (strValue.length == 5) {
                        var strNo = strValue.substring(1, 5);
                        var intNum = parseFloat(strNo);
                        if (intNum > 44.75) {
                            alert("invalid number range, not within specified range of 45");
                            //document.getElementById(strControlName).focus();
                        }
                        if ((strValue.substring(3, 5) % 25) != 0) {
                            alert("Invalid Decimal value");
                            //document.getElementById(strControlName).focus();
                            return false;
                        }
                    }
                }
                return true;
            }
        </script>

        <script>
            function updateAndValidateAXIS(TextBoxId1AX, targetTextBoxId2AX, targetTextBoxId3AX, controlNameAXIS) {
                // Call the updateTextBoxes function
                updateTextBoxesAXIS(TextBoxId1AX, targetTextBoxId2AX, targetTextBoxId3AX);

                // Call the validatecontrol function
                validatecontrol(controlNameAXIS);
            }

            function updateTextBoxesAXIS(TextBoxIdAX, TextBoxId12AX, TextBoxId3AX) {
                var TextBoxIdAX = document.getElementById('<%= txtRfOdAxis.ClientID %>');
                var TextBoxId12AX = document.getElementById('<%= txtAcOdDvAxisOpt.ClientID %>');
                var TextBoxId3AX = document.getElementById('<%= txtAcOdDvAxis.ClientID %>');

                if (TextBoxIdAX && TextBoxId12AX && TextBoxId3AX) {
                    var value = TextBoxIdAX.value;
                    TextBoxId12AX.value = value;
                    TextBoxId3AX.value = value;
                }
            }

            // Rest of your JavaScript code here...

            function validatecontrol(strControlName) {
                var bool = validate(strControlName);

                if (bool == false) {
                    setTimeout("Focuset('" + strControlName + "');", 50);
                }
            }

            function Focuset(strControlName) {
                document.getElementById(strControlName).focus();
                return false;
            }

            function validate(strControlName) {
                var strValue = document.getElementById(strControlName).value;

                if (strValue.length != 0) {
                    if (strValue.length != 6) {
                        if (strValue.length != 5) {
                            alert("Improper Format, Proper Format is [+##.## or -##.## or +#.## or -#.##] ");
                            //document.getElementById(strControlName).focus();
                            return false;
                        }
                    }
                }

                if (strValue.length != 0) {
                    if (strValue.substring(0, 1) != "+" && strValue.substring(0, 1) != "-") {
                        alert("Value must start with + or - , Proper Format [+##.## or -##.## or +#.## or -#.##] ");
                        //document.getElementById(strControlName).focus();
                        return false;
                    }
                }

                if (strValue.length != 0) {
                    if (strValue.substring(1, 3) < 0 || strValue.substring(1, 3) > 45) {
                        alert("Value must be between -45.00 to +45.00");
                        //document.getElementById(strControlName).focus();
                        return false;
                    }
                }

                if (strValue.length != 0) {
                    if (strValue.length == 6) {
                        var strNo = strValue.substring(1, 6);
                        var intNum = parseFloat(strNo);
                        if (intNum > 44.75) {
                            alert("invalid number range, not within specified range of 45");
                            //document.getElementById(strControlName).focus();
                            return false;
                        }
                        if ((strValue.substring(4, 6) % 25) != 0) {
                            alert("Invalid Decimal value, must be in steps of 25");
                            //document.getElementById(strControlName).focus();
                            return false;
                        }
                    }
                    else if (strValue.length == 5) {
                        var strNo = strValue.substring(1, 5);
                        var intNum = parseFloat(strNo);
                        if (intNum > 44.75) {
                            alert("invalid number range, not within specified range of 45");
                            //document.getElementById(strControlName).focus();
                        }
                        if ((strValue.substring(3, 5) % 25) != 0) {
                            alert("Invalid Decimal value");
                            //document.getElementById(strControlName).focus();
                            return false;
                        }
                    }
                }
                return true;
            }
        </script>

        <script>
            function updateAndValidateDX(sourceTextBoxId01, targetTextBoxId11, targetTextBoxId22, controlNameDX) {
                // Call the updateTextBoxes function
                updateTextBoxesDX(sourceTextBoxId01, targetTextBoxId11, targetTextBoxId22);

                // Call the validatecontrol function
                validatecontrol(controlNameDX);
            }

            function updateTextBoxesDX(sourceTextBoxIdDX, targetTextBoxId1DX, targetTextBoxId2DX) {
                var sourceTextBoxIdDX = document.getElementById('<%= txtRfOdCylindrical.ClientID %>');
                var targetTextBoxId1DX = document.getElementById('<%= txtAcOdDvCylindricalOpt.ClientID %>');
                var targetTextBoxId2DX = document.getElementById('<%= txtAcOdDvCylindrical.ClientID %>');

                if (sourceTextBoxIdDX && targetTextBoxId1DX && targetTextBoxId2DX) {
                    var value = sourceTextBoxIdDX.value;
                    targetTextBoxId1DX.value = value;
                    targetTextBoxId2DX.value = value;
                }
            }

            // Rest of your JavaScript code here...

            function validatecontrol(strControlName) {
                var bool = validate(strControlName);

                if (bool == false) {
                    setTimeout("Focuset('" + strControlName + "');", 50);
                }
            }

            function Focuset(strControlName) {
                document.getElementById(strControlName).focus();
                return false;
            }

            function validate(strControlName) {
                var strValue = document.getElementById(strControlName).value;

                if (strValue.length != 0) {
                    if (strValue.length != 6) {
                        if (strValue.length != 5) {
                            alert("Improper Format, Proper Format is [+##.## or -##.## or +#.## or -#.##] ");
                            //document.getElementById(strControlName).focus();
                            return false;
                        }
                    }
                }

                if (strValue.length != 0) {
                    if (strValue.substring(0, 1) != "+" && strValue.substring(0, 1) != "-") {
                        alert("Value must start with + or - , Proper Format [+##.## or -##.## or +#.## or -#.##] ");
                        //document.getElementById(strControlName).focus();
                        return false;
                    }
                }

                if (strValue.length != 0) {
                    if (strValue.substring(1, 3) < 0 || strValue.substring(1, 3) > 45) {
                        alert("Value must be between -45.00 to +45.00");
                        //document.getElementById(strControlName).focus();
                        return false;
                    }
                }

                if (strValue.length != 0) {
                    if (strValue.length == 6) {
                        var strNo = strValue.substring(1, 6);
                        var intNum = parseFloat(strNo);
                        if (intNum > 44.75) {
                            alert("invalid number range, not within specified range of 45");
                            //document.getElementById(strControlName).focus();
                            return false;
                        }
                        if ((strValue.substring(4, 6) % 25) != 0) {
                            alert("Invalid Decimal value, must be in steps of 25");
                            //document.getElementById(strControlName).focus();
                            return false;
                        }
                    }
                    else if (strValue.length == 5) {
                        var strNo = strValue.substring(1, 5);
                        var intNum = parseFloat(strNo);
                        if (intNum > 44.75) {
                            alert("invalid number range, not within specified range of 45");
                            //document.getElementById(strControlName).focus();
                        }
                        if ((strValue.substring(3, 5) % 25) != 0) {
                            alert("Invalid Decimal value");
                            //document.getElementById(strControlName).focus();
                            return false;
                        }
                    }
                }
                return true;
            }

        </script>


        <script type="text/javascript">
            function updateAndValidate(sourceTextBoxId, targetTextBoxId1, targetTextBoxId2, controlName) {
                // Call the updateTextBoxes function
                updateTextBoxes(sourceTextBoxId, targetTextBoxId1, targetTextBoxId2);

                // Call the validatecontrol function
                validatecontrol(controlName);
            }

            function updateTextBoxes(sourceTextBoxId, targetTextBoxId1, targetTextBoxId2) {
                var sourceTextBox = document.getElementById('<%= txtRfOdSpherical.ClientID %>');
                var targetTextBox1 = document.getElementById('<%= txtAcOdDvSphericalOpt.ClientID %>');
                var targetTextBox2 = document.getElementById('<%= txtAcOdDvSpherical.ClientID %>');

                if (sourceTextBox && targetTextBox1 && targetTextBox2) {
                    var value = sourceTextBox.value;
                    targetTextBox1.value = value;
                    targetTextBox2.value = value;
                }
            }

            // Rest of your JavaScript code here...

            function validatecontrol(strControlName) {
                var bool = validate(strControlName);

                if (bool == false) {
                    setTimeout("Focuset('" + strControlName + "');", 50);
                }
            }

            function Focuset(strControlName) {
                document.getElementById(strControlName).focus();
                return false;
            }

            function validate(strControlName) {
                var strValue = document.getElementById(strControlName).value;

                if (strValue.length != 0) {
                    if (strValue.length != 6) {
                        if (strValue.length != 5) {
                            alert("Improper Format, Proper Format is [+##.## or -##.## or +#.## or -#.##] ");
                            //document.getElementById(strControlName).focus();
                            return false;
                        }
                    }
                }

                if (strValue.length != 0) {
                    if (strValue.substring(0, 1) != "+" && strValue.substring(0, 1) != "-") {
                        alert("Value must start with + or - , Proper Format [+##.## or -##.## or +#.## or -#.##] ");
                        //document.getElementById(strControlName).focus();
                        return false;
                    }
                }

                if (strValue.length != 0) {
                    if (strValue.substring(1, 3) < 0 || strValue.substring(1, 3) > 45) {
                        alert("Value must be between -45.00 to +45.00");
                        //document.getElementById(strControlName).focus();
                        return false;
                    }
                }

                if (strValue.length != 0) {
                    if (strValue.length == 6) {
                        var strNo = strValue.substring(1, 6);
                        var intNum = parseFloat(strNo);
                        if (intNum > 44.75) {
                            alert("invalid number range, not within specified range of 45");
                            //document.getElementById(strControlName).focus();
                            return false;
                        }
                        if ((strValue.substring(4, 6) % 25) != 0) {
                            alert("Invalid Decimal value, must be in steps of 25");
                            //document.getElementById(strControlName).focus();
                            return false;
                        }
                    }
                    else if (strValue.length == 5) {
                        var strNo = strValue.substring(1, 5);
                        var intNum = parseFloat(strNo);
                        if (intNum > 44.75) {
                            alert("invalid number range, not within specified range of 45");
                            //document.getElementById(strControlName).focus();
                        }
                        if ((strValue.substring(3, 5) % 25) != 0) {
                            alert("Invalid Decimal value");
                            //document.getElementById(strControlName).focus();
                            return false;
                        }
                    }
                }
                return true;
            }

        </script>

        <script language="javascript" type="text/javascript">
            {
                window.setTimeout("test();", 1000);

                function test() {
                    if (document.getElementById("hdncopyvalidate").value == "Y") {
                        autorefractionenablecopy();
                    }
                    else {
                        autorefractiondisablecopy();
                    }
                }
            }
        </script>
        <script language="javascript" type="text/javascript">

            function validatecontrol(strControlName) {
                var bool = validate(strControlName);

                if (bool == false) {
                    setTimeout("Focuset('" + strControlName + "');", 50);
                }
            }

            function Focuset(strControlName) {
                document.getElementById(strControlName).focus();
                return false;
            }

            function validate(strControlName) {
                var strValue = document.getElementById(strControlName).value;

                if (strValue.length != 0) {
                    if (strValue.length != 6) {
                        if (strValue.length != 5) {
                            alert("Improper Format, Proper Format is [+##.## or -##.## or +#.## or -#.##] ");
                            //document.getElementById(strControlName).focus();
                            return false;
                        }
                    }
                }

                if (strValue.length != 0) {
                    if (strValue.substring(0, 1) != "+" && strValue.substring(0, 1) != "-") {
                        alert("Value must start with + or - , Proper Format [+##.## or -##.## or +#.## or -#.##] ");
                        //document.getElementById(strControlName).focus();
                        return false;
                    }
                }

                if (strValue.length != 0) {
                    if (strValue.substring(1, 3) < 0 || strValue.substring(1, 3) > 45) {
                        alert("Value must be between -45.00 to +45.00");
                        //document.getElementById(strControlName).focus();
                        return false;
                    }
                }

                if (strValue.length != 0) {
                    if (strValue.length == 6) {
                        var strNo = strValue.substring(1, 6);
                        var intNum = parseFloat(strNo);
                        if (intNum > 44.75) {
                            alert("invalid number range, not within specified range of 45");
                            //document.getElementById(strControlName).focus();
                            return false;
                        }
                        if ((strValue.substring(4, 6) % 25) != 0) {
                            alert("Invalid Decimal value, must be in steps of 25");
                            //document.getElementById(strControlName).focus();
                            return false;
                        }
                    }
                    else if (strValue.length == 5) {
                        var strNo = strValue.substring(1, 5);
                        var intNum = parseFloat(strNo);
                        if (intNum > 44.75) {
                            alert("invalid number range, not within specified range of 45");
                            //document.getElementById(strControlName).focus();
                        }
                        if ((strValue.substring(3, 5) % 25) != 0) {
                            alert("Invalid Decimal value");
                            //document.getElementById(strControlName).focus();
                            return false;
                        }
                    }
                }
                return true;
            }

        </script>

    </form>
</body>
</html>
