<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="StockManagement.Customer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Customer</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Customer</h1>
    <div class="form-group w-50">
        <label for="name">Customer Name</label>
        <asp:TextBox ID="CusName" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequireCusName" ControlToValidate="CusName" ValidationGroup="FieldValidation" runat="server" ForeColor="#e30e0e" ErrorMessage="Customer Name is required"></asp:RequiredFieldValidator>


    </div>
    <div class="form-group w-50 mb-0">
        <label for="address">
            Address
        </label>

        &nbsp;<asp:TextBox ID="Address" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequireAddress" ControlToValidate="Address" ValidationGroup="FieldValidation" runat="server" ForeColor="#e30e0e" ErrorMessage="Address is required"></asp:RequiredFieldValidator>

    </div>
    <div class="form-group w-50 mb-0">
        <label for="number">
            Number
        </label>
        &nbsp;<asp:TextBox ID="NumberBox" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RequireNumber" runat="server" ControlToValidate="NumberBox" ValidationGroup="FieldValidation" ForeColor="#e30e0e" ErrorMessage="Phone number shouldn't be less than 9 digits!" ValidationExpression="[0-9]{9,}"></asp:RegularExpressionValidator>


    </div>
    <div class="form-group w-50 mb-0">
        <label for="email">
            Email
        </label>

        &nbsp;<asp:TextBox ID="Email" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequireEmailAdd" ControlToValidate="Email" ValidationGroup="FieldValidation" runat="server" ForeColor="#e30e0e" ErrorMessage="Email is required"></asp:RequiredFieldValidator>
    </div>
    <div class="form-group w-50">
            <label for="customerType">Customer Type</label>
            <asp:DropDownList ID="CategoryDropDown" CssClass="form-control" runat="server">
                <asp:ListItem Text="Regular" Value="Regular"></asp:ListItem>
                <asp:ListItem Text="New" Value="New"></asp:ListItem>
            </asp:DropDownList>
        </div>
    <asp:Button ID="AddCustomer" CssClass="btn btn-primary" ValidationGroup="FieldValidation" runat="server" Text="Add Customer" OnClick="AddCustomer_Click" />
    <asp:Button ID="UpdateCustomer" Text="Update" ValidationGroup="FieldValidation" CssClass="btn btn-success ml-5" runat="server" OnClick="UpdateCustomer_Click" />
     
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
            <asp:GridView ID="CustomerTable" CssClass="table table-bordered gridview" runat="server" AutoGenerateColumns="False" OnRowCommand="CustomerTable_RowCommand" OnPreRender="GridView_PreRender">
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="Customer Name" />
                    <asp:BoundField DataField="address" HeaderText="Address" />
                    <asp:BoundField DataField="number" HeaderText="Number" />
                    <asp:BoundField DataField="email" HeaderText="Email" />
                    <asp:BoundField DataField="customer_type" HeaderText="Customer Type" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="RowSelectBtn" Text="Select" CssClass="btn btn-secondary" runat="server" CommandName="select" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CausesValidation="false" />
                            <asp:Button ID="RowDeleteBtn" Text="Delete" CssClass="btn btn-danger" runat="server" CommandName="deletecustomer" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CausesValidation="false"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
