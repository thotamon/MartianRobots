﻿namespace MartianRobots.Core.Enums
{
    using System;
    using System.ComponentModel;
    using System.Linq;

    /// <summary>
    /// Helper class for extraction enum description attribute value
    /// </summary>
    public static class DescriptionHelper
    {
        public static string GetEnumDescription(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());

            var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }
    }
}
