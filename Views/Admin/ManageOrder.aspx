<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="ManageOrder.aspx.cs" Inherits="DECXML_Maximillian_Leonard.Views.Admin.ManageOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 95%; margin: 5px auto">
        <h1 class="fs-2">Manage Order</h1>
        <p class="fs-6" style="color: grey; font-weight: 500;">Manage the orders here</p>
        <ul class="nav nav-tabs" id="myTab" role="tablist">
            <li class="nav-item" role="presentation">
                <button class="nav-link active" id="process-tab" data-bs-toggle="tab" data-bs-target="#process-tab-pane" type="button" role="tab" aria-controls="process-tab-pane" aria-selected="true">Waiting for delivery</button>
            </li>
            <li class="nav-item" role="presentation" runat="server">
                <button class="nav-link" id="delivered-tab" data-bs-toggle="tab" data-bs-target="#delivered-tab-pane" type="button" role="tab" aria-controls="delivered-tab-pane" aria-selected="false">Delivered</button>
            </li>
            <li class="nav-item" role="presentation" runat="server">
                <button class="nav-link" id="failed-tab" data-bs-toggle="tab" data-bs-target="#failed-tab-pane" type="button" role="tab" aria-controls="failed-tab-pane" aria-selected="false">Failed</button>
            </li>
        </ul>
        <div class="tab-content" id="myTabContent">
            <div class="tab-pane fade show active" id="process-tab-pane" role="tabpanel" aria-labelledby="process-tab" tabindex="0">
                <div class="row row-cols-auto gap-2" style="width: 80%; margin: 20px auto 50px;">
                    <asp:PlaceHolder runat="server" ID="process_placeholder"></asp:PlaceHolder>
                </div>
            </div>
            <div class="tab-pane fade show" id="delivered-tab-pane" role="tabpanel" aria-labelledby="delivered-tab">
                <div class="row row-cols-auto gap-2" style="width: 80%; margin: 20px auto 50px;">
                    <asp:PlaceHolder runat="server" ID="delivered_placeholder"></asp:PlaceHolder>
                </div>
            </div>
            <div class="tab-pane fade" id="failed-tab-pane" role="tabpanel" aria-labelledby="failed-tab" tabindex="0">
               <div class="row row-cols-auto gap-2" style="width: 80%; margin: 20px auto 50px;">
                    <asp:PlaceHolder runat="server" ID="failed_placeholder"></asp:PlaceHolder>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
