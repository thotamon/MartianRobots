using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace MartianRobots.Core
{
    public static class MartianRobotCommandParser
    {
        private sealed class CharInvariantComparerIgnoreCase : IEqualityComparer<char>
        {
            public bool Equals([AllowNull] char x, [AllowNull] char y)
            {
                return StringComparer.InvariantCultureIgnoreCase.Compare(x.ToString(), y.ToString()) == 0;
            }

            public int GetHashCode([DisallowNull] char obj)
            {
                return obj.GetHashCode();
            }
        }

        private static HashSet<char> positionCharCommand = new HashSet<char>(new CharInvariantComparerIgnoreCase()) { 'n', 's', 'e', 'w' };
        private static HashSet<char> directionCharCommand = new HashSet<char>(new CharInvariantComparerIgnoreCase()) { 'l', 'r', 'f' };
        private static HashSet<char> charCommands = new HashSet<char>(positionCharCommand.Union(directionCharCommand), new CharInvariantComparerIgnoreCase()); 
        // new HashSet<char>(new CharInvariantComparerIgnoreCase()) { 'l', 'r', 'f', 'n', 's', 'e', 'w' };

        private enum TokenType
        {
            Empty = 0,
            CharCommand,
            TextValue, 
            Num
        }

        private class Token
        {
            public TokenType TokenType { get; set; }
            public string StringValue { get; set; }
            public int NumericValue { get; set; }

            public Token(TokenType tokenType)
            {
                this.TokenType = TokenType;
            }
        }

        public static IEnumerable<ISceneAction> Parse(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                yield break;
            }

            if (command.Length > 100)
            {
                throw new ArgumentException(nameof(command));
            }

            var tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).SelectMany(token => ClassifyToken(token));

            var queue = new Queue<Token>();
            foreach (var token in tokens)
            {
                switch (token.Item2)
                {
                    case TokenType.CharCommand:
                    {
                        break;
                    }
                    case TokenType.Num:
                    {
                        break;
                    }
                    case TokenType.TextCommand:
                    {
                        break;
                    }
                }
            }
        }

        private static IEnumerable<Token> ClassifyToken (string text)
        {
            if (text.Length == 1 && charCommands.Contains(text[0]))
            {
                yield return new Token(TokenType.CharCommand) { StringValue = text };
                yield break;
            }

            if (text.All(c => charCommands.Contains(c)))
            {
                foreach (var c in text)
                {
                    yield return new Token(TokenType.CharCommand) { StringValue = c.ToString() };
                }
                yield break;
            }

            if (int.TryParse(text, out var value))
            {
                yield return new Token(TokenType.Num) { NumericValue = value };
                yield break;
            }

            yield return new Token(TokenType.Empty) { StringValue = text };
        }
    }
}
