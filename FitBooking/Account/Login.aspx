<%@ Page Title="Logowanie" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FitBooking.Account.Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    

    <div class="row">
            <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
            </asp:PlaceHolder>
            <div class="signup__container" style="height: 500px;">
                <div class="container__child signup__form">
                    <span class="signup__text">Logowanie</span>
            
                <div class="form-horizontal">
                            <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
                            <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                CssClass="text-danger" ErrorMessage="Adres email jest wymagany." />
                    </div>
                            <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Hasło</asp:Label>
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="Pole hasła jest wymagane." />
                    </div>
                    <div class="form-group">
                            <div class="checkbox">
                                <asp:CheckBox runat="server" ID="RememberMe" />
                                <asp:Label runat="server" AssociatedControlID="RememberMe">Zapamiętać hasło?</asp:Label>
                            </div>
                    </div>
                    <div class="m-t-lg">
                    <ul class="list-inline" style="text-align:center;">
                    <li><div class="form-group">
                            <asp:Button runat="server" OnClick="LogIn" Text="Zaloguj się" CssClass="btn btn--form" />
                            &nbsp;&nbsp;
                            <asp:Button runat="server" ID="ResendConfirm"  OnClick="SendEmailConfirmationToken" Text="Resend confirmation" Visible="false" CssClass="btn btn-default" />
                    </div>
                    </li>

                     <li>      
                <p>
                    <asp:HyperLink runat="server" CssClass="signup__link" ID="RegisterHyperLink" ViewStateMode="Disabled">Zarejestruj się</asp:HyperLink>
                </p>
                         </li><li>
                <p>
                    <asp:HyperLink runat="server" CssClass="signup__link" ID="ForgotPasswordHyperLink" ViewStateMode="Disabled">Zapomniałeś/aś hasła?</asp:HyperLink>
                </p></li>
                </ul>
                        </div>
                    </div>
            </section>
                </div>
                <div class="container__child login__thumbnail">
                            <div class="signup__overlay"></div>
                        </div>
                </div>
    </div>
</asp:Content>