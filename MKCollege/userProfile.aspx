<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="userProfile.aspx.cs" Inherits="MKCollege.userProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Footer" runat="server">


    <div class="container-fluid">
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
                                <label>Full Name</label>
                                <div class="form-group" style="margin-top: 10px">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1"
                        runat="server" placeholder="Full Name"></asp:TextBox>
                                </div>

                            </div>

                            <div class="col-md-6">
                                <label>Date of Birth</label>
                                <div class="form-group" style="margin-top: 10px">
                                    <asp:TextBox CssClass="form-control" ID="TextBox3"
                        runat="server" placeholder="Date of Birth" TextMode="Date"></asp:TextBox>
                                </div>

                            </div>
                        </div>
                    </div>
                        <br>
                    <div class="container">
                        <div class="row justify-content-between">
                            <div class="col-md-6">
                                <label>Contact Number</label>
                                <div class="form-group" style="margin-top: 10px">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4"
                        runat="server" placeholder="Contact Number" TextMode="Number"></asp:TextBox>
                                </div>

                            </div>

                            <div class="col-md-6">
                                <label>Email Address</label>
                                <div class="form-group" style="margin-top: 10px">
                                    <asp:TextBox CssClass="form-control" ID="TextBox5"
                        runat="server" placeholder="Email Address" TextMode="Email"></asp:TextBox>
                                </div>

                            </div>
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
                            </div>
                        </div>

                    </div>
                </div>
                <br>
                <a href="Home page.aspx"><< Back to Home</a><br><br>

            </div>

            <div class="col-md-7">



            </div>

        </div>
    </div>


</asp:Content>
