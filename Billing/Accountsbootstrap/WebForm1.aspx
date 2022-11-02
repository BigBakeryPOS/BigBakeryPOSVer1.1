<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="EditableDropDownListTest.WebForm1" %>

<%@ Register Assembly="EditableDropDownList" Namespace="EditableControls" TagPrefix="editable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <table border="0" cellpadding="2" cellspacing="2">
        <tr>
            <td>Update Panel</td>
            <td>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" >
                <ProgressTemplate>
                <asp:Label ID="lblLoading" runat="server" Text="Loading..." ForeColor="Red" ViewStateMode="Disabled"></asp:Label>
                </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        </table>
        <div style="border: 1px solid #120A8F; margin: 5px; padding: 5px; float: left; clear: both;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            Example 1 - Manual Items
            <br />
            Greek Alphabet 
                <editable:EditableDropDownList ID="EditableDropDownList1" 
                    runat="server" Width="100"
                    ontextchanged="EditableDropDownList_TextChanged" 
                    ononclick="EditableDropDownList_OnClick">
                <asp:ListItem Text="Alpha" Value="Aα"></asp:ListItem>
                <asp:ListItem Text="Beta" Value="Ββ"></asp:ListItem>
                <asp:ListItem Text="Gamma" Value="Γγ"></asp:ListItem>
                <asp:ListItem Text="Delta" Value="Δδ"></asp:ListItem>
                <asp:ListItem Text="Epsilon" Value="Εε"></asp:ListItem>
                <asp:ListItem Text="Zeta" Value="Ζζ"></asp:ListItem>
                <asp:ListItem Text="Eta" Value="Ηη"></asp:ListItem>
                <asp:ListItem Text="Theta" Value="Θθ"></asp:ListItem>
                <asp:ListItem Text="Iota" Value="Ιι"></asp:ListItem>
                <asp:ListItem Text="Kappa" Value="Κκ"></asp:ListItem>
                <asp:ListItem Text="Lambda" Value="Λλ"></asp:ListItem>
                <asp:ListItem Text="Mu" Value="Μμ"></asp:ListItem>
                <asp:ListItem Text="Nu" Value="Νν"></asp:ListItem>
                <asp:ListItem Text="Xi" Value="Ξξ"></asp:ListItem>
                <asp:ListItem Text="Omicron" Value="Οο"></asp:ListItem>
                <asp:ListItem Text="Pi" Value="Ππ"></asp:ListItem>
                <asp:ListItem Text="Rho" Value="Ρρ"></asp:ListItem>
                <asp:ListItem Text="Sigma" Value="Σσς"></asp:ListItem>
                <asp:ListItem Text="Tau" Value="Ττ"></asp:ListItem>
                <asp:ListItem Text="Upsilon" Value="Υυ"></asp:ListItem>
                <asp:ListItem Text="Phi" Value="Φφ"></asp:ListItem>
                <asp:ListItem Text="Chi" Value="Χχ"></asp:ListItem>
                <asp:ListItem Text="Psi" Value="Ψψ"></asp:ListItem>
                <asp:ListItem Text="Omega" Value="Ωω"></asp:ListItem>
            </editable:EditableDropDownList>
            <br /><br /><br />
            Example 2 - Standard Datasource
            <br />
            Greetings <editable:EditableDropDownList ID="EditableDropDownList2" runat="server" 
                    Sorted="true" 
                    ontextchanged="EditableDropDownList_TextChanged" 
                    ononclick="EditableDropDownList_OnClick">
            </editable:EditableDropDownList>
            <br /><br /><br />
            Example 3 - Custom Datasource
            <br />
            Web Controls 
                <editable:EditableDropDownList ID="EditableDropDownList3" 
                    runat="server" Width="250" Sorted="true" 
                    ontextchanged="EditableDropDownList_TextChanged" 
                    ononclick="EditableDropDownList_OnClick">
            </editable:EditableDropDownList>
            <br /><br /><br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
                onclick="btnSubmit_Click" />
            <br /><br />
            <asp:GridView ID="grdResults" runat="server" CellSpacing="3" CellPadding="1">
            </asp:GridView>
            <asp:Label ID="lblInfo" runat="server" ViewStateMode="Disabled" ForeColor="Blue" ></asp:Label>
            </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </asp:Content>
