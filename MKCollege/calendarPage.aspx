<%@ Page Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="calendarPage.aspx.cs" Inherits="MKCollege.calenderPage" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ContentPlaceHolderID="Main" runat="server">
    <div class="container calendar-page">
        <h1 class="calendar-title text-center">
            My Calendar
        </h1>
        <div id="calendar">
        </div>
    </div>

    <script>
        $(document).ready(function () {
            $.ajax({
                url: 'calendarPage.aspx/GetEvents',
                method: 'POST',
                contentType: 'application/json',
                success: function (data) {
                    var events = data.d;
                    renderCalendar(events);
                },
                error: function (error) {
                    console.log(error);
                }
            });
        });

        function renderCalendar(events) {
            $('#calendar').fullCalendar({
                header: {
                    left: 'prev,next today',
                    center: 'title',
                    right: 'month,agendaWeek,agendaDay'
                },
                defaultView: 'month',
                editable: true,
                events: events
            });
        }
    </script>



</asp:Content>