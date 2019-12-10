<%@ Page Title="" Language="C#" MasterPageFile="~/Staffs/StaffManagement.Master" AutoEventWireup="true" CodeBehind="QLyHoaDon.aspx.cs" Inherits="PhoneShop.Staffs.QLyHoaDon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="col-lg-12">
            <section class="panel">
              <header class="panel-heading">
                 <a class="btn btn-primary" href="#"><i class="glyphicon glyphicon-plus"></i>Quản lý hóa đơn</a>
              </header>

                    <asp:DataList ID="DataList1" runat="server" CssClass="table table-striped table-advance table-hover">
                        <HeaderTemplate>
                             
                    <th><i class="glyphicon glyphicon-wrench" ></i> Mã hóa đơn</th>
                    <th><i class="	glyphicon glyphicon-user" ></i> Mã khách hàng</th>
                    <th><i class="glyphicon glyphicon-lock"></i> Tên khách hàng</th>
                    <th><i></i> Điện thoại</th>
                    <th><i ></i> Ngày nhận hóa đơn</th>
                    <th><i></i> Tổng tiền</th>
                
                        </HeaderTemplate>
                        <ItemTemplate>
                            
                  
                      
                    <td><asp:Label runat="server" Text='<%#Eval("HD_ID") %>'></asp:Label></td>
                    <td><asp:Label runat="server" Text='<%#Eval("User_ID") %>'></asp:Label></td>
                    <td><asp:Label runat="server" Text='<%#Eval("TenKhachHang") %>'></asp:Label></td>
                    <td><asp:Label runat="server" Text='<%#Eval("Phone") %>'></asp:Label></td> 
                    <td><asp:Label runat="server" Text='<%# Eval("NgayHD") %>'></asp:Label></td>
                    <td> <asp:Label runat="server" Text='<%# Eval("TongTien") %>'></asp:Label></td>
                   <%-- <td>
                      <div class="btn-group">
                          <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("User_ID") %>' CssClass="btn btn-success" OnClick="LinkButton1_Click"><i class="glyphicon glyphicon-pencil"></i></asp:LinkButton>
                        <asp:LinkButton ID="btn_xoa" CommandArgument='<%#Eval("User_ID") %>' runat="server" OnClick="btn_xoa_Click" class="btn btn-danger"><i class="glyphicon glyphicon-remove"></i></asp:LinkButton>
                      </div>
                    </td>--%>
                  
                            </ItemTemplate>
                 </asp:DataList>
         
</section>
             <div id="thanhtien" style="color: red; font-size: 20px; float: right;">
        <strong><asp:Label ID="lbl_ThanhTien" runat="server"></asp:Label></strong>
    </div>
         </div>

</asp:Content>
