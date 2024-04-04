<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Final_Report.aspx.cs" Inherits="Final_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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

        .custom-image {
            height: 70px;
            margin-left: 50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   

    <div class="container">

        <br />
        <br />
        <h1 class="txtcnter">FINAL REPORT  DASHBOARD  </h1>
        <hr />
        <br />
        <br />

        <div class="row">

            <div style="margin-left: 6%;">
                <asp:DropDownList ID="sch_no_rpt" Width="154px" Height="36px" runat="server"></asp:DropDownList>
            </div>
            <div style="margin-left: 6%;">
                <asp:Button ID="FETCH_BTN" runat="server" Text="FETCH" CssClass="BTNSTYLE" OnClick="FETCH_BTN_Click" />
            </div>

            <div style="margin-left: 6%;">
                <asp:Button ID="ECPORT_XL" runat="server" Text="EXPORT TO EXCEL " CssClass="BTNSTYLE" OnClick="ECPORT_XL_Click" />
            </div>
        </div>
        <br />
        <br />
     
             <asp:Panel ID="PNL2" runat="server">
              <table>
                  <tr>
                      <td>
                          <asp:Label ID="sch_lbl" runat="server" Text="School Name "></asp:Label>
                      </td>
                      <td>
                          <asp:TextBox ID="sch_txt" runat="server"></asp:TextBox>
                      </td>
                  </tr>
                <tr>
                    <td>
                        <asp:Label ID="date_lbl" runat="server" Text="Date of screening"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="date_txt" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="no_children_lbl" runat="server" Text="Total number of children  "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="no_children_txt" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="screened" runat="server" Text="Total number of children screened"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="total_screened_txt" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="spe_pre" runat="server" Text="Number of spectacles prescribed"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="spe_pre_txt" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="child_ref" runat="server" Text="Number of children referred"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="child_ref_txt" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="continue_same" runat="server" Text="Number of children with continue same glasses"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="continue_same_txt" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="NSBVA" runat="server" Text="Number of children with NSBVA"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="NSBVA_txt" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="deficiency" runat="server" Text="Number children identified with color vision deficiency"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="deficiency_txt" runat="server"></asp:TextBox>
                    </td>
                </tr>

            </table>

  </asp:Panel>

        <asp:Panel ID="PNL1" runat="server"> 

                        <br />
                        <br />                     
                  
                        <asp:GridView ID="GridView8" runat="server" CssClass="gridview" Width="80%"></asp:GridView>
                        <br />
                        <br />
                        <asp:GridView ID="GridView9" runat="server" CssClass="gridview" Width="80%"></asp:GridView>
                        <br />
                        <br />
                        <asp:GridView ID="GridView10" runat="server" CssClass="gridview" Width="80%"></asp:GridView>
                        <br />
                        <br />
                        <asp:GridView ID="GridView11" runat="server" CssClass="gridview" Width="80%"></asp:GridView>
                        <br />
                        <br />
                        <asp:GridView ID="GridView12" runat="server" CssClass="gridview" Width="80%"></asp:GridView>

                        <br />
                        <br />

        </asp:Panel>


    </div>

</asp:Content>

