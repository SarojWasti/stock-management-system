<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Supplier.aspx.cs" Inherits="StockManagement.Supplier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Suppliers</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Suppliers</h1>
    <asp:TextBox ID="SupplierID" runat="server" Visible="false"></asp:TextBox>
    <div class="form-group w-50" style="margin-bottom: 0.5em !important;">
        <label for="Name"> Supplier name</label>
        <asp:TextBox ID="SupName" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="NameRequiredValidator" ControlToValidate="SupName" ValidationGroup="FieldValidation" runat="server" ForeColor="#e30e0e" ErrorMessage="User Name is required"></asp:RequiredFieldValidator>
    </div>
    <div class="form-group w-50" style="margin-bottom: 0.5em !important;">
        <label for="Name">Address</label>
        <asp:TextBox ID="Address" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="AddressRequiredFieldValidator" ControlToValidate="Address" ValidationGroup="FieldValidation" runat="server" ForeColor="#e30e0e" ErrorMessage="User Name is required"></asp:RequiredFieldValidator>
    </div>
    <div class="form-group w-50" style="margin-bottom: 0.5em !important;">
        <label for="Name">Contact</label>
        <asp:TextBox ID="Phone" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="PhoneRegularExpressionValidator" runat="server" ControlToValidate="Phone" ValidationGroup="FieldValidation" ForeColor="#e30e0e" ErrorMessage="Phone number shouldn't be less than 9 digits!" ValidationExpression="[0-9]{9,}"></asp:RegularExpressionValidator>
    </div>
    <asp:Button ID="AddSupplier" CssClass="btn btn-primary" runat="server" Text="Add Supplier" ValidationGroup="FieldValidation" OnClick="AddSupplier_Click" />
    <asp:Button ID="UpdateSupplier" Text="Update" ValidationGroup="FieldValidation" CssClass="btn btn-success ml-5" runat="server" OnClick="UpdateSupplier_Click" />
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
            <asp:GridView ID="SupplierTable" CssClass="table table-bordered gridview" runat="server" AutoGenerateColumns="False" OnRowCommand="SupplierTable_RowCommand" OnPreRender="GridView_PreRender">
                <Columns>
                    <asp:BoundField DataField="supplier_id" HeaderText="Supplier ID" />
                    <asp:BoundField DataField="name" HeaderText="Supplier Name" />
                    <asp:BoundField DataField="address" HeaderText="Address" />
                    <asp:BoundField DataField="phone" HeaderText="Contact" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="RowSelectBtn" Text="Select" CssClass="btn btn-secondary" runat="server" CommandName="select" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CausesValidation="false" />
                            <asp:Button ID="RowDeleteBtn" Text="Delete" CssClass="btn btn-danger" runat="server" CommandName="deletesupplier" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CausesValidation="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
