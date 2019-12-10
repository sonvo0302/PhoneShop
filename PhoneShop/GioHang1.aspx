<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_User.Master" AutoEventWireup="true" CodeBehind="GioHang1.aspx.cs" Inherits="PhoneShop.GioHang1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
     <asp:GridView ID="grdGIOHANG" runat="server" AutoGenerateColumns="False" CssClass="table" Height="93px" Width="593px" AllowPaging="True" OnPageIndexChanging="grdGIOHANG_PageIndexChanging" PageSize="5"  >
        <Columns>
            
            <asp:BoundField DataField="TenSanPham" HeaderText="Tên mặt hàng" />
            <asp:ImageField DataImageUrlField="HinhAnh" HeaderText="Hình ảnh"   ControlStyle-Height="60px">
            </asp:ImageField>
            <asp:BoundField DataField="SoLuong" HeaderText="Số lượng" />
            <asp:BoundField DataField="DonGia" HeaderText="Đơn giá" />
            <asp:BoundField DataField="ThanhTien" HeaderText="Thành tiền" />
            <asp:TemplateField HeaderText="Trả hàng">
                <ItemTemplate>
                    <asp:CheckBox ID="ckbTRAHANG" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnTRAHANG" runat="server" OnClick="btnTRAHANG_Click" Text="Trả hàng" />
    <asp:Button ID="btnTHANHTOAN" runat="server" Text="Thanh toán" />
</asp:Content>
