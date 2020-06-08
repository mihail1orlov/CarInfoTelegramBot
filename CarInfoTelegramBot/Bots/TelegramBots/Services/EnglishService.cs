﻿using System;
using BotCommon;
using ServiceCommon;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace TelegramBots.Services
{
    public class EnglishService : Exception, IService
    {
        private readonly ITelegramBotClient _telegramBotClient;
        private readonly IMessageProcessor _messageProcessor;

        public EnglishService(ITelegramBotClient telegramBotClient,
            IMessageProcessor messageProcessor)
        {
            _telegramBotClient = telegramBotClient;
            _messageProcessor = messageProcessor;
        }

        public void Start()
        {
            User user = _telegramBotClient.GetMeAsync().Result;

            _telegramBotClient.OnMessage += OnMessage;
            _telegramBotClient.StartReceiving();
        }

        public void Stop()
        {
            _telegramBotClient.OnMessage -= OnMessage;
            _telegramBotClient.StopReceiving();
        }

        private async void OnMessage(object sender, MessageEventArgs e)
        {
            var text = e?.Message?.Text;
            var id = e.Message.Chat.Id;

            User user = e.Message.From;
            var message = await _messageProcessor.Process(text, id);
            await _telegramBotClient.SendTextMessageAsync(id, message)
                .ConfigureAwait(false);
        }
    }
}
