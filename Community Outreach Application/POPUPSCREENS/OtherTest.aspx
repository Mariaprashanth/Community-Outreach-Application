<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OtherTest.aspx.cs" Inherits="POPUPSCREENS_OtherTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	<link href="OthertestCSS/Buttonstyle.css" rel="stylesheet" />
	<link href="OthertestCSS/container.css" rel="stylesheet" />
	<link href="OthertestCSS/threediv.css" rel="stylesheet" />
	
	<script src="DBRCSS/jquery.min.js"></script>

	 <script type="text/javascript">
    
                
      $(document).ready(function() {

        $('input[type=text]').keypress(function (event) {
            
            return isNumber(event, this)

        });        

    });
    function isNumber(evt, element) {

        var charCode = (evt.which) ? evt.which : event.keyCode

        if (
            (charCode != 45 || $(element).val().indexOf('-') != -1) &&      // “-” CHECK MINUS, AND ONLY ONE.
            (charCode != 46 || $(element).val().indexOf('.') != -1) &&      // “.” CHECK DOT, AND ONLY ONE.
            (charCode < 48 || charCode > 57))
            
            return false;
            

        return true;
    } 
    </script>

	<script language="javascript" type="text/javascript" >
function CreatePOPUP()

{
setTimeout('Flash()', 3);
}
function Flash()
{

//
var p=window.createPopup()
var pbody=p.document.body
pbody.style.backgroundColor="lime"
pbody.style.border="solid black 1px"
pbody.innerHTML="<font color='red'><b>Data Saved successfully! .</b></font>"
p.show(425,76,195,40,document.body)

}

</script>

      <script type="text/javascript">
        window.onload = function () {
            var docCode = '<%= Request.QueryString["studentID"] %>';
        
        };
    </script>


</head>
<body>
	<form id="form1" runat="server">

		<div class="container">
			<div class="threedivsec">
				<div class="left" style="margin-left: 22%">

					<asp:Button ID="btnScreen1" runat="server" Text="DBR" OnClick="btnScreen1_Click" class="outlined-button" />
				</div>
				<div class="center" style="margin-left: -7%">

					<asp:Button ID="btnScreen2" runat="server" Text="COVER TEST / EOM" OnClick="btnScreen2_Click" class="outlined-button" />
				</div>
				<div class="right">

					<asp:Button ID="btnScreen3" runat="server" Text="OCULAR FINDING'S" OnClick="btnScreen3_Click" class="outlined-button" />
				</div>
			</div>
			<br />
			<hr />
            <br />
			<asp:Panel ID="pnlScreen1" runat="server">
				 <div>
        <asp:HiddenField ID="newText" runat="server" />
    <table id="tblLayout" width="100%" height="100%" border="0" bordercolor="black" cellpadding="1"
                cellspacing="2" runat="server">
                <tr>
                    <td colspan="4" id="tdAppHeader" bordercolor="chocolate" align="center">
                      <%--  <app:AppHeader Visible="True" ID="pgAppHeader" runat="server" EnableViewState="False" />--%>
                    </td>
                    
                </tr>
                <tr>
                 <td colspan="4" id="td1" bordercolor="chocolate" align="center">
                       <%-- <Pat:PatHeader Visible="True" ID="PatientInfo" runat="server" EnableViewState="False" />--%>
                    </td>
                </tr>
  </table> 
    </div>
    
    
    <br />
    <br />

    <div align=center>

<asp:Button ID="CmdSave" runat="server" CssClass="button" Height="37px" Width="200px" Text="Save and Populate IOL" OnClick="CmdSave_Click" Visible="false"  />

        <asp:Button ID="update_btn" runat="server" CssClass="button" Height="37px" Width="200px" Text="Update" OnClick="update_btn_Click" Visible="false" />
</div>

    <div>
    <table width="50%" border="0">
    <tr>
        <td width="5%">
            <input type="button" id="cmdDbr" value=" -- "  onclick="HideAndSeek('cmdDbr','div_dbr')"/>
        </td>
        <td width="80%" align="left">
            <table class="OutlineTable" id="Table11" width="30%">
                <tr class="GroupHeader" align="center" width="100%">
                    <td>
                   Digital Biometry Reader
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>

