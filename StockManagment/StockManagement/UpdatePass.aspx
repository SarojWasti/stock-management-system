<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UpdatePass.aspx.cs" Inherits="StockManagement.UpdatePass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Change Password</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Change Password</h1>
    <div class="form-group w-50" style="margin-bottom: 0.5em !important;">
        <label for="Old">Old Pass</label>
        <asp:TextBox ID="OldPass" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="OldPassValidate" ControlToValidate="OldPass" ValidationGroup="FieldValidation" runat="server" ForeColor="#e30e0e" ErrorMessage="Old password is required"></asp:RequiredFieldValidator>

        <asp:Panel ID="ErrorPanel" runat="server" Visible="false">
            <div class="alert alert-danger mt-3 alert-dismissible fade show" role="alert">
                <asp:Label ID="ErrorAlert" Text="" runat="server" />
                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
        </asp:Panel>
    </div>

    <div class="form-group w-50" style="margin-bottom: 0.5em !important;">
        <label for="New">New Password</label>
        <asp:TextBox ID="NewPass" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="NewPassValidate" ControlToValidate="NewPass" ValidationGroup="FieldValidation" runat="server" ForeColor="#e30e0e" ErrorMessage="New password is required"></asp:RequiredFieldValidator>
    </div>
    <asp:Panel ID="SuccessPanel" runat="server" Visible="false">
        <div class="alert alert-success mt-3 alert-dismissible fade show" role="alert">
            <asp:Label ID="SuccessAlert" Text="" runat="server" />
            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                <span aria-hidden="true">&times;</span>
            </button>
        </div>
    </asp:Panel>
    <asp:Button ID="ChangePassword" CssClass="btn btn-primary" runat="server" Text="Update Password" ValidationGroup="FieldValidation" OnClick="ChangePassword_Click" />

</asp:Content>
