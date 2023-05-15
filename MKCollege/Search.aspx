<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="MKCollege.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Footer" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-3">
            </div>
            <div class="col-md-6">
                 <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Mentor/Course Search</h4><!--Ammend as appropriate.-->
                               </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    
                                    <input type="text" placeholder="Search..." />
                                    <select style="height: 30px;">
                                        <option>Mentors</option>
                                        <option>Courses</option>
                                        <option>Skills</option>
                                    </select>
                                    <button type="submit"><i class="fa fa-search"></i></button>
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
