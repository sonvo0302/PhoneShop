<%@ Page Title="" Language="C#" MasterPageFile="~/ChiTietMaster.Master" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="PhoneShop.DangNhap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="UserStyle/css/LoginStyle/login.css" rel="stylesheet" />
    <link href="UserStyle/css/LoginStyle/bootstrap.min.css" rel="stylesheet" />
    <link href="UserStyle/css/LoginStyle/font-awesome.css" rel="stylesheet" />
    <script src="UserStyle/js/LoginJS/bootstrap.min.js"></script>
    <script src="UserStyle/js/LoginJS/jquery-1.9.1.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main">
        <div class="content">
            <div class="content_top">
    
        <div class="container-fluid">
 <div class="row-fluid"> 
  <div class="col-md-offset-4 col-md-4"> 
   <h2>Chào mừng bạn đến với Phone Shop. Đăng nhập ngay</h2> 
   <hr> 
    <fieldset> 
     <div class="form-group"> 
      <div class="col-md-12"> 
       <div class="input-group"> <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span> <input  placeholder="Username" id="username"  class="form-control" type="text" runat="server"/> 
       </div> 
      </div> 
     </div> 
     <div class="form-group"> 
      <div class="col-md-12"> 
       <div class="input-group"> <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span> <input  placeholder="Password" id="password"  class="form-control" type="password" runat="server"/> 
       </div> 
      </div> 
     </div> 
     <div class="form-group"> 
      <div class="col-md-12"> 
       <asp:Button class="btn btn-md btn-danger pull-right" runat="server" ID="Button1" Text="Đăng nhập" OnClick="Button1_Click" />
      </div> 
     </div> 
    </fieldset> 
  </div> 
 </div>
            </div>
        </div>
   </div></div>
</asp:Content>
