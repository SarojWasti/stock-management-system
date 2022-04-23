<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="StockManagement.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Dashboard</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Stock Management System</h1>
    
    <div class="w-25">
        <h4>Out Of Stock Items</h4>
        <label for="name">Sort By: </label>
        <asp:DropDownList ID="SortDropDown" CausesValidation="false" AutoPostBack="true" CssClass="form-control" runat="server" OnSelectedIndexChanged="SortDropDown_SelectedIndexChanged">
            <asp:ListItem Text="Item Name"></asp:ListItem>
            <asp:ListItem Text="Quantity"></asp:ListItem>
            <asp:ListItem Text="Stocked Date"></asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="mt-3">
        <div class="table-responsive-lg">
            <asp:GridView ID="OutOfStock" CssClass="table table-bordered gridview" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="item_id" HeaderText="ID" />
                    <asp:BoundField DataField="name" HeaderText="Item Name" />
                    <asp:BoundField DataField="description" HeaderText="Description" />
                    <asp:BoundField DataField="price" HeaderText="Price (Rs.)" />
                    <asp:BoundField DataField="supplier" HeaderText="Supplier Name" />
                </Columns>
            </asp:GridView>
        </div>
    </div>

    
    <div class="mt-5">
        <h4>Inactive Customers of Last 31 Days</h4>
        <div class="table-responsive-lg">
            <asp:GridView ID="InactiveCustomers" CssClass="table table-bordered gridview" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="Customer Name" />
                    <asp:BoundField DataField="address" HeaderText="Address" />
                    <asp:BoundField DataField="number" HeaderText="Number" />
                    <asp:BoundField DataField="email" HeaderText="Email" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
    
    <div class="mt-5">
        <h4>Unsold Items in 31 Days</h4>
        <div class="table-responsive-lg">
            <asp:GridView ID="UnsoldItems" CssClass="table table-bordered gridview" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="Item Name" />
                    <asp:BoundField DataField="description" HeaderText="Description" />
                    <asp:BoundField DataField="price" HeaderText="Price" />
                    <asp:BoundField DataField="stocked_date" HeaderText="Stocked Date" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

