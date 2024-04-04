<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PostDilatedRefraction.aspx.cs" Inherits="POPUPSCREENS_PostDilatedRefraction" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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

    <script type="text/javascript">
        window.onload = function () {
            var docCode = '<%= Request.QueryString["studentID"] %>';
        
        };
    </script>


</head>
<body>
    <form id="form1" runat="server">

		<div class="container">
			<h1 class="txtcnter"> Post Dilated Refraction </h1>
			<hr />
			<br />
			<br />
			<div style="width: 100%;">
    <div style="text-align: center;">
       <%-- <label id="lblautref" runat="server" style="display: block; font-weight: bold;">Post Dilated Refraction</label>--%>
    </div>
    <div style="text-align: center; margin-bottom: 10px;">&nbsp;</div>
    <div style="display: flex; justify-content: space-between; margin-bottom: 10px;">
        <div style="width: 10%; text-align: center;">
            <label id="lblodeye" runat="server" class="Generallbl">OD</label>
        </div>
        <div style="width: 20%;">
			<asp:TextBox ID="txtodsph" runat="server" class="generaltxt" style="width: 50%;" onblur="javascript:validatecontrol('txtodsph');"></asp:TextBox>
            <%--<input id="txtodsph" runat="server" class="generaltxt" style="width: 50%;" onblur="javascript:validatecontrol('txtodsph');" />--%>
            <label id="lblodsph" runat="server" class="Generallbl"> DS / </label>
        </div>
        <div style="width: 20%;">
			<asp:TextBox ID="txtodcyl" runat="server" class="generaltxt" style="width: 50%;" onblur="javascript:validatecontrol('txtodcyl');"></asp:TextBox>
            <%--<input id="txtodcyl" runat="server" class="generaltxt" style="width: 50%;" onblur="javascript:validatecontrol('txtodcyl');" />--%>
            <label id="lblodcyl" runat="server" class="Generallbl"> DC X </label>
        </div>
        <div style="width: 20%;">
			<asp:TextBox ID="txtodaxi" runat="server" class="generaltxt" style="width: 50%;"></asp:TextBox>
           <%-- <input id="txtodaxi" runat="server" class="generaltxt" style="width: 50%;" />--%>
            <label id="lblodaxi" runat="server" class="Generallbl"> Axis </label>
        </div>
        <div style="width: 30%;">
            <label id="Label1" runat="server" class="Generallbl"> V/A </label>
			<asp:DropDownList ID="cmbAcOdDvBCVAOpt" runat="server" class="generalcbo" style="width: 94%;"></asp:DropDownList>
            <%--<select id="cmbAcOdDvBCVAOpt" runat="server" class="generalcbo" style="width: 94%;"></select>--%>
        </div>
    </div>
    <div style="display: flex; justify-content: space-between; margin-bottom: 10px;">
        <div style="width: 10%; text-align: center;">
            <label id="lbloseye" runat="server" class="Generallbl">OS</label>
        </div>
        <div style="width: 20%;">
			<asp:TextBox ID="txtossph" runat="server" class="generaltxt" style="width: 50%;" onblur="javascript:validatecontrol('txtossph');"></asp:TextBox>
          <%--  <input id="txtossph" runat="server" class="generaltxt" style="width: 50%;" onblur="javascript:validatecontrol('txtossph');" />--%>
            <label id="lblossph" runat="server" class="Generallbl"> DS / </label>
        </div>
        <div style="width: 20%;">
			<asp:TextBox ID="txtoscyl" runat="server" class="generaltxt" style="width: 50%;" onblur="javascript:validatecontrol('txtoscyl');"></asp:TextBox>
          <%--  <input id="txtoscyl" runat="server" class="generaltxt" style="width: 50%;" onblur="javascript:validatecontrol('txtoscyl');" />--%>
            <label id="lbloscyl" runat="server" class="Generallbl"> DC X </label>
        </div>
        <div style="width: 20%;">
			<asp:TextBox ID="txtosaxi" runat="server" class="generaltxt" style="width: 50%;"></asp:TextBox>
           <%-- <input id="txtosaxi" runat="server" class="generaltxt" style="width: 50%;" />--%>
            <label id="lblosaxi" runat="server" class="Generallbl"> Axis </label>
        </div>
        <div style="width: 30%;">
            <label id="Label2" runat="server" class="Generallbl"> V/A </label>
			<asp:DropDownList ID="cmbAcOsDvBCVAOpt" runat="server" class="generalcbo" style="width: 94%;"></asp:DropDownList>
           <%-- <select id="cmbAcOsDvBCVAOpt" runat="server" class="generalcbo" style="width: 94%;"></select>--%>
        </div>
    </div>
    <div style="display: flex; justify-content: space-between; margin-bottom: 10px;">
        <div style="width: 10%; text-align: center;">
            <label id="lblRemarks" runat="server" class="Generallbl">Remarks</label>
        </div>
        <div style="width: 90%;" colspan="3">
            <textarea id="txtRemarks" runat="server" class="generaltxt" style="width: 95%;" rows="3" cols="5"></textarea>
        </div>
    </div>
    <div style="display: flex; justify-content: center;">
		<asp:Button ID="save_btn" runat="server" Text="SAVE" OnClick="save_btn_Click" style="margin-right: 20px;" />

        <asp:Button ID="modify_btn" runat="server" Text="MODIFY" OnClick="modify_btn_Click" />
       
    </div>
