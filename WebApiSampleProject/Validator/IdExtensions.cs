using System.Text;

namespace WebApiSampleProject.Validator
{
    public static class IdExtensions
    {
       
        public static string RemoveSpecialCharacthers(this string ssn)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < ssn?.Length; i++)
            {
                if (char.IsLetterOrDigit(ssn[i]))
                {
                    sb.Append(ssn[i]);
                }
            }
            return sb.ToString();
        }

        public static int ToInt(this char c)
        {
            return Convert.ToInt32(c) - Convert.ToInt32('0');
        }

    }
}