<div id="div_dbr">
<table cellspacing="1" cellpadding="1" border="0" width="100%" class="table">
    <tr>
        <td align="center" width="20%">
            &nbsp;
        </td>
        <td align="center" width="40%" colspan="2" style="border-right-style:solid;border-right-width:2px; border-color:red;">
            <asp:Label ID="lblOD" CssClass="labelheading" runat="server">OD</asp:Label>
        </td>
        <td align="center" width="40%" colspan="2">
            <asp:Label ID="lblOS" CssClass="labelheading" runat="server">OS</asp:Label>
        </td>
    </tr>
    <tr>
        <td width="20%">
            <asp:Label ID="lblAxialLength" CssClass="label" runat="server">Axial Length</asp:Label>
        </td>
        <td width="40%" colspan="2" style="border-right-style:solid;border-right-width:2px; border-color:red;">
            <asp:TextBox ID="txtAxialLengthOD" TabIndex="1" CssClass="GeneralTxt" MaxLength="5"
                TextMode="SingleLine" Width="35%" runat="server"></asp:TextBox><font
                    size="1">mm</font>
           
        </td>
        <td width="40%" colspan="2">
            <asp:TextBox ID="txtAxialLengthOS" TabIndex="2" CssClass="GeneralTxt" MaxLength="5"
                TextMode="SingleLine" Width="35%" runat="server"></asp:TextBox><font  size="1">mm</font>
            
        </td>
    </tr>
    <tr>
        <td width="20%">
            <asp:Label ID="lblKeratometryK1" CssClass="Generallbl" Width="100%" runat="server">Keratometry Reading K1 (in Dioptres)</asp:Label>
        </td>
        <td width="20%">
            <asp:TextBox ID="txtKeratometryODK1" CssClass="GeneralTxt" TextMode="SingleLine"
                MaxLength="5" TabIndex="3" Width="70%" runat="server"></asp:TextBox><font
                    size="1">mm</font>
        
        </td>
        <td width="20%" style="border-right-style:solid;border-right-width:2px; border-color:red;">
           @
            <asp:TextBox ID="txtKeratometryOD2" MaxLength="3" CssClass="GeneralTxt" TextMode="SingleLine"
                Width="70%" TabIndex="4" runat="server"></asp:TextBox>
           
        </td>
        <td width="20%">
            <asp:TextBox ID="txtKeratometryOSK1" MaxLength="5" CssClass="GeneralTxt" TextMode="SingleLine"
                TabIndex="5" Width="70%" runat="server" onblur="javascript:clearStatusMsg()"
                onfocus="javascript:setStatusMsg('Base_pgContentHolder_pgContent_txtKeratometryOSK1','Enter a value between 30 mm  and 70 mm')"></asp:TextBox><font
                    size="1">mm</font>
           
        </td>
        <td width="20%">
           @
            <asp:TextBox ID="txtKeratometryOS2" CssClass="GeneralTxt" MaxLength="3" TextMode="SingleLine"
                Width="70%" runat="server" TabIndex="6" onblur="javascript:clearStatusMsg()"
                onfocus="javascript:setStatusMsg('Base_pgContentHolder_pgContent_txtKeratometryOS2','Enter a value between 0 and 180 degrees ')"></asp:TextBox>
           
        </td>
    </tr>
    <tr>
        <td width="20%">
            <asp:Label ID="lblKeratometryK2" CssClass="Generallbl" Width="100%" runat="server">Keratometry Reading K2 (in Dioptres)</asp:Label>
        </td>
        <td width="20%">
            <asp:TextBox ID="txtKeratometryODK2" MaxLength="5" TabIndex="7" CssClass="GeneralTxt"
                TextMode="SingleLine" Width="70%" runat="server" onblur="javascript:clearStatusMsg()"
                onfocus="javascript:setStatusMsg('Base_pgContentHolder_pgContent_txtKeratometryODK2','Enter a value between 30 mm  and 70 mm')"></asp:TextBox><font
                    size="1">D</font>
            
        </td>
        <td width="20%" style="border-right-style:solid;border-right-width:2px; border-color:red;">
            @
            <asp:TextBox ID="txtKeratometryODk22" CssClass="GeneralTxt" MaxLength="3" TabIndex="8"
                TextMode="SingleLine" Width="70%" runat="server" onblur="javascript:clearStatusMsg()"
                onfocus="javascript:setStatusMsg('Base_pgContentHolder_pgContent_txtKeratometryODk22','Enter a value between 0 and 180 degrees')"></asp:TextBox>
           
        </td>
        <td width="20%">
            <asp:TextBox ID="txtKeratometryOSK2" CssClass="GeneralTxt" MaxLength="5" TabIndex="9"
                TextMode="SingleLine" Width="70%" runat="server" onblur="javascript:clearStatusMsg()"
                onfocus="javascript:setStatusMsg('Base_pgContentHolder_pgContent_txtKeratometryOSK2','Enter a value between 30 mm  and 70 mm')"></asp:TextBox><font
                    size="1">D</font>
           
        </td>
        <td width="20%">
           @
            <asp:TextBox ID="txtKeratometryOSk22" CssClass="GeneralTxt" TextMode="SingleLine"
                MaxLength="3" TabIndex="10" Width="70%" runat="server" onblur="javascript:clearStatusMsg()"
                onfocus="javascript:setStatusMsg('Base_pgContentHolder_pgContent_txtKeratometryOSk22','nter a value between 0 and 180 degrees')"></asp:TextBox>
           
        </td>
    </tr>
    <tr>
        <td width="20%">
            <asp:Label ID="lblKeratometryMethod" CssClass="Generallbl" Width="100%" runat="server">Keratometry Method</asp:Label>
        </td>
        <td width="40%" colspan="2" style="border-right-style:solid;border-right-width:2px; border-color:red;">
            <asp:RadioButtonList ID="radODKeratometryMethod" TabIndex="11" CssClass="GeneralRbt"
                Width="60%" AutoPostBack="False" RepeatDirection="Horizontal" runat="server">
                <asp:ListItem Value="A">Auto</asp:ListItem>
                <asp:ListItem Value="M">Manual</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td width="40%" colspan="2" >
            <asp:RadioButtonList ID="radOSKeratometryMethod" TabIndex="12" CssClass="GeneralRbt"
                Width="60%" AutoPostBack="False" RepeatDirection="Horizontal" runat="server">
                <asp:ListItem Value="A">Auto</asp:ListItem>
                <asp:ListItem Value="M">Manual</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>

     <tr>
        <td width="20%">
            <asp:Label ID="Label2" CssClass="label" runat="server">Anterior Chamber Depth </asp:Label>
        </td>
        <td width="40%" colspan="2" style="border-right-style:solid;border-right-width:2px; border-color:red;">
            <asp:TextBox ID="AnteriorChambeDepthod" TabIndex="1" CssClass="GeneralTxt" MaxLength="5"
                TextMode="SingleLine" Width="35%" runat="server"></asp:TextBox><font
                    size="1">mm</font>
           
        </td>
        <td width="40%" colspan="2">
            <asp:TextBox ID="AnteriorChambeDepthos" TabIndex="2" CssClass="GeneralTxt" MaxLength="5"
                TextMode="SingleLine" Width="35%" runat="server"></asp:TextBox> <font  size="1">mm</font>
            
        </td>
    </tr>

     <tr>
        <td width="20%">
            <asp:Label ID="Label3" CssClass="label" runat="server">Lens Thickness</asp:Label>
        </td>
        <td width="40%" colspan="2" style="border-right-style:solid;border-right-width:2px; border-color:red;">
            <asp:TextBox ID="lensthicknessod" TabIndex="1" CssClass="GeneralTxt" MaxLength="5"
                TextMode="SingleLine" Width="35%" runat="server"></asp:TextBox><font
                    size="1">mm</font>
           
        </td>
        <td width="40%" colspan="2">
            <asp:TextBox ID="lensthicknessos" TabIndex="2" CssClass="GeneralTxt" MaxLength="5"
                TextMode="SingleLine" Width="35%" runat="server"></asp:TextBox> <font  size="1">mm</font>
            
        </td>
    
  <tr>
  <td>Remarks</td>
  <td colspan="4"><asp:TextBox ID="txtDBRRemarks" runat="server" TextMode="MultiLine" Width="80%" TabIndex="13"></asp:TextBox></td>

     
      
  </tr>

    <br />
    <br />

    <div>
         <tr>
        <td>
          summary
      </td>

      <td colspan="4">
          <asp:Literal ID="Summaryfordbr" runat="server"></asp:Literal>
      </td>
    </tr>
    </div>
   
