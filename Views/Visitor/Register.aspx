<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Visitor.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="DECXML_Maximillian_Leonard.Views.Visitor.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display: flex; flex-direction: column; width: 100%;">
        <div style="width: 55%; height: fit-content; border: 1px solid grey; margin: 2.5rem auto 2.5rem; border-radius: 10px; display: flex; flex-direction: column; align-items: center">
            <img src="../../Image/WebContent/LogoOnlyNoBg.png" style="width: 40px; margin-top: 1.25rem; height: 40px;" alt="Eclat Logo" />
            <h1 class="fs-2 mt-1 mb-0" style="color: black; font-family: 'Montserrat'; font-weight: 600">Register<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [user]"></asp:SqlDataSource>
            </h1>
            <h3 class="fs-6 mb-3" style="color: #a1a1a1; font-family: 'Montserrat'; font-weight: 500">Create an account and start shopping</h3>
            <div class="row" style="width: 90%;">
                <div class="col-12 mb-2">
                    <asp:Label runat="server" ID="errMsg" Style="width: 100%; display: block; padding: 10px 10px; background-color: #ffeaef; color: #ef144a; font-weight: 500; border-radius: 10px" Visible="false"></asp:Label>
                </div>
                <div class="col-md-6 mb-4">
                    <label for="first_name" class="form-label">First Name</label>
                    <asp:TextBox runat="server" class="form-control" placeholder="John" ID="first_name" />
                </div>
                <div class="col-md-6 mb-4">
                    <label for="last_name" class="form-label">Last Name</label>
                    <asp:TextBox runat="server" class="form-control" placeholder="Doe" ID="last_name" />
                </div>
                <div class="col-12 mb-4">
                    <label for="phone" class="form-label">Phone Number</label>
                    <asp:TextBox runat="server" TextMode="Phone" class="form-control" placeholder="0123123123" ID="phone" />
                </div>
                <div class="col-md-6 mb-4">
                    <label for="email" class="form-label">Email</label>
                    <asp:TextBox runat="server" TextMode="Email" class="form-control" placeholder="johndoe@gmail.com" ID="email" />
                </div>
                <div class="col-md-6 mb-4">
                    <label for="password" class="form-label">Password</label>
                    <asp:TextBox runat="server" TextMode="Password" class="form-control" placeholder="●●●●●●" ID="password" />
                </div>
                <asp:Button class="black-button fs-5 py-1 mb-3" Style="align-self: center; width: 100%; border-radius: 10px; border: none;" Text="Register" runat="server" type="submit" ID="registerSubmit" OnClick="registerSubmit_Click" />
                <p class="mb-4" style="color: #a1a1a1; text-align: center;">Already have an account? <a href="login" style="text-decoration: none;">Login now</a></p>
            </div>
        </div>
    </div>
</asp:Content>
