<%@ Page Title="" Language="C#" MasterPageFile="~/mainTemplate.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="WebProg_3___Car_Rental_Website.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="col-xs-12 col-md-4">
            <div class="panel panel-info">
                <div class="panel-heading"><h4>Our price includes</h4></div>
                <div class="panel-body">
                        <ul>
                            <li><i class='fa fa-check tick-icon'></i>Vat (Sales Tax)</li>
                            <li><i class='fa fa-check tick-icon'></i>Unlimited Millage</li>
                            <li><i class='fa fa-check tick-icon'></i>Third Party Cover</li>
                            <li><i class='fa fa-check tick-icon'></i>Collision Damage Waiver</li>
                            <li><i class='fa fa-check tick-icon'></i>Theft Protection</li>
                        </ul>
                </div>
            </div>
            <div class="panel panel-info">
                <div class="panel-heading"><h4>Filter</h4></div>
                <div class="panel-body">
                    <div class="filter-block col-xs-4 col-md-6">
                        <label>Price</label>
                        <asp:DropDownList ID="lstPrice" CssClass="col-xs-12" runat="server">
                            <asp:ListItem Value="0" Selected="True">Low - High</asp:ListItem>
                            <asp:ListItem Value="1">High - Low</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="filter-block col-xs-4 col-md-6">
                        <label>Min No. Seats</label>
                        <asp:DropDownList ID="lstSeats" CssClass="col-xs-12" runat="server">
                            <asp:ListItem Value="0" Selected="True">- Seats -</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                            <asp:ListItem Value="7">7</asp:ListItem>
                            <asp:ListItem Value="9">9</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="filter-block col-xs-4 col-md-6">
                        <label>Doors</label>
                        <asp:DropDownList ID="lstDoors" CssClass="col-xs-12" runat="server">
                            <asp:ListItem Value="0" Selected="True">- Doors -</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="filter-block col-xs-4 col-md-6">
                        <label>Min No. Suitcases</label>
                        <asp:DropDownList ID="lstSuitcases" CssClass="col-xs-12" runat="server">
                            <asp:ListItem Value="0" Selected="True">- Suitcases -</asp:ListItem>
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="filter-block col-xs-4 col-md-6">
                        <label>Min No. Bags</label>
                        <asp:DropDownList ID="lstBags" CssClass="col-xs-12" runat="server">
                            <asp:ListItem Value="0" Selected="True">- Bags -</asp:ListItem>
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="filter-block col-xs-4 col-md-6">
                        <label>Gearbox Type</label>
                        <asp:DropDownList ID="lstGearbox" CssClass="col-xs-12" runat="server">
                            <asp:ListItem Value="0" Selected="True">- Gearbox -</asp:ListItem>
                            <asp:ListItem Value="1">Manual</asp:ListItem>
                            <asp:ListItem Value="2">Automatic</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <asp:Button ID="btnFilter" CssClass="btn btn-success col-xs-12" Text="Filter" OnClick="btnFilter_Click" runat="server" />
                </div>
            </div>
        </div>
        <div id="carListMain" class="col-xs-12 col-md-8" runat="server"></div>
    </div>
</asp:Content>
