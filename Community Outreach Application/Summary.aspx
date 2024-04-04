<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="POPUPSCREENS_Summary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>


    <style>
        .blue-bold-label {
            color: blue;
            font-weight: bold;
            text-decoration: underline;
        }
    </style>

    <style>
        .bold {
            font-weight: bold;
        }
    </style>
    <style>
        .spacer {
            margin-right: 40px;
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
            margin-left: 313px;
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

        .line {
            border: 10px solid #000;
            padding: 3px;
            width: 105%;
        }


        #gobtnclcick {
            height: 55px
        }
    </style>

    <style>
        .custom-button {
            background-color: green;
            color: white;
            padding: 10px 20px;
            border: none;
            cursor: pointer;
        }
    </style>


    <style>
        /* Define styles for the button */
        .print-button {
            padding: 10px 20px;
            background-color: #007bff;
            color: #fff;
            border: none;
            cursor: pointer;
        }

        @media print {
            /* Define the page size */
            @page {
                size: 210mm 297mm; /* A4 size in millimeters (adjust as needed) */
                margin: 20mm; /* Adjust margins as needed */
            }

            /* Header Styles */
            .header {
                display: flex;
                justify-content: space-between;
                align-items: center;
                padding: 10px 20px;
            }

            .logo img {
                width: 125px;
                height: 100px;
            }

            /* Institution Name Styles */
            .institution-name {
                font-size: 18px;
                font-weight: bold;
            }

            /* Student Name Styles */
            .student-name {
                font-weight: bold;
            }
        }
    </style>




</head>
<body>
    <form id="form1" runat="server">
        <div>





            <!-- Create a Print Button -->




            <div class="container">
                <h1 class="txtcnter">SUMMARY  SCREEN </h1>
                <hr />
                <br />
                <br />
                <br />
                <div class="txtcnter">

                    <asp:Label ID="Label1" runat="server" Text="STUDENT NUMBER :" CssClass="bold"></asp:Label>

                    <asp:TextBox ID="Textbox" runat="server" CssClass="spacer"></asp:TextBox>

                    <asp:Button ID="searchbtn" runat="server" Text="Search" OnClick="SearchButton" CssClass="custom-button" />

                    <button id="print-button" class="print-button">Print</button>

                    <asp:Button ID="redirectButton" runat="server" Text="Back" OnClick="RedirectButton_Click" CssClass="custom-button" />


                    <%-- <button class="print-button" onclick="printPageParts()">Print Page</button>--%>

                    <%--  <button class="print-button"  id="printButton" onclick="printPage()">Print Page</button>--%>
                </div>
                <br />
                <div  class="txtcnter">
                      
                    <asp:CheckBox runat="server" id="vacheck" Text="Visual Acuity" CssClass="bold" Value="1" AutoPostBack="true" OnCheckedChanged="VisualAcuity_CheckedChanged"/> 

                     
                    <asp:CheckBox runat="server" id="ivcheck"  Text="Intermediate Vision" CssClass="bold" Value="1" AutoPostBack="true" OnCheckedChanged="IntermediateVision_CheckedChanged"/>

                    <asp:CheckBox runat="server" id="ochcheck" Text="Ocular History" CssClass="bold" Value="1" AutoPostBack="true" OnCheckedChanged="OCULAR_HISTORY_CheckedChanged"/> 
                    
          
                     <asp:CheckBox  runat="server" id="compcheck"  Text="Complaints" CssClass="bold" Value="1" AutoPostBack="true" OnCheckedChanged="COMPLAINTS_CheckedChanged"/> 
                    
                    <asp:CheckBox  runat="server" id="dbrcheck" Text="DBR" CssClass="bold" Value="1" AutoPostBack="true" OnCheckedChanged="DBR_CheckedChanged"/>
                   
                     
                   <asp:CheckBox runat="server" id="covertestcheck" Text="Cover Test / EOM" CssClass="bold" Value="1" AutoPostBack="true" OnCheckedChanged="Covertest_CheckedChanged"/>




                  </div>


                <br />
                <br />
                <br />
                <div class="line" id="printDiv">


                  <div class="row">
    <div style="display: flex; align-items: center;">
        <img src="../img/logoSNjpg.jpg" alt="Logo" width="125" height="100">
    </div>
    <div style="margin-left: 5%;">
        <h4>MEDICAL RESEARCH FOUNDATION</h4>
        <h4 style="margin-left: 28%;">Chennai 600 006 </h4>
    </div>
    <div style="margin-left: 17%;">

        <p>
            <asp:Label ID="Label4" runat="server" Text="School Name :"></asp:Label>
            <asp:Label ID="school_name" runat="server" Text=""></asp:Label>
        </p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Student Name:"></asp:Label>
            <asp:Label ID="stu_name" runat="server" Text=""></asp:Label>
        </p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="Age:"></asp:Label>
            <asp:Label ID="stu_age" runat="server" Text=""></asp:Label>
        </p>
        <p>
            <asp:Label ID="Label5" runat="server" Text="Class:"></asp:Label>
            <asp:Label ID="stu_class" runat="server" Text=""></asp:Label>
        </p>
        <p>
            <asp:Label ID="Label7" runat="server" Text="Section:"></asp:Label>
            <asp:Label ID="stu_sec" runat="server" Text=""></asp:Label>
        </p>
    </div>
