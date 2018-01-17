<%@ Page Title="Potwierdzenie konta" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Confirm.aspx.cs" Inherits="FitBooking.Account.Confirm" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3 style="text-align:center; margin-top:20px;">Gratulacje!</h3>

    <div>
        <asp:PlaceHolder runat="server" ID="successPanel" ViewStateMode="Disabled" Visible="true">
            <p style="text-align:center;margin: 25px 0 40px 0;">
                 Kliknij <asp:HyperLink ID="login" runat="server" NavigateUrl="~/Account/Login"> tutaj </asp:HyperLink>  w celu zalogowania sie             
            </p>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="errorPanel" ViewStateMode="Disabled" Visible="false">
            <p class="text-danger">
                Wystąpił błąd.
            </p>
        </asp:PlaceHolder>
    </div>
</asp:Content>
