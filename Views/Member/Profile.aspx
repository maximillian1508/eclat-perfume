<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Member.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="DECXML_Maximillian_Leonard.Views.Member.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../Content/ProfileTab.css" rel="stylesheet" />
    <div style="width: 95%; margin: 5px auto;">
        <h1 class="fs-1" style="margin: 0">Account</h1>
        <p class="fs-6" style="color: grey; font-weight: 500;">Manage your account here</p>
        <ul class="nav nav-tabs" id="myTab" role="tablist">
            <li class="nav-item" role="presentation">
                <button class="nav-link active" id="profile-tab" data-bs-toggle="tab" data-bs-target="#profile-tab-pane" type="button" role="tab" aria-controls="profile-tab-pane" aria-selected="true">Profile</button>
            </li>
            <li class="nav-item" role="presentation" runat="server" id="order_nav_list">
                <button class="nav-link" id="order-tab" data-bs-toggle="tab" data-bs-target="#order-tab-pane" type="button" role="tab" aria-controls="order-tab-pane" aria-selected="false">Order</button>
            </li>
        </ul>
        <div class="tab-content" id="myTabContent">
            <div class="tab-pane fade show active" id="profile-tab-pane" role="tabpanel" aria-labelledby="profile-tab" tabindex="0">
                <div class="row" style="width: 70%; margin: 40px auto 40px;">
                    <div class="col-12 mb-2">
                        <asp:Label runat="server" ID="errMsg" Style="width: 100%; display: block; padding: 10px 10px; background-color: #ffeaef; color: #ef144a; font-weight: 500; border-radius: 10px" Visible="false"></asp:Label>
                    </div>
                    <div class="col-md-6 mb-4">
                        <div class="profile-desc">
                            <label for="first_name" class="form-label">First Name</label>
                            <asp:Button runat="server" type="button" ID="fn_edit" OnClick="fn_edit_Click" Text="edit..." />
                        </div>
                        <asp:Label runat="server" ID="firstName" class="profile-data"></asp:Label>
                        <asp:TextBox runat="server" class="form-control" ID="first_name_input" Visible="false" />
                    </div>
                    <div class="col-md-6 mb-4">
                        <div class="profile-desc">
                            <label for="last_name" class="form-label">Last Name</label>
                            <asp:Button runat="server" type="button" ID="ln_edit" OnClick="ln_edit_Click" Text="edit..." />
                        </div>
                        <asp:Label runat="server" ID="lastName" class="profile-data"></asp:Label>
                        <asp:TextBox runat="server" class="form-control" ID="last_name_input" Visible="false" />
                    </div>
                    <div class="col-12 mb-4">
                        <div class="profile-desc">
                            <label for="address" class="form-label">Address</label>
                            <asp:Button runat="server" type="button" ID="address_edit" OnClick="address_edit_Click" Text="edit..." />
                            <span id="no_address" runat="server" visible="false" style="font-weight: 500; color: red; padding: 5px; background-color: #ffa7a7; border-radius: 5px; border: solid 1px red; margin-left: 3px;">Please add an address!</span>
                        </div>
                        <asp:Label runat="server" ID="address" class="profile-data" Style="max-height: fit-content; height: 30px; display: block;"></asp:Label>
                        <asp:TextBox runat="server" class="form-control" ID="address_input" Visible="false" />
                    </div>
                    <div class="col-md-6 mb-4">
                        <div class="profile-desc">
                            <label for="email" class="form-label">Email</label>
                            <asp:Button runat="server" type="button" ID="email_edit" OnClick="email_edit_Click" Text="edit..." />
                        </div>
                        <asp:Label runat="server" ID="email" class="profile-data"></asp:Label>
                        <asp:TextBox runat="server" TextMode="Email" class="form-control" ID="email_input" Visible="false" />
                    </div>
                    <div class="col-md-6 mb-4">
                        <div class="profile-desc">
                            <label for="phone" class="form-label">Phone Number</label>
                            <asp:Button runat="server" type="button" ID="phone_edit" OnClick="phone_edit_Click" Text="edit..." />
                        </div>
                        <asp:Label runat="server" ID="phone" class="profile-data"></asp:Label>
                        <asp:TextBox runat="server" TextMode="Phone" class="form-control" ID="phone_input" Visible="false" />
                    </div>
                    <div class="col-12 mb-4">
                        <asp:Button runat="server" ID="password" class="white-button" Style="padding: 3px; border: solid 1px grey; margin-bottom: 5px; border-radius: 7.5px;" Text="Change Password" OnClick="password_Click" />
                        <asp:TextBox runat="server" TextMode="Password" class="form-control" ID="password_input" Style="width: 30%;" Visible="false" />
                    </div>
                    <asp:Button class="black-button fs-5 py-1" Style="margin: 0 auto; align-self: center; width: 25%; border-radius: 10px; border: none;" Text="Save Changes" runat="server" type="button" ID="editProfile" OnClick="editProfile_Click" />
                </div>
            </div>
            <div class="tab-pane fade" id="order-tab-pane" role="tabpanel" aria-labelledby="order-tab" tabindex="0">
                <div class="row row-cols-auto gap-2" style="width: 80%; margin: 20px auto 50px;">
                    <asp:PlaceHolder runat="server" ID="order_placeholder"></asp:PlaceHolder>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