</table>

</div>


</div>
	</asp:Panel>




			<asp:Panel ID="pnlScreen2" runat="server">
				<table cellspacing="1" cellpadding="1" border="0" width="100%" class="screenheading" style="margin-left: 40%;">
                    <tr>
                        <td>
                            <asp:Button ID="covertest_btn" runat="server" CssClass="button" Height="37px" Width="200px" Text="Save" OnClick="covertest_btn_Click" Visible="false"  />

                            <asp:Button ID="covertest_upt" runat="server" CssClass="button" Height="37px" Width="200px" Text="Update" OnClick="covertest_upt_Click" Visible="false" />
                        </td>
                    </tr>
    <tr>
        <td>Cover Test
        </td>
        <td>
            <asp:Button ID="cmdBack" runat="server" CssClass="GeneralBtn" EnableViewState="false"
                Visible="false" Text="Go Back"></asp:Button>
        </td>
    </tr>
</table>
<asp:TextBox ID="txtStats" runat="server" CssClass="generallbl" Visible="False" Width="20%"
    Rows="10" Height="20%" EnableViewState="True"></asp:TextBox>
<table class="table" id="tblControlArea" border="1" cellspacing="1" cellpadding="0"
    width="100%" runat="server">
    <tr>
        <td width="20%">
            <asp:Label ID="lblHirschbergTest" runat="server" CssClass="Generallbl" EnableViewState="False">Hirschberg Test</asp:Label>
        </td>
        <td width="80%" colspan="3">
            <div id="divHirschbergTest" style="left: 110px; overflow: auto; width: 142px; height: 67px">
                <asp:CheckBoxList ID="chklstHirschbergTest" TabIndex="1" runat="server" CssClass="CheckBoxList"  Width="100%">
                    
                </asp:CheckBoxList>
            </div>
        </td>
    </tr>
    <tr>
        <td width="20%">
            <asp:Label ID="lblDistance" CssClass="generallbl" runat="server" EnableViewState="False">Cover Test Distance</asp:Label>
        </td>
        <td width="30%">
            <div id="divDistance" style="left: 110px; overflow: auto; width: 142px; height: 67px">
                <asp:CheckBoxList ID="chklstDistance" TabIndex="2" runat="server" CssClass="CheckBoxList"  Width="100%">
                  

                </asp:CheckBoxList>
            </div>
        </td>
        <td width="25%">
            <asp:Label ID="lblNear" CssClass="generallbl" runat="server" EnableViewState="False">Cover Test Near</asp:Label>
        </td>
        <td width="25%">
            <div id="divNear" style="left: 110px; overflow: auto; width: 142px; height: 67px">
                <asp:CheckBoxList ID="chklstNear" TabIndex="3" runat="server" CssClass="CheckBoxList"   Width="100%">                  

                    
                </asp:CheckBoxList>
            </div>
        </td>
    </tr>
    <tr>
        <td width="20%">
            <asp:Label ID="lbl4" CssClass="generallbl" runat="server" EnableViewState="False">4</asp:Label><img
                id="imgTriangle" title="Triangle" src="~/img/Triangle.gif"
                border="0" runat="server">
            <asp:Label ID="lblBOBI" CssClass="generallbl" runat="server" EnableViewState="False">BO/BI Test</asp:Label>
        </td>
        <td width="80%" colspan="3">
            <asp:DropDownList ID="cmb4BOBI" TabIndex="4" CssClass="generalcbo" runat="server"   Width="15%">

                
                <asp:ListItem Value="sel" Text="---- Select ----"></asp:ListItem>
                <asp:ListItem Value="Nagative" Text="Nagative"></asp:ListItem>
                <asp:ListItem Value="Positive" Text="Positive"></asp:ListItem>

           
              
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td colspan="4">
            <table cellspacing="1" cellpadding="1" border="0" width="100%">
                <tr>
                    <td align="left">
                        <table cellspacing="1" cellpadding="1" border="0" class="tab">
                            <tr>
                                <td>Ocular Movement
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td width="20%">
            <asp:Label ID="lblODOcularMotility" runat="server" CssClass="Generallbl" EnableViewState="False">Ocular Motility - <b>
						OD</b></asp:Label>
        </td>
        <td width="30%">
            <div id="divODOcularMotility" style="left: 110px; overflow: auto; width: 180px; height: 67px">
                <asp:CheckBoxList ID="chklstODOcularMotility" TabIndex="5" runat="server" CssClass="CheckBoxList"  Width="100%">
                 

                </asp:CheckBoxList>
            </div>
        </td>
        <td width="20%">
            <asp:Label ID="lblOSOcularMotility" runat="server" CssClass="Generallbl" EnableViewState="False">Ocular Motility - <b>
						OS</b></asp:Label>
        </td>
        <td width="30%">
            <div id="divOSOcularMotility" style="left: 110px; overflow: auto; width: 180px; height: 67px">
                <asp:CheckBoxList ID="chklstOSOcularMotility" TabIndex="6" runat="server" CssClass="CheckBoxList"   Width="100%">
                  
                   
                </asp:CheckBoxList>
            </div>
        </td>
    </tr>
   
    
