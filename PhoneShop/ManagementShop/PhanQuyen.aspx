<%@ Page Title="" Language="C#" MasterPageFile="~/ManagementShop/AdminArea.Master" AutoEventWireup="true" CodeBehind="PhanQuyen.aspx.cs" Inherits="PhoneShop.ManagementShop.PhanQuyen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .table-1{
            margin:0 auto;
        }
        .auto-style1{
            width:20px;
        }
        .auto-style2 {
            width: 235px;
        }
        .auto-style3 {
            width: 100px;
        }
        .auto-style4 {
            width: 50%;
            height: 165px;
        }
        .auto-style5 {
            height: 26px;
            width:593px;
        }
        .auto-style6 {
            margin-top: 0px;
            padding: 10px;
        }
        .auto-style7 {
            width: 104px;
        }
        .auto-style8 {
            height: 26px;
            width: 104px;
        }
       
    </style>
    <script src="Mangement_Style/js/jquery.2.1.4.js"></script>
    <script src="Mangement_Style/js/jquery.min.1.8.3.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script type="text/javascript">  
                $(function()  
                  {  
                    $("[id*=trview_grant] input[type=checkbox]").bind("click", function()  
                        {  
                        var table = $(this).closest("table");  
                        if (table.next().length > 0 && table.next()[0].tagName == "DIV")  
                        {  
                            var childDiv = table.next();  
                            var isChecked = $(this).is(":checked");  
                            $("input[type=checkbox]", childDiv).each(function()  
                                {  
                                if (isChecked)  
                                {  
                                    $(this).attr("checked", "checked");   
                                } else   
                                {  
                                    $(this).removeAttr("checked"); 
                                }  
                            });  
                        } else   
                        {  
                            var parentDIV = $(this).closest("DIV");  
                            if ($("input[type=checkbox]", parentDIV).length == $("input[type=checkbox]:checked", parentDIV).length) {  
                                $("input[type=checkbox]", parentDIV.prev()).attr("checked", "checked");  
                            } else  
                            {  
                                $("input[type=checkbox]", parentDIV.prev()).removeAttr("checked");  
                            }  
                        }  
                    });  
                })  
            </script>  
   
    <table style="width: 100%;" class="table-1">
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>
                <asp:DropDownList ID="drpd_NhomNguoi" runat="server"  AutoPostBack="True"  OnSelectedIndexChanged="drpd_NhomNguoi_SelectedIndexChanged" Width="198px"  AppendDataBoundItems="True">
                </asp:DropDownList>
               
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>
                <table>
                    <tr>
                        <td class="auto-style2">
                            <asp:ListBox ID="lst_Left" runat="server" CssClass="auto-style6" Height="142px" SelectionMode="Multiple" Width="235px"></asp:ListBox>
                        </td>
                        <td class="auto-style3">
                            <table class="auto-style4">
                                <tr>
                                    <td>
                                        <asp:Button ID="btn_Next" CssClass="btn btn-primary btn-danger" runat="server" OnClick="btn_Next_Click" Text="&gt;" Width="80px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btn_NextAll" CssClass="btn btn-primary btn-danger" runat="server" Text="&gt;&gt;" Width="80px" OnClick="btn_NextAll_Click"  />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btn_Back" CssClass="btn btn-primary btn-danger" runat="server" Text="&lt;" Width="80px" OnClick="btn_Back_Click"  />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btn_BackAll" CssClass="btn btn-primary btn-danger" runat="server" Text="&lt;&lt;" Width="80px" OnClick="btn_BackAll_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="auto-style2">
                            <asp:ListBox ID="lst_Box2" runat="server" Height="142px" SelectionMode="Multiple" Width="235px" OnSelectedIndexChanged="lst_Box2_SelectedIndexChanged"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style7">&nbsp;</td>
                        <td class="auto-style3">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style5 list-group-item-light border" colspan="3">
                            <asp:TreeView ID="trview_grant" runat="server" CssClass="MyTreeView" Height="313px" OnTreeNodeCheckChanged="trview_grant_TreeNodeCheckChanged" OnSelectedNodeChanged="trview_grant_SelectedNodeChanged" ShowCheckBoxes="All" Width="593px">
                            </asp:TreeView>
                             <asp:Button ID="btn_Save" CssClass="btn btn-primary btn-success float-right" runat="server" Height="42px" Text="Save" Width="117px" OnClick="btn_Save_Click" />
                             </td>
                            </tr>
                      
                </table>
            </td>
            <td>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <%--<a href="PhanQuyen.aspx" class="list-group-item list-group-item-action bg-light list-group-item-success">Phân quyền</a>
        <a href="QuanLyTaiKhoan.aspx" class="list-group-item list-group-item-action bg-light">Quản lý tài khoản</a>--%>
    <asp:LinkButton ID="phanquyen" CssClass="list-group-item list-group-item-action bg-light list-group-item-success" runat="server" OnClick="phanquyen_Click">Phân quyền</asp:LinkButton>
          <asp:LinkButton ID="qltaikhoan" CssClass="list-group-item list-group-item-action bg-light" runat="server" OnClick="qltaikhoan_Click">Quản lý tài khoản</asp:LinkButton>
</asp:Content>
