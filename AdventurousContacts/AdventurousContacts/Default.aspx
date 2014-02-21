﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AdventurousContacts.Default" %>

<!DOCTYPE html>
<html lang="sv">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="description" content="Kontaktlista i ASP.NET Web Forms C#" />
    <meta name="author" content="Robert Roos"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Äventyrliga Kontakter</title>
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link href='http://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,700,400italic' rel='stylesheet' type='text/css'>
    <link rel="stylesheet" type="text/css" href="~/css/style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="Wrapper">    
            <header>
                <div id="HeaderMenu">
                    <a href="Default.aspx">Startsidan</a>
                </div>
            <h1>Äventyrliga Kontakter</h1>
            </header>            

            <article class="grey">
                <section>
                    <h2>Header 1</h2>
                        <p>Text</p>
                </section>
            </article>

            <article class="white">
                <section>
                    <h2>Header 2</h2>
                        <p>Text</p>
                </section>
            </article>
        </div>
        
        <footer class="site-footer">
            <div style="padding-top: 13px; padding-left: 10px;">     
                <p><span class="smaller" style="color: #ffffff; padding-top: 5px;">© Copyright 2014 - Producerad av: <a href="http://www.robertroos.eu" target="_blank">RobertRoos.eu</a></span></p>
            </div>
        </footer>
    </form>
<script type="text/javascript" src="js/scripts.js"></script>
</body>
</html>