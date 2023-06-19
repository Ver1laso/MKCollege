<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="userSignup.aspx.cs" Inherits="MKCollege.userSignup" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto">

                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="imgs/generaluser.png"/>
                                </center>
                                <br>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>User Registration</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr class="solid">
                            </div>
                        </div>

                        <div class="container">
                            <div class="row justify-content-between">
                                <div class="col-md-6">
                                    <label>First Name</label>
                                    <div class="form-group" style="margin-top: 10px">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="First Name"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <label>Date of Birth</label>
                                    <div class="form-group" style="margin-top: 10px">
                                        <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Date of Birth"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="container">
                            <div class="row justify-content-between">
                                <div class="col-md-6">
                                    <label>Last Name</label>
                                    <div class="form-group" style="margin-top: 10px">
                                        <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Last Name" TextMode="SingleLine"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <label>Email Address</label>
                                    <div class="form-group" style="margin-top: 10px">
                                        <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Email Address" TextMode="Email"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col">
                                <center>
                                    <span class="badge rounded-pill bg-primary">Login Credentials</span>
                                </center>
                            </div>
                        </div>
                        <br />
                        <div class="container">
                            <div class="row justify-content-between">
                                <div>
                                    <button class="btn btn-primary btn-block btn-lg signup-home-button">
                                        <a class="signup-home-button" href="homePage.aspx">&lt;&lt; Back to Home</a>
                                    </button>
                                </div>
                                <div>
                                    <div class="form-group" style="margin-top: 10px">
                                        <asp:Button class="btn btn-success btn-block btn-lg signup-submit-button" ID="SignUpSubmit" runat="server" Text="Sign Up" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <br>
        </div>
    </div>
    <br>
</asp:Content>
