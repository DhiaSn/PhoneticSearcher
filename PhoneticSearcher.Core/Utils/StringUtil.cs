using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneticSearcher.Core.Utils
{
    public static class StringUtil
    {
        #region RemoveDiacritics
        /// <summary>
        /// Removes the diacritics and accents e.g. Société Générale -> Societe Generale
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>the cleaned string</returns>
        public static string RemoveDiacritics(string str)
        {
            // normalize the string to its full cannonical decomposition (formD)
            string formD = str.Normalize(NormalizationForm.FormD);
            var result = new StringBuilder();

            foreach (char chr in formD)
            {
                // checks what type of unicode it is
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(chr);

                // we leave out the nonSpacing Mark codes (diacritics, accents)
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    result.Append(chr);
                }
            }

            // convert back to the formC
            return (result.ToString().Normalize(NormalizationForm.FormC));
        }
        #endregion
    }
}
