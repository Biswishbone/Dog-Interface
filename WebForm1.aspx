<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm1.aspx.vb" Inherits="Intake_Interface.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            width: 49px;
        }
        .auto-style6 {
            width: 37px;
        }
        .auto-style7 {
            width: 137px;
        }
        .auto-style8 {
            width: 49px;
            height: 26px;
        }
        .auto-style13 {
            width: 37px;
            height: 26px;
        }
        .auto-style14 {
            width: 137px;
            height: 26px;
        }
        .auto-style15 {
            width: 130px;
        }
        .auto-style16 {
            width: 130px;
            height: 26px;
        }
        .auto-style17 {
            width: 89px;
        }
        .auto-style18 {
            width: 89px;
            height: 26px;
        }
        .auto-style19 {
            margin-top: 7px;
        }
        .auto-style20 {
            width: 136px;
        }
        .auto-style21 {
            width: 136px;
            height: 26px;
        }
        .auto-style22 {
            width: 49px;
            height: 23px;
        }
        .auto-style23 {
            width: 136px;
            height: 23px;
        }
        .auto-style26 {
            width: 89px;
            height: 23px;
        }
        .auto-style27 {
            width: 37px;
            height: 23px;
        }
        .auto-style28 {
            width: 137px;
            height: 23px;
        }
        .auto-style29 {
            width: 130px;
            height: 23px;
        }
        .auto-style30 {
            width: 98px;
        }
        .auto-style31 {
            width: 98px;
            height: 26px;
        }
        .auto-style32 {
            width: 98px;
            height: 23px;
        }
        .auto-style33 {
            width: 133px;
            height: 56px;
        }
        .auto-style34 {
            width: 74px;
        }
        .auto-style35 {
            width: 74px;
            height: 26px;
        }
        .auto-style36 {
            width: 74px;
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            &nbsp;
            <table class="auto-style1">
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style20">&nbsp;</td>
                    <td class="auto-style34">&nbsp;</td>
                    <td class="auto-style30">
                        <img alt="" class="auto-style33" src="wishbone.jfif" /></td>
                    <td class="auto-style17">&nbsp;</td>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style15">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style20">&nbsp;</td>
                    <td class="auto-style34">&nbsp;</td>
                    <td class="auto-style30">Intake Checklist</td>
                    <td class="auto-style17">&nbsp;</td>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style7">ID#</td>
                    <td class="auto-style15">
                        <asp:TextBox ID="TextBox1" runat="server" Width="126px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8"></td>
                    <td class="auto-style21">&nbsp;</td>
                    <td class="auto-style35"></td>
                    <td class="auto-style31">&nbsp;</td>
                    <td class="auto-style18"></td>
                    <td class="auto-style13"></td>
                    <td class="auto-style14">Source Code:</td>
                    <td class="auto-style16">
                        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Name:</td>
                    <td class="auto-style20">
                        <asp:TextBox ID="TextBox2" runat="server" Width="141px"></asp:TextBox>
                    </td>
                    <td class="auto-style34">Intake Date:</td>
                    <td class="auto-style30">
                        <asp:TextBox ID="TextBox5" runat="server" Width="151px" TextMode="Date"></asp:TextBox>
                    </td>
                    <td class="auto-style17">Age:</td>
                    <td class="auto-style6">
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style7">Sex (At Intake):</td>
                    <td class="auto-style15">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="auto-style19">
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                            <asp:ListItem>Male Neutered</asp:ListItem>
                            <asp:ListItem>Female Spaded</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">Breed:</td>
                    <td class="auto-style21">
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style35">MicroChip:</td>
                    <td class="auto-style31">
                        <asp:TextBox ID="TextBox7" runat="server" Width="145px"></asp:TextBox>
                    </td>
                    <td class="auto-style18"></td>
                    <td class="auto-style13">
                        &nbsp;</td>
                    <td class="auto-style14"></td>
                    <td class="auto-style16"></td>
                </tr>
                <tr>
                    <td class="auto-style22"></td>
                    <td class="auto-style23"></td>
                    <td class="auto-style36"></td>
                    <td class="auto-style32">&nbsp;</td>
                    <td class="auto-style26"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style28"></td>
                    <td class="auto-style29"></td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style20">&nbsp;</td>
                    <td class="auto-style34">
                        &nbsp;</td>
                    <td class="auto-style30">
                        <asp:Button ID="Button1" runat="server" Text="Enter Data" Width="166px" />
                    </td>
                    <td class="auto-style17">
                        &nbsp;</td>
                    <td class="auto-style6">
                        <asp:Button ID="Button2" runat="server" Text="Clear" Width="126px" />
                    </td>
                    <td class="auto-style7">
                        &nbsp;</td>
                    <td class="auto-style15">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style20">&nbsp;</td>
                    <td class="auto-style34">&nbsp;</td>
                    <td class="auto-style30">&nbsp;</td>
                    <td class="auto-style17">&nbsp;</td>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style15">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style22"></td>
                    <td class="auto-style23"></td>
                    <td class="auto-style36"></td>
                    <td class="auto-style32">
                        &nbsp;</td>
                    <td class="auto-style26"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style28"></td>
                    <td class="auto-style29"></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
