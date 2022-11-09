<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login_Branch.aspx.cs" Inherits="Billing.Accountsbootstrap.Login_Branch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <!-- Somehow I got an error, so I comment the title, just uncomment to show -->
    <!-- <title>Transparent Login Form UI</title> -->
    <link href="../css/Loginstore.css" rel="stylesheet" type="text/css" />
    <script src="https://kit.fontawesome.com/a076d05399.js"></script>
</head>
<body>
    <body>
        <div align="center">
            <label style="color: White">
                MAC ADDRESS:</label><asp:Label ID="macaddress" runat="server" Style="color: White"></asp:Label></div>
        <div class="login-box">
            <img src="../css/avatar.png" class="avatar">
            <h1>
                Login Here</h1>
            <form id="Form1" runat="server">
            <p>
                Username</p>
            <asp:TextBox ID="username" runat="server" AutoComplete="Off" Placeholder="UserName "></asp:TextBox>
            <p>
                Password</p>
            <asp:TextBox ID="password" runat="server" Placeholder="PassWord" AutoComplete="Off" TextMode="Password"></asp:TextBox>
            <p>
                Emp Code</p>
            <asp:TextBox ID="txtemp" runat="server" TextMode="Password" AutoComplete="Off" Placeholder="EmpName"></asp:TextBox>
            <%--<input type="submit" name="submit" value="Login">--%>
            <asp:Button BackColor="#1c8adb" OnClick="LoginButton_Click" ID="btn" Text="Submit"
                runat="server" />
            </form>
        </div>
    </body>
    <%--  <div class="login-box">
    <img src="avatar.png" class="avatar">
        <h1>Login Here</h1>
             <form id="form1" runat="server">
            <div class="field">
                <span class="fa fa-user"></span>
                
            </div>
            <div class="field space">
                <span class="fa fa-lock"></span>
                <asp:TextBox ID="password" runat="server" Placeholder="PassWord" TextMode="Password"></asp:TextBox>
                <span class="show">SHOW</span>
            </div>
            <div class="field space">
                <span class="fa fa-user"></span>
                <asp:TextBox ID="txtemp" runat="server" TextMode="Password" Placeholder="EmpName"></asp:TextBox>
            </div>
            <div class="pass">
                <a href="#">Forgot Password?</a>
            </div>
            <div runat="server" visible="false" class="field">
                <asp:Button BackColor="#d65357" OnClick="LoginButton_Click" ID="btn" Text="Sign-In"
                    runat="server" />
            </div>
            </form>
            <div runat="server" visible="false" class="login">
                Or login with</div>
            <div runat="server" visible="false" class="links">
                <div class="facebook">
                    <i class="fab fa-facebook-f"><span>Facebook</span></i>
                </div>
                <div class="instagram">
                    <i class="fab fa-instagram"><span>Instagram</span></i>
                </div>
            </div>
            <div class="signup">
                Don't have account? <a href="#">Signup Now</a>
            </div>
        </div>
    <script>
      const pass_field = document.querySelector('.pass-key');
      const showBtn = document.querySelector('.show');
      showBtn.addEventListener('click', function(){
       if(pass_field.type === "password"){
         pass_field.type = "text";
         showBtn.textContent = "HIDE";
         showBtn.style.color = "#3498db";
       }else{
         pass_field.type = "password";
         showBtn.textContent = "SHOW";
         showBtn.style.color = "#222";
       }
      });
    </script>--%>
</body>
</html>
