<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="StockManagement.User1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>User</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>User</h1>
    <asp:Panel ID="UserForm" runat="server">
        <asp:TextBox ID="UserId" CssClass="form-control" runat="server" Visible="false"></asp:TextBox>
        <div class="form-group w-50" style="margin-bottom: 0.5em !important;">
            <label for="Name">Name</label>
            <asp:TextBox ID="Name" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="NameRequiredValidator" ControlToValidate="Name" ValidationGroup="FieldValidation" runat="server" ForeColor="#e30e0e" ErrorMessage="User Name is required"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group w-50" style="margin-bottom: 0.5em !important;">
            <label for="Phone">
                Phone
           
            </label>
            &nbsp;<asp:TextBox ID="Phone" CssClass="form-control" TextMode="Phone" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Phone" ValidationGroup="FieldValidation" ForeColor="#e30e0e" ErrorMessage="Phone should be a number and shouldn't be less than 9 digits!" ValidationExpression="[0-9]{9,}"></asp:RegularExpressionValidator>

        </div>
        <div class="form-group w-50" style="margin-bottom: 0.5em !important;">
            <label for="Email">
                Email
           
            </label>
            &nbsp;<asp:TextBox ID="Email" CssClass="form-control" TextMode="Email" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="EmailRequiredValidator" ControlToValidate="Email" runat="server" ValidationGroup="FieldValidation" ErrorMessage="Email is required" ForeColor="#e30e0e"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+@\w+([-.]\w+).\w+([-.]\w+)*" ControlToValidate="Email" ValidationGroup="FieldValidation" ForeColor="#e30e0e" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group w-50">
            <label for="Password">
                Password
           
            </label>
            &nbsp;<asp:TextBox ID="Password" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="PasswordRequiredValidator" ControlToValidate="Password" ValidationGroup="FieldValidation" runat="server" ForeColor="#e30e0e" ErrorMessage="Password is required"></asp:RequiredFieldValidator>
        </div>
        <asp:Button ID="AddUser" CssClass="btn btn-primary" runat="server" Text="Add User" ValidationGroup="FieldValidation" OnClick="AddUser_Click" />
        <asp:Button ID="UpdateUser" Text="Update" ValidationGroup="FieldValidation" CssClass="btn btn-success ml-5" runat="server" OnClick="UpdateUser_Click" />
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
    </asp:Panel>
    <div class="mt-4">
        <div class="table-responsive-lg">
            <asp:GridView ID="UsersTable" CssClass="table table-bordered gridview" runat="server" AutoGenerateColumns="False" OnRowCommand="UsersTable_RowCommand" OnPreRender="GridView_PreRender">
                <Columns>
                    <asp:BoundField DataField="user_id" HeaderText="ID" />
                    <asp:BoundField DataField="name" HeaderText="Full Name" />
                    <asp:BoundField DataField="phone_no" HeaderText="Phone Number" />
                    <asp:BoundField DataField="email" HeaderText="Email" />
                    <asp:BoundField DataField="password" HeaderText="Password" />
                    <asp:TemplateField >
                        <ItemTemplate>
                            <asp:Button ID="RowSelectBtn" Text="Select" CssClass="btn btn-secondary" runat="server" CommandName="select" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CausesValidation="false" />
                            <asp:Button ID="RowDeleteBtn" Text="Delete" CssClass="btn btn-danger" runat="server" CommandName="deleteuser" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CausesValidation="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
