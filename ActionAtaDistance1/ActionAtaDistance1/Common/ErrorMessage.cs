using System;
using System.Text;

namespace ActionAtaDistance1.Common
{
    public static class ErrorMessage
    {
        public static string ReturnErrorMessage(Exception exception, string ErrorString)
        {
            if (exception == null)
            {
                return ErrorString;
            }

            StringBuilder sb = new StringBuilder(ErrorString);
            if (!string.IsNullOrEmpty(ErrorString))
            {
                sb.AppendLine();
            }
            sb.Append(exception.Message);

            return ReturnErrorMessage(exception.InnerException, sb.ToString());
        }
    }
}