</table>
<%--<table id="tblSummary" cellspacing="1" cellpadding="1" width="100%" border="0" runat="server">
    <tr>
        <td width="30%" colspan="2" align="center">
            <asp:Button ID="cmdSensoryEvaluation" TabIndex="7" runat="server" CssClass="GeneralBtn"
                Text="Sensory Evaluation"></asp:Button>
        </td>
        <td width="40%" align="center">
            <asp:Button ID="cmdSquintBasicExam" TabIndex="8" runat="server" CssClass="GeneralBtn"
                Text="Squint Basic Exam"></asp:Button>
        </td>
        <td width="30%" colspan="2" align="center">
            <asp:Button ID="cmdEOMPBCT" TabIndex="9" runat="server" CssClass="GeneralBtn" Text="EOM/PBCT"></asp:Button>
        </td>
    </tr>
</table>--%>
                <br />
                <br />
<table class="table" cellspacing="1" cellpadding="1" width="100%" border="0">
     <div>
         <tr>
        <td>
          summary
      </td>

      <td colspan="4">
          <asp:Literal ID="summaryforcovertest" runat="server"></asp:Literal>
      </td>
    </tr>
    </div>
</table>

<asp:ValidationSummary ID="Validationsummary1" runat="server" Width="100%" Height="50px"
    ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary>
