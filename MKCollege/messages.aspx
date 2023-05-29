<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="messages.aspx.cs" Inherits="MKCollege.messages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">

    <div class="container mt-5">
        <h1>Message System</h1>

        <div class="row">
            <div class="col-md-8">
                <div class="card mb-3">
                    <div class="card-body">
                        <h5 class="card-title">Messages</h5>

                        <div class="message-container">
                            <asp:Repeater ID="messageRepeater" runat="server">
                                <ItemTemplate>
                                    <div class="message">
                                        <p><strong><%# Eval("SenderName") %>:</strong> <%# Eval("MessageText") %></p>
                                        <small><%# Eval("SentDate", "{0:dd MMM yyyy HH:mm}") %></small>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>

                        <hr />

                        <div class="form-group">
                            <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" CssClass="form-control" Rows="3" placeholder="Compose a message"></asp:TextBox>
                        </div>

                        <div class="text-end">
                            <asp:Button ID="btnSend" runat="server" Text="Send" CssClass="btn btn-primary" OnClick="btnSend_Click" />
                        </div>
                    </div>
                </div>

                <div class="text-center">
                    <asp:HyperLink ID="lnkLoadMore" runat="server" NavigateUrl="Messages.aspx?page=2" CssClass="btn btn-secondary">Load More</asp:HyperLink>
                </div>
            </div>

            <!-- Sidebar or additional content can be added here -->
        </div>
    </div>

</asp:Content>
