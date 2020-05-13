<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" runat="server" CodeBehind="Default.aspx.cs" Inherits="ControlDeSubscipciones._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="text-align: center; width: 100%; background-color: white;  margin: 0,0,0,0; padding: 10px 0 0 0 ;">
    
        
        <div style="text-align: center; width: 100%; background-color: darkgray; color: black; margin: 50px,0,0,0; padding: 0;">
          
            <p style="text-align: center" class="lead">Inserte los datos a continuacion para verificar si el subscriptor se encuentra en nuesta base de datos</p>

            <div style="text-align: center; height: 96px; overflow: hidden" class="row">
                <div class="column">
                   <p> <b>Tipo de documento</b></p>
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="22px" Width="281px">
                        <asp:ListItem>DNI</asp:ListItem>
                        <asp:ListItem>LC</asp:ListItem>
                        <asp:ListItem>PSP</asp:ListItem>
                        <asp:ListItem>LEN</asp:ListItem>


                    </asp:DropDownList>
                </div>
                <div class="column">
                    <p>
                    <b>Numero de documento</b></p>
                    <asp:TextBox ID="TextBox1" runat="server" Width="326px"></asp:TextBox>
                </div>

            </div>
            <div style="text-align: center; height: 96px; overflow: hidden">

                <asp:Button style="margin: 10px;"
                    runat="server" Text="Buscar Subscriptor"  Width="221px" Height="46px" />
                <asp:Button  style="margin: 10px;"
                    runat="server" Text="Nuevo Subscriptor" Width="221px" Height="46px"/>
                <asp:Button  style="margin: 10px;"
                    runat="server" Text="Modificar" Width="221px" Height="46px" />


            </div>
        </div>

        <div style="width: 50%; margin: 20px auto; text-align: center; ">

            <h2>Datos del Subscriptor</h2>

            <div style="text-align: center; height: 96px; overflow: hidden" class="row">
                <div class="column">
                    <b>Nombre</b>
                    <asp:TextBox ID="TextBox2" runat="server" Width="326px"></asp:TextBox>
                </div>
                <div class="column">
                    <b>Apellido</b>
                    <asp:TextBox ID="TextBox3" runat="server" Width="326px"></asp:TextBox>
                </div>

            </div>


            <div style="text-align: center; height: 96px; overflow: hidden" class="row">
                <div class="column">
                    <b>Direccion</b>
                    <asp:TextBox ID="TextBox4" runat="server" Width="326px"></asp:TextBox>
                </div>
                <div class="column">
                    <b>Email</b>
                    <asp:TextBox ID="TextBox5" runat="server" Width="326px"></asp:TextBox>
                </div>

            </div>

            <div style="text-align: center; height: 96px; overflow: hidden" class="row">
                <div class="column">
                    <b>Telefono</b>
                    <asp:TextBox ID="TextBox6" runat="server" Width="326px"></asp:TextBox>
                </div>


            </div>


            <div style="text-align: center; height: 96px; overflow: hidden" class="row">
                <div class="column">
                    <b>Usuario</b>
                    <asp:TextBox ID="TextBox7" runat="server" Width="326px"></asp:TextBox>
                </div>
                <div class="column">
                    <b>Contraseña</b>
                    <asp:TextBox ID="TextBox8" TextMode="Password" runat="server" Width="326px"></asp:TextBox>
                </div>

            </div>

        </div>


              <div style="text-align: center; height: 96px; overflow: hidden">

                <asp:Button style="margin: 10px;"
                    runat="server" Text="Aceptar"  Width="221px" Height="46px" />
                <asp:Button  style="margin: 10px;"
                    runat="server" Text="Cancelar" Width="221px" Height="46px"/>
           

            </div>

    </div>

</asp:Content>
