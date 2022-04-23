<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Items.aspx.cs" Inherits="StockManagement.Items" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Items</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Items</h1>
    <div class="form-row">
        <asp:TextBox ID="ItemId" CssClass="form-control" runat="server" Visible="false"></asp:TextBox>
        <div class="form-group mb-0 col-md-5">
            <label for="ItemName">Item Name</label>
            <asp:TextBox ID="ItemName" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ItemValidate" ControlToValidate="ItemName" runat="server" ValidationGroup="FieldValidation" ErrorMessage="Item name is required" ForeColor="#e30e0e"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group mb-0 ml-5 col-md-5">
            <label for="Desc">Description</label>
            <asp:TextBox ID="Desc" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="form-group mb-0 col-md-5">
            <label for="Price">Price</label>
            <asp:TextBox ID="Price" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="PriceValidate" ControlToValidate="Price" runat="server" ValidationGroup="FieldValidation" ErrorMessage="Price is required" ForeColor="#e30e0e"></asp:RequiredFieldValidator>
            <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" ControlToValidate="Price" ValidationGroup="FieldValidation" ErrorMessage="Value must be a number" ForeColor="#e30e0e" />
        </div>

        <div class="form-group mb-0 ml-5 col-md-5">
            <label for="ManufDate">Manufactured Date</label>
            <asp:TextBox ID="ManufDate" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
        </div>

        <div class="form-group mb-3 col-md-5">
            <label for="ExpDate">Expiry Date</label>
            <asp:TextBox ID="ExpDate" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
        </div>

        <div class="form-group mb-0 ml-5 col-md-5">
            <label for="name">Category Name</label>
            <asp:DropDownList ID="CategoryDropdown" CssClass="form-control" runat="server">
            </asp:DropDownList>
        </div>

        <div class="form-group mb-0 col-md-5">
            <label for="Quantity">Quantity</label>
            <asp:TextBox ID="Quantity" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="Quantity" runat="server" ValidationGroup="FieldValidation" ErrorMessage="Quantity is required" ForeColor="#e30e0e"></asp:RequiredFieldValidator>
            <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" ControlToValidate="Quantity" ValidationGroup="FieldValidation" ErrorMessage="Value must be a number" ForeColor="#e30e0e" />
        </div>

        <div class="form-group mb-0 ml-5 col-md-5">
            <label for="supplierId">Supplier Name</label>
            <asp:DropDownList ID="SupplierDropdown" CssClass="form-control" runat="server">
            </asp:DropDownList>
        </div>

        <div class="form-group mb-4 col-md-5">
            <label for="stockDate">Stocked Date</label>
            <asp:TextBox ID="StockedDate" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
            <asp:RequiredFieldValidator ID="StockedDateRequiredValidator" ControlToValidate="Quantity" runat="server" ValidationGroup="FieldValidation" ErrorMessage="You need to provide the stocked date for item" ForeColor="#e30e0e"></asp:RequiredFieldValidator>
        </div>

    </div>
    <asp:Button ID="AddItem" Text="Add Item" CssClass="btn btn-primary" ValidationGroup="FieldValidation" CausesValidation="true" runat="server" OnClick="AddItem_Click" />
    <asp:Button ID="UpdateItem" Text="Update" ValidationGroup="FieldValidation" CssClass="btn btn-success ml-5" runat="server" OnClick="UpdateItem_Click" />
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

    <div class="row">
        <div class="col-10">
            <div class="w-25 mt-7">
                <label for="ItemsType"></label>
                <asp:DropDownList ID="ItemsFilterType" CausesValidation="false" AutoPostBack="true" CssClass="form-control" runat="server" OnSelectedIndexChanged="ItemsFilterType_SelectedIndexChanged">
                    <asp:ListItem Text="All Items"></asp:ListItem>
                    <asp:ListItem Text="Available on Stock"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-2 mt-4">
            <button type="button" class="btn btn-danger" data-toggle="modal" data-target="#exampleModalCenter">
                Delete multiple items
            </button>

            <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalCenterTitle">Delete long due out of stock items</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <p>Following items are out of stock for more than 31 days. Are you sure you want to delete these items?</p>
                            <asp:ListView runat="server" ID="MultiDeletableItems">
                                <ItemTemplate><p style="color: black;"> - <%# Eval("item_name") %></p></ItemTemplate>
                            </asp:ListView>
                        </div>
                        <div class="modal-footer">
                            <asp:Button Text="Cancel" CssClass="btn btn-secondary" data-dismiss="modal" runat="server" />
                            <asp:Button ID="DeleteMultiple" Text="Confirm" CssClass="btn btn-primary" runat="server" OnClick="DeleteMultiple_OnClick"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="mt-4">
        <div class="table-responsive-lg">
            <asp:GridView ID="ItemsTable" CssClass="table table-bordered gridview" runat="server" AutoGenerateColumns="False" OnRowCommand="ItemsTable_RowCommand" OnPreRender="GridView_PreRender">
                <Columns>
                    <asp:BoundField DataField="item_id" HeaderText="ID" />
                    <asp:BoundField DataField="name" HeaderText="Item Name" />
                    <asp:BoundField DataField="description" HeaderText="Description" />
                    <asp:BoundField DataField="price" HeaderText="Price (Rs.)" />
                    <asp:BoundField DataField="manufactured_date" HeaderText="Manufactured Date" DataFormatString="{0:yyyy/MM/dd}" />
                    <asp:BoundField DataField="expiry_date" HeaderText="Expiry Date" DataFormatString="{0:yyyy/MM/dd}" />
                    <asp:BoundField DataField="category_id" HeaderText="Category ID" />
                    <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="stocked_date" HeaderText="Stocked Date" DataFormatString="{0:yyyy/MM/dd}" />
                    <asp:BoundField DataField="supplier_id" HeaderText="Supplier ID" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="RowSelectBtn" Text="Select" CssClass="btn btn-secondary mb-1" runat="server" CommandName="select" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CausesValidation="false" />
                            <asp:Button ID="RowDeleteBtn" Text="Delete" CssClass="btn btn-danger" runat="server" CommandName="deleteitem" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CausesValidation="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
