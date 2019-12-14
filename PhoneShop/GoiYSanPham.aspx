<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_User.Master" AutoEventWireup="true" CodeBehind="GoiYSanPham.aspx.cs" Inherits="PhoneShop.GoiYSanPham" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Mangement_Style/css_table/style.css" rel="stylesheet" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="content_top">
                        <div class="heading">
                            <h3>Thông tin của bạn</h3>
                        </div>
                        <div class="clear"></div>
                    </div>

    <asp:DataList ID="DataList1" runat="server" CssClass="table table-striped table-advance table-hover">
        <HeaderTemplate>

            <th><i></i>Sở thích</th>
            <th><i></i>Thu nhập</th>
            <th><i></i>Tuổi</th>
            <th><i></i>Giới tính</th>
             <th><i></i>Ngày sinh</th>
             
        </HeaderTemplate>
        <ItemTemplate>

            <td>
                <asp:Label runat="server" Text='<%#Eval("TenSoThich") %>'></asp:Label></td>
            <td>
                <asp:Label runat="server" Text='<%#Eval("LoaiThuNhap") %>'></asp:Label></td>
            <td>
                <asp:Label runat="server" Text='<%#Eval("Tuoi") %>'></asp:Label></td>
            <td>
                <asp:Label runat="server" Text='<%#Eval("TenGioiTinh") %>'></asp:Label></td>
            <td>
                <asp:Label runat="server" Text='<%#Eval("NgaySinh") %>'></asp:Label></td>

        </ItemTemplate>
    </asp:DataList>


    <div class="col-lg-12">
                        <div class="heading">
                            <h3>Mặt hàng phù hợp với bạn</h3>
                        </div>
         <div class="see">
                             <p><a href="#">Tất cả mặt hàng</a></p>
                        </div>
                        <div class="clear"></div>
          </div>          
       <asp:DataList ID="dataGoiY" runat="server" CssClass="table table-striped table-advance table-hover">
        <HeaderTemplate>

            <th><i></i>Tên sản phẩm</th>
            <th><i></i>Hình ảnh</th>
            <th><i></i>Đơn giá</th>
            <th><i></i>Màu</th>
             <th><i></i>Mô tả</th>
             
            <th><i class="glyphicon glyphicon-cog"></i>Lựa chọn</th>
        </HeaderTemplate>
        <ItemTemplate>

            <td>
                <asp:Label runat="server" Text='<%#Eval("TenSanPham") %>'></asp:Label></td>
            <td>
                <asp:Image ID="lb1" Style="float: left" Width="50%" runat="server" ImageUrl='<%# "/images/AnhDT/"+Eval("HinhAnh") %>'></asp:Image></td>
            <td>
                <asp:Label runat="server" Text='<%#Eval("DonGia") %>'></asp:Label></td>
            <td>
                <asp:Label runat="server" Text='<%#Eval("TenMau") %>'></asp:Label></td>
            <td>
                <asp:Label runat="server" Text='<%#Eval("MoTa") %>'></asp:Label></td>
            <td>
                <div class="btn-group">                    
                    <asp:LinkButton ID="btn_mua" runat="server" CommandArgument='<%#Eval("SanPham_ID") %>' CssClass="btn btn-success" OnClick="btn_mua_Click"><i class="glyphicon glyphicon-shopping-cart"></i></asp:LinkButton>              
                </div>
            </td>

        </ItemTemplate>
    </asp:DataList>
    <div class="float-lt">
        <asp:Label ID="Label2" CssClass="label2" runat="server" Text=""></asp:Label>
    </div>

</asp:Content>
