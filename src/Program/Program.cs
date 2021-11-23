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
using System.IO;
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
            Residuo Residuo = new Residuo("metal", 100, "kg", 250, "$");
            
            string invitacion = InvitationGenerator.Generate();
            Console.WriteLine(invitacion);
            Ubicacion Ubicacion = new Ubicacion("Av. 8 de Octubre 2738");
            Empresa Empresa = new Empresa("MercadoPrivado", Ubicacion, "099679938");
            Empresa.Residuos.AddResiduo(Residuo);
            Empresario Usuario = new Empresario(invitacion, Empresa);

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
                                                                            .Append("/agregarresiduos: Agregue nuevos residuos a su empresa\n")
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