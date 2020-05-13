<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" runat="server" CodeBehind="Default.aspx.cs" Inherits="ControlDesuscipciones._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="text-align: center; width: 100%; background-color: white; margin: 0,0,0,0; padding: 10px 0 0 0;">


        <div style="text-align: center; width: 100%; background-color: darkgray; color: black; margin: 50px,0,0,0; padding: 0;">

            <p style="text-align: center" class="lead">Inserte los datos a continuacion para verificar si el suscriptor se encuentra en nuesta base de datos</p>

            <div style="text-align: center; height: 96px; overflow: hidden" class="row">
                <div class="column">
                    <p><b>Tipo de documento</b></p>
                    <asp:DropDownList ID="ASPTipoDeDocumento" runat="server" Height="22px" Width="281px">
                        <asp:ListItem>DNI</asp:ListItem>
                        <asp:ListItem>LC</asp:ListItem>
                        <asp:ListItem>PSP</asp:ListItem>
                        <asp:ListItem>LEN</asp:ListItem>


                    </asp:DropDownList>
                </div>
                <div class="column">
                    <p>
                        <b>Numero de documento</b>
                    </p>
                    <asp:TextBox ID="ASPNumeroDeDocumento" runat="server" Width="326px"></asp:TextBox>
                </div>

            </div>
            <div style="text-align: center; height: 96px; overflow: hidden">

                <asp:Button Style="margin: 10px;"
                    runat="server" Text="Buscar suscriptor" Width="221px" Height="46px" OnClick="SearchButton_Click" />

                <asp:Button Style="margin: 10px;" ID="ModificarButton"
                    runat="server" Text="Modificar" Width="221px" Height="46px" OnClick="ModificarButton_Click" />
                <asp:Button Style="margin: 10px;" ID="NuevoButton"
                    runat="server" Text="Nuevo suscriptor" Width="221px" Height="46px" OnClick="NuevoButton_Click" />

            </div>
        </div>

        <div style="width: 50%; margin: 20px auto; text-align: center;">


            <asp:Label ID="ASPMainUserLabel" runat="server"></asp:Label>
            <div id="DIVMainContent" style="text-align: center; height: 96px; overflow: hidden" class="row">
                <div class="column">
                    <b>Nombre</b>
                    <asp:TextBox ID="ASPNombre" runat="server" Width="326px"></asp:TextBox>
                </div>
                <div class="column">
                    <b>Apellido</b>
                    <asp:TextBox ID="ASPApellido" runat="server" Width="326px"></asp:TextBox>
                </div>

            </div>


            <div style="text-align: center; height: 96px; overflow: hidden" class="row">
                <div class="column">
                    <b>Direccion</b>
                    <asp:TextBox ID="ASPDireccion" runat="server" Width="326px"></asp:TextBox>
                </div>
                <div class="column">
                    <b>Email</b>
                    <asp:TextBox ID="ASPEmail" runat="server" Width="326px"></asp:TextBox>
                </div>

            </div>

            <div style="text-align: center; height: 96px; overflow: hidden" class="row">
                <div class="column">
                    <b>Telefono</b>
                    <asp:TextBox ID="ASPTelefono" runat="server" Width="326px"></asp:TextBox>
                </div>


            </div>


            <div style="text-align: center; height: 96px; overflow: hidden" class="row">
                <div class="column">
                    <b>Usuario</b>
                    <asp:TextBox ID="ASPUsuario" runat="server" Width="326px"></asp:TextBox>
                </div>
                <div class="column">
                    <b>Contraseña</b>
                    <asp:TextBox ID="ASPContraseña" TextMode="Password" runat="server" Width="326px"></asp:TextBox>
                </div>

            </div>


        </div>

        <div style="text-align: center">
            <asp:Panel runat="server" ID="DataSuscriptionPANEL">

                <p>Verifique la nueva suscripcion</p>

                <b>Fecha de Alta</b>
                <asp:TextBox ID="ASPFechaActual" runat="server" Width="326px"></asp:TextBox>

                <b style="margin: 0 0 0 0">Fecha de Finalizacion</b>
                <asp:TextBox ID="ASPFechaFin" runat="server" Width="326px"></asp:TextBox>

            </asp:Panel>
        </div>

        <div id="DIVRegistrarUsuario" style="text-align: center; height: 96px; overflow: hidden">

            <asp:Button Style="margin: 10px;" ID="AcceptarButton"
                runat="server" Text="Aceptar" Width="221px" Height="46px" OnClick="AcceptarButton_Click" />
            <asp:Button Style="margin: 10px;" ID="CancelarButton"
                runat="server" Text="Cancelar" Width="221px" Height="46px" />

        </div>



    </div>

</asp:Content>
