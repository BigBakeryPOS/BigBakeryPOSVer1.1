﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Billing.Accountsbootstrap.login" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Bakery POS - Login</title>


   <style type="text/css">




div.main{
    /*background: #0c693c; /* Old browsers */
       background: #428bca; /* Old browsers */
height:calc(100vh);
width:100%;
}

[class*="fontawesome-"]:before {
  font-family: 'FontAwesome', sans-serif;
}

/* ---------- GENERAL ---------- */

* {
  box-sizing: border-box;
    margin:0px auto;

  &:before,
  &:after {
    box-sizing: border-box;
  }

}

body {
   
    color: #606468;
  font: 87.5%/1.5em 'Open Sans', sans-serif;
  margin: 0;
}

a {
	color: #eee;
	text-decoration: none;
}

a:hover {
	text-decoration: underline;
}

input {
	border: none;
	font-family: 'Open Sans', Arial, sans-serif;
	font-size: 14px;
	line-height: 1.5em;
	padding: 0;
	-webkit-appearance: none;
}

p {
	line-height: 1.5em;
}

.clearfix {
  *zoom: 1;

  &:before,
  &:after {
    content: ' ';
    display: table;
  }

  &:after {
    clear: both;
  }

}

.container {
  left: 50%;
  position: fixed;
  top: 50%;
  transform: translate(-50%, -50%);
}

/* ---------- LOGIN ---------- */

#login form{
	width: 250px;
}
#login, .logo{
    display:inline-block;
    width:40%;
}
#login{
border-right:1px solid #fff;
  padding: 0px 22px;
  width: 59%;
}
.logo{
color:#fff;
font-size:50px;
  line-height: 125px;
}

#login form span.fa {
	background-color: #fff;
	border-radius: 3px 0px 0px 3px;
	color: #000;
	display: block;
	float: left;
	height: 50px;
    font-size:24px;
	line-height: 50px;
	text-align: center;
	width: 50px;
}

#login form input {
	height: 50px;
}
fieldset{
    padding:0;
    border:0;
    margin: 0;

}
#login form input[type="text"], input[type="password"] {
	background-color: #fff;
	border-radius: 0px 3px 3px 0px;
	color: #000;
	margin-bottom: 1em;
	padding: 0 16px;
	width: 200px;
}

#login form input[type="submit"] {
  border-radius: 3px;
  -moz-border-radius: 3px;
  -webkit-border-radius: 3px;
  background-color: #000000;
  color: #eee;
  font-weight: bold;
  /* margin-bottom: 2em; */
  text-transform: uppercase;
  padding: 5px 10px;
  height: 30px;
}

#login form input[type="submit"]:hover {
	/*background-color: #d44179;*/
	
}

#login > p {
	text-align: center;
}

#login > p span {
	padding-left: 5px;
}
.middle {
  display: flex;
  width: 600px;
}
#login form span.fa {
	background-color: #fff;
	border-radius: 3px 0px 0px 3px;
	color: #000;
	display: block;
	float: left;
	height: 50px;
    font-size:24px;
	line-height: 50px;
	text-align: center;
	width: 50px;
}
 
.fa-user-o:before{content:"\f2c0"}
.fa-users:before{content:"\f0c0"}
.fa-user-md:before{content:"\f0f0"}
.fa-user-plus:before{content:"\f234"}


.fa-user:before
{
    
    content:"\f007";
   
    
    
    }
    
    .fa-lock:before
    {
        content:"\f023"}
        
       .topform{
  border-bottom:2px solid lightgrey;
  margin:0px;
  background-image: url('../images/user.png');
  background-repeat: no-repeat;
  background-color:white;
  background-size: 9%;
  background-position: 50% 50%;
}




.bottomform{
  margin-top:0px;
  margin-bottom:20px;
  background-image: url('../images/pass.png');
  background-repeat: no-repeat;
  background-color:white;
  background-size: 10%;
  background-position: 50% 50%;
}
   </style>

   
    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="css/newstyl.css" rel="stylesheet" type="text/css" />
    <link href="css/newstyl.css" rel="stylesheet" type="text/css" />
    <link href="//maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css" rel="stylesheet">

     <script src="../js/JQry.js" type="text/javascript"></script>
    <script src="../js/index.js" type="text/javascript"></script>
</head>
<body style="background-color:White">     
     




   
<div class="main">  <div align="center">
       <label style="color:White">MAC ADDRESS:</label><asp:Label  ID="macaddress" runat="server" style="color:White"></asp:Label></div>
    <div class="container">
      <div align="center"><asp:Image ID="Image1" ImageUrl="../images/BlackForrestRe.png" Width="150px" runat="server"  Visible="false"  />
      
      
<center>
<div class="middle">
      <div id="login">
    
         <form id="form1" runat="server">

          <fieldset class="clearfix">

        
           
           
            <p> <span class="fa fa-user"></span><asp:TextBox  ID="username" runat="server"  Placeholder="UserName "></asp:TextBox>
            <p> <span class="fa fa-lock"></span><asp:TextBox  ID="password" runat="server"  Placeholder="PassWord" TextMode="Password"></asp:TextBox>
                     <p> <span class="fa fa-lock"></span><asp:TextBox  ID="txtemp" runat="server"  Placeholder="Name"></asp:TextBox>  
            <%--<input type="password"  Placeholder="Password" required>--%></p> <!-- JS because of IE support; better: placeholder="Password" -->
            
             <div>
                                <span style="width:48%; text-align:left;  display: inline-block;"><a class="small-text" href="#">Forgot
                                password?</a></span>
                                <span style="width:50%; text-align:right;  display:  inline-block;"><asp:Button   OnClick="LoginButton_Click" id="btn" Text="Sign-In" runat="server" />
                                <%--<input type="submit" value="Sign In">--%></span>
                            </div>

          </fieldset>
<div class="clearfix"></div>
        </form>

        <div class="clearfix"></div>

      </div> <!-- end login -->
      <div class="logo" style="padding-top:22px" ><asp:Image ID="log" ImageUrl="../images/BlackForrestRe.png"  Width="150px" runat="server" style="margin-left: 20px;"  />
          
          <div class="clearfix"></div>
      </div>
      
      </div>
</center>
    </div>

</div>
















    
  
</body>
</html>