<div id="popupbox" runat="server" class="popupbox">
</div>
<asp:HiddenField ID="hdnTemRemarks" runat="server" />


			</asp:Panel>


			<asp:Panel ID="pnlScreen3" runat="server">

                <div class="center">
                     <div class="row">
                    <div >
                        <asp:Label ID="Label1" runat="server" Text="OCULAR FINDINGS"></asp:Label>
                    </div>
                    <div style="margin-left: 26%;">
                        <asp:TextBox ID="ocular_txt" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </div>

                         <div style="margin-left: 10%;">
                             <asp:Button ID="OCULAR_BTN" runat="server" Text="SAVE" OnClick="OCULAR_BTN_Click" CssClass="button" Visible="false" />
                         </div>

                         <div style="margin-left: 7%;">
                             <asp:Button ID="ocular_update_btn" runat="server" Text="UPDATE" OnClick="ocular_update_btn_Click" CssClass="button" Visible="false" />
                         </div>

                    </div>
                </div>
               
				
			</asp:Panel>

		</div>



        <script language="javascript" type="text/javascript">

    window.setTimeout("assignValToIframe();", 50);

    function assignValToIframe() {

        var s = document.getElementById("pgContentHolder_pgContent_newText").value;

        var iFrame = document.getElementById('ifrmeCovertestSummary');

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

</script>

<script language="javascript" type="text/javascript">
    function DoHidePatientInfo() {
        divContent.style.width = "100%";
        //divContent.style.height = "0%";
        pgAppHeader.style.visibility = "hidden";
        pgAppHeader.style.display = "none";
        pgMenu.style.visibility = "hidden";
        pgMenu.style.display = "none";
        pgNewsTicker.style.visibility = "hidden";
        pgNewsTicker.style.display = "none";
    }

</script>

<script language="javascript" type="text/javascript">
    function handleError() {
        return true;
    }
    window.onerror = handleError;
</script>

<asp:HiddenField ID="hdnSaveFlag" runat="server" />

<script language="javascript" type="text/javascript">

    //window.onbeforeunload = confirmExit;

    function confirmExit() {
        try {
            if (document.getElementById("pgContentHolder_pgContent_hdnSaveFlag").value == "") {
                parent.window.dialogArguments.strResult = "CO";
                parent.window.dialogArguments.strResultRemarks = document.getElementById("pgContentHolder_pgContent_hdnTemRemarks").value;
            }
            else {
                parent.window.dialogArguments.strResult = document.getElementById("pgContentHolder_pgContent_hdnSaveFlag").value;
                parent.window.dialogArguments.strResultRemarks = document.getElementById("pgContentHolder_pgContent_hdnTemRemarks").value;
            }

            window.returnValue = true;

        }
        catch (ex)
        { }
    }
</script>

<script language="javascript" type="text/javascript">
    function one1() {
        document.getElementById('pgContentHolder_pgContent_popupbox').style.visibility = "visible";
        document.getElementById('pgContentHolder_pgContent_popupbox').innerHTML = "Data Inserted Successfully";
        setTimeout("hidebox();", 1000);
        setTimeout("windowclose();", 1000);
    }
    function one2() {
        document.getElementById('pgContentHolder_pgContent_popupbox').style.visibility = "visible";
        document.getElementById('pgContentHolder_pgContent_popupbox').innerHTML = "Data Updated Successfully";
        setTimeout("hidebox();", 1000);
        setTimeout("windowclose();", 1000);
    }
    function hidebox() {
        document.getElementById('pgContentHolder_pgContent_popupbox').style.visibility = "hidden";
    }
    function windowclose() {
        if (document.getElementById("pgContentHolder_pgContent_hdnSaveFlag").value == "") {
            parent.window.dialogArguments.strResult = "CO";
            parent.window.dialogArguments.strResultRemarks = document.getElementById("pgContentHolder_pgContent_hdnTemRemarks").value;
        }
        else {
            parent.window.dialogArguments.strResult = document.getElementById("pgContentHolder_pgContent_hdnSaveFlag").value;
            parent.window.dialogArguments.strResultRemarks = document.getElementById("pgContentHolder_pgContent_hdnTemRemarks").value;
        }
        window.returnValue = true;
        parent.parent.document.getElementById('dialog-close').click();
    }
    function Menuins() {
        document.getElementById('pgContentHolder_pgContent_popupbox').style.visibility = "visible";
        document.getElementById('pgContentHolder_pgContent_popupbox').innerHTML = "Data Inserted Successfully";
        setTimeout("hidebox();", 1000);
        window.location = "../../../EMR/OPPatientDetails/CaseSummary/CaseSummary.aspx";
    }
    function Menuupd() {
        document.getElementById('pgContentHolder_pgContent_popupbox').style.visibility = "visible";
        document.getElementById('pgContentHolder_pgContent_popupbox').innerHTML = "Data Inserted Successfully";
        setTimeout("hidebox();", 1000);
        window.location = "../../../EMR/OPPatientDetails/CaseSummary/CaseSummary.aspx";
    }
</script>

	</form>
</body>
</html>
