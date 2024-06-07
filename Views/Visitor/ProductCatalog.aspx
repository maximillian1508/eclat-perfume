<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Visitor.Master" AutoEventWireup="true" CodeBehind="ProductCatalog.aspx.cs" Inherits="DECXML_Maximillian_Leonard.Views.Visitor.ProductCatalog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display: flex; flex-direction: column; margin: 20px 0 75px; align-items: center;">
        <asp:Label runat="server" ID="errMsg" Style="width: 100%; display: block; padding: 10px 10px; background-color: #ffeaef; color: #ef144a; font-weight: 500; border-radius: 10px" Visible="false"></asp:Label>
        <h1 style="margin: 0; font-size: 2rem; font-weight: 700; font-family: 'Manrope'">Catalog</h1>
        <h2 class="fs-4" style="margin: 0 0 20px; color: grey;" id="catalog_type" runat="server"></h2>
        <div class="container mx-auto">
            <div class="row row-cols-auto gap-3 mx-auto">
                <asp:Xml ID="product_xml" runat="server"></asp:Xml>
            </div>
        </div>
    </div>
</asp:Content>
