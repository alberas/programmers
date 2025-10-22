<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="Programmers._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <div>
            <asp:TextBox id="InptTxtNumber" runat="server"/>
            <asp:Button id="BtnAction" Text="Write number" runat="server"/>
        </div>
        <asp:Label ID="LblNumber" runat="server"></asp:Label>
    </main>

</asp:Content>
