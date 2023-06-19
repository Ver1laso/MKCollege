<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="userProfile.aspx.cs" Inherits="MKCollege.userProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">


    <div class="container">
        <div class="row">
            <div class="col-md-5 ">

                <div class="card">
                    <div class="card-body">
                        <div class"row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="imgs/generaluser.png"/>
                                </center>
                                <br>
                            </div>
                        </div>

                        <div class"row">
                            <div class="col">
                                <center>
                                    <h4>Your Profile</h4>
                                    <span><b>Account Status - </b></span>
                                    <asp:Label class="badge rounded-pill bg-success" ID="Active" runat="server" Text="Active"></asp:Label>
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
                            <div class="col-md-6">
                                <label>First Name</label>
                                <div class="form-group" style="margin-top: 10px">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1"
                        runat="server" placeholder="First Name"></asp:TextBox>
                                </div>

                            </div>

                            <div class="col-md-6">
                                <label>Date of Birth</label>
                                <div class="form-group" style="margin-top: 10px">
                                    <asp:TextBox CssClass="form-control" ID="TextBox3"
                        runat="server" placeholder="Date of Birth"></asp:TextBox>
                                </div>

                            </div>
                        </div>

                                                <div class="row justify-content-between">
                            <div class="col-md-6">
                                <label>Last Name</label>
                                <div class="form-group" style="margin-top: 10px">
                                    <asp:TextBox CssClass="form-control" ID="TextBox8"
                        runat="server" placeholder="Last Name"></asp:TextBox>
                                </div>

                            </div>

                            <div class="col-md-6">
                                <label>Mentor Status</label>
                                <div class="form-group" style="margin-top: 10px">
                                    <asp:TextBox CssClass="form-control" ID="TextBox9"
                        runat="server" placeholder="Mentor Status" TextMode="SingleLine"></asp:TextBox>
                                </div>

                            </div>
                        </div>

                    </div>
                        <br>
                    <div class="container">
                        <div class="row justify-content-between">
                            <center>
                            <div class="col-md-6">
                                <label>Email Address</label>
                                <div class="form-group" style="margin-top: 10px">
                                    <asp:TextBox CssClass="form-control" ID="TextBox5"
                        runat="server" placeholder="Email Address" TextMode="Email"></asp:TextBox>
                                </div>

                            </div>
                             </center>
                        </div>
                    </div>
                        <br>
                        <div class="row">
                            <div class="col">
                                <center>
                                <span class="badge rounded-pill bg-success">Login Credentials</span>
                                </center>
                            </div>
                        </div>
                        <br>
                    <div class="container">
                        <div class="row justify-content-between">
                            <div class="col-md-4">
                                <label>User ID</label>
                                <div class="form-group" style="margin-top: 10px">
                                    <asp:TextBox class="form-control" ID="TextBox2"
                        runat="server" placeholder="User ID" ReadOnly="True" BackColor="#EFEFEF"></asp:TextBox>
                                </div>

                            </div>
                            
                            <div class="col-md-4">
                                <label>Old Password</label>
                                <div class="form-group" style="margin-top: 10px">
                                    <asp:TextBox class="form-control" ID="TextBox6"
                        runat="server" placeholder="Old Password" TextMode="Password" ReadOnly="True" BackColor="#EFEFEF"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>New Password</label>
                                <div class="form-group" style="margin-top: 10px">
                                    <asp:TextBox class="form-control" ID="TextBox7"
                        runat="server" placeholder="New Password" TextMode="Password" BackColor="#EFEFEF"></asp:TextBox>
                                </div>
                            </div>

                        </div>
                    </div>
                        <br>
                        <div class"row">
                            <div class="col-4 mx-auto ">
                                <center>  
                                <div class="form-group" style="margin-top: 10px">
                                    <asp:Button class="btn btn-primary w-100 " ID="Button1" 
                        runat="server" Text="Update" />

                                </div>
                                </center>
                                <div class="form-group" style="margin-top: 10px">
                                    <asp:Button class="btn btn-danger w-100 " ID="Button2" 
                        runat="server" Text="Delete Account" />

                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <br>
                <a href="homePage.aspx">
                    << Back to Home
                 </a>
                <br><br>
            </div>
            <div class="col-md-7">
                <!-- Profile Right Hand Side -->
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center><h4>Profile Course Viewer</h4></center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <h5>Enrolled Courses</h5>
                                <table style="width: 100%; table-layout: fixed;">
                                    <col width = "35%" />
                                    <col width = "25%" />
                                    <col width = "20%" />
                                    <col width = "20%" />
                                    <tr>
                                        <th>Course Name</th>
                                        <th>Mentor</th>
                                        <th>Start Date</th>
                                        <th>End Date</th>
                                    </tr>
                                    <tr>
                                        <td>Learn Spanish Quick with Jose</td>
                                        <td>Jose P. Santana</td>
                                        <td>16/05/2023</td>
                                        <td>30/05/2023</td>
                                    </tr>
                                    <tr>
                                        <td>Git good with Git</td>
                                        <td>Dominic Clarke</td>
                                        <td>16/05/2023</td>
                                        <td>30/05/2023</td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class ="col">
                                <h5>Completed Courses</h5>
                                <table style="width: 100%; table-layout: fixed;">
                                    <col width = "35%" />
                                    <col width = "25%" />
                                    <col width = "20%" />
                                    <col width = "20%" />
                                    <tr>
                                        <th>Course Name</th>
                                        <th>Mentor</th>
                                        <th>Start Date</th>
                                        <th>End Date</th>
                                    </tr>
                                    <tr>
                                        <td>Splunk Fundamentals</td>
                                        <td>Sharon Wu</td>
                                        <td>11/03/2023</td>
                                        <td>13/03/2023</td>
                                    </tr>
                                    <tr>
                                        <td>Crying at Jasper</td>
                                        <td>Sharon Wu</td>
                                        <td>14/02/2023</td>
                                        <td>21/02/2023</td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>