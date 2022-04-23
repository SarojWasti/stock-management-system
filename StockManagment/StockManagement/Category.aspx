<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="StockManagement.Category" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Category</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Category</h1>
    <asp:TextBox ID="CategoryID" Visible="false" runat="server" />
    <div class="form-group w-50">
        <label for="name">Category Name</label>
        <asp:TextBox ID="CategoryName" CssClass="form-control" runat="server" />
        <asp:RequiredFieldValidator ID="RequireCategory" ControlToValidate="CategoryName" ValidationGroup="FieldValidation" runat="server" ForeColor="#e30e0e" ErrorMessage="Category is required"></asp:RequiredFieldValidator>
    </div>
    <asp:Button ID="AddCategory" CssClass="btn btn-primary" ValidationGroup="FieldValidation" Text="Add Category" runat="server" OnClick="AddCategory_Click" />
    <asp:Button ID="UpdateCategory" Text="Update" ValidationGroup="FieldValidation" CssClass="btn btn-success ml-5" runat="server" OnClick="UpdateCategory_Click" />
     <asp:Panel ID="SuccessPanel" runat="server" Visible="false">
        <div class="alert alert-success mt-3 alert-dismissible fade show" role="alert">
            <asp:Label ID="SuccessAlert" Text="" runat="server" />
            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                <span aria-hidden="true">&times;</span>
            </button>
        </div>
    </asp:Panel>
    <asp:Panel ID="ErrorPanel" runat="server" Visible="false">
        <div class="alert alert-danger mt-3 alert-dismissible fade show" role="alert">
            <asp:Label ID="ErrorAlert" Text="" runat="server" />
            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                <span aria-hidden="true">&times;</span>
            </button>
        </div>
    </asp:Panel>
    <div class="mt-4">
        <div class="table-responsive-lg">
            <asp:GridView ID="CategoryTable" CssClass="table table-bordered gridview" runat="server" AutoGenerateColumns="False" OnRowCommand="CategoryTable_RowCommand" OnPreRender="GridView_PreRender">
                <Columns>
                    <asp:BoundField DataField="category_id" HeaderText="Category ID" />
                    <asp:BoundField DataField="category_name" HeaderText="Category Name" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="RowSelectBtn" Text="Select" CssClass="btn btn-secondary" runat="server" CommandName="select" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CausesValidation="false" />
                            <asp:Button ID="RowDeleteBtn" Text="Delete" CssClass="btn btn-danger" runat="server" CommandName="deletecategory" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CausesValidation="false"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
