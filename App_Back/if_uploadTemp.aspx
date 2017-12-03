<%@ Page Language="C#" AutoEventWireup="true" CodeFile="if_uploadTemp.aspx.cs" Inherits="App_Back_if_uploadTemp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../App_style/CSS_b_albumHome.css" rel="stylesheet" />
    <script src="../App_script/jquery-3.2.1.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#img_upload").click(function(){
                $("#fup_1").click();
            });

            $("#fup_1").change(function () {
                $("#btn_upload").click();
            });
        });


        function showPopup(_fname) {
            var _img = parent.document.getElementById("img_preview");
            var _txt = parent.document.getElementById("txt_temp");
            var _btn = parent.document.getElementById("btn_showMpop");
            $(_txt).val(_fname);
            $(_img).attr("src", _fname);
            $(_btn).click();
        }
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
