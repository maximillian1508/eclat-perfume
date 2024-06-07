<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="DECXML_Maximillian_Leonard.Views.Admin.EditUser" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display: flex; align-items: center; flex-direction: column; width: 70%; margin: 5px auto;">
        <h1 class="fs-2">Edit user</h1>
        <div class="container-shadow" style="width: 100%; height: fit-content; border: 1px solid black; border-radius: 10px; margin: 10px 0 35px; background-color: white;">
            <div class="row" style="width: 95%; margin: 25px auto;">
                <div class="col-12" style="width: 100%; display: grid; margin-bottom: 20px">
                    <asp:LinkButton Style="color: black; justify-self: end; font-size: 25px; display: inline; width: fit-content;" runat="server" ID="exit_add_user" href="manage-user"><i class="fa-solid fa-xmark"></i></asp:LinkButton>
                </div>
                <div class="col-12" style="width: 100%; display: grid; justify-items:center; margin-bottom: 20px">
                    <asp:Label runat="server" ID="errMsg" Style="width: 100%; display: block; padding: 10px 10px; background-color: #ffeaef; color: #ef144a; font-weight: 500; border-radius: 10px;" Visible="false"></asp:Label>
                </div>
                <div class="col-md-6 mb-4">
                    <label for="first_name" class="form-label">First Name</label>
                    <asp:TextBox runat="server" class="form-control" ID="first_name" />
                </div>
                <div class="col-md-6 mb-4">
                    <label for="last_name" class="form-label">Last Name</label>
                    <asp:TextBox runat="server" class="form-control" ID="last_name" />
                </div>
                <div class="col-12 mb-4">
                    <label for="phone" class="form-label">Phone</label>
                    <asp:TextBox runat="server" TextMode="Phone" class="form-control" ID="phone" Style="display: block" />
                </div>
                <div class="col-md-6 mb-4">
                    <label for="email" class="form-label">Email</label>
                    <asp:TextBox runat="server" TextMode="Email" class="form-control" ID="email" />
                </div>
                <div class="col-md-6 mb-4">
                    <label for="password" class="form-label">Password</label>
                    <asp:TextBox runat="server" TextMode="Password" class="form-control" ID="password" />
                </div>
                <div class="col-8 mb-4">
                    <label for="address" class="form-label">Address</label>
                    <asp:TextBox runat="server" class="form-control" ID="address" />
                </div>
                <div class="col-md-4 mb-4">
                    <label class="form-label" style="color: red; display: block; width: fit-content; margin: 0 auto;">Delete User<i class="fa-solid fa-trash-can"></i></label>
                    <asp:Button runat="server" class="red-button" Style="border-radius: 10px; padding: 5px 15px; width: fit-content; margin: 7.5px auto 0; display: block;" ID="delUser" OnClick="deleteUser_Click" Text="Delete!" />
                </div>
                <asp:Button class="black-button fs-5 py-1 mb-3" Style="align-self: center; width: 100%; border-radius: 10px; border: none;" Text="Save Edit" runat="server" type="submit" ID="editUser" OnClick="editUser_Click" />
            </div>
        </div>
    </div>

</asp:Content>
