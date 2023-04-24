using System;


namespace R5T.F0121
{
    public class Characters : ICharacters
    {
        #region Infrastructure

        public static ICharacters Instance { get; } = new Characters();


        private Characters()
        {
        }

        #endregion
    }
}
