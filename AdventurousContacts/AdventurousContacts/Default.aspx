﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AdventurousContacts.Default" ViewStateMode="Disabled" %>

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
            
            <div id="MessageWrapper">
                <article id="StatusMessage" class="green" runat="server" visible="false">
                    <section>
                        <h2><asp:Literal ID="StatusLitteral" runat="server"></asp:Literal></h2>
                        <a href="#" id="CloseMessage">Stäng meddelande</a> 
                    </section>
                </article>            
            </div>            

            <article class="grey">
                <section>
                    <h2>Kontaktlista</h2>
                    <%-- Platshållare för valideringssummering om något gått på tok. --%>
                    <asp:ValidationSummary runat="server" HeaderText="Följande fel inträffade vid din begäran" CssClass="validation-summary-error" />

                    <asp:ListView ID="ContactListView" runat="server" ItemType="AdventurousContacts.Models.Contact" SelectMethod="ContactListView_GetData" DataKeyNames="ContactID" 
                        InsertMethod="ContactListView_InsertItem" UpdateMethod="ContactListView_UpdateItem" DeleteMethod="ContactListView_DeleteItem" InsertItemPosition="FirstItem">
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
                                    <th>
                                        Hantering
                                    </th>
                                </tr>
                        <%-- Platshållare varje rad i tabellen. --%>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                            </table>
                            <div id="sitePaging">
                                <asp:DataPager ID="DataPager" runat="server" PageSize="20" QueryStringField="Page">
                                    <Fields>
                                        <asp:NextPreviousPagerField ShowFirstPageButton="True" FirstPageText=" Första " ShowNextPageButton="False" ShowPreviousPageButton="True" ButtonType="Button"  />
                                        <asp:NumericPagerField ButtonType="Link" />
                                        <asp:NextPreviousPagerField ShowLastPageButton="True" LastPageText=" Sista " ShowNextPageButton="True" ShowPreviousPageButton="False" ButtonType="Button"  />
                                    </Fields>
                                </asp:DataPager>
                            </div>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <%-- Mall för varje rad i databasen, dvs varje rad i tabellen som loopas fram.  --%>
                            <tr>
                                <td><%#: Item.FirstName %></td>
                                <td><%#: Item.LastName %></td>
                                <td><%#: Item.EmailAddress %></td>
                                <td>
                                    <%-- Knappar för att ta bort och redigera kunduppgifter. --%>
                                    <asp:LinkButton runat="server" CommandName="Delete" Text="Ta bort" CausesValidation="false" OnClientClick='<%# Eval("FirstName", "return confirm(\"Vill du radera {0} permanent?\");") %>' />
                                    <asp:LinkButton runat="server" CommandName="Edit" Text="Redigera" CausesValidation="false" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <%-- Om inget finns i databasen presenteras detta istället.  --%>
                            <p>Inga kontakter finns inlagda i databasen just nu.</p>
                        </EmptyDataTemplate>
                        <%-- Template för att lägga till nya rader i databasen (kontakter). --%>
                        <InsertItemTemplate>
                            <tr>
                                <td>
                                    <asp:TextBox ID="FirstName" runat="server" Text="<%# BindItem.FirstName %>" MaxLength="50"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="LastName" runat="server" Text="<%# BindItem.LastName %>" MaxLength="50"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="EmailAddress" runat="server" Text="<%# BindItem.EmailAddress %>" MaxLength="50"></asp:TextBox>
                                </td>
                                <td>
                                    <%-- Knappar för att lägga till kontakter. --%>
                                    <asp:LinkButton runat="server" CommandName="Insert" Text="Lägg till" /> 
                                    <asp:LinkButton runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false" />
                                </td>
                            </tr>
                        </InsertItemTemplate>
                        <%-- Template för att uppdatera rader i databasen (kontakter). --%>
                        <EditItemTemplate>
                            <tr>
                                <td>
                                    <asp:TextBox ID="FirstName" runat="server" Text="<%# BindItem.FirstName %>" MaxLength="50"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="LastName" runat="server" Text="<%# BindItem.LastName %>" MaxLength="50"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="EmailAddress" runat="server" Text="<%# BindItem.EmailAddress %>" MaxLength="50"></asp:TextBox>
                                </td>
                                <td>
                                    <%-- Knappar för att kontakter. --%>
                                    <asp:LinkButton runat="server" CommandName="Update" Text="Spara" /> / 
                                    <asp:LinkButton runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false" />
                                </td>
                            </tr>
                        </EditItemTemplate>

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