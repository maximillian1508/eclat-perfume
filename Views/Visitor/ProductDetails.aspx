<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Visitor.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="DECXML_Maximillian_Leonard.Views.Visitor.ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display: flex; flex-direction: row; width: 90%; margin: 40px auto 60px;">
        <div style="width: 40%">
            <asp:Image runat="server" ID="product_image" Style="aspect-ratio: 1/1; object-fit: cover; width: 100%;" />
        </div>
        <div style="width: 30%; display: flex; flex-direction: column; margin: 50px 0 0 30px; font-size: 30px; color: grey;">
            <asp:Label Style="font-size: 60px; color: black; line-height: normal; margin-bottom: 20px" runat="server" ID="name"></asp:Label>
            <asp:Label runat="server" ID="type"></asp:Label>
            <asp:Label runat="server" ID="gender"></asp:Label>
            <asp:Label runat="server" ID="note"></asp:Label>
            <span style="font-size: 20px; margin-top: 15px;">Additional Information:</span>
            <asp:Label Style="font-size: 20px" runat="server" ID="desc"></asp:Label>
        </div>
        <div style="width: 30%; display: flex; flex-direction: column; align-items: center; margin: 50px 0 0;">
            <asp:Label runat="server" ID="errMsg" Style="width: 100%; display: block; padding: 10px 10px; background-color: #ffeaef; color: #ef144a; font-weight: 500; border-radius: 10px" Visible="false"></asp:Label>
            <asp:Label Style="font-size: 50px" runat="server" ID="price"></asp:Label>
            <asp:Label Style="font-size: 30px; color: grey; margin-bottom: 40px" ID="stock" runat="server"></asp:Label>
            <span style="font-size: 30px">Quantity: </span>
            <asp:TextBox Style="width: 60px;" TextMode="Number" runat="server" ID="quantity" min="1">1</asp:TextBox>
            <asp:Button class="black-button fs-4 py-1" Style="margin: 25px 0 0; align-self: center; width: fit-content; height: 50px; border-radius: 10px; border: none; padding: 50px" Text="Add to cart" runat="server" type="button" ID="addToCart" OnClick="addToCart_Click" />
        </div>
    </div>
</asp:Content>
