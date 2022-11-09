<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Informationstatus.aspx.cs" Inherits="Bakery.Informationstatus" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head >
    <title></title>
    <link href="Styles/tufte-graph.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/NewFolder1/jquery.tufte-graph.js" type="text/javascript"></script>
    <script src="Scripts/NewFolder1/jquery.enumerable.js" type="text/javascript"></script>
    <script src="Scripts/NewFolder1/raphael.js" type="text/javascript"></script>
    <script src="Scripts/NewFolder1/jquery-ui.js" type="text/javascript"></script>
    <script src="Scripts/NewFolder1/jquery-1.10.2.min.js" type="text/javascript"></script>
   
</head>
<body style="background-color:#d6ecf7">
  <usc:Header ID="Header" runat="server" />   
    <form id="form1" runat="server">
    <div>
    <div id="contentInner" >
	<br class="clear" />
	<div id="productionHistory" class="graph" style="padding-bottom: 0px; padding-top: 35px; width: 100%; height: 300px; margin-bottom: 60px;">
		<div style="position: absolute; left: 0px; bottom: 0px; width: 68.6667px;" class="label bar-label">0</div>
        <div style="position: absolute; left: 0px; top: 300px; width: 68.6667px;" class="label axis-label">25 Nov</div>
        <div style="position: absolute; left: 68.6667px; bottom: 0px; width: 68.6667px;" class="label bar-label">0</div>
        <div style="position: absolute; left: 68.6667px; top: 300px; width: 68.6667px;" class="label axis-label">26 Nov</div>
        <div style="position: absolute; left: 137.333px; bottom: 0px; width: 68.6667px;" class="label bar-label">0</div>
        <div style="position: absolute; left: 137.333px; top: 300px; width: 68.6667px;" class="label axis-label">27 Nov</div>
        <div style="position: absolute; left: 206px; bottom: 0px; width: 68.6667px;" class="label bar-label">0</div>
        <div style="position: absolute; left: 206px; top: 300px; width: 68.6667px;" class="label axis-label">28 Nov</div>
        <div style="position: absolute; left: 274.667px; bottom: 0px; width: 68.6667px;" class="label bar-label">0</div>
        <div style="position: absolute; left: 274.667px; top: 300px; width: 68.6667px;" class="label axis-label">29 Nov</div>
	</div>
	</div>
    </div>
    </form>
</body>
</html>
