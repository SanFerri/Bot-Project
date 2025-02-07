﻿//--------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using Telegram.Bot;
using System.Collections.Generic;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using ClassLibrary;
using Telegram.Bot.Types.Enums;
using FileReader = System.IO ;
using System.Text;
using System.Text.Json;

namespace Program
{
    class Program
    {
        static BaseHandler handler1;
        static BaseHandler handler2;
        static BaseHandler handler3;
        static BaseHandler handler4;
        static BaseHandler handler5;
        static BaseHandler handler6;
        static BaseHandler handler7;
        static BaseHandler handler8;
        static BaseHandler handler9;
        static BaseHandler handler10;
        static BaseHandler handler11;
        public static void Main()
        {
            InvitationGenerator generator = new InvitationGenerator();
            Residuo Residuo = new Residuo("Metal", 100, "kg", 250, "$");
            
            string invitacion = ListaInvitaciones.GetInstance(generator).AddInvitacion();
            Console.WriteLine(invitacion);
            Ubicacion Ubicacion = new Ubicacion("Av. 8 de Octubre 2738");
            Empresa Empresa = new Empresa("MercadoPrivado", Ubicacion, "099679938");
            Empresa.Residuos.AddResiduo(Residuo);
            Empresario Usuario = new Empresario(invitacion, Empresa);

            Residuo Residuo1 = new Residuo("Plastico (PET)", 150, "kg", 150, "$");

            string invitacion1 = ListaInvitaciones.GetInstance(generator).AddInvitacion();
            Console.WriteLine(invitacion1);
            Ubicacion Ubicacion1 = new Ubicacion("Av. 18 de Julio");
            Empresa Empresa1 = new Empresa("PlasticAssets", Ubicacion, "098954786");
            Empresa.Residuos.AddResiduo(Residuo1);
            Empresario Usuario1 = new Empresario(invitacion1, Empresa1);

            Residuo Residuo2 = new Residuo("Plastico (PET)", 100, "kg", 50, "$");

            string invitacion2 = ListaInvitaciones.GetInstance(generator).AddInvitacion();
            Console.WriteLine(invitacion2);
            Ubicacion Ubicacion2 = new Ubicacion("Av. Luis Alberto Herrera 1290");
            Empresa Empresa2 = new Empresa("BagsCompany", Ubicacion, "099452698");
            Empresa.Residuos.AddResiduo(Residuo2);
            Empresario Usuario2 = new Empresario(invitacion2, Empresa2);

            Residuo Residuo3 = new Residuo("Plastico (PET)", 400, "kg", 450, "$");

            string invitacion3 = ListaInvitaciones.GetInstance(generator).AddInvitacion();
            Console.WriteLine(invitacion3);
            Ubicacion Ubicacion3 = new Ubicacion("Bv. Gral Artigas 1825");
            Empresa Empresa3 = new Empresa("DeliciousBettyCrackers", Ubicacion, "097219632");
            Empresa.Residuos.AddResiduo(Residuo3);
            Empresario Usuario3 = new Empresario(invitacion3, Empresa3);

            Residuo Residuo4 = new Residuo("Plastico (PET)", 300, "kg", 50, "$");

            string invitacion4 = ListaInvitaciones.GetInstance(generator).AddInvitacion();
            Console.WriteLine(invitacion4);
            Ubicacion Ubicacion4 = new Ubicacion("Av. Luis Alberto Herrera 3365");
            Empresa Empresa4 = new Empresa("MegaBottlesUY", Ubicacion, "094572984");
            Empresa.Residuos.AddResiduo(Residuo4);
            Empresario Usuario4 = new Empresario(invitacion4, Empresa4);

            Residuo Residuo5 = new Residuo("Goma", 600, "kg", 500, "$");

            string invitacion5 = ListaInvitaciones.GetInstance(generator).AddInvitacion();
            Console.WriteLine(invitacion5);
            Ubicacion Ubicacion5 = new Ubicacion("Magallanes 1721");
            Empresa Empresa5 = new Empresa("GomeriaRAD", Ubicacion, "096785482");
            Empresa.Residuos.AddResiduo(Residuo5);
            Empresario Usuario5 = new Empresario(invitacion5, Empresa5);

            Residuo Residuo6 = new Residuo("Cobre", 60, "kg", 300, "$");

            string invitacion6 = ListaInvitaciones.GetInstance(generator).AddInvitacion();
            Console.WriteLine(invitacion6);
            Ubicacion Ubicacion6 = new Ubicacion("Jose Eullari 350");
            Empresa Empresa6 = new Empresa("InterTECH", Ubicacion, "091536982");
            Empresa.Residuos.AddResiduo(Residuo6);
            Empresario Usuario6 = new Empresario(invitacion6, Empresa6);

            Residuo Residuo7 = new Residuo("Papel", 1000, "kg", 30, "$");

            string invitacion7 = ListaInvitaciones.GetInstance(generator).AddInvitacion();
            Console.WriteLine(invitacion7);
            Ubicacion Ubicacion7 = new Ubicacion("Av. Italia 5775");
            Empresa Empresa7 = new Empresa("Papeleria", Ubicacion, "097549621");
            Empresa.Residuos.AddResiduo(Residuo7);
            Empresario Usuario7 = new Empresario(invitacion7, Empresa7);

            Residuo Residuo8 = new Residuo("Algodon", 200, "kg", 50, "$");

            string invitacion8 = ListaInvitaciones.GetInstance(generator).AddInvitacion();
            Console.WriteLine(invitacion8);
            Ubicacion Ubicacion8 = new Ubicacion("Claudio Williman 626");
            Empresa Empresa8 = new Empresa("CottonTAP", Ubicacion, "097012958");
            Empresa.Residuos.AddResiduo(Residuo8);
            Empresario Usuario8 = new Empresario(invitacion8, Empresa8);

            Residuo Residuo9 = new Residuo("Cuero", 70, "kg", 1000, "$");

            string invitacion9 = ListaInvitaciones.GetInstance(generator).AddInvitacion();
            Console.WriteLine(invitacion9);
            Ubicacion Ubicacion9 = new Ubicacion("Av. Alfredo Arocena 1806");
            Empresa Empresa9 = new Empresa("LeatherSUR", Ubicacion, "097519862");
            Empresa.Residuos.AddResiduo(Residuo9);
            Empresario Usuario9 = new Empresario(invitacion9, Empresa9);

            Publicacion publicacion = new Publicacion(Residuo, Ubicacion, Empresa, "Permiso para manipular metales", true);

            Publicacion publicacion1 = new Publicacion(Residuo1, Ubicacion1, Empresa1, "Permiso para transporte pesado", true);

            Publicacion publicacion2 = new Publicacion(Residuo2, Ubicacion2, Empresa2, "Permiso para manipular nylon", false);

            Publicacion publicacion3 = new Publicacion(Residuo3, Ubicacion3, Empresa3, "Permiso para uso de aluminio", false);

            Publicacion publicacion4 = new Publicacion(Residuo4, Ubicacion4, Empresa4, "Este residuo no precisa de un permiso", true);

            Publicacion publicacion5 = new Publicacion(Residuo5, Ubicacion5, Empresa5, "Permiso para transporte", false);

            Publicacion publicacion6 = new Publicacion(Residuo6, Ubicacion6, Empresa6, "Permiso para manipular y transportar este material", false);

            Publicacion publicacion7 = new Publicacion(Residuo7, Ubicacion7, Empresa7, "No requiere de un permiso", true);

            Publicacion publicacion8 = new Publicacion(Residuo8, Ubicacion8, Empresa8, "No es necesario un permiso", false);

            Publicacion publicacion9 = new Publicacion(Residuo9, Ubicacion9, Empresa9, "Permiso para transportar", true);
          
            Emprendedor emprendedor = new Emprendedor(9093);

            string JsonEmpresas = FileReader.File.ReadAllText(@"EmpresasData.json");
            string JsonUsuarios = FileReader.File.ReadAllText(@"UsuariosData.json");

            JsonSerializerOptions options = new()
                {
                    ReferenceHandler = MyReferenceHandler.Instance,
                    WriteIndented = true
                };
            // string json = FileReader.File.ReadAllText(@"../Library/Jsons/SerializerData.json");
            // Serializer serializer = new Serializer();
            // serializer.LoadFromJson(json);

            // Console.WriteLine(ListaEmpresas.GetInstance().Empresas.Count);

            // Serializer serializer = new Serializer();
            // string JsonSerializer = serializer.ConvertToJson();
            // FileReader.File.WriteAllText(@"../Library/Jsons/SerializerData.json", JsonSerializer);
            //ListaUsuarios Usuarios = ListaUsuarios.GetInstance();
            //Usuarios = JsonSerializer.Deserialize<ListaUsuarios>(JsonUsuarios, options);


        // string json2 = ListaAdministradores.GetInstance().ConvertToJson();
        // Console.WriteLine(json2);
        // FileReader.File.WriteAllText(@"../Library/Jsons/AdministradoresData.json", json2);

        // string json3 = ListaUsuarios.GetInstance().ConvertToJson();
        // Console.WriteLine(json3);
        // FileReader.File.WriteAllText(@"../Library/Jsons/UsuariosData.json", json3);

        // string json4 = ListaEmpresas.GetInstance().ConvertToJson();
        // Console.WriteLine(json4);
        // FileReader.File.WriteAllText(@"../Library/Jsons/EmpresasData.json", json4);

            handler1 = new OfertasHandler(null);
            handler2 = new AgregarResiduoHandler(handler1);
            handler3 = new CambiarDatosHandler(handler2);
            handler4 = new InvitarHandler(handler3);
            handler5 = new PublicarHandler(handler4);
            handler6 = new RegistrarseHandler(handler5);
            handler7 = new ResiduosConstantesHandler(handler6);
            handler8 = new ResiduosPuntualesHandler(handler7);
            handler9 = new VerEntregadosHandler(handler8);
            handler10 = new VerPublicacionesHandler(handler9);
            handler11 = new VerResiduosConsumidosHandler(handler10);
            
            //Obtengo una instancia de TelegramBot
            TelegramBot telegramBot = TelegramBot.Instance;
            Console.WriteLine($"Hola soy el Bot de P2, mi nombre es {telegramBot.BotName} y tengo el Identificador {telegramBot.BotId}");

            //Obtengo el cliente de Telegram
            ITelegramBotClient bot = telegramBot.Client;

            //Asigno un gestor de mensajes
            bot.OnMessage += OnMessage;

            //Inicio la escucha de mensajes
            bot.StartReceiving();


            Console.WriteLine("Presiona una tecla para terminar");
            Console.ReadKey();

            //Detengo la escucha de mensajes 
            bot.StopReceiving();

            // string JsonEmpresa = ListaEmpresas.GetInstance().ConvertToJson();
            // Console.WriteLine(JsonEmpresa);
            // FileReader.File.WriteAllText(@"EmpresasData.json", JsonEmpresa);

            // string JsonUsuario = ListaUsuarios.GetInstance().ConvertToJson();
            // Console.WriteLine(JsonUsuarios);
            // FileReader.File.WriteAllText(@"UsuariosData.json", JsonUsuario);
            
        }

