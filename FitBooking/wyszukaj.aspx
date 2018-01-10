<%@ Page Title="Wyniki wyszukiwania" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wyszukaj.aspx.cs" Inherits="FitBooking.Wyszukaj" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="text-align:center;">
        Adres: <%=Adres %><br />
        Szerokość geograficzna: <%=Szerokosc %><br />
        Długość geograficzna: <%=Dlugosc %><br />
        Typ wyszukania: <%=Typ %>
    </div>
</asp:Content>
