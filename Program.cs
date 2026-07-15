using System;
using OtpNet;
using TextCopy;


class Program
{

    static void ShowHelp()
    {
        string appName = OperatingSystem.IsWindows() ? "Authenticator.exe" : "./Authenticator";
        Console.WriteLine("Usage:");
        Console.WriteLine($"  {appName} --secret <value>  [options]\n");

        Console.WriteLine("Required:");
        Console.WriteLine("  --secret <value>     Secret string\n");
       

        Console.WriteLine("Optional:");
        Console.WriteLine("  --step <number>      Step size (default: 30)");
        Console.WriteLine("  --mode <number>      Hash mode: 1 = Sha1, 2 = Sha256, 3 = Sha512 (default: 1)");
        Console.WriteLine("  --totpSize <number>  TOTP size (default: 6)\n");
        Console.ReadKey();

    }

    static void Main(string []args)
    {
        
  

        string secret = null;
        
        int step = 30;
        int mode = 1;
        int totpSize = 6;


        for (int i = 0; i < args.Length; i++)
        {
            string arg = args[i];

            switch (arg)
            {
                case "--secret":
                    if (i + 1 < args.Length)
                        secret = args[++i];

                    break;

                case "--step":
                    if (i + 1 < args.Length && int.TryParse(args[++i], out int st))
                        step = st;
                    break;

                case "--mode":
                    if (i + 1 < args.Length && int.TryParse(args[++i], out int md))
                        mode = md;

                    break;

                case "--totpSize":
                    if (i + 1 < args.Length && int.TryParse(args[++i], out int ts))
                        totpSize = ts;
                    break;

                default:
                    ShowHelp();
                    return;
                
            }
        }
        if (String.IsNullOrEmpty(secret))
        {

            Console.WriteLine("Error: --secret is  required.\n");
            ShowHelp();
            return;

        }
        if (mode < 1 || mode > 3)
        {

            Console.WriteLine("Invalid value for --mode.");
            Console.WriteLine("Allowed values:");
            Console.WriteLine("  1 = Sha1");
            Console.WriteLine("  2 = Sha256");
            Console.WriteLine("  3 = Sha512");
            Console.ReadKey();
            return;

        }

        byte[] secretBytes = Base32Encoding.ToBytes(secret.Trim());

        var totp = new Totp(
            secretBytes,
            step: step,                       
            mode: (OtpHashMode)(mode-1),         
            totpSize: totpSize
        );
       
            string token = totp.ComputeTotp();
        ClipboardService.SetText(token);
        Console.WriteLine("Copied to clipboard");
        



    }
}