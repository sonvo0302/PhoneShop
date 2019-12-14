<%@ Page Title="" Language="C#" MasterPageFile="~/Staffs/StaffManagement.Master" AutoEventWireup="true" CodeBehind="SuaSanPham.aspx.cs" Inherits="PhoneShop.Staffs.SuaSanPham" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="clear: both"></div>
    <br />
    <br />
    <div class="col-lg-12">
        <section class="panel">
            <header class="panel-heading" style="font-weight:bold">
                Sửa sản phẩm
            </header>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <label for="inputPassword4">Hình ảnh</label>
                    <asp:Image ID="Image1" ImageUrl='<%#Eval("HinhAnh") %>'  runat="server" />   
                </div>
                <div class="form-group col-md-6">
                    <label for="inputEmail4">Mã sản phẩm</label>
                    <input type="text" class="form-control" id="txt_spid" text='<%#Eval("SanPham_ID") %>' runat="server" readonly="readonly" />
                </div>
                <div class="form-group col-md-6">
                    <label for="inputEmail4">Tên sản phẩm</label>
                    <input type="text" class="form-control" id="txt_tensp" text='<%#Eval("TenSanPham") %>' runat="server" />
                </div>
                <div class="form-group col-md-6">
                    <label for="inputPassword4">Đơn giá</label>
                    <input type="text" class="form-control" id="txt_dongia" runat="server" text='<%#Eval("DonGia") %>' />
                </div>
                <div class="form-group col-md-6">
                    <label for="inputPassword4">Số lượng</label>
                    <input type="text" class="form-control" id="txt_soluong" runat="server" text='<%#Eval("SoLuong") %>' />
                </div>
                <div class="form-group col-md-6">
                    <label for="inputPassword4">Mô tả</label>
                    <input type="text" class="form-control" id="txt_mota" runat="server" text='<%#Eval("MoTa") %>' />
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <label for="inputGroup">Nhóm màu</label>
                    <asp:DropDownList ID="drp_mau" CssClass="btn btn-secondary dropdown-item" runat="server"></asp:DropDownList>
                </div>
                <div class="form-group col-md-6">
                    <label for="inputGroup">Nhóm sản phẩm</label>
                    <asp:DropDownList ID="drp_DanhMuc" CssClass="btn btn-secondary dropdown-item" runat="server"></asp:DropDownList>
                </div>
            </div>
            <asp:Button runat="server" CssClass="btn btn-primary" ID="btn_back" OnClick="btn_back_Click" Text="Quay về" />
            &nbsp;&nbsp;&nbsp;
  <asp:Button runat="server" CssClass="btn btn-primary btn-danger" ID="btn_save" CommandArgument='<%#Eval("SanPham_ID") %>' OnClick="btn_save_Click" Text="Lưu" />
        </section>
    </div>
</asp:Content>
