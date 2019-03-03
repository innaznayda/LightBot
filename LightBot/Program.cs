﻿using System;
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

                await botClient.SendTextMessageAsync(
                  chatId: e.Message.Chat.Id,
                  text: "Hello, " + e.Message.From.FirstName + ". Nice to meet you. Here I am"
                );

                await botClient.SendStickerAsync(
                    chatId: e.Message.Chat.Id,
                    sticker: "https://github.com/TelegramBots/book/raw/master/src/docs/sticker-dali.webp"
);
            }
        }
    }
}