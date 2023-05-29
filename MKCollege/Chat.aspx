<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="MKCollege.Chat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">


<!DOCTYPE html>
<html>
<head>
    <title>Web Chat</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h1>Web Chat</h1>
                <div id="chatContainer"></div>
                <div id="messageInputContainer">
                    <input type="text" id="messageInput" class="form-control" placeholder="Type your message..." />
                    <button type="button" id="sendButton" class="btn btn-primary">Send</button>
                </div>
            </div>
        </div>
    </div>

    <script src="Bootstrap/js/jquery.min3.7.0.js"></script>
    <script src="Bootstrap/js/jquery.signalR.min2.4.3.js"></script>

    <script src="signalr/hubs"></script>
    <script>
        $(function () {
            var chatHub = $.connection.chatHub;

            chatHub.client.receiveMessage = function (user, message) {
                var encodedUser = $('<div />').text(user).html();
                var encodedMessage = $('<div />').text(message).html();
                var messageHtml = '<div><strong>' + encodedUser + '</strong>: ' + encodedMessage + '</div>';
                $('#chatContainer').append(messageHtml);
                // Scroll to the bottom of the chat container to show the latest message
                $('#chatContainer').scrollTop($('#chatContainer')[0].scrollHeight);
            };

            $.connection.hub.start().done(function () {
                console.log("SignalR connection established.");

                // Wire up the sendButton click event
                $('#sendButton').click(function () {
                    var message = $('#messageInput').val();
                    chatHub.server.sendMessage(message);
                    $('#messageInput').val('');
                });
            });


            $('#messageInput').keypress(function (e) {
                if (e.which === 13) { // Enter key
                    e.preventDefault(); // Prevent the default form submission
                    var message = $('#messageInput').val().trim();
                    if (message !== '') {
                        chatHub.server.sendMessage(message);
                        $('#messageInput').val('');
                    }
                }
            });

        });
</script>
</body>
</html>
</asp:Content>
