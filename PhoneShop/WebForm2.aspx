<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="PhoneShop.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" method="post" action="WebForm2.aspx" runat="server">
        <div>
                <asp:FileUpload ID="FileUpload1" CssClass="form-control" runat="server" />
                    <asp:Button ID="btnsave" runat="server" CssClass="btn btn-primary btn-danger" OnClick="btnsave_Click" Text="Save" Style="width: 85px" />
                    <asp:Label ID="lblthongbao" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