</div>
        <br />
		<br />

			<div class="txtcnter"  style="margin-left:23%;width:135%;">
			<asp:Literal ID="SummaryLiteral" runat="server"></asp:Literal>
		</div>

			<%--<div class="table" id="TableSummary" style="display: table; width: 100%; border-collapse: collapse;">
    <div  style="display: table-row;">
        <div class="td" style="display: table-cell; width: 10%;">
            <asp:label enableviewstate="False" id="lblSummary" runat="server" cssclass="boldlbl">Summary</asp:label>
        </div>
        <div class="td" style="display: table-cell; width: 0%;">
            <asp:textbox id="txtSummary" onblur="javascript:clearStatusMsg()" onfocus="javascript:setStatusMsg('pgContentHolder_pgContent_txtSummary','Enter a maximum of 4000 characters')" tabindex="97" runat="server" cssclass="NumericTxt" width="0%" rows="4" textmode="MultiLine" visible="true"></asp:textbox>
        </div>

		<div class="txtcnter"  style="margin-left:23%;width:135%;">
			<asp:Literal ID="SummaryLiteral" runat="server"></asp:Literal>
		</div>

    </div>
</div>--%>


		
</div>
		

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

        function autorefractionenablecopy() {
            document.getElementById("btnCOPY").disabled = false;
        }

        function autorefractiondisablecopy() {
            document.getElementById("btnCOPY").disabled = true;
        }

        function fnjavafunctioncallbtnCOPY() {
            parent.window.dialogArguments.strtxtodsph = document.getElementById("txtodsph").value;
            parent.window.dialogArguments.strtxtodcyl = document.getElementById("txtodcyl").value;
            parent.window.dialogArguments.strtxtodaxi = document.getElementById("txtodaxi").value;
            parent.window.dialogArguments.strtxtossph = document.getElementById("txtossph").value;
            parent.window.dialogArguments.strtxtoscyl = document.getElementById("txtoscyl").value;
            parent.window.dialogArguments.strtxtosaxi = document.getElementById("txtosaxi").value;
            window.returnValue = true;
            parent.parent.document.getElementById('dialog-close').click();
        }

        function one1() {
            document.getElementById('popupbox').style.visibility = "visible";
            document.getElementById('popupbox').innerHTML = "Data Inserted Successfully";
            setTimeout("hidebox();", 1000);
            setTimeout("windowclose();", 1000);
        }

        function hidebox() {
            document.getElementById('popupbox').style.visibility = "hidden";
        }

        function windowclose() {
            window.returnValue = true;
            parent.parent.document.getElementById('dialog-close').click();
        }
    </script>
        
    </form>
</body>
</html>
