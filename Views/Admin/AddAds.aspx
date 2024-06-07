<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="AddAds.aspx.cs" Inherits="DECXML_Maximillian_Leonard.Views.Admin.AddAds" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display: flex; align-items: center; flex-direction: column; width: 70%; margin: 5px auto;">
        <h1 class="fs-2">Add advertisement</h1>
        <div class="container-shadow" style="width: 100%; height: fit-content; border: 1px solid black; border-radius: 10px; margin: 10px 0 35px; background-color: white;">
            <div class="row" style="width: 95%; margin: 25px auto;">
                <div class="col-12" style="width: 100%; display: flex; align-items: end; flex-direction: column;">
                    <asp:LinkButton Style="color: black; font-size: 25px; display: inline; width: fit-content;" runat="server" ID="exit_add_ads" href="manage-ads"><i class="fa-solid fa-xmark"></i></asp:LinkButton>
                </div>
                <div class="col-12" style="width: 100%; display: grid; justify-items: center; margin-bottom: 20px">
                    <asp:Label runat="server" ID="errMsg" Style="width: 100%; display: block; padding: 10px 10px; background-color: #ffeaef; color: #ef144a; font-weight: 500; border-radius: 10px;" Visible="false"></asp:Label>
                </div>
                <div class="col-12 mb-4">
                    <label for="ads_img" class="form-label">Ads Image</label>
                    <asp:FileUpload runat="server" class="form-control" ID="ads_img" accept="image/*" />
                </div>
                <div class="col-md-6 mb-4">
                    <label for="nav_url" class="form-label">Navigate Url</label>
                    <asp:TextBox runat="server" class="form-control" TextMode="Url" ID="nav_url" />
                </div>
                <div class="col-md-6 mb-4">
                    <label for="alt_text" class="form-label">Alternate Text</label>
                    <asp:TextBox runat="server" class="form-control" ID="alt_text" />
                </div>
                <div class="col-md-6 mb-4">
                    <label for="keyword" class="form-label">Keyword</label>
                    <asp:TextBox runat="server" class="form-control" ID="keyword" />
                </div>
                <div class="col-md-6 mb-4">
                    <label for="impressions" class="form-label">Impressions</label>
                    <asp:TextBox runat="server" TextMode="Number" min="1" class="form-control" ID="impressions" />
                </div>
                <asp:Button class="black-button fs-5 py-1 mb-3" Style="align-self: center; width: 100%; border-radius: 10px; border: none;" Text="Add Ads" runat="server" type="submit" ID="addAds" OnClick="addAds_Click" />
            </div>
        </div>
    </div>

</asp:Content>


