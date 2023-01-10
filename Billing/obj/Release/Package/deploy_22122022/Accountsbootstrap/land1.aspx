<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="land1.aspx.cs" Inherits="chitfund_admin.files.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table style="margin-bottom:25px;">
    
    <tr>
    <td><label>Name</label></td>
    <td> <asp:TextBox CssClass="form-control" ID="txtcustname"  runat="server"></asp:TextBox></td>
    </tr>

    <tr>
    <td><label>Project Name</label></td>
    <td><asp:TextBox CssClass="form-control" ID="txtproname"  runat="server"></asp:TextBox></td>
    </tr>

    <tr>
    <td><label>Plot No</label></td>
    <td><asp:TextBox class="form-control" ID="txtplotno" runat="server"></asp:TextBox></td>
    </tr>

    <tr>
    <td><label>Plan Type</label></td>
    <td><asp:TextBox CssClass="form-control" ID="txtplantype"  runat="server"></asp:TextBox></td>
    </tr>
    
    
    </table>


    <table border="1px;" style="margin-left:25px">
        <tr>
        <td><label>S.No</label></td>
        <td align="center"><label>Particulars</label></td>
        <td align="center"><label>Square.Feet</label></td>
        <td align="center"><label>Rate</label></td>
        <td align="center"><label>Total</label></td>
        </tr>

        <tr>
        <td><label>1</label></td>
        <td><label>Total Area Rate</label></td>
        <td><asp:TextBox CssClass="form-control" ID="txtTotalAreaSq"  runat="server"></asp:TextBox></td>
        <td><asp:TextBox CssClass="form-control" ID="txtTotalAreaRate"  runat="server"></asp:TextBox></td>
        <td><asp:TextBox CssClass="form-control" ID="txtTotalAreaTotal"  runat="server"></asp:TextBox></td>
        </tr>

        <tr>
        <td><label>2</label></td>
        <td><label>Plinth Area Rate</label></td>
        <td><asp:TextBox CssClass="form-control" ID="txtPlinthSq"  runat="server"></asp:TextBox></td>
        <td><asp:TextBox CssClass="form-control" ID="txtPlinthAreaRate"  runat="server"></asp:TextBox></td>
        <td><asp:TextBox CssClass="form-control" ID="txtPlinthTotal"  runat="server"></asp:TextBox></td>
        </tr>

        <tr>
        <td><label>3</label></td>
        <td><label>Head Room Charge</label></td>
        <td><asp:TextBox CssClass="form-control" ID="txtHeadSq"  runat="server"></asp:TextBox></td>
        <td><asp:TextBox CssClass="form-control" ID="txtHeadRate"  runat="server"></asp:TextBox></td>
        <td><asp:TextBox CssClass="form-control" ID="txtHeadTotal"  runat="server"></asp:TextBox></td>
        </tr>

        <tr>
        <td><label>4</label></td>
        <td><label>Land Registration</label></td>
        <td><asp:TextBox CssClass="form-control" ID="txtLandSq"  runat="server"></asp:TextBox></td>
        <td><asp:TextBox CssClass="form-control" ID="txtLandRate"  runat="server"></asp:TextBox></td>
        <td><asp:TextBox CssClass="form-control" ID="txtLandTotal"  runat="server"></asp:TextBox></td>
        </tr>

        <tr>
        <td><label></label></td>
        <td><label>Plan Approval Charges</label></td>
        <td><asp:TextBox CssClass="form-control" ID="txtPlanSq"  runat="server"></asp:TextBox></td>
        <td><asp:TextBox CssClass="form-control" ID="txtPlanRate"  runat="server"></asp:TextBox></td>
        <td><asp:TextBox CssClass="form-control" ID="txtPlanTotal"  runat="server"></asp:TextBox></td>
        </tr>

        <tr>
        <td><label></label></td>
        <td><label>EB III Phase Connection Charges</label></td>
        <td><asp:TextBox CssClass="form-control" ID="txt3PhaseSq"  runat="server"></asp:TextBox></td>
        <td><asp:TextBox CssClass="form-control" ID="txt3PhaseRate"  runat="server"></asp:TextBox></td>
        <td><asp:TextBox CssClass="form-control" ID="txt3phaseTotal"  runat="server"></asp:TextBox></td>
        </tr>

        <tr>
        <td><label></label></td>
        <td><label>Driange Work</label></td>
        <td><asp:TextBox CssClass="form-control" ID="txtDriangeSq"  runat="server"></asp:TextBox></td>
        <td><asp:TextBox CssClass="form-control" ID="txtDriangeRate"  runat="server"></asp:TextBox></td>
        <td><asp:TextBox CssClass="form-control" ID="txtDriangeTotal"  runat="server"></asp:TextBox></td>
        </tr>

        <tr>
        <td><label></label></td>
        <td><label>House Tax</label></td>
        <td><asp:TextBox CssClass="form-control" ID="txtHouseSq"  runat="server"></asp:TextBox></td>
        <td><asp:TextBox CssClass="form-control" ID="txtHouseRate"  runat="server"></asp:TextBox></td>
        <td><asp:TextBox CssClass="form-control" ID="txtHouseTotal"  runat="server"></asp:TextBox></td>
        </tr>
       
        <tr>
        <td><label>5</label></td>
        <td><label>Ground Floor Cupboard Work</label></td>
        <td><asp:TextBox CssClass="form-control" ID="txtGFSq"  runat="server"></asp:TextBox></td>
        <td><asp:TextBox CssClass="form-control" ID="txtGFRate"  runat="server"></asp:TextBox></td>
        <td><asp:TextBox CssClass="form-control" ID="txtGFTotal"  runat="server"></asp:TextBox></td>
        </tr>

        <tr>
        <td><label>6</label></td>
        <td><label>First Floor House Rate</label></td>
        <td><asp:TextBox CssClass="form-control" ID="txtFFSq"  runat="server"></asp:TextBox></td>
        <td><asp:TextBox CssClass="form-control" ID="txtFFRate"  runat="server"></asp:TextBox></td>
        <td><asp:TextBox CssClass="form-control" ID="txtFFTotal"  runat="server"></asp:TextBox></td>
        </tr>

        <tr>
        <td><label>7</label></td>
        <td><label>First Floor Plan Approval Charge</label></td>
        <td><asp:TextBox CssClass="form-control" ID="txtFFPlanSq"  runat="server"></asp:TextBox></td>
        <td><asp:TextBox CssClass="form-control" ID="txtFFplanRate"  runat="server"></asp:TextBox></td>
        <td><asp:TextBox CssClass="form-control" ID="txtFFPlanTotal"  runat="server"></asp:TextBox></td>
        </tr>

        <tr>
        <td><label>8</label></td>
        <td><label>Compound Wall Work</label></td>
        <td><asp:TextBox CssClass="form-control" ID="txtWallSq"  runat="server"></asp:TextBox></td>
        <td><asp:TextBox CssClass="form-control" ID="txtWallRate"  runat="server"></asp:TextBox></td>
        <td><asp:TextBox CssClass="form-control" ID="txtWallTotal"  runat="server"></asp:TextBox></td>
        </tr>

        <tr>
        <td><label></label></td>
        <td><label>TOTAL</label></td>
        <td><asp:TextBox CssClass="form-control" ID="txtTotalSq"  runat="server"></asp:TextBox></td>
        <td><asp:TextBox CssClass="form-control" ID="txtTotalRate"  runat="server"></asp:TextBox></td>
        <td><asp:TextBox CssClass="form-control" ID="txtTotalTotal"  runat="server"></asp:TextBox></td>
        </tr>

       
       
       </table>
    </div>
    </form>
</body>
</html>
