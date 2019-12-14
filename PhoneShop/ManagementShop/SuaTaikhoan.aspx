<%@ Page Title="" Language="C#" MasterPageFile="~/ManagementShop/AdminArea.Master" AutoEventWireup="true" CodeBehind="SuaTaikhoan.aspx.cs" Inherits="PhoneShop.ManagementShop.SuaTaikhoan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:LinkButton ID="phanquyen" CssClass="list-group-item list-group-item-action bg-light " runat="server" OnClick="phanquyen_Click">Phân quyền</asp:LinkButton>
    <asp:LinkButton ID="qltaikhoan" CssClass="list-group-item list-group-item-action bg-light list-group-item-success" runat="server" OnClick="qltaikhoan_Click">Quản lý tài khoản</asp:LinkButton>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div style="clear: both"></div>
    <br />
    <br />
    <div class="col-lg-12">
        <section class="panel">
            <header class="panel-heading">
                Sửa tài khoản
            </header>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <label for="inputEmail4">Mã tài khoản</label>
                    <input type="text" class="form-control" id="Text1" text='<%#Eval("User_ID") %>' runat="server" readonly="readonly" />
                </div>
                <div class="form-group col-md-6">
                    <label for="inputEmail4">Tên tài khoản</label>
                    <input type="text" class="form-control" id="user_name" text='<%#Eval("UserName") %>' runat="server" readonly="readonly" />
                </div>
                <div class="form-group col-md-6">
                    <label for="inputPassword4">Mật khẩu</label>
                    <input type="text" class="form-control" id="inputPassword" runat="server" text='<%#Eval("Password") %>' readonly="readonly" />
                </div>
            </div>
            <div class="form-group">
                <label for="inputGroup">Nhóm tài khoản</label>
                <asp:DropDownList ID="dropdown_group" CssClass="btn btn-secondary dropdown-item" runat="server"></asp:DropDownList>
            </div>
            <asp:Button runat="server" CssClass="btn btn-primary" ID="btn_back" OnClick="btn_back_Click" Text="Quay về" />
            &nbsp;&nbsp;&nbsp;
  <asp:Button runat="server" CssClass="btn btn-primary btn-danger" ID="btn_save" OnClick="btn_save_Click" Text="Lưu" />
        </section>
    </div>
</asp:Content>
