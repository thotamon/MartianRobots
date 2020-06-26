namespace MartianRobots.Core
{
    using MartianRobots.Core.Actions;
    using MartianRobots.Core.Enums;
    using MartianRobots.Core.Exceptions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Simple input text command parser.Translates text to sequence of actions.
    /// </summary>
    public static class MartianRobotCommandParser
    {
        private enum TokenType
        {
            Empty = 0,
            CharCommand,
            TextValue,
            Num
        }

        private enum SubType
        {
            None = 0,
            Orientation,
            MoveOrRotate
        }

        private class Token
        {
            public TokenType TokenType { get; set; }
            public SubType SubType { get; set; }
            public string StringValue { get; set; }
            public int NumericValue { get; set; }

            public Token(TokenType tokenType)
            {
                this.TokenType = tokenType;
            }
        }

        private static Regex orientationChar = new Regex("[NSEW]", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private static Regex moveOrRoteateChar = new Regex("[LRF]", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private static Regex commandChar = new Regex("[NSEWLRF]", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private static Dictionary<char, RobotOrientation> oriantationIndex = new Dictionary<char, RobotOrientation>() 
        { 
          {'n', RobotOrientation.North }, 
          {'s', RobotOrientation.South }, 
          {'e', RobotOrientation.East },
          {'w', RobotOrientation.West } 
        };

        /// <summary>
        /// Assume context-free grammar
        /// InitSurface := num num
        /// PlaceRobot := num num orientation
        /// RobotAction := rotation | move
        /// RobotActionSequence := RobotActionSequence RobotAction | RobotAction
        /// </summary>
        /// <returns></returns>
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

            var prefetch = new Queue<Token>();
            foreach (var token in tokens)
            {
                prefetch.Enqueue(token);
                if (TryToExtractLongestRule(prefetch, out var action))
                {
                    yield return action;
                }
            }

            if (prefetch.Count == 2)
            {
                var first = prefetch.Dequeue();
                var second = prefetch.Dequeue();

                if (first.TokenType == TokenType.Num && second.TokenType == TokenType.Num)
                {
                    yield return new InitializeMarthianSurface(first.NumericValue + 1, second.NumericValue + 1);
                }
            }

            if (prefetch.Any())
            {
                throw new GrammarException();
            }
        }

        private static ISceneAction CreateMoveOrRotateAction(Token token)
        {
            var c = char.ToLower(token.StringValue[0]);
            return c switch
            {
                'f' => new MartianRobotMoveAction(),
                'l' => new MartianRobotRotateAction(RobotDirection.Left),
                'r' => new MartianRobotRotateAction(RobotDirection.Right),
                _ => throw new GrammarException(),
            };
        }

        private static bool TryToExtractLongestRule(Queue<Token> prefetch, out ISceneAction action)
        {
            action = null;
            if (!prefetch.Any())
            {
                return false;
            }

            if (prefetch.Count == 3)
            {
                var first = prefetch.Dequeue();
                var second = prefetch.Dequeue();
                var third = prefetch.Dequeue();

                if (first.TokenType == TokenType.Num && second.TokenType == TokenType.Num && third.TokenType == TokenType.CharCommand)
                {
                    if (third.SubType == SubType.Orientation)
                    {
                        action = new PlaceRobotAction(first.NumericValue, second.NumericValue, ParseRobotOrientation(third.StringValue));
                    }
                    else
                    {
                        action = new InitializeMarthianSurface(first.NumericValue + 1, second.NumericValue + 1);
                        prefetch.Enqueue(third);
                    }

                    return true;
                }
            }

            if (prefetch.Count == 1)
            {
                var first = prefetch.Dequeue();
                if (first.TokenType == TokenType.CharCommand && first.SubType == SubType.MoveOrRotate)
                {
                    action = CreateMoveOrRotateAction(first);
                    return true;
                }
                else
                {
                    prefetch.Enqueue(first);
                }
            }

            return false;
        }

        private static RobotOrientation ParseRobotOrientation(string value)
        {
            return oriantationIndex[char.ToLower(value[0])];
        }

        private static SubType CalculateSubType(char c)
        {
            if (orientationChar.IsMatch(c.ToString()))
            {
                return SubType.Orientation;
            }

            if (moveOrRoteateChar.IsMatch(c.ToString()))
            {
                return SubType.MoveOrRotate;
            }

            return SubType.None;
        }

        private static IEnumerable<Token> ClassifyToken (string text)
        {
            if (text.Length == 1 && commandChar.IsMatch(text[0].ToString()))
            {
                yield return new Token(TokenType.CharCommand) { SubType = CalculateSubType(text[0]), StringValue = text };
                yield break;
            }

            if (text.All(c => commandChar.IsMatch(c.ToString())))
            {
                foreach (var c in text)
                {
                    yield return new Token(TokenType.CharCommand) { SubType = CalculateSubType(c), StringValue = c.ToString() };
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
