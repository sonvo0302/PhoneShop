<%@ Page Title="" Language="C#" MasterPageFile="~/ManagementShop/AdminArea.Master" AutoEventWireup="true" CodeBehind="QuanLyTaiKhoan.aspx.cs" Inherits="PhoneShop.ManagementShop.QuanLyTaiKhoan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Mangement_Style/css_table/style.css" rel="stylesheet" />
    <link href="../UserStyle/css/LoginStyle/bootstrap.min.css" rel="stylesheet" />
    <link href="../UserStyle/css/LoginStyle/font-awesome.css" rel="stylesheet" />
    <script src="../UserStyle/js/LoginJS/bootstrap.min.js"></script>
    <script src="../UserStyle/js/LoginJS/jquery-1.9.1.min.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="clear: both"></div>
    <br />
    <br />
    <div class="col-sm-6">
        <section class="panel">
            <header class="panel-heading">
                <a class="btn btn-primary" href="#">Quản lý nhóm tài khoản</a>
                <p>Thêm tên nhóm</p>
            </header>

            <div class="form-row">
                <div class="form-group col-md-6">
                    <input type="text" id="groupname" runat="server" />
                    <asp:Button ID="btn_themGroup" CssClass="btn btn-primary btn-danger" OnClick="btn_themGroup_Click" runat="server" Text="Thêm" />
                </div>
            </div>
            <asp:DataList ID="DataList2" runat="server" CssClass="table table-striped table-advance table-hover">
                <HeaderTemplate>

                    <th><i></i>Mã nhóm</th>
                    <th><i></i>Tên nhóm</th>
                </HeaderTemplate>
                <ItemTemplate>



                    <td>
                        <asp:Label runat="server" Text='<%#Eval("Group_ID") %>'></asp:Label></td>

                    <td>
                        <asp:Label runat="server" Text='<%#Eval("GroupName") %>'></asp:Label></td>

                </ItemTemplate>
            </asp:DataList>

        </section>
    </div>
    <div class="col-lg-12">
        <section class="panel">
            <header class="panel-heading">
                <a class="btn btn-primary" href="#">Quản lý tài khoản</a>
            </header>

            <%--  <table class="table table-striped table-advance table-hover">--%>
            <%--<tbody>
                  <tr>
                    <th><i class="glyphicon glyphicon-wrench" ></i> Mã tài khoản</th>
                    <th><i class="	glyphicon glyphicon-user" ></i> Tên đăng nhập</th>
                    <th><i class="glyphicon glyphicon-lock"></i> Mật khẩu</th>
                    <th><i ></i> Nhóm tài khoản</th>
                    <th><i class="glyphicon glyphicon-cog" ></i> Lựa chọn</th>
                  </tr>--%>
            <%--<asp:GridView ID="grdTaiKhoan"  runat="server" CssClass="table table-striped table-advance table-hover" DataKeyNames="User_ID">
        <Columns>
            <asp:BoundField DataField="User_ID" HeaderText="Mã tài khoản"  />
            
            <asp:BoundField DataField="UserName" HeaderText="Tên đăng nhập"/>
           <asp:BoundField DataField="Password" HeaderText="Mật khẩu" />   
            <asp:TemplateField HeaderText="Nhóm tài khoản">                 
                  <ItemTemplate>
                      <asp:TextBox ID="TextBox1" style="float:left" Width="100px" runat="server" Text='<%# Eval("Group_ID") %>'>
                      </asp:TextBox> 
                       
                  </ItemTemplate>             
              </asp:TemplateField>
            <asp:TemplateField HeaderText="Lựa chọn">
                <ItemTemplate>
           
                      <div class="btn-group">
                          <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("User_ID") %>' CssClass="btn btn-success" OnClick="LinkButton1_Click"><i class="glyphicon glyphicon-pencil"></i></asp:LinkButton>
                        <asp:LinkButton ID="btn_xoa" CommandArgument='<%#Eval("User_ID") %>' runat="server" OnClick="btn_xoa_Click" class="btn btn-danger"><i class="glyphicon glyphicon-remove"></i></asp:LinkButton>
                      </div>
                 
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>--%>


            <asp:DataList ID="DataList1" runat="server" DataKeyField="User_ID" CssClass="table table-striped table-advance table-hover">
                <HeaderTemplate>

                    <th><i class="glyphicon glyphicon-wrench"></i>Mã tài khoản</th>
                    <th><i class="	glyphicon glyphicon-user"></i>Tên đăng nhập</th>
                    <th><i class="glyphicon glyphicon-lock"></i>Mật khẩu</th>
                    <th><i></i>Nhóm tài khoản</th>
                    <th><i class="glyphicon glyphicon-cog"></i>Lựa chọn</th>

                </HeaderTemplate>
                <ItemTemplate>



                    <td>
                        <asp:Label runat="server" Text='<%#Eval("User_ID") %>'></asp:Label></td>
                    <td>
                        <asp:Label runat="server" Text='<%#Eval("UserName") %>'></asp:Label></td>
                    <td>
                        <asp:Label runat="server" Text='<%#Eval("Password") %>'></asp:Label></td>
                    <td>
                        <asp:Label Text='<%#Eval("Group_ID") %>' runat="server"></asp:Label></td>
                    <td>
                        <div class="btn-group">
                            <asp:LinkButton ID="LinkButton1" CommandArgument='<%#Eval("User_ID") %>' CssClass="btn btn-success" OnClick="LinkButton1_Click" runat="server"><i class="glyphicon glyphicon-pencil"></i></asp:LinkButton>
                            <asp:LinkButton ID="btn_xoa" CommandArgument='<%#Eval("User_ID") %>' OnClick="btn_xoa_Click" class="btn btn-danger" runat="server"><i class="glyphicon glyphicon-remove"></i></asp:LinkButton>
                        </div>
                    </td>

                </ItemTemplate>
            </asp:DataList>
            <%--  </tbody>--%>
            <%-- </table>--%>
        </section>
    </div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:LinkButton ID="phanquyen" CssClass="list-group-item list-group-item-action bg-light " runat="server" OnClick="phanquyen_Click">Phân quyền</asp:LinkButton>
    <asp:LinkButton ID="qltaikhoan" CssClass="list-group-item list-group-item-action bg-light list-group-item-success" runat="server" OnClick="qltaikhoan_Click">Quản lý tài khoản</asp:LinkButton>
</asp:Content>
