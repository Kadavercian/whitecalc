using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using whiteMath.Functions;

namespace whiteCalc
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 0 || string.IsNullOrWhiteSpace(string.Concat(args)))
            {
                Console.WriteLine();
                Console.WriteLine("Syntax: whitecalc \"[function] [<< argumentValue]\".");
                Console.WriteLine();
                Console.WriteLine("Parameter description:");
                Console.WriteLine();
                Console.WriteLine("\t[function] - a required argument. Either a function of 'x' (i.e. '2sin(x) + 6') or an expression (i.e. '63^2 + cos(25)').");
                Console.WriteLine("\t[<< argumentValue] - an optional parameter specifying the value of 'x'. If not specified, x will be assumed equal to 0.");
                Console.WriteLine();
                Console.WriteLine("The result of the evaluation will be copied to the clipboard.");
                Console.WriteLine();
                Console.WriteLine("Please note the usage of the double quotes.");
                Console.WriteLine("Also note that the 'argumentValue' MUST be preceded by an '<<'.");
                Console.WriteLine();
                Console.WriteLine("Example call and output: ");
                Console.WriteLine();
                Console.WriteLine("whitecalc 2x^2 + 5sin(x) + 6 << 8");
                Console.WriteLine("--| x = 8 |-| res = 138.946791233117 |--");
                Console.WriteLine("--| 'res' copied to clipboard |--");
                return;
            }

            string arg = string.Concat(args).Replace(" ", "");

            int     indexOfArgumentArea = arg.IndexOf("<<");            
            double  argumentValue = 0;

            if (indexOfArgumentArea != arg.LastIndexOf("<<"))
            {
                Console.WriteLine("ERROR: The incoming string contained several '<<' symbols");
                return;
            }

            if (indexOfArgumentArea >= 0 && !double.TryParse(arg.Substring(indexOfArgumentArea + 2), out argumentValue))
            {
                Console.WriteLine("ERROR: Could not parse the argument value into a number.");
                return;
            }

            if (indexOfArgumentArea >= 0)
                arg = whiteMath.General.OtherExtensions.SubstringToIndex(arg, 0, indexOfArgumentArea);

            AnalyticFunction fun = new AnalyticFunction("f(x)=" + arg);

            try
            {
                double functionValue = fun[argumentValue];

                Console.WriteLine("--| x = {0} |-| res = {1} |--", argumentValue, functionValue);

                System.Windows.Forms.Clipboard.SetText(functionValue.ToString());
                Console.WriteLine("--| 'res' copied to clipboard |--");  
            }
            catch (Exception exception)
            {
                Console.WriteLine(string.Format("ERROR: Could not calculate the value of {0}: {1}", fun.ToString(), exception.Message));
            }

            return;
        }
    }
}
