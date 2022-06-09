using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0055;


namespace System
{
    public static partial class IGuidOperatorExtensions
    {
        public static Guid FromStringStandard(this IGuidOperator _,
            string guidString)
        {
            var output = Guid.Parse(guidString);
            return output;
        }

        public static IEnumerable<Guid> FromStringsStandard(this IGuidOperator _,
            IEnumerable<string> guidStrings)
        {
            var output = guidStrings
                .Select(x => _.FromStringStandard(x))
                ;

            return output;
        }

        /// <summary>
        /// Chooses <see cref="ToStringUppercase(IGuidOperator, Guid)"/> as the standard.
        /// The standard string representation of a GUID.
        /// </summary>
        /// <remarks>
        /// See the discussion of formats here: https://docs.microsoft.com/en-us/dotnet/api/system.guid.tostring?view=netcore-2.2.
        /// </remarks>
        public static string ToStringStandard(this IGuidOperator _,
            Guid guid)
        {
            var representation = _.ToStringUppercase(guid);
            return representation;
        }

        /// <summary>
        /// Returns a GUID in uppercase format.
        /// Example: 382C74C3-721D-4F34-80E5-57657B6CBC27.
        /// </summary>
        public static string ToStringUppercase(this IGuidOperator _,
            Guid guid)
        {
            var representation = guid.ToString("D").ToUpperInvariant();
            return representation;
        }

        /// <summary>
        /// Returns a GUID in uppercase format, bracketed.
        /// Example: {382C74C3-721D-4F34-80E5-57657B6CBC27}.
        /// </summary>
        public static string ToStringUppercaseBracketed(this IGuidOperator _,
            Guid guid)
        {
            var representation = guid.ToString("B").ToUpperInvariant();
            return representation;
        }
    }
}