<%@ Page Title="Profil użytkownika" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="profil.aspx.cs" Inherits="FitBooking.Profil" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
      <div class="container">
    <div class="row my-2">
        <div class="col-lg-8 order-lg-2" style="margin-top:30px;">
            <div class="tab-content py-4">
                <div class="tab-pane active" id="profile" >
                    <h5 class="mb-3" style="font-weight:500;"><%=User.imie %> <%=User.nazwisko %></h5>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-6" style="float:left;">
                            <h6>Profesja</h6>
                            <p> <% if (Rola == "trener")
                                {
                                        %>
                                Trener personalny <%}
                            else{%>
                                Dietetyk <%} %>


                                 
                            </p>
                            <h6>Miasto</h6>
                            <p>
                                <%=Miasto %>
                            </p>
                            </div>
                            <div class="col-md-6" style="float:right;">
                                <a class="btn-primaryS" style="margin-top:40px;float:right;" href='/Kalendarz?id=<%=User.Id%>'>Umów się na spotkanie</a>
                                </div>
                        </div>
                        <div class="col-md-12">
                            <h5 class="mt-2" style="float:left;">O mnie</h5>
                        </div>
                        <div class="col-md-12" style="text-align:left;">
                            <%=OMnie %>
                            </div>
                        <br /> 
                        <div class="col-md-12" style="margin: 0 auto;">
                            <h5 class="mt-2" style="float:left;">Obszar pracy</h5>
                            <div id="map_canvas" style="margin-bottom:15px; width: 620px; height: 250px;"></div>
                            <script>var map;
                                var latlng = new google.maps.LatLng(<%=Szerokosc%>, <%=Dlugosc%>);
                                function initialize() {
                                    var mapOptions = {
                                        center: latlng,
                                        zoom: 9,
                                        mapTypeId: google.maps.MapTypeId.ROADMAP
                                    };
                                    var el = document.getElementById("map_canvas");
                                    map = new google.maps.Map(el, mapOptions);

                                    var marker = new google.maps.Marker({
                                        map: map,
                                        position: latlng
                                    });

                                    var sunCircle = {
                                        strokeColor: "#186A3B",
                                        strokeOpacity: 0.8,
                                        strokeWeight: 2,
                                        fillColor: "#186A3B ",
                                        fillOpacity: 0.4,
                                        map: map,
                                        center: latlng,
                                        radius: 15000
                                    };
                                    cityCircle = new google.maps.Circle(sunCircle);
                                    cityCircle.bindTo('center', marker, 'position');
                                }
                                initialize();    </script>
                        </div>

                    </div>
                    <!--/row-->
                </div>
              
                    
                </div>
            </div>
        <div class="col-lg-4 order-lg-1 text-center" style="margin-top:30px;">
            <img class="profile-avatar"  src="/images/avatar.png" alt="avatar"><br /><br />
                 <h5 style="margin-bottom:-5px;" class="mt-2">Społeczności</h5><br />
            <%if(Facebook != "brak") 
                    {%>
            <a href="//<%=Facebook %>" class="fa fa-facebook"></a>
            <%} %>
            <%if(Instagram != "brak") 
                        {%>
            <a href="//<%=Instagram %>" class="fa fa-instagram"></a>
            <%} %>
            <%if(Twitter != "brak") 
                    {%>
            <a href="//<%=Twitter %>" class="fa fa-twitter"></a>
            <%} %>
            <%if (Twitter != "brak")
                {%>
            <a href="//snapchat.com/add/<%=Snapchat %>" class="fa fa-snapchat-ghost"></a>
            <%} %>
            <%if ((Facebook == "brak") && (Instagram == "brak") && (Twitter == "brak") && (Snapchat == "brak"))
                { %>
            Brak danych odnośnie serwisów społecznościowych
            <%} %>

        </div>

    </div>
</div>
</asp:Content>
