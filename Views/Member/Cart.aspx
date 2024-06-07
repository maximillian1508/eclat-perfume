<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Member.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="DECXML_Maximillian_Leonard.Views.Member.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        #change-address {
            text-decoration: underline;
            color: black;
            width: fit-content;
        }

            #change-address:hover {
                color: grey;
            }
    </style>
    <div style="width: 90%; margin: 20px auto 50px">
        <h1 class="fs-1" style="margin: 0 0 15px;">Cart</h1>
        <asp:Label runat="server" ID="errMsg" Style="width: 100%; display: block; padding: 10px 10px; background-color: #ffeaef; color: #ef144a; font-weight: 500; border-radius: 10px" Visible="false"></asp:Label>
        <div style="display: flex; flex-direction: row; justify-content: space-between;">
            <div style="width: 55%; display: flex; flex-direction: column; gap: 10px">
                <asp:Repeater ID="cartRepeater" runat="server">
                    <ItemTemplate>
                        <div style="display: flex; flex-direction: row; height: 150px">
                            <img src="../../<%#Eval("product_image") %>" style="height: 100%; aspect-ratio: 1/1; object-fit: cover" />
                            <div style="display: flex; flex-direction: column; gap: 3px; margin-left: 20px;">
                                <span style="font-size: 24px; font-weight: 500"><%# Eval("product_name") %></span>
                                <span>Quantity:
                                    <asp:TextBox runat="server" type="number" AutoPostBack="true" OnTextChanged="stock_TextChanged" cart_id='<%#Eval("cart_id")%>' Style="width: 75px;" class="form-control" min="1" Text='<%# Eval("cart_quantity")%>' /></span>
                                <asp:Button runat="server" OnClick="removeItem_Click" cart_id='<%#Eval("cart_id")%>' class="white-button" Style="margin-top: 5px; width: fit-content; border: none; background-color: transparent; text-decoration: underline" Text="Remove..." />
                            </div>
                            <span style="margin-left: auto; margin-top: 5px; font-size: 20px">RM <%#Eval("product_price") %></span>
                        </div>
                        <hr style='border: 1px solid grey; width: 85%; margin: 5px auto;' />
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div style="width: 40%; height: fit-content; border: 1px solid black; border-radius: 10px; background-color: #e3e3e3">
                <div style="display: flex; flex-direction: column; margin: 15px">
                    <h2 class="fs-3" style="margin-bottom: 0">Order Summary</h2>
                    <hr style="border: 1px solid black; width: 100%;" />
                    <span style="font-size: 24px; font-weight: 500">Address</span>
                    <asp:Label ID="cust_address" runat="server"></asp:Label>
                    <a href="profile" id="change-address">Change Address...</a>
                    <hr style="border: 1px solid black; width: 100%;" />
                    <div style="display: flex; flex-direction: row; justify-content: space-between; margin-bottom: 15px">
                        <span style="font-size: 24px; font-weight: 500">Subtotal: 
                        </span>
                        <div style="font-size: 24px; font-weight: 500">
                            <span>RM</span>
                            <asp:Label ID="subtotal" runat="server">0</asp:Label>
                        </div>
                    </div>
                    <asp:Button class="black-button" ID="checkout" type="button" runat="server" Text="Checkout" OnClick="checkout_Click" Style="align-self: center; border: none; width: 40%; border-radius: 10px; font-size: 16px; padding: 10px 25px; text-align: center" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
