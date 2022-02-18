using System.Net.Mail;

namespace CoinRLogic;

public class LoginHelper
{
    public static bool checkIfEmail(String email)
    {
        string trimmedemail = email.Trim();
        try
        {
            MailAddress emailAdress = new MailAddress(trimmedemail);
        }
        catch (Exception ex)
        {
            return false;
        }

        return true;
    }
}