using System;

using R5T.T0055;


namespace System
{
    public static partial class IGuidOperatorExtensions
    {
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
        public static Guid GetNewSeededGuid(this IGuidOperator _,
            Random random)
        {
            var guidBytes = new byte[16];

            random.NextBytes(guidBytes);

            var output = new Guid(guidBytes);
            return output;
        }
    }
}