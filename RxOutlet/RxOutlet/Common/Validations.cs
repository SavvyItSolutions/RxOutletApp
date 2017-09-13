using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;

namespace RxOutlet.Common
{
    public static class Validations
    {
        public static bool IsEmailValidate(string email)
        {
            try
            {
                string emailReg = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

                return Regex.IsMatch(email, emailReg) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Tuple<bool, string> IsPasswordValidate(string password)
        {
            try
            {
                StringBuilder msg = new StringBuilder();

                if (password.Length < 6)
                    msg.Append(Messages.PswLength);

                if (!Regex.IsMatch(password, @"[!@#$%^&*]"))
                    msg.Append(Messages.PswNonChar);

                if (!Regex.IsMatch(password, @"[A-Z]*$"))
                    msg.Append(Messages.PswAlp);

                if (!Regex.IsMatch(password, @"[0-9]*$"))
                    msg.Append(Messages.PswNo);

                return string.IsNullOrEmpty(msg.ToString()) ?
                    new Tuple<bool, string>(true, string.Empty) :
                    new Tuple<bool, string>(false, msg.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
