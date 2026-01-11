using Spectre.Console;
using System;
using System.Collections.Generic;
using System.CommandLine.Help;
using System.CommandLine.Invocation;
using System.CommandLine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_Line
{

    public enum FormatOptions { G, F}
    internal class Description : SynchronousCommandLineAction
    {
        private readonly HelpAction _defaultHelp;

        public Description(HelpAction action) => _defaultHelp = action;

        public override int Invoke(ParseResult parseResult)
        {
            Spectre.Console.AnsiConsole.Write(new FigletText(parseResult.RootCommandResult.Command.Description!));

            int result = _defaultHelp.Invoke(parseResult);

            Spectre.Console.AnsiConsole.WriteLine("Sample usage: fcalc mty 10,124 20,276 -p 3");

            return result;
        }
    }
}
