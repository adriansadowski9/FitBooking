<%@ Page Title="Zapomniane hasło" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Forgot.aspx.cs" Inherits="FitBooking.Account.ForgotPassword" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="row">
        <div class="col-md-12">
            <asp:PlaceHolder id="loginForm" runat="server">
                <div class="form-horizontal">
                    <h2 style="text-align:center; margin-top:10px;">Przypomnienie hasła</h2>
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group" style="text-align:center;">
                        <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-5">Adres e-mail</asp:Label>
                        <div class="col-md-5 col-md-center">
                            <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                CssClass="text-danger" ErrorMessage="Pole adresu e-mail jest wymagane." />
                        </div>
                    </div>
                    <div class="form-group"style="text-align:center;">
                        <div class="col-md-offset-5 col-md-5 col-md-center">
                            <asp:Button runat="server" OnClick="Forgot" Text="Wyślij email" CssClass="btn-primaryS" />
                        </div>
                    </div>
                </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder runat="server" ID="DisplayEmail" Visible="false">
                <p class="text-info">
                    Sprawdź pocztę e-mail, aby zresetować hasło.
                </p>
            </asp:PlaceHolder>
        </div>
    </div>
</asp:Content>
