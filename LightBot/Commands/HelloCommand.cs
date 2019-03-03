using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace LightBot.Commands {
    public class HelloCommand : Command {
        public override string Name => "hello";

        public override async void Execute(Message message, TelegramBotClient client) {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            // TO DO : some logic here

            await client.SendTextMessageAsync(chatId,"hello",replyToMessageId: messageId);
        }
    }
}