﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SitePiadaRuim.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	<meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>Piada Ruim</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-/Y6pD6FV/Vv2HJnA6t+vslU6fwYXjCFtcEpHbNJ0lyAFsXTsjBbfaDjzALeQsN6M" crossorigin="anonymous"/>

    <style> 
        body, html{
            height: 100%;
        }
    </style>
</head>
<body">
    <form ID="Form1" runat="server" style="height: 100%;">
        <div class="container" style="height: 100%;">
            <div class="row bg-primary" style="border-bottom: 6px solid #fff; ">
                <div class="col-12 col-sm-12 col-md-6 col-lg-6 col-xl-6 text-center text-sm-center">
                    <a href="#">
                        <asp:Image ID="Image2" Class="img-fluid" ImageUrl="~/img/Logo.png" runat="server" />
                    </a>
                </div>
                <div class="col-12 col-sm-12 col-md-6 col-lg-6 col-xl-6 text-center text-sm-center text-md-right text-lg-right text-xl-right pt-2 pt-sm-2 pt-md-3 pt-lg-3 pt-xl-3 pb-3 pb-sm-3 pb-md-0 pb-lg-0 pb-xl-0">
                    <a href="EnvioDePiada.aspx" class="btn btn-info btn-lg" role="button">
                        Envie sua piada!
                    </a>
                </div>
            </div>
        
            <div class="row bg-light pt-3 pb-2 text-center">
                <div class="col-12">
                    <asp:Label class="text-primary font-weight-bold" ID="Label1" runat="server" Text="Clique no botão para ver uma piada ruim!"></asp:Label>
                </div>
            </div>

            <div class="row bg-light pb-2">
                <div class="col-12">
                    <asp:TextBox style="font: 14px;" class="form-control text-dark font-weight-bold" ID="txtPiada" TextMode="MultiLine" Columns="50" Rows="10" runat="server" ReadOnly="True"></asp:TextBox>
                </div>
            </div>

            <div class="row bg-light pb-2">
                <div class="col-6">
                    <asp:Label ID="lblQuantidade" class="text-primary font-weight-bold" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-6">
                    <asp:TextBox class="float-right text-center text-primary font-weight-bold" ID="txtSorteio" Columns="5" runat="server" ReadOnly="True"></asp:TextBox>
                </div>
            </div>

            <div class="row bg-light pb-2" style="height: 21%;">
                <div class="col-12 text-center">
                    <asp:Button class="btn btn-info btn-lg" ID="Button1" runat="server" Text="Ver Piada Ruim" OnClick="btnGerarPiada_Click" style="cursor:pointer;" />
                </div>
            </div>

            <div class="row bg-primary text-center" style="border-top: 6px solid #fff; bottom: 100%;">
                <div class="col-12">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/img/Emoji.png" Width="80px" Height="80px" />
                </div>
            </div>
        </div>
        
    </form>

    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.3/umd/popper.min.js" integrity="sha384-vFJXuSJphROIrBnz7yo7oB41mKfc8JzQZiCq4NCceLEaO4IHwicKwpJf9c9IpFgh" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/js/bootstrap.min.js" integrity="sha384-h0AbiXch4ZDo7tp9hKZ4TsHbi047NrKGLO3SEJAg45jXxnGIfYzk4Si90RDIqNm1" crossorigin="anonymous"></script>
</body>
</html>
