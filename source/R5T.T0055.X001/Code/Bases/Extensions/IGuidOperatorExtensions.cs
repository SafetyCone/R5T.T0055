using System;

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