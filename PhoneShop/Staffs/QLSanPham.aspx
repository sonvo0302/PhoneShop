<%@ Page Title="" Language="C#" MasterPageFile="~/Staffs/StaffManagement.Master" AutoEventWireup="true" CodeBehind="QLSanPham.aspx.cs" Inherits="PhoneShop.Staffs.QLSanPham" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Mangement_Style/css_table/style.css" rel="stylesheet" />
    <link href="../UserStyle/css/LoginStyle/bootstrap.min.css" rel="stylesheet" />
    <%--    <link href="../UserStyle/css/LoginStyle/font-awesome.css" rel="stylesheet" />--%>
    <%--    <script src="../UserStyle/js/LoginJS/bootstrap.min.js"></script>--%>
    <%--  <script src="../UserStyle/js/LoginJS/jquery-1.9.1.min.js"></script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <%-- <div class="col-sm-6">
        <section class="panel">
            <header class="panel-heading">
                <a class="btn btn-primary" href="ThemDanhMuc.aspx"><i class="glyphicon glyphicon-plus"></i>Quản lý danh mục</a>
            </header>

            <asp:DataList ID="DataList2" runat="server" CssClass="table table-striped table-advance table-hover">
                <HeaderTemplate>

                    <th><i></i>Mã danh mục</th>
                    <th><i></i>Tên danh mục</th>
                    <th><i></i>Mã danh mục cha</th>
                    <th><i class="glyphicon glyphicon-cog"></i>Lựa chọn</th>
                </HeaderTemplate>
                <ItemTemplate>



                    <td>
                        <asp:Label runat="server" Text='<%#Eval("DanhMuc_ID") %>'></asp:Label></td>
                    <td>
                        <asp:Label runat="server" Text='<%#Eval("TenDanhMuc") %>'></asp:Label></td>
                    <td>
                        <asp:Label runat="server" Text='<%#Eval("Parent_ID") %>'></asp:Label></td>
                    <td>
                        <div class="btn-group">
                            <asp:LinkButton ID="btn_sua_danhmuc" runat="server" CommandArgument='<%#Eval("DanhMuc_ID") %>' CssClass="btn btn-success"><i class="glyphicon glyphicon-pencil"></i></asp:LinkButton>
                            <asp:LinkButton ID="btn_xoa_danhmuc" CommandArgument='<%#Eval("DanhMuc_ID") %>' runat="server" class="btn btn-danger"><i class="glyphicon glyphicon-remove"></i></asp:LinkButton>

                        </div>
                    </td>

                </ItemTemplate>
            </asp:DataList>

        </section>
    </div>--%>
    <div class="col-sm-6">
        <section class="panel">
            <header class="panel-heading">
                <a class="btn btn-primary" href="#"><i class="glyphicon glyphicon-plus"></i>Quản lý màu sản phẩm</a>
            </header>

            <asp:DataList ID="DataList3" runat="server" CssClass="table table-striped table-advance table-hover">
                <HeaderTemplate>

                    <th><i></i>Mã màu</th>
                    <th><i></i>Tên màu</th>
                    <th><i class="glyphicon glyphicon-cog"></i>Lựa chọn</th>
                </HeaderTemplate>
                <ItemTemplate>



                    <td>
                        <asp:Label runat="server" Text='<%#Eval("Mau_ID") %>'></asp:Label></td>
                    <td>
                        <asp:Label runat="server" Text='<%#Eval("TenMau") %>'></asp:Label></td>

                    <td>
                        <div class="btn-group">
                            <asp:LinkButton ID="btn_sua_mau" runat="server" CommandArgument='<%#Eval("Mau_ID") %>' CssClass="btn btn-success"><i class="glyphicon glyphicon-pencil"></i></asp:LinkButton>
                            <asp:LinkButton ID="btn_xoa_mau" CommandArgument='<%#Eval("Mau_ID") %>' runat="server" class="btn btn-danger"><i class="glyphicon glyphicon-remove"></i></asp:LinkButton>

                        </div>
                    </td>

                </ItemTemplate>
            </asp:DataList>

        </section>
    </div>
    <div class="col-lg-12">
        <section class="panel">
            <header class="panel-heading">
                <a class="btn btn-primary" href="ThemSanPhamMoi.aspx"><i class="glyphicon glyphicon-plus"></i>Quản lý sản phẩm</a>
            </header>

            <asp:DataList ID="DataList1" runat="server" CssClass="table table-striped table-advance table-hover">
                <HeaderTemplate>

                    <th><i class="glyphicon glyphicon-wrench"></i>Mã sản phẩm</th>
                    <th><i class="	glyphicon glyphicon-user"></i>Tên sản phẩm</th>
                    <th><i class="glyphicon glyphicon-lock"></i>Đơn giá</th>
                    <th><i></i>Số lượng</th>
                    <th><i></i>Hình ảnh</th>
                    <th><i></i>Mô tả</th>
                    <th><i></i>Màu_ID</th>
                    <th><i></i>Danh Mục_ID</th>
                    <th><i class="glyphicon glyphicon-cog"></i>Lựa chọn</th>
                </HeaderTemplate>
                <ItemTemplate>



                    <td>
                        <asp:Label runat="server" Text='<%#Eval("SanPham_ID") %>'></asp:Label></td>
                    <td>
                        <asp:Label runat="server" Text='<%#Eval("TenSanPham") %>'></asp:Label></td>
                    <td>
                        <asp:Label runat="server" Text='<%#Eval("DonGia") %>'></asp:Label></td>
                    <td>
                        <asp:Label runat="server" Text='<%#Eval("SoLuong") %>'></asp:Label></td>
                    <td>
                        <asp:Label runat="server" Text='<%# Eval("HinhAnh") %>'></asp:Label></td>
                    <td>
                        <asp:Label runat="server" Text='<%# Eval("MoTa") %>'></asp:Label></td>
                    <td>
                        <asp:Label runat="server" Text='<%# Eval("Mau_ID") %>'></asp:Label></td>
                    <td>
                        <asp:Label runat="server" Text='<%# Eval("TenDanhMuc") %>'></asp:Label></td>
                    <td>
                        <div class="btn-group">

                            <asp:LinkButton ID="btn_sua_sanpham" runat="server" CommandArgument='<%#Eval("SanPham_ID") %>' CssClass="btn btn-success" OnClick="btn_sua_sanpham_Click"><i class="glyphicon glyphicon-pencil"></i></asp:LinkButton>
                            <asp:LinkButton ID="btn_xoa_sp" runat="server" CommandArgument='<%#Eval("SanPham_ID") %>' CssClass="btn btn-danger" OnClick="btn_xoa_sp_Click"><i class="glyphicon glyphicon-remove"></i></asp:LinkButton>

                        </div>
                    </td>

                </ItemTemplate>
            </asp:DataList>

        </section>

    </div>

</asp:Content>
