//--------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
/*
using System;
using ClassLibrary;
using Telegram.Bot;

namespace ConsoleApplication
{
    /// <summary>
    /// Programa de consola de demostración.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Punto de entrada al programa principal.
        /// </summary>
        public static void Main()
        {
            var botClient = new TelegramBotClient("2120252827:AAEWDFQM7j3IuClAUSiQaTIW3IaeGXX3J7o");
            var me = await botClient.GetMeAsync();
            Console.WriteLine($"Hello, World! I am user {me.Id} and my name is {me.FirstName}.");
        }
    }
}
*/
/*
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;

namespace Ucu.Poo.TelegramBot
{
    /// <summary>
    /// En este program se encuentra nuestro bot de Telegram.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// La instancia del bot.
        /// </summary>
        private static TelegramBotClient TelegramBot;

        /// <summary>
        /// El token que nos otorgó el BotFather via Telegram al crear el bot.
        /// </summary>
        private static string Token = "2120252827:AAEWDFQM7j3IuClAUSiQaTIW3IaeGXX3J7o";

        /// <summary>
        /// Punto de entrada al programa.
        /// </summary>
        public static void Main()
        {
            TelegramBot = new TelegramBotClient(Token);
            var cts = new CancellationTokenSource();

            // Comenzamos a escuchar mensajes. Esto se hace en otro hilo (en background). El primer método
            // HandleUpdateAsync es invocado por el bot cuando se recibe un mensaje. El segundo método HandleErrorAsync
            // es invocado cuando ocurre un error.
            TelegramBot.StartReceiving(
                new DefaultUpdateHandler(HandleUpdateAsync, HandleErrorAsync),
                cts.Token
            );

            Console.WriteLine($"Bot is up!");

            // Esperamos a que el usuario aprete Enter en la consola para terminar el bot.
            Console.ReadLine();

            // Terminamos el bot.
            cts.Cancel();
        }

        /// <summary>
        /// Maneja las actualizaciones del bot (todo lo que llega), incluyendo mensajes, ediciones de mensajes,
        /// respuestas a botones, etc. En este ejemplo sólo manejamos mensajes de texto.
        /// </summary>
        public static async Task HandleUpdateAsync(Update update, CancellationToken cancellationToken)
        {
            try
            {
                // Sólo respondemos a mensajes de texto
                if (update.Type == UpdateType.Message)
                {
                    await HandleMessageReceived(update.Message);
                }
            }
            catch(Exception e)
            {
                await HandleErrorAsync(e, cancellationToken);
            }
        }

        /// <summary>
        /// Maneja los mensajes que se envían al bot.
        /// Lo único que hacemos por ahora es escuchar 3 tipos de mensajes:
        /// - "hola": responde con texto
        /// - "chau": responde con texto
        /// - "foto": responde con una foto
        /// </summary>
        /// <param name="message">El mensaje recibido</param>
        /// <returns></returns>
        private static async Task HandleMessageReceived(Message message)
        {
            Console.WriteLine($"Received a message from {message.From.FirstName} saying: {message.Text}");

            string response;

            switch(message.Text.ToLower().Trim())
            {
                case "hola":
                    response = "¡Hola! ¿Cómo estás?";
                    break;

                case "chau":
                    response = "¡Chau! ¡Qué andes bien!";
                    break;

                case "foto":
                    // Si nos piden una foto, mandamos la foto en vez de responder con un mensaje de texto.
                    await SendProfileImage(message);
                    return;

                default:
                    response = "Disculpa, ¡no se qué hacer con ese mensaje!";
                    break;
            }

            // Enviamos el texto de respuesta
            await TelegramBot.SendTextMessageAsync(message.Chat.Id, response);
        }

        /// <summary>
        /// Envía una imagen como respuesta al mensaje recibido. Como ejemplo enviamos siempre la misma foto.
        /// </summary>
        static async Task SendProfileImage(Message message)
        {
            await TelegramBot.SendChatActionAsync(message.Chat.Id, ChatAction.UploadPhoto);

            const string filePath = @"profile.jpeg";
            using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            var fileName = filePath.Split(Path.DirectorySeparatorChar).Last();
            await TelegramBot.SendPhotoAsync(
                chatId: message.Chat.Id,
                photo: new InputOnlineFile(fileStream, fileName),
                caption: "Te ves bien!"
            );
        }

        /// <summary>
        /// Manejo de excepciones. Por ahora simplemente la imprimimos en la consola.
        /// </summary>
        public static Task HandleErrorAsync(Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(exception.Message);
            return Task.CompletedTask;
        }
    }
}
*/
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
            Administrador administrador = new Administrador(Convert.ToInt32(chatInfo.Id));
            string messageText = message.Text.ToLower();
            if (messageText != null)
            {
                ITelegramBotClient client = TelegramBot.Instance.Client;
                Console.WriteLine($"{chatInfo.FirstName}: envío {message.Text}");

                if (messageText == "/commands" || messageText == "/comandos")
                {
                        StringBuilder commandsStringBuilder = new StringBuilder("Lista de Comandos:\n")
                                                                            .Append("/registrarse\n")
                                                                            .Append("/cambiardatos\n")
                                                                            .Append("/invitar\n")
                                                                            .Append("/ofertas\n")
                                                                            .Append("/publicar\n")
                                                                            .Append("/agregarresiduos\n")
                                                                            .Append("/residuosconstantes\n")
                                                                            .Append("/residuospuntuales\n")
                                                                            .Append("/verentregados\n")
                                                                            .Append("/verpublicaciones\n")
                                                                            .Append("/verresiduosconsumidos\n");


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