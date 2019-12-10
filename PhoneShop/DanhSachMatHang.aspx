<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_User.Master" AutoEventWireup="true" CodeBehind="DanhSachMatHang.aspx.cs" Inherits="PhoneShop.DanhSachMatHang" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="content_top">
                        <div class="heading">
                            <h3>Sản phẩm mới</h3>
                        </div>
                        <div class="see">
    			            <p><a href="#">Tất cả sản phẩm</a></p>
    		            </div>
                        <div class="clear"></div>
                    </div>
   <%-- <div class="section group">--%>
  
        <asp:DataList ID="DataList1" runat="server" RepeatColumns="4" CssClass="section group table1" >
            <ItemTemplate>
                <%--<div class="grid_1_of_4 images_1_of_4">--%>
                    <a href="ChiTietSanPham1.aspx?MaSP=<%#Eval("SanPham_ID") %>">
                        <img src="<%# "/images/AnhDT/"+Eval("HinhAnh") %>"/></a>
                    <h2><%#Eval("TenSanPham") %></h2>
                    <div class="price-details">
                        <div class="price-number">
                            <p><span class="rupees"><%#Eval("DonGia") %></span></p>
                        </div>
                        <div class="clear"></div>
                    </div>
               <%--</div>--%>
            </ItemTemplate>
        </asp:DataList>
        <div style="float:right;padding-top:10px;">
            <asp:Literal ID="Literal1" runat="server" ></asp:Literal>
        </div>
        <%--<div style="float:right;">
            <cc1:CollectionPager ID="pager" runat="server"></cc1:CollectionPager>
        </div>--%>
   <%-- </div>--%>

</asp:Content>
