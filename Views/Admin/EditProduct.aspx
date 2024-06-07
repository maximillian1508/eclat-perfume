<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="DECXML_Maximillian_Leonard.Views.Admin.EditProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display: flex; align-items: center; flex-direction: column; width: 70%; margin: 5px auto;">
        <h1 class="fs-2">Edit product</h1>
        <div class="container-shadow" style="width: 100%; height: fit-content; border: 1px solid black; border-radius: 10px; margin: 10px 0 35px; background-color: white;">
            <div class="row" style="width: 95%; margin: 25px auto;">
                <div class="col-12" style="width: 100%; display: grid; margin-bottom: 20px">
                    <asp:LinkButton Style="color: black; justify-self: end; font-size: 25px; display: inline; width: fit-content;" runat="server" ID="exit_add_product" href="manage-product"><i class="fa-solid fa-xmark"></i></asp:LinkButton>
                    <asp:Image ID="product_image" runat="server" Style="width: 200px; height: 200px; aspect-ratio: 1/1; object-fit: cover; justify-self: center" alt="Product Image" />
                </div>
                <div class="col-12" style="width: 100%; display: grid; justify-items: center; margin-bottom: 20px">
                    <asp:Label runat="server" ID="errMsg" Style="width: 100%; display: block; padding: 10px 10px; background-color: #ffeaef; color: #ef144a; font-weight: 500; border-radius: 10px;" Visible="false"></asp:Label>
                </div>
                <div class="col-md-6 mb-4">
                    <label for="name" class="form-label">Name</label>
                    <asp:TextBox runat="server" class="form-control" ID="name" />
                </div>
                <div class="col-md-6 mb-4">
                    <label for="type" class="form-label">Type</label>
                    <asp:DropDownList runat="server" ID="type" class="form-select">
                        <asp:ListItem Selected="true" runat="server" disabled="true" id="type_placeholder"></asp:ListItem>
                        <asp:ListItem Value="edt">Eau de toilette</asp:ListItem>
                        <asp:ListItem Value="edp">Eau de parfum</asp:ListItem>
                        <asp:ListItem Value="parfum">Parfum</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-6 mb-4">
                    <label for="gender" class="form-label">Gender</label>
                    <asp:DropDownList runat="server" ID="gender" class="form-select">
                        <asp:ListItem Selected="true" runat="server" disabled="true" id="gender_placeholder"></asp:ListItem>
                        <asp:ListItem Value="male">Male</asp:ListItem>
                        <asp:ListItem Value="female">Female</asp:ListItem>
                        <asp:ListItem Value="unisex">Unisex</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-6 mb-4">
                    <label for="note" class="form-label">Note</label>
                    <asp:DropDownList runat="server" ID="note" class="form-select">
                        <asp:ListItem Selected="true" runat="server" disabled="true" id="note_placeholder"></asp:ListItem>
                        <asp:ListItem Value="fresh">Fresh</asp:ListItem>
                        <asp:ListItem Value="sweet">Sweet</asp:ListItem>
                        <asp:ListItem Value="woody">Woody</asp:ListItem>
                        <asp:ListItem Value="leather">Leather</asp:ListItem>
                        <asp:ListItem Value="spices">Spices</asp:ListItem>
                        <asp:ListItem Value="musk">Musk</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-6 mb-4">
                    <label for="price" class="form-label">Price</label>
                    <asp:TextBox runat="server" TextMode="Number" class="form-control" ID="price" min="1" />
                </div>
                <div class="col-md-6 mb-4">
                    <label for="stock" class="form-label">Stock Qty</label>
                    <asp:TextBox runat="server" TextMode="Number" class="form-control" ID="stock" min="1" />
                </div>
                <div class="col-12 mb-4">
                    <label for="desc" class="form-label">Description</label>
                    <asp:TextBox runat="server" TextMode="MultiLine" class="form-control" Rows="3" Style="resize: none;" ID="desc" />
                </div>
                <div class="col-md-6 mb-4">
                    <label for="product_img" class="form-label">Change Image</label>
                    <asp:FileUpload runat="server" class="form-control" ID="product_img" accept="image/*" />
                </div>
                <div class="col-md-6 mb-4">
                    <label class="form-label" style="color: red; display: block; width: fit-content; margin: 0 auto">Delete Product <i class="fa-solid fa-trash-can"></i></label>
                    <asp:Button runat="server" class="red-button" Style="display: block; width: fit-content; margin: 7.5px auto 0; border-radius: 10px; padding: 5px 15px" ID="delProd" OnClick="deleteProduct_Click" Text="Delete!" />
                </div>
                <asp:Button class="black-button fs-5 py-1 mb-3" Style="align-self: center; width: 100%; border-radius: 10px; border: none;" Text="Save Edit" runat="server" type="submit" ID="editProduct" OnClick="editProduct_Click" />
            </div>
        </div>
    </div>

</asp:Content>

