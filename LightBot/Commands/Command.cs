using LightBot.Models;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace LightBot.Commands {
    public abstract class Command {
        public abstract string Name { get; }

        public abstract void Execute(Message message, TelegramBotClient client);

        public bool Constains(string command) {
            return command.Contains(this.Name) && command.Contains(AppSettings.Name);
        }

    }
}