<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="userlogin.aspx.cs" Inherits="MKCollege.userlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Footer" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">

                <div class="card">
                    <div class="card-body">
                        <div class"row">
                            <div class="col">
                                <center>
                                    <img width="150px" src="imgs/generaluser.png" />
                                </center>
                            </div>
                        </div>

                        <div class"row">
                            <div class="col">
                                <center>
                                    <h3> Member Login</h3>
                                </center>
                            </div>
                        </div>

                        <div class"row">
                            <div class="col">
                                <hr class="solid">
                            </div>
                        </div>


                        <div class"row">
                            <div class="col">
                                
                                <div class="form-group" style="margin-top: 10px">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1"
                        runat="server" placeholder="Email"></asp:TextBox>
                                </div>


                                
                                <div class="form-group" style="margin-top: 10px; margin-bottom: 10px">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2"
                        runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>

                                </div>


                                <div class="form-group" style="margin-top: 10px">
                                    <asp:Button class="btn btn-success w-100" ID="Button1" 
                        runat="server" Text="Login" />

                                </div>
                                <div class="form-group" style="margin-top: 10px">
                                    <a href="userSignup.aspx"><input class="btn btn-info w-100 text-white" id="Button2" type="button" value="Sign Up" /></a>
                                </div>


                            </div>
                        </div>

                    </div>
                </div>
                <br>
                <a href="homePage.aspx"><< Back to Home</a><br><br>

            </div>


        </div>
    </div>

</asp:Content>
