using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace ClassLibrary
{
    public class TelegramBot
    {

        private const string TELEBRAM_BOT_TOKEN = "2103937324:AAEXUORSVN7MntMqmcl56yXwsHcEKa-korM";
        private static TelegramBot instance { get; set; }
        private ITelegramBotClient bot;

        private TelegramBot()
        {
            this.bot = new TelegramBotClient(TELEBRAM_BOT_TOKEN);
        }

        public ITelegramBotClient Client
        {
            get
            {
                return this.bot;
            }
        }

        private User BotInfo
        {
            get
            {
                return this.Client.GetMeAsync().Result;
            }
        }

        public long BotId
        {
            get
            {
                return this.BotInfo.Id;
            }
        }

        public string BotName
        {
            get
            {
                return this.BotInfo.FirstName;
            }
        }

        public static TelegramBot Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TelegramBot();
                }
                return instance;
            }
        }
    }
}