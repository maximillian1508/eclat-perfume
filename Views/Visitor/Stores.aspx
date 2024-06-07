<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Visitor.Master" AutoEventWireup="true" CodeBehind="Stores.aspx.cs" Inherits="DECXML_Maximillian_Leonard.Views.Visitor.Stores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../Content/Stores.css" rel="stylesheet" />

    <div class="stores">
        <h1>Flagship Store</h1>
        <div id="lalaport" class="container-shadow store-card">
            <div class="left">
                <h2>Lalaport BBCC</h2>
            </div>
            <div class="middle">
                <p>Open Days: Monday - Saturday</p>
                <p>Open Hours: 10:00 - 21:00</p>
                <p>Address: 2, Jln Hang Tuah, Bukit Bintang, 55100 Kuala Lumpur, Wilayah Persekutuan Kuala Lumpur</p>
                <p>Phone: 012312312312</p>
                <a href="https://maps.app.goo.gl/mwa7ehaTNyW3WSLZ9">Open in Google Maps <i class="fa-solid fa-map-location-dot"></i></a>
            </div>
            <img class="right" src="../../Image/WebContent/lalaport.jpg" alt="Eclat Lalaport" />
        </div>
        <div id="suria_klcc" class="container-shadow store-card">
            <div class="left">
                <h2>Suria KLCC</h2>
            </div>
            <div class="middle">
                <p>Open Days: Tuesday - Sunday</p>
                <p>Open Hours: 09:00 - 21:00</p>
                <p>Address: 241, Petronas Twin Tower, Kuala Lumpur City Centre, 50088 Kuala Lumpur, Wilayah Persekutuan Kuala Lumpur</p>
                <p>Phone: 0912491282221</p>
                <a href="https://maps.app.goo.gl/94PRtNLBG4nFnjp17">Open in Google Maps <i class="fa-solid fa-map-location-dot"></i></a>
            </div>
            <img src="../../Image/WebContent/suria.jpg" alt="Eclat Suria KLCC" class="right" />
        </div>
        <div id="central_market" class="container-shadow store-card">
            <div class="left">
                <h2>Central Market KL</h2>
            </div>
            <div class="middle">
                <p>Open Days: Monday - Friday</p>
                <p>Open Hours: 08:00 - 19:00</p>
                <p>Address: Kuala Lumpur City Centre, 50050 Kuala Lumpur, Federal Territory of Kuala Lumpur</p>
                <p>Phone: 0562844246822</p>
                <a href="https://maps.app.goo.gl/DvNxjFyjKEdVB5e69"> Open in Google Maps <i class="fa-solid fa-map-location-dot"></i></a>
            </div>
            <img src="../../Image/WebContent/central-market.jpg" alt="Eclat Central Market" class="right" />
        </div>
        <div id="pavillion_bj" class="container-shadow store-card">
            <div class="left">
                <h2>Pavillion Bukit Jalil</h2>
            </div>
            <div class="middle">
                <p>Open Days: Monday - Sunday</p>
                <p>Open Hours: 11:00 - 20:00</p>
                <p>Address: 2, Persiaran Jalil 8, Bukit Jalil, 57000 Kuala Lumpur, Wilayah Persekutuan Kuala Lumpur</p>
                <p>Phone: 0812382137127</p>
                <a href="https://maps.app.goo.gl/tjgX1HkuvBH3YYQj8">Open in Google Maps <i class="fa-solid fa-map-location-dot"></i></a>
            </div>
            <img src="../../Image/WebContent/pavillion-bj.jpg" alt="Eclat Pavillion Bukit Jalil" class="right" />
        </div>

    </div>

</asp:Content>
