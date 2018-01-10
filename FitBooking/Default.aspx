<%@ Page Title="Strona główna" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FitBooking._Default" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeaderContent" runat="server">
        <div class="container mt-5">
            <p style="font-size:25px;color:#E5E7E9;">Wyszukaj</p>
            <div class="box">
  <div class="container-4">
    <asp:TextBox ID="search" ClientIDMode="Static" CssClass="inputSearch" name="adres" placeholder="Podaj adres" runat="server"></asp:TextBox>
      <asp:LinkButton ID="btnsubmit" ClientIDMode="Static" runat="server" CssClass="buttonIcon" OnClick="SubmitForm"><i class="searchBtnIcon glyphicon glyphicon-search"></i></asp:LinkButton>
          <div id="searchInContainer button-wrap">  
              <label class="control control--radio">Trener personalny
		 <input type="radio" name="typ" checked="checked" value="trener"/>
		<div class="control__indicator"></div>
	    </label>

        <label class="control control--radio">Dietetyk
		 <input type="radio" name="typ" value="dietetyk"/>
		<div class="control__indicator"></div>
	    </label>
          </div>
  </div>
</div>
        <div class="img-holder mt-3"></div>
        </div>
  </asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <div class="row">
        <div class="col-md-6">
            <div class="top5">
            <h3 style="text-align:center;">Najlepsi trenerzy</h3>
                <div class="best1st"><img src="../images/basic.png" /><br /><span>Jan Kowalski</span></div>
                <hr />
                <div class="best">
                <img src="../images/basic.png" /><span>Jan Kowalski</span><br /><br />
                <img src="../images/basic.png" /><span>Jan Kowalski</span><br /><br />
                <img src="../images/basic.png" /><span>Jan Kowalski</span><br /><br />
                <img src="../images/basic.png" /><span>Jan Kowalski</span><br /><br />
                </div>
            <p style="text-align:center; margin-top: 12px;">
                <a class="btn-primaryS" runat="server" href="~/">PEŁNY RANKING</a>
            </p>
            </div>
        </div>
        <div class="col-md-6">
            <div class="top5">
            <h3 style="text-align:center;">Najlepsi dietetycy</h3>
            <div class="best1st"><img src="../images/basicDiet.png" /><br /><span>Jan Kowalski</span></div>
                <hr />
                <div class="best">
                <img src="../images/basicDiet.png" /><span>Jan Kowalski</span><br /><br />
                <img src="../images/basicDiet.png" /><span>Jan Kowalski</span><br /><br />
                <img src="../images/basicDiet.png" /><span>Jan Kowalski</span><br /><br />
                <img src="../images/basicDiet.png" /><span>Jan Kowalski</span><br /><br />
                </div>
            <p style="text-align:center; margin-top: 12px;">
                <a class="btn-primaryS" runat="server" href="~/">PEŁNY RANKING</a>
            </p>
            </div>
        </div>
    </div>
    

</asp:Content>
