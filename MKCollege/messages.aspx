<%@ Page Title= "" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="messages.aspx.cs" Inherits="MKCollege.messages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">

<!DOCTYPE html>

<body>
    <div class="container">
        <h1>Messages</h1>
        <div class="row">
            <div class="col-md-6">
                <h2>Message Listing</h2>
                <table class="table table-striped">
                    <tr>
                        <th>From</th>
                        <th>Subject</th>
                        <th>Received</th>
                    </tr>
                    <asp:Repeater ID="messageRepeater" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("From") %></td>
                                <td><%# Eval("Subject") %></td>
                                <td><%# Eval("ReceivedDate") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <div class="col-md-6">
                <h2>Compose Message</h2>
                <form method="post">
                    <div class="form-group">
                        <label for="txtTo">To:</label>
                        <input type="text" id="txtTo" class="form-control" name="txtTo" required />
                    </div>
                    <div class="form-group">
                        <label for="txtSubject">Subject:</label>
                        <input type="text" id="txtSubject" class="form-control" name="txtSubject" required />
                    </div>
                    <div class="form-group">
                        <label for="txtMessage">Message:</label>
                        <textarea id="txtMessage" class="form-control" name="txtMessage" rows="5" required></textarea>
                    </div>
                    <button type="submit" class="btn btn-primary">Send</button>
                </form>
            </div>
        </div>
    </div>
</body>
</asp:Content>