<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeFile="contact.aspx.cs" Inherits="MKCollege.contact" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Contact Form</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Contact Us</h2>
            <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
            <p>
                <asp:Label ID="lblName" runat="server" Text="Name:"></asp:Label>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="lblMessageContent" runat="server" Text="Message:"></asp:Label>
                <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            </p>
        </div>
    </form>
</body>
</html>
</asp:Content>
