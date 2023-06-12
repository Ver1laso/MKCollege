<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="MKCollege.contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">


<div class="container">
        <h1>Contact Form</h1>

        <div class="form-group">
            <label for="txtName">Name:</label>
            <input type="text" class="form-control" id="txtName" name="txtName" required />
        </div>

        <div class="form-group">
            <label for="txtEmail">Email:</label>
            <input type="email" class="form-control" id="txtEmail" name="txtEmail" required />
        </div>

        <div class="form-group">
            <label for="txtSubject">Subject:</label>
            <input type="text" class="form-control" id="txtSubject" name="txtSubject" required />
        </div>

        <div class="form-group">
            <label for="txtMessage">Message:</label>
            <textarea class="form-control" id="txtMessage" name="txtMessage" rows="5" required></textarea>
        </div>

        <button type="submit" class="btn btn-primary">Submit</button>
    </div>



</asp:Content>
