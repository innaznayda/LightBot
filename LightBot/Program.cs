using System;
using System.IO;
using System.Net;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace LightBot {
    class Program {
        static ITelegramBotClient botClient;
        static void Main() {
            botClient = new TelegramBotClient("691239211:AAGeWB4EkHtSk5RWY1s_cIRM5Okly5w72dc");
            var me = botClient.GetMeAsync().Result;
            Console.WriteLine($"Hello, World! I am user {me.Id} and my name is {me.FirstName}.");
            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
            Thread.Sleep(int.MaxValue);

        }

        static async void Bot_OnMessage(object sender, MessageEventArgs e) {
            if (e.Message.Text != null) {
                Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id}.");

                if (e.Message.Text.Contains("hello")) {

                    await botClient.SendTextMessageAsync(
                      chatId: e.Message.Chat.Id,
                      text: "Hello, " + e.Message.From.FirstName + ". Nice to meet you. Here I am"
                    );

                    await botClient.SendStickerAsync(
                        chatId: e.Message.Chat.Id,
                        sticker: "https://github.com/TelegramBots/book/raw/master/src/docs/sticker-dali.webp"
                    );
                }

                if (e.Message.Text.Contains("joke", StringComparison.InvariantCultureIgnoreCase)) {
                    var request = (HttpWebRequest)WebRequest.Create("https://geek-jokes.sameerkumar.website/api");
                    var responce = request.GetResponse();
                    string joke = "";
                    using (Stream stream = responce.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream)) {
                        joke = reader.ReadToEnd();
                    }
                    await botClient.SendTextMessageAsync(
                      chatId: e.Message.Chat.Id,
                      text: joke
                    );
                    await botClient.SendStickerAsync(
                    chatId: e.Message.Chat.Id,
                    sticker: "https://github.com/innaznayda/LightBot/blob/master/LightBot/alf.webp"
                );

                }
            }
        }
    }
}
