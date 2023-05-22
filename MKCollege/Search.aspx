<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="MKCollege.Search" %>
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
                                <center>
                                    <h4>Mentor/Course Search</h4><!--Ammend as appropriate.-->
                               </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <form method="post">
                                        <input type="text" name="searchText" placeholder="Search..." />
                                        <select name="searchType" style="height: 30px;">
                                            <option>Mentors</option>
                                            <option>Courses</option>
                                            <option>Skills</option>
                                        </select>
                                        <button runat="server" id="btnRun" onserverclick="runSearch" title="Search">
                                            <i class="fa fa-search"></i>
                                        </button>
                                        <!--<button type="submit"><i class="fa fa-search"></i></button>-->
                                    </form>
                                </center>
                            </div>
                        </div>

                    </div>
                </div>
                 <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">

                                <%= outputText %>

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
