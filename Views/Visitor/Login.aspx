<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Visitor.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DECXML_Maximillian_Leonard.Views.Visitor.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="display: flex; flex-direction: column; width: 100%; height: 100vh">
        <div style="width: 40%; height: fit-content; border: 1px solid grey; margin: 2.5rem auto 0; border-radius: 10px; display: flex; flex-direction: column; align-items: center">
            <img src="../../Image/WebContent/LogoOnlyNoBg.png" style="width: 40px; margin-top: 1.25rem; height: 40px;" alt="Eclat Logo" />
            <h1 class="fs-2 mt-1 mb-0" style="color: black; font-family: 'Montserrat'; font-weight: 600">Welcome</h1>
            <h3 class="fs-6 mb-3" style="color:#a1a1a1; font-family: 'Montserrat'; font-weight: 500 ">Please log in to your account</h3>
            <div style="width: 85%; display: flex; flex-direction: column">
                <div class="mb-2">
                    <asp:Label runat="server" ID="errMsg" style="width:100%;display:block; padding: 10px 10px; background-color: #ffeaef; color: #ef144a; font-weight: 500; border-radius:10px" Visible="false"></asp:Label>
                </div>
                <div class="mb-4">
                    <label for="email" class="form-label">Email</label>
                    <asp:TextBox TextMode="Email" runat="server" class="form-control" placeholder="johndoe@gmail.com" ID="email" OnTextChanged="email_TextChanged" />
                </div>
                <div class="mb-4">
                    <label for="password" class="form-label">Password</label>
                    <asp:TextBox runat="server" TextMode="Password" class="form-control" placeholder="●●●●●●●" ID="password" />
                </div>
                <asp:Button class="black-button fs-5 py-1" style="align-self: center; width:100%; border-radius: 10px; border: none;" Text="Login" runat="server" ID="login_submit" type="submit" OnClick="login_submit_Click"/>
                <p class="mt-3 mb-4" style="color: #a1a1a1; align-self: center">Don't have an account? <a href="register" style="text-decoration: none;">Register now</a></p>
            </div>
        </div>
    </div>
</asp:Content>
