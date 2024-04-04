<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Management.aspx.cs" Inherits="POPUPSCREENS_Management" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>


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
       
.custom-label {
 
  width: 150px;
  height: 40px;

  
  background-color: #3498db; 
  
  
  color: #fff; 
  font-size: 16px; 
  text-align: center; 
  padding: 10px; 
  border: 2px solid #2980b9; 
  border-radius: 5px;
  cursor: pointer; 
}


.custom-label:hover {
  background-color: #2980b9; 
}

    </style>

      <script type="text/javascript">
        window.onload = function () {
            var docCode = '<%= Request.QueryString["studentID"] %>';
        
        };
    </script>

</head>
<body>
    <form id="form1" runat="server">


        <div class="container">

            <h1 class="txtcnter"> Management Screen </h1>
            <hr />

            
            <div class="row">
                 <div>
                    <asp:Label ID="Label1" runat="server" Text="CHOOSE ANY ONE "></asp:Label>
                </div>
                <div style="margin-left:6%">
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        <asp:ListItem Value="sel" Text="--- select ----"></asp:ListItem>
                        <asp:ListItem Value="New glasses prescribed" Text="New glasses prescribed"></asp:ListItem>
                        <asp:ListItem Value="Glasses prescribed and referral" Text="Glasses prescribed and referral"></asp:ListItem>
                        <asp:ListItem Value="Referral" Text="Referral"></asp:ListItem>
                        <asp:ListItem Value="Glasses Prescription only" Text=" Glasses Prescription only"></asp:ListItem>
                        <asp:ListItem Value="Reassured" Text="Reassured"></asp:ListItem>
                        <asp:ListItem Value="Normal" Text="Normal"></asp:ListItem>
                        <asp:ListItem Value="continuesameglass" Text="Continue Same glasses"></asp:ListItem>
                        <asp:ListItem Value="Discontinueglass" Text="Discontinue glasses"></asp:ListItem>
                        <asp:ListItem Value="Others" Text="Others"></asp:ListItem>

                    </asp:DropDownList>
                </div>
                <div style="margin-left:5%">
                    <asp:Button ID="save_btn" runat="server" Text="SAVE" OnClick="save_btn_Click" Visible="false"  />
                </div>
                <div style="margin-left:5%">
                    <asp:Button ID="ubdate_btn" runat="server" Text="UPDATE" OnClick="ubdate_btn_Click" Visible="false" />
                </div>
                <div style="margin-left:54px;">
                    <asp:Button ID="Button2" runat="server" Text="ADD REMARK'S" OnClientClick="showRemarksTextBox(); return false;" />
                </div>
            </div>

            <br />
            <br />
            <br />
            <div style="margin-left: 34%;">
                   <asp:TextBox ID="overallremarksTextBox" runat="server" TextMode="MultiLine" style="display: none;" placeholder="Enter remarks"></asp:TextBox>
            </div>
         
            <br />
            <br />


             <asp:Panel ID="PNLOTHER" runat="server" Visible="false">
                 <div style=" margin-left: 35%;">
                     <asp:TextBox ID="chooseremark" runat="server" TextMode="MultiLine" placeholder="Enter other reason"></asp:TextBox>
                 </div>
                 

             </asp:Panel>


            <asp:Panel ID="pnlNewGlasses" runat="server" Visible="false">
                <div class="row">
                    <div style="margin-left:31%" >
                        <asp:Label ID="Label3" runat="server" CssClass="custom-label" Text="PD"></asp:Label>
                    </div>
                   
                </div>
                <div class="row">
                    <div class="left-part">
                        <asp:Label ID="Label4" runat="server" Text="OD"></asp:Label>
                    </div>
                    <div class="right-part">
                        <asp:TextBox ID="od_val_txt" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="left-part">
                        <asp:Label ID="Label5" runat="server" Text="OS"></asp:Label>
                    </div>
                    <div class="right-part">
                        <asp:TextBox ID="os_val_txt" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="left-part">
                        <asp:Label ID="Label6" runat="server" Text="FRAME SIZE"></asp:Label>
                    </div>
                    <div class="right-part">
                        <asp:TextBox ID="frame_size_txt" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="left-part">
                        <asp:Label ID="Label7" runat="server" Text="FRAME MODEL"></asp:Label>
                    </div>
                    <div class="right-part">
                        <asp:TextBox ID="frame_model_txt" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="left-part">
                        <asp:Label ID="Label8" runat="server" Text="FRAME COLOR"></asp:Label>
                    </div>
                    <div class="right-part">
                        <asp:TextBox ID="frame_color_txt" runat="server"></asp:TextBox>
                    </div>
                </div>
            </asp:Panel>
            <br />
            <br />

            <asp:Panel ID="pnlGlassesAndReferral" runat="server" Visible="false">
                <div class="row" >
                    <div>
                        <asp:Label ID="Label2" runat="server" Text="REASON FOR REFERRAL"></asp:Label>
                    </div>
                    <div style="margin-left:15%">
                        <asp:DropDownList ID="reasonforref" runat="server" onchange="showTextBox(this);">
                            <asp:ListItem Value="sel" Text="---select----"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Amblyopia"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Cataract"></asp:ListItem>
                            <asp:ListItem Value="3" Text="Conjunctivitis - allergic"></asp:ListItem>
                            <asp:ListItem Value="4" Text="Conjunctivitis - infectious"></asp:ListItem>
                            <asp:ListItem Value="5" Text="Corneal scar/ opacity"></asp:ListItem>
                            <asp:ListItem Value="6" Text="Glaucoma"></asp:ListItem>
                            <asp:ListItem Value="7" Text="High myopia"></asp:ListItem>
                            <asp:ListItem Value="8" Text="Neuro (Nystagmus/ AHP/RAPD etc)"></asp:ListItem>
                            <asp:ListItem Value="9" Text="Posterior capsular opacity"></asp:ListItem>
                            <asp:ListItem Value="10" Text="Pseudophakia"></asp:ListItem>
                            <asp:ListItem Value="11" Text="Ptosis"></asp:ListItem>
                            <asp:ListItem Value="12" Text="Retina"></asp:ListItem>
                            <asp:ListItem Value="13" Text="Scissoring reflex"></asp:ListItem>
                            <asp:ListItem Value="14" Text="Strabismus"></asp:ListItem>
                            <asp:ListItem Value="15" Text="Subconjunctival hemmorhage"></asp:ListItem>
                            <asp:ListItem Value="16" Text="Sustained chalazion"></asp:ListItem>
                            <asp:ListItem Value="17" Text="Others"></asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <br />

                        <div class="txtcnter">
                            <asp:TextBox ID="otherReasonTextBox" runat="server" TextMode="MultiLine" Style="display: none;" placeholder="Enter other reason" Width="102%"></asp:TextBox>
                        </div>

                    </div>
                </div>

            </asp:Panel>

            <div class="txtcnter" style="margin-left:23%;width:135%;">
			<asp:Literal ID="SummaryLiteral" runat="server"></asp:Literal>
		   </div>

        </div>

        <script type="text/javascript">
            function showTextBox(dropdown) {
                var selectedValue = dropdown.value;
                var otherReasonTextBox = document.getElementById('<%= otherReasonTextBox.ClientID %>');

                // Check if "Others" is selected and toggle TextBox visibility
                if (selectedValue === "17") {
                    otherReasonTextBox.style.display = "block"; // Show the TextBox
                } else {
                    otherReasonTextBox.style.display = "none"; // Hide the TextBox
                }
            }
        </script>

        <script type="text/javascript">
    function showRemarksTextBox() {
        var remarksTextBox = document.getElementById('<%= overallremarksTextBox.ClientID %>');

        // Toggle TextBox visibility
        if (remarksTextBox.style.display === "none") {
            remarksTextBox.style.display = "block"; // Show the TextBox
        } else {
            remarksTextBox.style.display = "none"; // Hide the TextBox
        }
    }
</script>


    </form>
</body>
</html>
