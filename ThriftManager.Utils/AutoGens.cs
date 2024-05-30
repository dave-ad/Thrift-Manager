namespace ThriftManager.Utils;

public class AutoGens
{

    private static int upper = 99999999;
    private static int lower = 12345678;

    public static string GenerateWalletNo()
    {
        var random = new Random();
        var accountNo = random.Next(lower, upper);
        if (accountNo == 0)
        {
            accountNo = random.Next(lower, upper);
            if (accountNo == 0)
            {
                throw new ApplicationException("Unable to generate Account Number");
            }
        }

        //var accountNumber = "";

        //switch (accountType)
        //{
        //    case AccountType.Savings:
        //        accountNumber = $"1{accountNo:D10}";
        //        break;
        //    case AccountType.Current:
        //        break;
        //    case AccountType.Fixed:
        //        break;
        //    case AccountType.Collection:
        //        break;
        //    default:
        //        break;
        //}

        return accountNo.ToString("D10");
    }
}