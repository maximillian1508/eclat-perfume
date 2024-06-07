<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Visitor.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="DECXML_Maximillian_Leonard.Home" %>

<asp:Content ID="Home" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../Content/Home.css" rel="stylesheet" />
    <div style="display: flex; flex-direction: column; align-items: center;">
        <div class="imageContainer first-home-container">
            <div style="width: 27.5rem; margin: 6.5rem 1rem auto 4rem;">
                <h2 style="font-size: 3.25rem; font-family: 'Manrope'; font-weight: 900; color: #353535; line-height: 1.5em;">Symphony of Elegance and Sophistication</h2>
            </div>
            <img style="width: 22.5%; height: 95%; padding-top: 2.5em;" src="../../Image/WebContent/HomePerfume-removebg.png" />
            <div style="width: 30rem; margin-top: 6.5rem; text-align: center;">
                <h2 style="font-size: 2.5rem; font-family: 'Montserrat'; font-weight: 600; color: #353535; line-height: 1.25em;">Experience the enchantment</h2>
                <div style="display: flex; flex-direction: column; align-items: center; gap: 1rem; margin-top: 1em">
                    <a href="product-catalog" class="white-button button-shadow">Shop online
                        <img src="../../Image/WebContent/internet-pointer.png" style="width: 20px; height: 20px;" />
                        <img src="../../Image/WebContent/internet-pointer-hover.png" style="width: 20px; height: 20px;" />
                    </a>
                    <a class="black-button" href="stores">Find our store <i class="fa-solid fa-shop"></i></a>
                </div>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" style="width:85%;">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
            </Triggers>
            <ContentTemplate>
                <asp:Timer ID="Timer1" Interval="1500" runat="server"></asp:Timer>
                <asp:AdRotator ID="AdRotator1" runat="server"
                    AdvertisementFile="~/xml/Advertisements.xml" Height="350px" Target="_top"
                    Width="100%" style="border-radius:10px"/>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="gender-container" style="margin-top: 25px">
            <a class="card container-shadow" href="product-catalog?gender=male">
                <img class="card-img" src="../../Image/WebContent/men-perfume.jpg" />
                <div class="card-img-overlay">
                    <h3 class="card-title">Men</h3>
                </div>
            </a>
            <a class="card container-shadow" href="product-catalog?gender=female">
                <img class="card-img" src="../../Image/WebContent/women-perfume.jpg" />
                <div class="card-img-overlay">
                    <h3 class="card-title">Women</h3>
                </div>
            </a>
            <a class="card container-shadow" href="product-catalog?gender=unisex">
                <img class="card-img" src="../../Image/WebContent/unisex-perfume.jpg" />
                <div class="card-img-overlay">
                    <h3 class="card-title">Unisex</h3>
                </div>
            </a>
        </div>

        <div class="about-container container-shadow">
            <img src="../../Image/WebContent/home-about.jpg" />
            <div style="position: absolute; top: 50px; right: 40px; color: white; width: 45%; display: flex; flex-direction: column; gap: 1.25rem">
                <p style="font-size: 2.25rem; letter-spacing: 1.5px; word-spacing: 2.5px; font-weight: 600; font-family: 'Manrope'; line-height: 3rem">
                    Éclat Perfume, where <span style="color: #fedb66">brilliance </span>becomes scent. Dive into the artistry and passion defining our creations.
                </p>
                <a class="white-button" href="about">DISCOVER OUR JOURNEY</a>
            </div>
        </div>
    </div>
</asp:Content>
