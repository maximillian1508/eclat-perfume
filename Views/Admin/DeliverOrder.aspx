<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="DeliverOrder.aspx.cs" Inherits="DECXML_Maximillian_Leonard.Views.Admin.DeliverOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display: flex; align-items: center; flex-direction: column; width: 60%; margin: 5px auto;">
        <h1 class="fs-2">Deliver Order</h1>
        <div class="container-shadow" style="width: 100%; height: fit-content; border: 1px solid black; border-radius: 10px; margin: 10px 0 35px; background-color: white;">
            <div class="row" style="width: 95%; margin: 25px auto;">
                <div class="col-12" style="width: 100%; display: flex; flex-direction: row; margin-bottom: 20px; justify-content: space-between">
                    <asp:Label runat="server" ID="order_id" Style="font-size: 26px; font-weight: 500; width: fit-content"></asp:Label>
                    <asp:LinkButton Style="color: black; font-size: 25px; display: inline; width: fit-content;" runat="server" ID="exit_delivery_order" href="manage-order"><i class="fa-solid fa-xmark"></i></asp:LinkButton>
                </div>
                <div class="col-12" style="width: 100%; display: grid; justify-items: center; margin-bottom: 20px">
                    <asp:Label runat="server" ID="errMsg" Style="width: 100%; display: block; padding: 10px 10px; background-color: #ffeaef; color: #ef144a; font-weight: 500; border-radius: 10px;" Visible="false"></asp:Label>
                </div>
                <div class="col-12 mb-4">
                    <label class="form-label" style="display: block; font-weight: 500;">Ordered Item</label>
                    <asp:Label runat="server" ID="order_item"></asp:Label>
                </div>
                <div class="col-md-6 mb-4">
                    <label class="form-label" style="display: block; font-weight: 500;">Customer Email</label>
                    <asp:Label runat="server" ID="cust_email"></asp:Label>
                </div>
                <div class="col-md-6 mb-4">
                    <label class="form-label" style="display: block; font-weight: 500;">Customer Phone</label>
                    <asp:Label runat="server" ID="cust_phone"></asp:Label>
                </div>
                <div class="col-12 mb-4">
                    <label class="form-label" style="display: block; font-weight: 500;">Customer Address</label>
                    <asp:Label runat="server" ID="cust_address"></asp:Label>
                </div>
                <div class="col-md-6 mb-4">
                    <label class="form-label" style="display: block; font-weight: 500;">Total Price</label>
                    <asp:Label runat="server" ID="order_amount"></asp:Label>
                </div>
                <div class="col-md-6 mb-4">
                    <label class="form-label" style="display: block; font-weight: 500;">Status</label>
                    <span>Waiting for delivery</span>
                </div>

                <asp:Button class="black-button fs-5 py-1 mb-3" Style="align-self: center; width: 100%; border-radius: 10px; border: none;" Text="Deliver Order" runat="server" type="submit" ID="deliverOrder" OnClick="deliverOrder_Click" />
            </div>
        </div>
    </div>

</asp:Content>
