<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GovModify.aspx.cs" Inherits="POPUPSCREENS_GovModify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <style>
        .txtcenter {
            text-align: center;
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
            margin-left: 20px;
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
        .center-part {
            text-align: center;
            padding: 10px;
        }

        #gobtnclcick {
            height: 55px
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
                margin-bottom: 7px;
            }

            .gridview-container th,
            .gridview-container td {
                padding: 4px;
                text-align: left;
                border-bottom: 1px solid #ddd;
            }

            .gridview-container th {
                background-color:#00FFFF;
            }

            .gridview-container tbody tr:nth-child(even) {
                background-color: white;
            }

            .gridview-container tbody tr:hover {
                background-color:#808080;
            }

            .gridview-container .table .row-dark {
                background-color: antiquewhite; 
            }
            .gridview-font-small {
    font-size: 12px; /* You can adjust the value as needed */
}


            .gridview-heading-small {
    font-size: 12px;
    /* Add more styling if needed */
}
    </style>


    <style>
        .gridview-container1 {
            max-width: 100%;
            overflow-x: auto;
        }

            .gridview-container1 table {
                border-collapse: collapse;
                width: 100%;
                margin-bottom: 7px;
            }

            1
            .gridview-container1 th,
            .gridview-container1 td {
                padding: 4px;
                text-align: left;
                border-bottom: 1px solid #ddd;
            }

            .gridview-container1 th {
                background-color: #00FFFF ;
            }

            .gridview-container1 tbody tr:nth-child(even) {
                background-color: white;
            }

            .gridview-container1 tbody tr:hover {
                background-color: #808080;
            }

            .gridview-container1 .table .row-dark {
                background-color: antiquewhite;
            }

        .gridview-font-small {
            font-size: 12px; /* You can adjust the value as needed */
        }


        .gridview-heading-small {
            font-size: 12px;
            /* Add more styling if needed */
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
    <style>
        .outer-glow {
            box-shadow: 0 0 20px forestgreen;
        }
    </style>
    <style>
        .outer-glow1 {
            box-shadow: 0 0 20px steelblue;
        }
    </style>

       <style>
        @keyframes blink {
            0%, 100% {
                background-color: white; /* Start and end with default background color */
            }
            50% {
                background-color: #00FFFF; /* Midpoint color */
            }
        }
        .blink-box {
            animation: blink 1s infinite; /* Apply blinking animation */
            
            padding: 10px;
        }
    </style>

     <style>
        @keyframes blink1 {
            0%, 100% {
                background-color: white; /* Start and end with default background color */
            }
            50% {
                background-color: yellow; /* Midpoint color */
            }
        }
        .blink1-box {
            animation: blink1 1s infinite; /* Apply blinking animation */
            
            padding: 10px;
        }
    </style>

    <style>

    .left-part {
        border: 4px solid #000; /* This adds a 4px solid black border around the element */
        padding: 20px; /* Add some padding inside the border */
         margin-bottom: 2px;
    }
</style>

    <script type="text/javascript">
        window.onload = function () {
            var docCode = '<%= Request.QueryString["DocCode"] %>';
        if (docCode) {
            var label8Element = document.getElementById('<%= Label8.ClientID %>');
            label8Element.textContent = docCode;

             bindGridViewData(docCode);
            }
        };
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 class="txtcenter"> GOVERNMENT DOCUMENT MODIFY </h1>

      
			

			
               <div class="row">
                    
                   
                   <div class="container">
                       <div class="txtcnter">
                            <div class="blink1-box">
                         <asp:Label ID="Label21" runat="server" Text="DOCUMENT CODE:"  Style="font-weight: bold;"></asp:Label>
                           <asp:Label ID="Label8" runat="server"   Style="font-weight: bold; margin-right: 100px;"></asp:Label>
                                 <asp:Button ID="Button12" runat="server" Text="DELETE" CommandName="DELETE" ONCLICK="delete_document" Style="background-color: red; color: white;" />
                                </div>
                       </div>
                       </div>
                       <div class="left-part">
                           <div class="gridview-container">
                               <asp:GridView ID="gridViewData" runat="server" Class="table table-striped table-bordered" AutoGenerateColumns="true" OnRowDataBound="gridViewData_RowDataBound" OnRowCreated="gridViewData_RowCreated">
                               </asp:GridView>

                           </div>
                           
                           <br />
                           <br />
                           <div class="row">
                               <asp:Label ID="Label2" runat="server" Text="DOCUMENT DETAILS :" Style="margin-right: 20px;"></asp:Label>
                               <asp:TextBox ID="txt_pro_name" runat="server"></asp:TextBox>
                           </div>
                           <br />
                           <br />
                           <div class="row">
                               <asp:Label ID="Label3" runat="server" Text="VALIDITY FROM DATE :" Style="margin-right: 10px;"></asp:Label>
                               <asp:TextBox ID="date_vid_from" runat="server" TextMode="Date"></asp:TextBox>
                           </div>
                           <br />
                           <br />
                           <div class="row">
                               <asp:Label ID="Label4" runat="server" Text="VALIDITY TO DATE :" Style="margin-right: 30px;"></asp:Label>
                               <asp:TextBox ID="date_vid_to" runat="server" TextMode="Date"></asp:TextBox>
                           </div>
                           <br />
                           <br />
                           <div class="row">
                               <asp:Label ID="Label5" runat="server" Text="STATUS :" Style="margin-right: 30px;"></asp:Label>
                               <div class="radio-container">
                                   <asp:RadioButton ID="rdt_Active" runat="server" Visible="true" Text="Active" GroupName="genderGroup" CssClass="radiobtn-style" />
                               </div>
                               <div class="radio-container">
                                   <asp:RadioButton ID="rdt_Inactive" runat="server" Visible="true" Text="Inactive" GroupName="genderGroup" CssClass="radiobtn-style" />
                               </div>
                           </div>
                           <br />
                           <br />

                           <asp:Button ID="btnupdate" runat="server" Text="UPDATE" onclick="Update_Click" CssClass="outer-glow1" Style="margin-left: 150px; background-color: #4c99af; color: white; width: 100px; height: 30px; border: 2px solid #333;" />


                       </div>


                       <div class="left-part">

                           <div class="gridview-container1">
                               <asp:GridView ID="gridViewData1" runat="server" Class="table table-striped table-bordered" AutoGenerateColumns="true" OnRowDataBound="gridViewData_RowDataBound" OnRowDeleting="gridViewB_RowDeleting" OnRowCreated="gridViewData_RowCreated">
                                   <Columns>
                                       <asp:TemplateField HeaderText="DELETE">
                                           <ItemTemplate>
                                               <asp:Button ID="Button1" runat="server" Text="DELETE" CommandName="DELETE"  Style="background-color: red; color: white;" />
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                   </Columns>
                               </asp:GridView>

                           </div>
                           <br />
                           <br />
                           <br />
                           <br />

                           <div class="row" style="margin-left: 90px;">
                               <div class="blink-box">
                                   <asp:Label ID="Label6" runat="server" Text="ADD NEW DOCUMENT " Style="font-weight: bold;"></asp:Label>
                               </div>
                           </div>
                           <br />
                           <br />
                           <div class="row">
                               <asp:Label ID="Label7" runat="server" Text="UPLOAD DOCUMENT :" Style="margin-right: 10px;"></asp:Label>
                               <asp:FileUpload ID="GOV_ADD_DOC_FL_UP" runat="server" />

                           </div>
                           <br />
                           <br />
                           <div class="row">
                               <asp:Button ID="btnsave" runat="server" Text="SAVE" CssClass="outer-glow" OnClick="btn_FileSave_Click" Style="margin-left: 140px; background-color: forestgreen; color: white; width: 100px; height: 30px; border: 2px solid #333;" />

                           </div>

                       </div>

                   </div>
           




       
    </form>
</body>
</html>
