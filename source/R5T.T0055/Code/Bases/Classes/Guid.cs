using System;


namespace R5T.T0055
{
    /// <summary>
    /// Empty implementation as base for extension methods.
    /// </summary>
    public class Guid : IGuid
    {
        #region Static
        
        public static Guid Instance { get; } = new();

        #endregion
    }
}