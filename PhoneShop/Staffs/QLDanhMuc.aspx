<%@ Page Title="" Language="C#" MasterPageFile="~/Staffs/StaffManagement.Master" AutoEventWireup="true" CodeBehind="QLDanhMuc.aspx.cs" Inherits="PhoneShop.Staffs.QLDanhMuc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Mangement_Style/css_table/style.css" rel="stylesheet" />
    <link href="../UserStyle/css/LoginStyle/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-12">
        <section class="panel">
            <header class="panel-heading">
                <a class="btn btn-primary" href="#">Quản lý danh mục</a>
               
            </header>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <span>Thêm tên danh mục cha&nbsp;&nbsp;&nbsp;</span><input type="text" id="danhmuccha" runat="server" />
                    <asp:Button ID="btn_themDMCha" CssClass="btn btn-primary btn-danger" OnClick="btn_themDMCha_Click" runat="server" Text="Thêm" />
                </div>
            </div>
            <asp:DataList ID="DataList1" runat="server" CssClass="table table-striped table-advance table-hover">
                <HeaderTemplate>

                    <th><i></i>Mã danh mục</th>
                    <th><i ></i>Tên danh mục</th>
                    <th><i ></i>Mã danh mục cha</th>
                </HeaderTemplate>
                <ItemTemplate>



                    <td>
                        <asp:Label runat="server" Text='<%#Eval("DanhMuc_ID") %>'></asp:Label></td>
                    <td>
                        <asp:Label runat="server" Text='<%#Eval("TenDanhMuc") %>'></asp:Label></td>
                    <td>
                        <asp:Label runat="server" Text='<%#Eval("Parent_ID") %>'></asp:Label></td>
                   <%-- <td>
                        <div class="btn-group">
                            
                            <asp:LinkButton ID="btn_sua_danhmuc" runat="server" CommandArgument='<%#Eval("DanhMuc_ID") %>' CssClass="btn btn-success" OnClick="btn_sua_danhmuc_Click"><i class="glyphicon glyphicon-pencil"></i></asp:LinkButton>
                            <asp:LinkButton ID="btn_xoa_dm" runat="server" CommandArgument='<%#Eval("DanhMuc_ID") %>' CssClass="btn btn-danger" OnClick="btn_xoa_dm_Click"><i class="glyphicon glyphicon-remove"></i></asp:LinkButton>

                        </div>
                    </td>--%>

                </ItemTemplate>
            </asp:DataList>

        </section>

    </div>
</asp:Content>
