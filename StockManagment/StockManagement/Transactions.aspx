<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Transactions.aspx.cs" Inherits="StockManagement.Transactions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Transaction history of last 31 days</h2>
    <div class="w-25">
        <label for="name">Customer: </label>
        <asp:DropDownList ID="CustomerDropdown" CausesValidation="false" AutoPostBack="true" CssClass="form-control" runat="server" OnSelectedIndexChanged="CustomerDropdown_SelectedIndexChanged">
        </asp:DropDownList>
    </div>
    <div class="mt-4">
        <div class="table-responsive-lg">
            <asp:GridView ID="TransactionsTable" CssClass="table table-bordered gridview" runat="server" AutoGenerateColumns="False" OnPreRender="GridView_PreRender">
                <Columns>
                    <asp:BoundField DataField="category_name" HeaderText="Category" />
                    <asp:BoundField DataField="item_name" HeaderText="Item Name" />
                    <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="price" HeaderText="Price (Rs.)" />
                    <asp:BoundField DataField="total_amount" HeaderText="Total Amount (Rs.)" />
                    <asp:BoundField DataField="transaction_date" HeaderText="Transaction Date" DataFormatString="{0:yyyy/MM/dd}" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