</div>



                    <asp:Label ID="VAlabel" runat="server" Text="" CssClass="blue-bold-label"></asp:Label>
                    <br />
                    <br />

                    <asp:Label ID="SummaryLabel" runat="server" Text="" ></asp:Label>

                    <br />
                    <br />
                    <%--          -- Intermediate Vision--%>
                    <asp:Label ID="IVLabel" runat="server" Text="" CssClass="blue-bold-label"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="IVSummaryLabel" runat="server" Text=""></asp:Label>
                    <br />
                    <br />

                    <%--  ---Post Dilated Refraction ----%>

                    <asp:Label ID="PDRLabel" runat="server" Text="" CssClass="blue-bold-label"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="PDRSummarylabel" runat="server" Text=""></asp:Label>
                    <br />
                    <br />

                    <%-- -- OCULAR HISTORY--%>

                    <asp:Label ID="OHLabel" runat="server" Text="" CssClass="blue-bold-label"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="OHSummaryLabel" runat="server" Text=""></asp:Label>
                    <br />
                    <br />

                    <%--    Complaints  --%>

                    <asp:Label ID="ComLabel" runat="server" Text="" CssClass="blue-bold-label"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="ComSummaryLabel" runat="server" Text=""></asp:Label>
                    <br />
                    <br />

<%--                    DBR --%>
                <asp:Label ID="DBRLabel" runat="server" Text="" CssClass="blue-bold-label" ></asp:Label>
                <br />
                <br />
                <asp:Label ID="DBRSummaryLabel" runat="server" Text=""  ></asp:Label>
                <br />
                <br />
              <%--      Cover test--%>
                <asp:Label ID="CovertestLabel" runat="server" Text="" CssClass="blue-bold-label" ></asp:Label>
                <br />
                <br />
                <asp:Label ID="CovertestSummaryLabel" runat="server" Text=""  ></asp:Label>
                <br />
                <br />

                </div>
            </div>
        </div>


  <script>
    // Get references to the button and the divs to be printed
    const printButton = document.getElementById('print-button');
    const printableContent = document.getElementById('printDiv');

    // Add a click event listener to the button
    printButton.addEventListener('click', () => {
        // Clone the header and the content you want to print
        const clonedContent = printableContent.cloneNode(true);

        // Create a new window to open the cloned content
        const printWindow = window.open('', '', 'width=1200,height=900');
        printWindow.document.open();
        printWindow.document.write('<html><head><title>Print</title></head><body>');

        // Add CSS styles to set the page size to A4 with left and right margins and shift content to the left
        printWindow.document.write(`
            <style>
                @page {
                    size: A4;
                    margin: 1cm 0.5cm; /* Adjust margins as needed (1cm top/bottom, 0.5cm left/right) */
                }
                body {
                    margin: 0;
                }
                #printDiv {
                    width: 100%; /* Ensure content fits within the page width */
                }
                .row {
                    display: flex;
                    align-items: center;
                    margin-left:10px; /* Adjust this value to shift content to the left */
                }
            </style>
        `);

        printWindow.document.write(clonedContent.outerHTML); // Add the cloned content to the new window
        printWindow.document.write('</body></html>');
        printWindow.document.close();

        // Print the new window
        printWindow.print();
        printWindow.close();
    });
</script>

      <script>
    // Get a reference to the button element
    var redirectButton = document.getElementById("redirectButton");

    // Add a click event listener to the button
    redirectButton.addEventListener("click", function () {
        // Redirect to a new URL when the button is clicked
        window.location.href = "/COMMUNITY_OUTREACH/DETAILEXAM.aspx";
    });
</script>




    </form>
</body>
</html>
