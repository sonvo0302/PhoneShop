<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_User.Master" AutoEventWireup="true" CodeBehind="DatHangThanhCong.aspx.cs" Inherits="PhoneShop.DatHangThanhCong" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content_top">
        <div class="heading_top">
            <h3>Đơn đặt hàng</h3>
        </div>
        <div class="see">
            <p><a href="#">Tất cả đơn hàng</a></p>
        </div>
        <div class="clear"></div>
    </div>
    <div class="section group">
        <div class="heading_top">
            <h4>&nbsp;<img src="images/list-img.png" />Đơn hàng đã đặt</h4>
        </div>
        <br />
        <asp:GridView ID="GridView1" runat="server">
             <Columns>
                <asp:BoundField DataField="HD_ID" HeaderText="Mã Hóa Đơn" Visible="False" />
                <asp:BoundField DataField="TenSanPham" HeaderText="Tên sản phẩm" />
                <asp:TemplateField HeaderText="Hình ảnh">
                    <ItemTemplate>
                        <asp:Image ImageUrl='<%# "/images/AnhDT/"+Eval("HinhAnh") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Mau" HeaderText="Màu" />
                <asp:BoundField DataField="DonGia" HeaderText="Đơn Giá" />
                
                <asp:TemplateField HeaderText="Số Lượng">
                    <ItemTemplate>
                        <asp:Label ID="lblamount" runat="server" Text='<%# Eval("SoLuongDat") %>' /> 
                    </ItemTemplate>
                   
                    <FooterTemplate>
                        <asp:Label runat="server" CssClass="label1" Text="Tổng số lượng : "></asp:Label><asp:Label ID="lblTotal" CssClass="label2" runat="server" Text=""></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Thành tiền">
                    <ItemTemplate>
                        <asp:Label ID="lbl_tongtien" runat="server" Text='<%# Eval("ThanhTien") %>' /> 
                    </ItemTemplate>
                    
                    <FooterTemplate>
                        <asp:Label  runat="server" CssClass="label1" Text="Tổng tiền : "></asp:Label><asp:Label ID="lblTotalMoney" CssClass="label2" runat="server" Text=""></asp:Label><asp:Label  style="font-size: 20px;
            font-style:italic;color: #ff006e;" runat="server" CssClass="label3" Text="VND"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
        <asp:GridView ID="grdDonHang" CssClass="table" runat="server" OnRowDataBound="grdDonHang_RowDataBound" AutoGenerateColumns="False" Width="100%" AllowPaging="True" PageSize="5" OnPageIndexChanging="grdDonHang_PageIndexChanging" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" ShowFooter="True">
            <Columns>
                <asp:BoundField DataField="HD_ID" HeaderText="Mã Hóa Đơn" Visible="False" />
                <asp:BoundField DataField="TenSanPham" HeaderText="Tên sản phẩm" />
                 <asp:TemplateField HeaderText="Hình ảnh">
                    <ItemTemplate>
                        <asp:Image style="float:left" Width="50%" ImageUrl='<%# "/images/AnhDT/"+Eval("HinhAnh") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Mau" HeaderText="Màu" />
                <asp:BoundField DataField="DonGia" HeaderText="Đơn Giá" />
                <%--<asp:BoundField DataField="SoLuongDat" HeaderText="Số Lượng" />--%>
                <asp:TemplateField HeaderText="Số Lượng">
                    <ItemTemplate>
                        <asp:Label ID="lblamount" runat="server" Text='<%# Eval("SoLuongDat") %>' /> 
                    </ItemTemplate>
                   
                    <FooterTemplate>
                        <asp:Label runat="server" CssClass="label1" Text="Tổng số lượng : "></asp:Label><asp:Label ID="lblTotal" CssClass="label2" runat="server" Text=""></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Thành tiền">
                    <ItemTemplate>
                        <asp:Label ID="lbl_tongtien" runat="server" Text='<%# Eval("ThanhTien") %>' /> 
                    </ItemTemplate>
                    
                    <FooterTemplate>
                        <asp:Label  runat="server" CssClass="label1" Text="Tổng tiền : "></asp:Label><asp:Label ID="lblTotalMoney" CssClass="label2" runat="server" Text=""></asp:Label><asp:Label  style="font-size: 20px;
            font-style:italic;color: #ff006e;" runat="server" CssClass="label3" Text="VND"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />

        </asp:GridView>

        <div style="float: right">
            <%-- <asp:Label ID="Label1" runat="server" CssClass="label1" Text="Tổng tiền : "></asp:Label><asp:Label ID="Label2" CssClass="label2" runat="server" Text=""></asp:Label><asp:Label ID="Label3" style="font-size: 20px;
            font-style:italic;color: #ff006e;" runat="server" CssClass="label3" Text="VND"></asp:Label>--%>
        </div>
    </div>
</asp:Content>
