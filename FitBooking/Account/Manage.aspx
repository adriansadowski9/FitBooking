<%@ Page Title="Zarządzanie kontem" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="FitBooking.Account.Manage" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h2 style="margin-top:20px;text-align:center;">Panel użytkownika</h2>
    <hr />
    <div>
        <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
            <p class="text-success"><%: SuccessMessage %></p>
        </asp:PlaceHolder>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="form-horizontal">
                <h4 style="text-align: center;">Informacje o spotkaniach</h4>
                <div style="margin-top:25px;text-align: center">
                <asp:HyperLink NavigateUrl="/Account/ManagePassword" cssClass="btn-primaryS" Text="Kalendarz" Visible="True" runat="server" />
                    </div>
                <h4 style="text-align: center; margin-top:25px;">Edycja ustawień konta</h4>
                <div style="margin-top:25px;text-align: center">
                        <asp:HyperLink NavigateUrl="/Account/ManagePassword" cssClass="btn-primaryS" Text="Zmiana hasła" Visible="True" ID="ChangePassword" runat="server" />
                        <asp:HyperLink NavigateUrl="/UzytkownikHome/Index" cssClass="btn-primaryS" Text="Edycja danych osobowych" Visible="True" runat="server" />
                    </div>
            </div>
        </div>
    </div>

</asp:Content>
