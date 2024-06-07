<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="ManageAds.aspx.cs" Inherits="DECXML_Maximillian_Leonard.Views.Admin.ManageAds" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 95%; margin: 5px auto">
        <h1 class="fs-2">Manage Ads</h1>
        <p class="fs-6" style="color: grey; font-weight: 500;">Manage the advertisements here</p>
        <div style="display: flex; flex-direction: column;">
            <a href="add-ads" class="black-button" style="border: none; border-radius: 10px; padding: 7.5px; width: fit-content; align-self: end;">Add Ads</a>

            <div class="table-responsive overflow-y-auto" style="height: 325px; background-color: white; margin-top: 15px;">
                <table class="table table-bordered">
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Image Url</th>
                            <th>Navigate Url</th>
                            <th>Alternate Text</th>
                            <th>Keyword</th>
                            <th>Impressions</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Xml ID="ads_xml" runat="server"></asp:Xml>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
