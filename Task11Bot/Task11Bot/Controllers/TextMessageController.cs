using Task11Bot.Configuration;
using Task11Bot.Services;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Task11Bot.Controllers
{
    public class TextMessageController
    {
        private readonly IStorage _memoryStorage; // Добавим это
        private readonly ITelegramBotClient _telegramClient;

        public TextMessageController(ITelegramBotClient telegramBotClient, IStorage memoryStorage)
        {
            _telegramClient = telegramBotClient;
            _memoryStorage = memoryStorage; // и это
        }

        public async Task Handle(Message message, CancellationToken ct)
        {

            //string userLanguageCode = _memoryStorage.GetSession(message.Chat.Id).UserChose; // Здесь получим язык из сессии пользователя

            switch (message.Text)
            {
                case "/start":

                    // Объект, представляющий кнопки
                    var buttons = new List<InlineKeyboardButton[]>();
                    buttons.Add(new[]
                    {
                        InlineKeyboardButton.WithCallbackData($" Подсчет символов в строке" , $"stringLenght"),
                        InlineKeyboardButton.WithCallbackData($" Подсчет суммы чесел последовательности" , $"sumInt")

                    });

                    // передаем кнопки вместе с сообщением (параметр ReplyMarkup)
                    await _telegramClient.SendMessage(message.Chat.Id, $"<b>  Наш бот может: </b> {Environment.NewLine}" +
                        $"{Environment.NewLine}1. Подсчитывать количество символов в строке \n2. Считать сумму чисел в последовательности, введенных через пробел.{Environment.NewLine}", cancellationToken: ct, parseMode: ParseMode.Html, replyMarkup: new InlineKeyboardMarkup(buttons));
                    break;

                default:
                    string userChoseCode = _memoryStorage.GetSession(message.Chat.Id).UserChose; // Здесь получим язык из сессии пользователя
                    await _telegramClient.SendMessage(message.Chat.Id, $"Пользователь выбрал - {userChoseCode}", cancellationToken: ct);
                    //await _telegramClient.SendMessage(message.Chat.Id, "Отправте строку для подсчета символов в ней.", cancellationToken: ct);
                    break;
            }
        }
    }
}
