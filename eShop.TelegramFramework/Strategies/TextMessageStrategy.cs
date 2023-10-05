﻿using eShop.TelegramFramework.Attributes;
using eShop.TelegramFramework.Contexts;
using System.Reflection;
using Telegram.Bot.Types;

namespace eShop.TelegramFramework.Strategies
{
    internal class TextMessageStrategy : IStrategy
    {
        private readonly string _command;
        private readonly string _action;
        private readonly string[] _parameters;

        public TextMessageStrategy(string command, string action, string[] parameters)
        {
            _command = command;
            _action = action;
            _parameters = parameters;
        }

        public object[] GetParameters(MethodInfo method, Update update)
        {
            var context = new TextMessageContext(update);
            var parameters = ReflectionUtilities.MatchParameters(method, context, _parameters);
            return parameters;
        }

        public MethodInfo? PickControllerMethod()
        {
            var controller = ReflectionUtilities.FindControllerMethod<TextMessageAttribute>(attribute =>
                attribute.Command == _command && attribute.Action == _action);
            return controller;
        }
    }
}