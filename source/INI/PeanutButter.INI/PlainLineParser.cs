using System;
using System.Collections.Generic;
using System.Linq;

namespace PeanutButter.INI
{
    internal class PlainLineParser : ILineParser
    {
        public IParsedLine Parse(string line)
        {
            if (line is null)
            {
                return new ParsedLine("", "", "", false);
            }

            if (line.Trim().StartsWith(";"))
            {
                return new ParsedLine("", null, TrimComment(line), false);
            }

            var parts = line.Split('=');
            var key = parts[0];
            if (parts.Length == 1)
            {
                // probably a section heading 
                return new ParsedLine(
                    key.Trim(),
                    null,
                    "",
                    false
                );
            }

            var data = string.Join("=", parts.Skip(1));

            return new ParsedLine(
                key.Trim(),
                data,
                "",
                false
            );
        }


        private string TrimComment(string str)
        {
            str = str.Trim();
            return str.StartsWith(";")
                ? str.Substring(1)
                : str;
        }
    }

    internal class ParsedLine : IParsedLine
    {
        public string Key { get; }
        public string Value { get; }
        public string Comment { get; }
        public bool ContainedEscapedEntities { get; }

        public ParsedLine(
            string key,
            string value,
            string comment,
            bool containedEscapedEntities
        )
        {
            Key = key;
            Value = value;
            Comment = comment;
            ContainedEscapedEntities = containedEscapedEntities;
        }
    }
}
