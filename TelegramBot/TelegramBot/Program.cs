using System.Text.Json;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot
{
    public class Program
    {
        private static string BotToken = "7772908579:AAFWf62Cel9ZuvPkKFE3n2hasbJu65va8oM";
        private static TelegramBotClient BotClient = new TelegramBotClient(BotToken);
        private static readonly string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "UserIds.txt");
        private static HashSet<long> Ids = new();
        static async Task Main(string[] args)
        {
            if (!File.Exists(FilePath))
            {
                File.WriteAllText(FilePath, "[]");
            }
            var receiverOprtions = new ReceiverOptions()
            {
                AllowedUpdates = new[] { UpdateType.Message, UpdateType.InlineQuery }
            };
            Console.WriteLine("Your bot is startign");

            BotClient.StartReceiving(HandleUpdateAsync, HandleErrorAsync);

            Console.ReadKey();
        }
        static async Task HandleUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken cancellationToken) // new messages come here
        {
            Ids = await GetAllIds();
            var message = update.Message;
            var user = message.Chat;
            Console.WriteLine($"{user.Id} , {user.FirstName} , {message.Text}");

            if (message.Text == "/start")
            {

                Ids.Add(user.Id);
                await SaveUserId();
                var keyboard = new ReplyKeyboardMarkup(new[]
                {
                new KeyboardButton[] { new KeyboardButton("📍 Lokatsiyani yuborish") { RequestLocation = true } },
                new KeyboardButton[] { new KeyboardButton("📞 Telefon raqamni yuborish") { RequestContact = true } }
                });


                await bot.SendTextMessageAsync(user.Id, $"Welcome to talking bot, dear {user.FirstName}", replyMarkup: keyboard);
                return;
            }

            //if (message.Text != "/start")
            //{
            //    await bot.SendTextMessageAsync(user.Id, $"ERROR HEAD WHAT ARE YOU DOING?");
            //    return;
            //}

            if (message.Text.ToLower().Contains("salom"))
            {
                await bot.SendTextMessageAsync(user.Id, "Salom, nima gap?");
            }
            if (message.Text.ToLower().Contains("hello"))
            {
                var ids = await GetAllIds();
                foreach (var id in ids)
                {
                    await bot.SendTextMessageAsync(id, update.Message.Text);
                }
                return;
            }
            if (message.Text.ToLower().Contains("number"))
            {
                await bot.SendTextMessageAsync(user.Id, $"{Ids.Count()}");
            }
        }
        static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken) // exeptions come here
        {

        }

        public static async Task SaveUserId()
        {

            var jsonIds = JsonSerializer.Serialize(Ids);
            await File.WriteAllTextAsync(FilePath, jsonIds);
        }

        public static async Task<HashSet<long>> GetAllIds()
        {
            var idsAsText = File.ReadAllText(FilePath);
            var ids = JsonSerializer.Deserialize<HashSet<long>>(idsAsText);
            return ids ?? new HashSet<long>();
        }
    }
}
