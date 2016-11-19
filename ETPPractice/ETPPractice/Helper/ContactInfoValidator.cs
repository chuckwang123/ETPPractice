using System;
using System.Text.RegularExpressions;
using ETPPractice.Models;
using FluentValidation;

namespace ETPPractice.Helper
{
    public class ContactInfoValidator : AbstractValidator<ContactInfo>
    {
        public ContactInfoValidator()
        {
            RuleFor(contactInfo => contactInfo.id).NotEqual(1);
            RuleFor(contactInfo => contactInfo.Email).NotEmpty().Must(BeEmail);
            RuleFor(contactInfo => contactInfo.Name).NotEmpty();
            RuleFor(contactInfo => contactInfo.checkList_id.ToString()).Length(20, 250);
            RuleFor(contactInfo => contactInfo.role_ID).NotEmpty();
            RuleFor(contactInfo => contactInfo.org_position).NotEmpty().WithMessage("Please include the orginazation position");
        }

        private static bool BeEmail(string strIn)
        {
            if (string.IsNullOrEmpty(strIn))
                return false;
            try
            {
                return Regex.IsMatch(strIn,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}