        private static async void OnMessage(object sender, MessageEventArgs messageEventArgs)
        {
            Message message = messageEventArgs.Message;
            Chat chatInfo = message.Chat;
            Administrador administrador = new Administrador("7777");
            string messageText = message.Text.ToLower();
            if (messageText != null)
            {
                ITelegramBotClient client = TelegramBot.Instance.Client;
                Console.WriteLine($"{chatInfo.FirstName}: envío {message.Text}");

                if (messageText == "/commands" || messageText == "/comandos")
                {
                        StringBuilder commandsStringBuilder = new StringBuilder("Lista de Comandos:\n")
                                                                            .Append("/registrarse: Registrate como empresario o emprendedor\n")
                                                                            .Append("/cambiardatos: Cambie los datos de su empresa\n")
                                                                            .Append("/invitar: Invite a nuevas empresas\n")
                                                                            .Append("/ofertas: Vea las ofertas en el mercado\n")
                                                                            .Append("/publicar: Publique nuevas ofertas de residuos\n")
                                                                            .Append("/agregarresiduo: Agregue nuevos residuos a su empresa\n")
                                                                            .Append("/residuosconstantes: Aqui se mostraran los residuos que aparecen constantemente\n")
                                                                            .Append("/residuospuntuales: Aqui se mostraran los residuos que aparecen puntualmente\n")
                                                                            .Append("/verentregados: Vea sus publicaciones ya entregadas.\n")
                                                                            .Append("/verpublicaciones: Vea todas sus publicaciones y si quiere indique alguna como entregada\n")
                                                                            .Append("/verresiduosconsumidos: Vea todos los residuos que consumio\n");


                        await client.SendTextMessageAsync(
                                                  chatId: chatInfo.Id,
                                                   text: commandsStringBuilder.ToString());
                }
                else if (messageText[0] == '/')
                {
                    string response;
                    handler11.Handle(messageText, Convert.ToInt32(chatInfo.Id), out response);
                    if (response != string.Empty)
                    {
                        await client.SendTextMessageAsync(
                                              chatId: chatInfo.Id,
                                              text: response
                                            );
                    }
                    else
                    {
                        await client.SendTextMessageAsync(
                                              chatId: chatInfo.Id,
                                              text: $"{chatInfo.FirstName}, no comprendo lo que dices 😕"
                                            );
                    }
                }
                else
                {
                    string response;
                    handler11.Handle(messageText, Convert.ToInt32(chatInfo.Id), out response);
                    if (response == string.Empty)
                    {
                        await client.SendTextMessageAsync(
                                              chatId: chatInfo.Id,
                                              text: $"{chatInfo.FirstName}, no comprendo lo que dices 😕"
                                            );
                    }
                    else
                    {
                        await client.SendTextMessageAsync(
                                              chatId: chatInfo.Id,
                                              text: response
                                            );
                    }
                }
            }
        }
    }
}