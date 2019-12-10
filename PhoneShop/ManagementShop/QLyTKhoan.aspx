<%@ Page Title="" Language="C#" MasterPageFile="~/ManagementShop/AdminArea.Master" AutoEventWireup="true" CodeBehind="QLyTKhoan.aspx.cs" Inherits="PhoneShop.ManagementShop.QLyTKhoan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Mangement_Style/css_table/style.css" rel="stylesheet" />
<%--    <link href="Mangement_Style/css/bootstrap.min.css" rel="stylesheet" />--%>
   <link href="../UserStyle/css/LoginStyle/bootstrap.min.css" rel="stylesheet" />
<%--    <link href="../UserStyle/css/LoginStyle/font-awesome.css" rel="stylesheet" />
    <script src="../UserStyle/js/LoginJS/bootstrap.min.js"></script>
    <script src="../UserStyle/js/LoginJS/jquery-1.9.1.min.js"></script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
  <asp:LinkButton ID="phanquyen" CssClass="list-group-item list-group-item-action bg-light " runat="server" OnClick="phanquyen_Click">Phân quyền</asp:LinkButton>
          <asp:LinkButton ID="qltaikhoan" CssClass="list-group-item list-group-item-action bg-light" runat="server" OnClick="qltaikhoan_Click">Quản lý tài khoản</asp:LinkButton>
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server">
        <Columns>
            <asp:BoundField DataField="User_ID" HeaderText="Mã tài khoản" />
           <asp:BoundField DataField="UserName" HeaderText="Tên đăng nhập " />
            <asp:BoundField DataField="Password" HeaderText="Mật khẩu" />
            <%--<asp:TemplateField HeaderText="Nhóm tài khoản">
                <ItemTemplate>
                    <asp:TextBox DataField="Group_ID" Text='<%#Eval("Group_ID") %>' runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>--%>
            <%--<asp:TemplateField HeaderText="Lựa chọn">
                <ItemTemplate>
                 <div class="btn-group">
                          <asp:LinkButton ID="btn_sua" runat="server" CommandArgument='<%#Eval("User_ID") %>' CssClass="btn btn-success" OnClick="btn_sua_Click"><i class="glyphicon glyphicon-pencil"></i></asp:LinkButton>
                        <asp:LinkButton ID="btn_xoa" CommandArgument='<%#Eval("User_ID") %>' runat="server" OnClick="btn_xoa_Click" class="btn btn-danger"><i class="glyphicon glyphicon-remove"></i></asp:LinkButton>
                      </div>
                    </ItemTemplate>
            </asp:TemplateField>--%>
        </Columns>
    </asp:GridView>  
   
</asp:Content>
