﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="ManageProduct.aspx.cs" Inherits="DECXML_Maximillian_Leonard.Views.Admin.ManageProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Content/ManageProduct.css" rel="stylesheet" />
    <div style="width: 95%; margin: 5px auto">
        <h1 class="fs-2">Manage Product</h1>
        <p class="fs-6" style="color: grey; font-weight: 500; margin: 0;">Manage the products here</p>
        <div style="display: flex; flex-direction: column;">
            <a href="add-product" class="black-button" style="border: none; border-radius: 10px; padding: 7.5px; width: fit-content; align-self: end;">Add Product</a>

            <div class="table-responsive overflow-y-auto" style="height: 325px; background-color: white; margin-top: 15px;">
               <table class="table table-bordered">
                   <thead>
                       <tr>
                           <th>Id</th>
                           <th>Name</th>
                           <th>Type</th>
                           <th>Gender</th>
                           <th>Note</th>
                           <th>Price</th>
                           <th>Stock</th>
                       </tr>
                   </thead>
                   <tbody>
                           <asp:Xml ID="product_xml" runat="server"></asp:Xml>
                   </tbody>
               </table>
            </div>
        </div>
    </div>
</asp:Content>
