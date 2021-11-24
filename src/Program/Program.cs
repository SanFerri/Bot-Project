//--------------------------------------------------------------------------------
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
            Residuo Residuo = new Residuo("Metal", 100, "kg", 250, "$");
            
            string invitacion = InvitationGenerator.Generate();
            Console.WriteLine(invitacion);
            Ubicacion Ubicacion = new Ubicacion("Av. 8 de Octubre 2738");
            Empresa Empresa = new Empresa("MercadoPrivado", Ubicacion, "099679938");
            Empresa.Residuos.AddResiduo(Residuo);
            Empresario Usuario = new Empresario(invitacion, Empresa);

            Publicacion publicacion = new Publicacion(Residuo, Ubicacion, Empresa, "Permiso para usar metales", true);

            Residuo Residuo1 = new Residuo("madera", 150, "kg", 150, "$");

            string invitacion1 = InvitationGenerator.Generate();
            Console.WriteLine(invitacion1);
            Ubicacion Ubicacion1 = new Ubicacion("Av. 18 de Julio");
            Empresa Empresa1 = new Empresa("MaderasUY", Ubicacion, "098954786");
            Empresa.Residuos.AddResiduo(Residuo);
            Empresario Usuario1 = new Empresario(invitacion, Empresa);

            Residuo Residuo2 = new Residuo("nylon", 100, "kg", 50, "$");

            string invitacion2 = InvitationGenerator.Generate();
            Console.WriteLine(invitacion2);
            Ubicacion Ubicacion2 = new Ubicacion("Av. Italia");
            Empresa Empresa2 = new Empresa("NylonS", Ubicacion, "099452698");
            Empresa.Residuos.AddResiduo(Residuo);
            Empresario Usuario2 = new Empresario(invitacion, Empresa);

            Residuo Residuo3 = new Residuo("aluminio", 400, "kg", 450, "$");

            string invitacion3 = InvitationGenerator.Generate();
            Console.WriteLine(invitacion3);
            Ubicacion Ubicacion3 = new Ubicacion("Colonia");
            Empresa Empresa3 = new Empresa("CRAP", Ubicacion, "097219632");
            Empresa.Residuos.AddResiduo(Residuo);
            Empresario Usuario3 = new Empresario(invitacion, Empresa);

            Residuo Residuo4 = new Residuo("plastico", 300, "kg", 50, "$");

            string invitacion4 = InvitationGenerator.Generate();
            Console.WriteLine(invitacion4);
            Ubicacion Ubicacion4 = new Ubicacion("Uruguay");
            Empresa Empresa4 = new Empresa("PLASuy", Ubicacion, "094572984");
            Empresa.Residuos.AddResiduo(Residuo);
            Empresario Usuario4 = new Empresario(invitacion, Empresa);

            Residuo Residuo5 = new Residuo("goma", 600, "kg", 500, "$");

            string invitacion5 = InvitationGenerator.Generate();
            Console.WriteLine(invitacion5);
            Ubicacion Ubicacion5 = new Ubicacion("Sanchez");
            Empresa Empresa5 = new Empresa("GomeriaRAD", Ubicacion, "096785482");
            Empresa.Residuos.AddResiduo(Residuo);
            Empresario Usuario5 = new Empresario(invitacion, Empresa);

            Residuo Residuo6 = new Residuo("cobre", 60, "kg", 300, "$");

            string invitacion6 = InvitationGenerator.Generate();
            Console.WriteLine(invitacion6);
            Ubicacion Ubicacion6 = new Ubicacion("Rivera");
            Empresa Empresa6 = new Empresa("InterTECH", Ubicacion, "091536982");
            Empresa.Residuos.AddResiduo(Residuo);
            Empresario Usuario6 = new Empresario(invitacion, Empresa);

            Residuo Residuo7 = new Residuo("papel", 1000, "kg", 30, "$");

            string invitacion7 = InvitationGenerator.Generate();
            Console.WriteLine(invitacion7);
            Ubicacion Ubicacion7 = new Ubicacion("Treinta y tres");
            Empresa Empresa7 = new Empresa("Papeleria", Ubicacion, "097549621");
            Empresa.Residuos.AddResiduo(Residuo);
            Empresario Usuario7 = new Empresario(invitacion, Empresa);

            Residuo Residuo8 = new Residuo("Algodon", 200, "kg", 50, "$");

            string invitacion8 = InvitationGenerator.Generate();
            Console.WriteLine(invitacion8);
            Ubicacion Ubicacion8 = new Ubicacion("La Rosa");
            Empresa Empresa8 = new Empresa("CottonTAP", Ubicacion, "097012958");
            Empresa.Residuos.AddResiduo(Residuo);
            Empresario Usuario8 = new Empresario(invitacion, Empresa);

            Residuo Residuo9 = new Residuo("cuero", 70, "kg", 1000, "$");

            string invitacion9 = InvitationGenerator.Generate();
            Console.WriteLine(invitacion9);
            Ubicacion Ubicacion9 = new Ubicacion("Almirante");
            Empresa Empresa9 = new Empresa("LeatherSUR", Ubicacion, "097519862");
            Empresa.Residuos.AddResiduo(Residuo);
            Empresario Usuario9 = new Empresario(invitacion, Empresa);

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
          
            string json = ListaEmpresarios.GetInstance().ConvertToJson();
            Console.WriteLine(json);
            FileReader.File.WriteAllText(@"../Library/Jsons/EmpresariosData.json", json);

            string json2 = ListaAdministradores.GetInstance().ConvertToJson();
            Console.WriteLine(json2);
            FileReader.File.WriteAllText(@"../Library/Jsons/AdministradoresData.json", json2);

            string json3 = ListaUsuarios.GetInstance().ConvertToJson();
            Console.WriteLine(json3);
            FileReader.File.WriteAllText(@"../Library/Jsons/UsuariosData.json", json3);

            string json4 = Mercado.GetInstance().ConvertToJson();
            Console.WriteLine(json4);
            FileReader.File.WriteAllText(@"../Library/Jsons/MercadoData.json", json4);

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