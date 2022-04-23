<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Sales.aspx.cs" Inherits="StockManagement.Sales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Sales</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="SalesForm" runat="server">
        <h1>Sales</h1>
        <div class="form-group mb-0 w-50">
            <label for="item">Item ID</label>
            <asp:TextBox ID="ItemID" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequireItem" ControlToValidate="ItemID" ValidationGroup="FieldValidation" runat="server" ForeColor="#e30e0e" ErrorMessage="Item id is required"></asp:RequiredFieldValidator>
            <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" ControlToValidate="ItemID" ForeColor="#e30e0e" ErrorMessage="Value must be a number" />
        </div>

        <div class="form-group w-50">
            <label for="customer">Customer Name </label>
            <asp:DropDownList ID="CustomerNameDropDown" CssClass="form-control" runat="server">
            </asp:DropDownList>
        </div>

        <div class="form-group w-50">
            <label for="quantity">Quantity</label>
            <asp:TextBox ID="Quantity" CssClass="form-control" runat="server" AutoPostBack="true" OnTextChanged="Quantity_TextChanged"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequireQuantity" ControlToValidate="Quantity" ValidationGroup="FieldValidation" runat="server" ForeColor="#e30e0e" ErrorMessage="Quantity is required"></asp:RequiredFieldValidator>
            <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" ControlToValidate="Quantity" ForeColor="#e30e0e" ErrorMessage="Value must be a number" />
        </div>

        <div class="form-group w-50">
            <asp:Button ID="SellBtn" CssClass="btn btn-primary mt-3" ValidationGroup="FieldValidation" runat="server" Text="Sell" OnClick="SellBtn_Click" />
            <asp:Label ID="TotalAmount" Text="" CssClass="float-right ml-2" ForeColor="black" runat="server" />
            <asp:Label Text="Total Amount: " CssClass="float-right font-weight-bold" ForeColor="black" runat="server" />
        </div>

        <asp:Panel ID="ErrorPanel" runat="server" Visible="false">
            <div class="alert alert-danger mt-3 alert-dismissible fade show" role="alert">
                <asp:Label ID="ErrorAlert" Text="" runat="server" />
                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
        </asp:Panel>
    </asp:Panel>

    <asp:Panel ID="BillingDetails" runat="server" Visible="false">
        <h1>Billing</h1>
        <div class="form-group w-50">
            <asp:Label Text="Category: " CssClass="font-weight-bold" ForeColor="black" runat="server" />
            <asp:Label ID="Category" Text="" CssClass="ml-2" ForeColor="black" runat="server" />
        </div>
        <div class="form-group w-50">
            <asp:Label Text="Item Name: " CssClass="font-weight-bold" ForeColor="black" runat="server" />
            <asp:Label ID="ItemName" Text="" CssClass="ml-2" ForeColor="black" runat="server" />
        </div>
        <div class="form-group w-50">
            <asp:Label Text="Quantity: " CssClass="font-weight-bold" ForeColor="black" runat="server" />
            <asp:Label ID="ItemQuantity" Text="" CssClass="ml-2" ForeColor="black" runat="server" />
        </div>
        <div class="form-group w-50">
            <asp:Label Text="Total Amount: " CssClass="font-weight-bold" ForeColor="black" runat="server" />
            <asp:Label ID="Amount" Text="" CssClass="ml-2" ForeColor="black" runat="server" />
        </div>
        <div class="form-group w-50">
            <asp:Label ID="forTransaction" Text="Transaction Date: " CssClass="font-weight-bold" ForeColor="black" runat="server" />
            <asp:Label ID="TransactionDate" Text="" CssClass="ml-2" ForeColor="black" runat="server" />
        </div>
        <div class="mt-3">
            <asp:LinkButton ID="GoBackBtn" Text="<< Go back to sales" runat="server" OnClick="GoBackBtn_Click" />
        </div>
    </asp:Panel>
</asp:Content>
