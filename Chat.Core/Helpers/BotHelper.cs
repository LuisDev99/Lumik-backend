using Chat.Core.Entities;
using static Chat.Core.Entities.ShoppingBot;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Chat.Core.Helpers
{
    public static class BotHelper
    {
        public static Intent ConvertStringToIntent(string intentionStr)
        {
            return (Intent)Enum.Parse(typeof(Intent), intentionStr);
        }

        public static string RemoveGarbageFromString(string value)
        {
            var collection = Regex.Matches(value, "\\\"(.*?)\\\"");

            return collection[0].ToString().Trim('"');
        }
    }
}
