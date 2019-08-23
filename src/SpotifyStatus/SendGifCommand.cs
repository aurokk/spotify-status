using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;

namespace SpotifyStatus.App
{
    public class SendGifCommand
    {
        private readonly TelegramBotClient _telegramBotClient;
        private readonly Settings _settings;
        private readonly bool _isAvailable;
        private readonly string _gif;

        public SendGifCommand(TelegramBotClient telegramBotClient, Settings settings, bool isAvailable, string gif)
        {
            _telegramBotClient = telegramBotClient ?? throw new ArgumentNullException(nameof(telegramBotClient));
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
            _isAvailable = isAvailable;
            _gif = gif ?? throw new ArgumentNullException(nameof(gif));
        }

        public async Task Execute()
        {
            var caption = _isAvailable
                ? _settings.TelegramTextYes
                : _settings.TelegramTextNo;

            if (_settings.DryRun)
            {
                Console.WriteLine($"{caption}, {_gif}");
            }
            else
            {
                var chat = new ChatId(_settings.TelegramChannel);
                var file = new InputOnlineFile(_gif);
                await _telegramBotClient.SendAnimationAsync(chat, file, caption: caption);
            }
        }
    }
}