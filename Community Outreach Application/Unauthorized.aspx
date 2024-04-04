<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Unauthorized.aspx.cs" Inherits="Unauthorized" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
	
	<script src="JSPACK/bootstrap.min.js"></script>

	<style>
		.container {
			width: 100%;
			max-width: 1200px;
			margin: 0 auto;
			padding: 20px;
			box-sizing: border-box;
		}

		.alert {
			padding: 15px;
			border-radius: 4px;
			color: #fff;
			font-weight: bold;
			margin-bottom: 15px;
			text-align: center;
		}

		.alert-danger {
			background-color: #e1757f;
			border-color: #d31224;
		}

		.txtcnter
		{
			text-align:center;
		}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

	<br />
	<br />
	<br />
	<br />

	<div class="container">

		<div class="text-center">
			<div class="alert alert-danger">
				<strong>Warning!</strong> You are not authorized to access this page!
			</div>
			<div class="txtcnter">
				<img style="height="200px" width="200px""  src="img/giphy.gif" />
			</div>
		</div>
	</div>
</asp:Content>

