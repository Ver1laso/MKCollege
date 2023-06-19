<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="coursePage.aspx.cs" Inherits="MKCollege.coursePage" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-3">
            </div>
            <div class="col-md-6">
                 <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    
                <div class="card">
                    <div class="card-body">

                        <div class"row">
                            <div class="col">
                                <center>
                                    <h4><%= courseName %></h4>
                                    <span><b></b></span>
                                    <%= skill[0] %>
                                    <%= skill[1] %>
                                    <%= skill[2] %>
                                    <!--
                                    <asp:Label class="badge rounded-pill bg-warning" ID="Label1" runat="server" Text="Spanish"></asp:Label>
                                    <asp:Label class="badge rounded-pill bg-warning" ID="Label2" runat="server" Text="Dealing with Jose"></asp:Label>-->
                                </center>
                            </div>
                        </div>

                        <div class"row">
                            <div class="col">
                                <hr class="solid">
                            </div>
                        </div>


                    <div class="container">
                        <div class="row justify-content-between">
                            <label>Description</label>
                                <div class="form-group" style="margin-top: 10px">
                                    <p><%= description %></p>
                                </div>
                        </div>

                                                <div class="row justify-content-between">
                            <div class="col-md-6">
                                <label>Course Length</label>
                                <div class="form-group" style="margin-top: 10px">
                                    <p><%= length %></p>
                                </div>

                            </div>

                            <div class="col-md-6">
                                <label>Spaces Left</label>
                                <div class="form-group" style="margin-top: 10px">
                                    <p><%= capacity %></p>
                                </div>

                            </div>
                        </div>

                    </div>
                    <div class="container">
                        <div class="row justify-content-between">
                            <center>
                            <div class="col-md-6">
                                <label>Mentor</label>
                                <div class="form-group" style="margin-top: 10px">
                                    <p><%= mentor %></p>
                                </div>

                            </div>
                             </center>
                        </div>
                    </div>
                        <br>
                        <div class="row">
                            <div class="col">
                                <center>
                                   
                                    <%=(!isEnrolled) ? @"<label class=""badge rounded-pill bg-info"">Not Enrolled</label>" : @"<label class=""badge rounded-pill bg-success"">Enrolled</label>" %>

                         
                                <br />
                                </center>
                            </div>
                        </div>
                        <br>
                        <div class"row">
                            <div class="col-4 mx-auto ">
                                <center>  
                                <div class="form-group" style="margin-top: 10px">
                                    <form method="post">

                                        <button runat="server" class="btn btn-success w-100" id="btnRun" onserverclick="runEnrol">Enrol</button>
                                    
                                    
                                    </form>

                                </div>
                                </center>
                            </div>
                        </div>

                    </div>
                </div>
                <br>
                <a href="homePage.aspx">
                    << Back to Home
                 </a>
                <br><br>
                                </center>
                            </div>
                        </div>

                    </div>
                </div>


            </div>
            <div class ="col-md-3">
            </div>
        </div>
    </div>
</asp:Content>
