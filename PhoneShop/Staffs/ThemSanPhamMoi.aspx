<%@ Page Title="" Language="C#" MasterPageFile="~/Staffs/StaffManagement.Master" AutoEventWireup="true" CodeBehind="ThemSanPhamMoi.aspx.cs" Inherits="PhoneShop.Staffs.ThemSanPhamMoi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="clear: both"></div>
    <br />
    <br />
    <div class="col-lg-12">
        <section class="panel">
            <header class="panel-heading" style="font-weight:bold">
                Thêm sản phẩm mới
            </header>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <label for="inputEmail4">Tên sản phẩm</label>
                    <input type="text" class="form-control" id="txt_tensanpham" runat="server" />
                </div>
                <div class="form-group col-md-6">
                    <label for="inputEmail4">Đơn giá</label>
                    <input type="text" class="form-control" id="txt_dongia" runat="server" />
                </div>
                <div class="form-group col-md-6">
                    <label for="inputPassword4">Số lượng</label>
                    <input type="text" class="form-control" id="txt_soluong" runat="server" />
                </div>
                <div class="form-group col-md-6">
                    <label for="inputPassword4">Hình ảnh</label>
                    <asp:FileUpload ID="FileUpload1" CssClass="form-control" runat="server" />            
                    <asp:Label ID="lblthongbao" runat="server"></asp:Label>
                </div>
                <div class="form-group col-md-6">
                    <label for="inputPassword4">Mô tả</label>
                    <input type="text" class="form-control" id="txt_mota" runat="server" />
                </div>
            </div>
            <div class="form-group">
                <label for="inputGroup">Nhóm sản phẩm</label>
                <asp:DropDownList ID="dropdown_group" CssClass="btn btn-secondary dropdown-item" runat="server"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="inputGroup">Màu</label>
                <asp:DropDownList ID="drp_mau" CssClass="btn btn-secondary dropdown-item" runat="server"></asp:DropDownList>
            </div>
            <asp:Button runat="server" CssClass="btn btn-primary" ID="btn_back" OnClick="btn_back_Click" Text="Quay về" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button runat="server" CssClass="btn btn-primary btn-danger" ID="btn_save" OnClick="btn_save_Click" Text="Lưu" />
        </section>
    </div>
</asp:Content>
