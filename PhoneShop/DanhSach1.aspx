<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_User.Master" AutoEventWireup="true" CodeBehind="DanhSach1.aspx.cs" Inherits="PhoneShop.DanhSach1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <div class="content_top">
                        <div class="heading">
                            <h3>New Products</h3>
                        </div>
                        <div class="see">
    			            <p><a href="#">See all Products</a></p>
    		            </div>
                        <div class="clear"></div>
                    </div>
    <div class="section group">
  
        <asp:DataList ID="DataList1" runat="server" RepeatColumns="3">
            <ItemTemplate>
                <div class="grid_1_of_4 images_1_of_4">
                    <a href="ChiTiet1.aspx?MaSP=<%#Eval("SanPham_ID") %>">
                        <img src="<%# "/images/"+Eval("HinhAnh") %>" width="250px" height="250px" /></a>
                    <h2><%#Eval("TenSanPham") %></h2>
                    <div class="price-details">
                        <div class="price-number">
                            <p><span class="rupees"><%#Eval("DonGia") %></span></p>
                        </div>
                        <div class="add-cart">
                            <h4><a href="#">Add to Cart</a></h4>
                        </div>
                        <div class="clear"></div>
                    </div>
               </div>
            </ItemTemplate>
        </asp:DataList>
         
    </div>
</asp:Content>
