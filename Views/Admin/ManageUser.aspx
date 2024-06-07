<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="ManageUser.aspx.cs" Inherits="DECXML_Maximillian_Leonard.Views.Admin.ManageUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <link href="../Content/ManageProduct.css" rel="stylesheet" />
    <div style="width: 95%; margin: 5px auto">
        <h1 class="fs-2">Manage User</h1>
        <p class="fs-6" style="color: grey; font-weight: 500; margin: 0;">Manage the users here</p>
        <div style="display: flex; flex-direction: column;">
            <a href="add-admin" class="black-button" style="border: none; border-radius: 10px; padding: 7.5px; width: fit-content; align-self: end;">Add Admin</a>

            <div class="table-responsive overflow-y-auto" style="height: 325px; background-color: white; margin-top: 15px;">
               <table class="table table-bordered">
                   <thead>
                       <tr>
                           <th>Id</th>
                           <th>Name</th>
                           <th>Phone</th>
                           <th>Email</th>
                           <th>User Type</th>
                       </tr>
                   </thead>
                   <tbody>
                           <asp:Xml ID="user_xml" runat="server"></asp:Xml>
                   </tbody>
               </table>
            </div>
        </div>
    </div>
</asp:Content>
