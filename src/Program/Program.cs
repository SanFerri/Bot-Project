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
        BaseHandler handler1;
        BaseHandler handler2;
        BaseHandler handler3;
        BaseHandler handler4;
        BaseHandler handler5;
        BaseHandler handler6;
        BaseHandler handler7;
        BaseHandler handler8;
        BaseHandler handler9;
        BaseHandler handler10;
        BaseHandler handler11;
        public static void Main()
        {

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
            BaseHandler handler1 = new OfertasHandler(null);
            BaseHandler handler2 = new AgregarResiduoHandler(handler1);
            BaseHandler handler3 = new CambiarDatosHandler(handler2);
            BaseHandler handler4 = new InvitarHandler(handler3);
            BaseHandler handler5 = new PublicarHandler(handler4);
            BaseHandler handler6 = new RegistrarseHandler(handler5);
            BaseHandler handler7 = new ResiduosConstantesHandler(handler6);
            BaseHandler handler8 = new ResiduosPuntualesHandler(handler7);
            BaseHandler handler9 = new VerEntregadosHandler(handler8);
            BaseHandler handler10 = new VerPublicacionesHandler(handler9);
            BaseHandler handler11 = new VerResiduosConsumidosHandler(handler10);
            List<BaseHandler> AllHandlers = new List<BaseHandler>{handler11, handler10, handler9, handler8, handler7, handler6, handler5, handler4, handler3, handler2, handler1};
        

            Message message = messageEventArgs.Message;
            Chat chatInfo = message.Chat;
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
                        await client.SendTextMessageAsync(
                                              chatId: chatInfo.Id,
                                              text: response
                                            );
                }
                else
                {
                    string response;
                        await client.SendTextMessageAsync(
                                              chatId: chatInfo.Id,
                                              text: $"{chatInfo.FirstName}, no comprendo lo que dices 😕"
                                            );
                }
            }
        }
    }
}