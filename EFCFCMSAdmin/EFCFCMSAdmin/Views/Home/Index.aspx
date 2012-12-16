﻿<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: ViewBag.Message %></h2>
    <p>
        To learn more about ASP.NET MVC visit <a href="http://asp.net/mvc" title="ASP.NET MVC Website">http://asp.net/mvc</a>.
    </p>

    <p>
        To learn more about working with the Telerik Extensions for ASP.NET MVC, you can visit the folowing resources:
    </p>
    <ul>
        <li><a href="http://demos.telerik.com/aspnet-mvc/">online demos</a></li>
        <li><a href="http://www.telerik.com/help/aspnet-mvc/introduction.html">online documentation</a></li>
        <li><a href="http://www.telerik.com/community/forums/aspnet-mvc.aspx">community forums</a></li>
        <li><a href="http://tv.telerik.com/products/aspnet-mvc">videos on Telerik TV</a></li>
    </ul>
</asp:Content>
