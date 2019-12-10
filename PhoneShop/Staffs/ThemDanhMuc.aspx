<%@ Page Title="" Language="C#" MasterPageFile="~/Staffs/StaffManagement.Master" AutoEventWireup="true" CodeBehind="ThemDanhMuc.aspx.cs" Inherits="PhoneShop.Staffs.ThemDanhMuc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="clear: both"></div>
    <br />
    <br />
    <div class="col-lg-12">
        <section class="panel">
            <header class="panel-heading" style="font-weight: bold">
                Thêm danh mục con
            </header>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <label for="inputEmail4">Tên danh mục con</label>
                    <input type="text" class="form-control" id="txt_tendanhmuccon" runat="server" />
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <label for="inputEmail4">Tên danh mục cha</label>
                    <asp:DropDownList ID="drp_danhmuccha" runat="server"></asp:DropDownList>
                </div>
            </div>
            <asp:Button runat="server" CssClass="btn btn-primary" ID="btn_back" OnClick="btn_back_Click" Text="Quay về" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button runat="server" CssClass="btn btn-primary btn-danger" ID="btn_save" OnClick="btn_save_Click" Text="Lưu" />
        </section>
    </div>
</asp:Content>
