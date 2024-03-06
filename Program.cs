namespace RpnOne
{
    internal class Program
    {

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Shell();
                return;
            }

            if (args.Length > 0)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    string option = args[i].ToUpper().Trim();
                    if (option == "-H")
                    {
                        Usage();
                        return;
                    }
                }
            }

            if (args.Length == 1)
            {
                string filename = args[0];
                ReadFile(filename);
                return;
            }

            if (args.Length > 2)
            {
                Usage();
            }

        }

        static void Usage()
        {
            Console.WriteLine("Usage: RpnOne [filename] ");
            Console.WriteLine("FileName optional.");
            Console.WriteLine("Purpose:  Command-Line Calculator.");
        }

        static void Shell()
        {
            Util util = new Util();
            double result = 0.0;

            while (true)
            {
                Console.Write("> ");
                var input = Console.ReadLine();
                if (String.IsNullOrEmpty(input))
                {
                    break;
                }

                if (Console.IsInputRedirected)
                {
                    Console.WriteLine(input);
                }

                try
                {
                    result = util.Eval(input);
                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }


        static void ReadFile(string fileName)
        {
            Util util = new Util();
            double result = 0.0;

            if (!File.Exists(fileName))
            {
                Console.WriteLine("FileName not found:  {0}", fileName);
                return;
            }

            using (StreamReader sr = new StreamReader(fileName))
            {
                while (true)
                {
                    Console.Write("> ");
                    var input = sr.ReadLine();
                    if (String.IsNullOrEmpty(input))
                    {
                        break;
                    }

                    // Echo 
                    Console.WriteLine(input);

                    try
                    {
                        result = util.Eval(input);
                        Console.WriteLine(result);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }


    }
}