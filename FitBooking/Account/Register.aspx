<%@ Page Title="Zarejestruj" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="FitBooking.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <p style="text-align:center; margin-top:15px;" class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    
    <div class="form-horizontal">
                <div class="signup__container">
  <div class="container__child signup__thumbnail">
    <div class="thumbnail__content text-center">
      <span class="heading--primary">FitBooking wita!</span><br />
      <span class="heading--secondary">Jesteś gotów by odmienić swoje życie?</span>
    </div>
    <div class="signup__overlay"></div>
  </div>
  <div class="container__child signup__form">
      <span class="signup__text">Rejestracja</span>
    <form action="#">
      <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="Email">Adres e-mail</asp:Label>
        <asp:TextBox runat="server" CssClass="form-control" ID="Email" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="Pole adresu e-mail jest wymagane." />
      </div>
      <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="Password">Hasło</asp:Label>
        <asp:TextBox runat="server" CssClass="form-control" ID="Password" TextMode="Password"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="Pole hasła jest wymagane." />
      </div>
      <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="ConfirmPassword">Potwierdź hasło</asp:Label>
        <asp:TextBox runat="server" CssClass="form-control" ID="ConfirmPassword" TextMode="Password" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Pole potwierdzenia hasła jest wymagane." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Hasło i jego potwierdzenie są niezgodne." />
      </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Role" DataValueField="rola">Wybierz typ konta</asp:Label>
                <asp:DropDownList CssClass="btn btn-primary dropdown-toggle fullWidth" ID="Role" runat="server">
                    <asp:ListItem value="klient" Text="Klient"></asp:ListItem>
                    <asp:ListItem value="trener" Text="Trener personalny"></asp:ListItem>
                    <asp:ListItem value="dietetyk" Text="Dietetyk"></asp:ListItem>
                </asp:DropDownList>
        </div>
      <div class="m-t-lg">
        <ul class="list-inline" style="text-align:center;">
          <li>
            <asp:Button runat="server" OnClick="CreateUser_Click" Text="Zarejestruj się" CssClass="btn btn--form" />
          </li>
          <li>
            <a class="signup__link" href="../Account/Login">Posiadam już konto</a>
          </li>
        </ul>
      </div>
    </form>  
  </div>
    </div>
</asp:Content>
