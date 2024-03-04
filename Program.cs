namespace RpnOne
{
    internal class Program
    {

        static void Main(string[] args)
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
                    // Echo 
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


    }
}