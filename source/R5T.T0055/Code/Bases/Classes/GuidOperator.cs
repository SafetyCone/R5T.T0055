using System;


namespace R5T.T0055
{
    /// <summary>
    /// Empty implementation as base for extension methods.
    /// </summary>
    public class GuidOperator : IGuidOperator
    {
        #region Static
        
        public static GuidOperator Instance { get; } = new();

        #endregion
    }
}