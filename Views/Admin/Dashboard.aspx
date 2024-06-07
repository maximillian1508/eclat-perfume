<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="DECXML_Maximillian_Leonard.Views.Admin.Dashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 95%; margin: 5px auto; display: flex; flex-direction: column;">
        <asp:Label runat="server" ID="errMsg" Style="width: 100%; display: block; padding: 10px 10px; background-color: #ffeaef; color: #ef144a; font-weight: 500; border-radius: 10px; align-self:center" Visible="false"></asp:Label>
        <div style="display: flex; flex-direction: row; justify-content: space-around; margin-bottom: 30px">
            <div class="container-shadow" style="background-color: white; width: 125px; height: 125px; border: 1px solid black; border-radius: 10px; display: flex; text-align: center; flex-direction: column;">
                <h2 style="font-size: 20px; margin: 0;">Total Product</h2>
                <h3 style="margin: auto 0; font-size: 40px; font-weight: 600" id="total_product" runat="server">50</h3>
            </div>
            <div class="container-shadow" style="background-color: white; width: 125px; height: 125px; border: 1px solid black; border-radius: 10px; display: flex; text-align: center; flex-direction: column;">
                <h2 style="font-size: 20px; margin: 0; padding: 0 10px">Total Order</h2>
                <h3 style="margin: auto 0; font-size: 40px; font-weight: 600" id="total_order" runat="server">50
                </h3>
            </div>
            <div class="container-shadow" style="background-color: white; width: 125px; height: 125px; border: 1px solid black; border-radius: 10px; display: flex; text-align: center; flex-direction: column;">
                <h2 style="font-size: 20px; margin: 0;">Undelivered Order</h2>
                <h3 style="margin: auto 0; font-size: 40px; font-weight: 600" id="total_paid_order" runat="server">50</h3>
            </div>
            <div class="container-shadow" style="background-color: white; width: 125px; height: 125px; border: 1px solid black; border-radius: 10px; display: flex; text-align: center; flex-direction: column;">
                <h2 style="font-size: 20px; margin: 0;">Delivered Order</h2>
                <h3 style="margin: auto 0; font-size: 40px; font-weight: 600" id="total_delivered_order" runat="server">50</h3>
            </div>
            <div class="container-shadow" style="background-color: white; width: 125px; height: 125px; border: 1px solid black; border-radius: 10px; display: flex; text-align: center; flex-direction: column;">
                <h2 style="font-size: 20px; margin: 0;">Total Customer</h2>
                <h3 style="margin: auto 0; font-size: 40px; font-weight: 600" id="total_customer" runat="server">50</h3>
            </div>

        </div>
        <div style="display: flex; flex-direction: row; height: 55vh; justify-content: space-around;">
            <div class="container-shadow" style="background-color: white; width: 45%; height: 100%; border: 1px solid black; border-radius: 10px; display: flex; flex-direction: column; align-items: center">
                <h2 style="font-size: 25px; font-weight: 600; margin: 10px 0 0">Sales Per Product</h2>
                <asp:Chart ID="Chart1" runat="server" Style="width: 100%; height: 85%; border-radius: 10px">
                    <Series>
                        <asp:Series Name="Series1">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </div>
            <div class="container-shadow" style="background-color: white; width: 45%; height: 100%; border: 1px solid black; border-radius: 10px; display: flex; flex-direction: column; align-items: center">
                <h2 style="font-size: 25px; font-weight: 600; margin: 10px 0 0">Most Recent Order</h2>
                <hr style="width: 75%; margin: 10px 10px 0" />
                <table class='table' style="width: 90%; height: 100%; vertical-align: middle">
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>Cust</th>
                            <th>Amount</th>
                            <th>Status</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:PlaceHolder ID="order_Placeholder" runat="server"></asp:PlaceHolder>
                    </tbody>
                </table>
            </div>
        </div>
    </div>

</asp:Content>
