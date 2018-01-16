<%@ Page Title="Wyniki wyszukiwania" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wyszukaj.aspx.cs" Inherits="FitBooking.Wyszukaj" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="text-align:center;">
        <h2 style="text-align:center;margin-top:30px;">Wyszukiwanie <%=Typ %>a w promieniu 20 kilometrów</h2>
        <%=HtmlText %>


    </div>
</asp:Content>
