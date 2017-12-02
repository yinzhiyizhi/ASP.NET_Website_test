<%@ Page Language="C#" AutoEventWireup="true" CodeFile="if_uploadTemp.aspx.cs" Inherits="App_Back_if_uploadTemp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        $(document).ready(function () {
            $("#img_upload").click(function(){
                $("#fup_1").click();
            });

            $("#fup_1").click(function () {
                $("#btn_upload").click();
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <img src="../App_imgs/upload.jpg" id="img_upload"/>

        <div>
            <asp:FileUpload ID="fup_1" runat="server" />
            <asp:Button ID="btn_upload" runat="server" Text="Upload" OnClick="btn_upload_Click" />
        </div>
    
    </div>
    </form>
</body>
</html>
