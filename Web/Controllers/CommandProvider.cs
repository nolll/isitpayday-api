﻿using Web.Models;
using Web.Storage;

namespace Web.Controllers
{
    public class CommandProvider : ICommandProvider
    {
        private readonly IStorage _storage;

        public CommandProvider(IStorage storage)
        {
            _storage = storage;
        }

        public Command GetSaveSettingsCommand(IndexPagePostModel postModel)
        {
            return new SaveSettingsCommand(_storage, postModel);
        }
    }
}