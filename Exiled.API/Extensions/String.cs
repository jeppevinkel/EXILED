// -----------------------------------------------------------------------
// <copyright file="String.cs" company="Exiled Team">
// Copyright (c) Exiled Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.API.Extensions
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    /// <summary>
    /// A set of extensions for <see cref="string"/>.
    /// </summary>
    public static class String
    {
        /// <summary>
        /// Compute the distance between two <see cref="string"/>.
        /// </summary>
        /// <param name="firstString">The first string to be compared.</param>
        /// <param name="secondString">The second string to be compared.</param>
        /// <returns>Returns the distance between the two strings.</returns>
        public static int GetDistance(this string firstString, string secondString)
        {
            int n = firstString.Length;
            int m = secondString.Length;
            int[,] d = new int[n + 1, m + 1];

            if (n == 0)
                return m;

            if (m == 0)
                return n;

            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int cost = (secondString[j - 1] == firstString[i - 1]) ? 0 : 1;

                    d[i, j] = Math.Min(Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1), d[i - 1, j - 1] + cost);
                }
            }

            return d[n, m];
        }

        /// <summary>
        /// Extract command name and arguments from a <see cref="string"/>.
        /// </summary>
        /// <param name="commandLine">The <see cref="string"/> to extract from.</param>
        /// <returns>Returns a <see cref="ValueTuple"/> containing the exctracted command name and arguments.</returns>
        public static (string commandName, string[] arguments) ExtractCommand(this string commandLine)
        {
            string[] extractedArguments = commandLine.Split(' ');

            return (extractedArguments[0].ToLower(), extractedArguments.Skip(1).ToArray());
        }

        /// <summary>
        /// Converts a <see cref="string"/> to snake_case convention.
        /// </summary>
        /// <param name="str">The string to be converted.</param>
        /// <param name="shouldReplaceSpecialChars">Indicates whether special chars has to be replaced or not.</param>
        /// <returns>Returns the new snake_case string.</returns>
        public static string ToSnakeCase(this string str, bool shouldReplaceSpecialChars = true)
        {
            string snakeCaseString = string.Concat(str.Select((ch, i) => i > 0 && char.IsUpper(ch) ? "_" + ch.ToString() : ch.ToString())).ToLower();

            return shouldReplaceSpecialChars ? Regex.Replace(snakeCaseString, @"[^0-9a-zA-Z_]+", string.Empty) : snakeCaseString;
        }
    }
}
