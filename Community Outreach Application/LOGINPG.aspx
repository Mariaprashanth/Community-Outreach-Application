<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LOGINPG.aspx.cs" Inherits="LOGINPG" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Login Form</title>
	<link href="css/style.css" rel="stylesheet" />
	<link href="https://fonts.googleapis.com/css?family=Poppins:600&display=swap" rel="stylesheet">
	<script src="https://kit.fontawesome.com/a81368914c.js"></script>
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<script src="Sweetalert2/sweetalert.min.js"></script>
	<link href="Sweetalert2/sweetalert2.min.css" rel="stylesheet" />
	<script src="Sweetalert2/sweetalert2.min.js"></script>

	<style>
		.btn{
	display: block;
	width: 100%;
	height: 50px;
	border-radius: 25px;
	outline: none;
	border: none;
	background-image: linear-gradient(to right, #32be8f, #38d39f, #32be8f);
	background-size: 200%;
	font-size: 1.2rem;
	color: #fff;
	font-family: 'Poppins', sans-serif;
	text-transform: uppercase;
	margin: 1rem 0;
	cursor: pointer;
	transition: .5s;
}
.btn:hover{
	background-position: right;
}
	</style>

</head>
<body>
   <img class="wave" src="img/wave.png">
	<div class="container">
		<div class="img">
			<img src="img/bg.svg">
		</div>
		<div class="login-content">
			<form  id="form1" runat="server" >
				<img src="img/avatar.svg">
				<h2 class="title">Welcome</h2>

           		<div class="input-div one">
           		   <div class="i">
           		   		<i class="fas fa-user"></i>
           		   </div>
           		   <div class="div">
           		   		<%--<h5>HMS/EMR User ID</h5>--%>
						  <asp:TextBox ID="inputEmail" runat="server" CssClass="input" required="required" ></asp:TextBox>
						
           		   </div>
           		</div>
           		<div class="input-div pass">
           		   <div class="i"> 
           		    	<i class="fas fa-lock"></i>
           		   </div>
           		   <div class="div">
           		    	<%--<h5>HMS/EMR Password</h5>--%>
						  <asp:TextBox ID="inputPassword" TextMode="Password" CssClass="input" 
                    runat="server" required="required" onfocus="checkCapsWarning(event)" 
                    onkeyup="checkCapsWarning(event)" onkeypress="capLock(event)" 
                    onblur="removeCapsWarning(event)" ></asp:TextBox>
						   <asp:HiddenField ID="hashpass" runat="server" />
						
            	   </div>
            	</div>
				<asp:Button ID="lOGIN_BTN" runat="server" Text="Login" CssClass="btn" OnClick="lOGIN_BTN_Click" />

				<asp:HiddenField ID="Sessioncheck" runat="server" />
				<asp:HiddenField ID="ESOUSROLE" runat="server" />
            	
            </form>
        </div>
    </div>
    <script type="text/javascript" src="js/main.js"></script>
</body>
</html>
