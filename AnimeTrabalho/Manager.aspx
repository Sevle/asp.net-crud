<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manager.aspx.cs" Inherits="AnimeTrabalho.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="Style.css" rel="stylesheet" />
    <title>Listar animes</title>
</head>
<body>
    <h1>Listar animes</h1>

    <div class="menu">
        <a href="Default.aspx">Início</a>
        <a href="Manager.aspx">Animes</a>
    </div>
	<br />

    <form id="form1" runat="server">
        <div>
            <fieldset>
                <legend>Adicionar/Editar Anime</legend>
                <table>
                    <tr>
                        <td>ID:</td>
                        <td>
                            <asp:TextBox ID="txtId" runat="server" Enabled="false" />
                        </td>
                    </tr>
                    <tr>
                        <td>Nome:</td>
                        <td>
                            <asp:TextBox ID="txtNome" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>Nota:</td>
                        <td>
                            <asp:TextBox ID="txtNota" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>Ano:</td>
                        <td>
                            <asp:TextBox ID="txtAno" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>Qnt. Episódios:</td>
                        <td>
                            <asp:TextBox ID="txtQntEp" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>Sinopse:</td>
                        <td>
                            <asp:TextBox ID="txtSinopse" runat="server" TextMode="MultiLine" />
                        </td>
                    </tr>
                </table>
                <asp:Button ID="btnAdicionar" runat="server" Text="Adicionar" OnClick="btnAdicionar_Click" />
                <asp:Button ID="btnEditar" runat="server" Text="Editar" OnClick="btnEditar_Click" Enabled="false" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" Enabled="false" />
            </fieldset>

            <fieldset>
                <table>
                    <tr>
                        <th>Código</th>
                        <th>Nome</th>
                        <th>Nota</th>
                        <th>Ano</th>
                        <th>Qnt. Episódios</th>
                        <th>Sinopse</th>
                        
                        <th class="acoes">Editar</th>
                        <th class="acoes">Deletar</th>
                          
                    </tr>

					<asp:ListView runat="server"
                        ID="lvAnimes"
                        OnItemCommand="lvAnimes_ItemCommand"
                        OnItemDeleting="lvAnimes_ItemDeleting" OnItemUpdating="lvAnimes_ItemUpdating">

                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("id") %></td>
                                <td><%# Eval("nome") %></td>
                                <td><%# Eval("nota")  %></td>
                                <td><%# Eval("ano")  %></td>
                                <td><%# Eval("qnt_ep")  %></td>
                                <td><%# Eval("sinopse")  %></td>
                                
                                <td>
                                    <asp:ImageButton
                                        ID="ibUpdate"
                                        runat="server"
                                        ImageUrl="~/img/update.png"
                                        CssClass="image-icon"
                                        CommandName="Update"
                                        CommandArgument='<%# Eval("id") %>' />
                                </td>
                            <td>
                                <asp:ImageButton
                                    ID="ibDelete"
                                    runat="server"
                                    ImageUrl="~/img/delete.png"
                                    CssClass="image-icon"
                                    CommandName="Delete"
                                    CommandArgument='<%# Eval("id") %>'
                                    />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </table>
        </fieldset>
    </div>
</form>
