<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_User.Master" AutoEventWireup="true" CodeBehind="GioHang.aspx.cs" Inherits="PhoneShop.GioHang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <div class="content_top">
                        <div class="heading_top">
                            <h3>Thông tin giỏ hàng của bạn</h3>
                        </div>
                        <div class="see">
    			            <p><a href="#">Sản phẩm trong giỏ</a></p>
    		            </div>
                        <div class="clear"></div>
                    </div>
    <br />
    <div class="section group">
     <asp:GridView ID="grdGIOHANG"  runat="server" AutoGenerateColumns="False"  Width="100%" AllowPaging="True" PageSize="5" CssClass="table" DataKeyNames="SanPham_ID">
        <Columns>
            <asp:BoundField DataField="TenSanPham" HeaderText="Tên Sản Phẩm"  />
             <asp:TemplateField HeaderText="Hình Ảnh">                 
                  <ItemTemplate>
                      <asp:Image ID="lb1" style="float:left" Width="50%" runat="server" ImageUrl='<%# "/images/AnhDT/"+Eval("HinhAnh") %>'>
                      </asp:Image>                         
                  </ItemTemplate>             
              </asp:TemplateField>
            
            <asp:BoundField DataField="TenMau" HeaderText="Màu"/>
           <asp:BoundField DataField="DonGia" HeaderText="Đơn Giá" />   
            <asp:TemplateField HeaderText="Số Lượng">                 
                  <ItemTemplate>
                      <asp:TextBox ID="TextBox1" style="float:left" Width="100px" runat="server" Text='<%# Eval("SoLuong") %>'>
                      </asp:TextBox> 
                          <asp:Button ID="btn_Sua" style="float:right;text-align:center" Text="Sửa" Height="50px" CssClass="btn btn-primary btn-danger" runat="server" OnClick="btn_Sua_Click" />
                  </ItemTemplate>             
              </asp:TemplateField>
            <asp:BoundField DataField="ThanhTien" HeaderText="Thành Tiền" />     
            <asp:TemplateField HeaderText="Trả Hàng">
                <ItemTemplate>
                    <asp:CheckBox ID="ckbTRAHANG" runat="server"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div style="float:right">
        <asp:Label ID="Label1" runat="server" CssClass="label1" Text="Tổng tiền : "></asp:Label><asp:Label ID="Label2" CssClass="label2" runat="server" Text=""></asp:Label><asp:Label ID="Label3" style="font-size: 20px;
    font-style:italic;color: #ff006e;" runat="server" CssClass="label3" Text="VND"></asp:Label>
    </div>
        <div class="clear"></div>
    <div style="border:0px solid gray;width:100%">
            <span class="float-rt"><asp:Button ID="btnTRAHANG" runat="server" Text="Trả hàng" OnClick="btnTRAHANG_Click" CssClass="btn btn-primary btn-danger" /></span>
            &nbsp;&nbsp;
           <span class="float-rt">   <%Response.Write(strThanhtoan); %>  </span> 
         <%--   <span class="float-right"> <asp:Button ID="btnTHANHTOAN" runat="server" Text="Thanh toán" OnClick="btnTHANHTOAN_Click" CssClass=" btn_nhap "/></span>--%>
            <span class="float-lt"><asp:Button ID="btnTIEPTUCMUAHANG" runat="server" Text="< Tiếp tục mua hàng" OnClick="btnTIEPTUCMUAHANG_Click" CssClass="btn btn-primary btn-danger" /></span> 
    </div>
  
   </div>

    <div id="modalOne" class="modal">
        <div class="modal-content" style="width:30%">
            <div class="contact-form">
                <span class="close">&times;</span>
            
                    <h2 style="text-align:center">Thành viên</h2>
                    <div>
                        <input   type="text" id="user_name"  placeholder="Username" runat="server"/>
                        <input  type="password" id="password_c" placeholder="Password" runat="server"/>
                    </div>
                    <asp:Button ID="btn_dangnhap" CssClass="button1 btn btn-primary btn-lg btn-block login-btn" OnClick="btn_dangnhap_Click"  runat="server" Text="Đăng nhập"  />

           
            </div>
        </div>
    </div>
     <div id="modalTwo" class="modal">
        <div class="modal-content" style="width:30%">
            <div class="contact-form">
                <span class="close">&times;</span>
              
                    <h2 style="text-align:center">Register</h2>
                    <div>
                        <input  id="hoten" type="text"  placeholder="Full Name" runat="server"/>
                        <input id="username" type="text"  placeholder="Username" runat="server"/>
                        <input  id="password1" type="password" placeholder="Password" runat="server"/>
                        <input id="password2" type="password"  placeholder="Repeat password" runat="server"/>
                    </div>
                    
                        <asp:Button ID="btn_dangky" CssClass="button1 btn btn-primary btn-lg btn-block login-btn" OnClick="btn_dangnhap_Click" runat="server" Text="Button" />

            
            </div>
        </div>
    </div>


         <script>
            var modalBtns = [...document.querySelectorAll(".btn")];
            modalBtns.forEach(function (btn) {
                btn.onclick = function () {
                    var modal = btn.getAttribute('data-modal');
                    document.getElementById(modal).style.display = "block";
                }
            });

            var closeBtns = [...document.querySelectorAll(".close")];
            closeBtns.forEach(function (btn) {
                btn.onclick = function () {
                    var modal = btn.closest('.modal');
                    modal.style.display = "none";
                }
            });

            window.onclick = function (event) {
                if (event.target.className === "modal") {
                    event.target.style.display = "none";
                }
            }
        </script>
    
</asp:Content>
