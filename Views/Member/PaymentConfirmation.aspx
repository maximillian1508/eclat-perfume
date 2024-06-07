<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Member.Master" AutoEventWireup="true" CodeBehind="PaymentConfirmation.aspx.cs" Inherits="DECXML_Maximillian_Leonard.Views.Member.PaymentConfirmation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        div.status-container {
            width: 45%;
            height: fit-content;
            margin: 50px auto 100px;
            border: 1px solid black;
            border-radius: 10px;
            background-color: white;
        }

        .status-container > div {
            display: flex;
            flex-direction: column;
            align-items: center;
            width: 90%;
            margin: 30px auto;
        }

        .status-container i {
            font-size: 100px;
        }

        .status-container h1 {
            text-align: center;
            margin-top: 10px;
        }

        .status-container p {
            font-size: 24px;
            text-align: center;
            color: grey;
            font-weight: 400;
        }
    </style>
    <asp:Label runat="server" ID="errMsg" Style="width: 100%; display: block; padding: 10px 10px; background-color: #ffeaef; color: #ef144a; font-weight: 500; border-radius: 10px" Visible="false"></asp:Label>
    <div runat="server" class="container-shadow status-container" id="order_success" visible="false">
        <div>
            <i style="color: green" class="fa-solid fa-circle-check"></i>
            <h1>Thank you for ordering!</h1>
            <p>Your order #<span id="success_order_id" runat="server"></span> is confirmed. We will send you the order as soon as possible.</p>
            <div style="display: flex; flex-direction: row; justify-content: center; gap: 10px;">
                <a class="white-button" href="profile#order-tab-pane" style="padding: 10px 20px; border-radius: 10px;">View Order <i style="font-size: inherit" class="fa-solid fa-file-invoice"></i>
                </a>
                <a class="black-button" href="product-catalog" style="padding: 10px 20px; border-radius: 10px;">Continue Shopping <i style="font-size: inherit; color: white" class="fa-solid fa-cart-shopping"></i>
                </a>
            </div>
        </div>
    </div>
    <div runat="server" class="status-container" id="order_fail" visible="false">
        <div>
            <i style="color: red" class="fa-solid fa-circle-check"></i>
            <h1 style="color: red">Order failed!</h1>
            <p>Your payment for order #<span runat="server" id="fail_order_id"></span> failed. Please retry the order.</p>
            <div style="display: flex; flex-direction: row; justify-content: center; gap: 10px;">
                <a class="black-button" href="product-catalog" style="padding: 10px 20px; border-radius: 10px;">Product Catalog <i style="font-size: inherit" class="fa-solid fa-cart-shopping"></i>
                </a>
            </div>
        </div>
    </div>
</asp:Content>
