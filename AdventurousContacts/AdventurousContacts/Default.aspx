<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AdventurousContacts.Default" %>

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
                    <h2>Kontaktlista</h2>
                    <asp:ListView ID="ContactListView" runat="server" ItemType="AdventurousContacts.Models.Contact" SelectMethod="ContactListView_GetData" DataKeyNames="ContactID">
                        <LayoutTemplate>
                            <table class="normalTable">
                                <tr class="normalTableHeader">
                                    <th>
                                        Förnamn
                                    </th>
                                    <th>
                                        Efternamn
                                    </th>
                                    <th>
                                        Epost
                                    </th>
                                </tr>
                        <%-- Platshållare varje rad i tabellen --%>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <%-- Mall för varje rad i databasen, dvs varje rad i tabellen som loopas fram.  --%>
                            <tr>
                                <td><%#: Item.FirstName %></td>
                                <td><%#: Item.LastName %></td>
                                <td><%#: Item.EmailAddress %></td>
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <%-- Om inget finns i databasen presenteras detta istället.  --%>
                            <p>Inga kontakter finns inlagda i databasen just nu.</p>
                        </EmptyDataTemplate>
                    </asp:ListView>
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