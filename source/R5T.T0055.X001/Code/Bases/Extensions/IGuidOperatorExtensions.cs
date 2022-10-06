using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.Magyar;

using R5T.T0055;


namespace System
{
    public static partial class IGuidOperatorExtensions
    {
        /// <summary>
        /// All zeroes (0's).
        /// </summary>
        public static Guid DefaultGuid(this IGuidOperator _)
        {
            var output = new Guid();
            return output;
        }

        public static bool IsDefault(this IGuidOperator _,
            Guid guid)
        {
            var output = guid == default;
            return output;
        }

        public static bool IsSet(this IGuidOperator _,
            Guid guid)
        {
            var isDefault = _.IsDefault(guid);

            var output = !isDefault;
            return output;
        }

        /// <summary>
        /// Quality of life overload for <see cref="IsDefault(IGuidOperator, Guid)"/>.
        /// </summary>
        public static bool IsUnset(this IGuidOperator _,
            Guid guid)
        {
            var output = _.IsDefault(guid);
            return output;
        }

        public static Guid NewGuid(this IGuidOperator _)
        {
            var output = Guid.NewGuid();
            return output;
        }

        /// <summary>
        /// Uses <see cref="ToStringStandard(IGuidOperator, Guid)"/>.
        /// </summary>
        public static string NewGuidString(this IGuidOperator _)
        {
            var guid = _.NewGuid();

            var output = _.ToStringStandard(guid);
            return output;
        }

        // Source: https://stackoverflow.com/a/13188409/10658484
        public static Guid NewSeededGuid(this IGuidOperator _,
            Random random)
        {
            var guidBytes = new byte[16];

            random.NextBytes(guidBytes);

            var output = new Guid(guidBytes);
            return output;
        }
    }
}


namespace System.IO
{
    using R5T.Magyar.IO;


    public static partial class IGuidOperatorExtensions
    {
        public static async Task<Guid[]> ReadGuidsFromTextFile(this IGuidOperator _,
            TextReader reader,
            string separator,
            Func<string, Guid> parser)
        {
            var data = await reader.ReadToEndAsync();

            // Do not keep empty tokens.
            var tokens = data.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            var output = tokens
                .Select(parser)
                .ToArray();

            return output;
        }

        public static async Task<Guid[]> ReadGuidsFromTextFile(this IGuidOperator _,
            string filePath)
        {
            using var reader = TextReaderHelper.New(filePath);

            var output = await _.ReadGuidsFromTextFile(
                reader,
                Strings.NewLineForEnvironment,
                _.FromStringStandard);

            return output;
        }

        public static async Task WriteGuidsToTextFile(this IGuidOperator _,
            TextWriter writer,
            IEnumerable<Guid> values,
            string separator,
            Func<Guid, string> formatter)
        {
            var tokens = values
                .Select(formatter)
                .Now_OLD();

            var data = String.Join(separator, tokens);

            await writer.WriteAsync(data);
        }

        public static async Task WriteGuidsToTextFile(this IGuidOperator _,
            string filePath,
            IEnumerable<Guid> values)
        {
            using var writer = TextWriterHelper.New(filePath);

            await _.WriteGuidsToTextFile(
                writer,
                values,
                Strings.NewLineForEnvironment,
                _.ToStringStandard);
        }
    }
}