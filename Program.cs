using System.CommandLine;
using System.CommandLine.Help;
using System.CommandLine.Parsing;
using System.Globalization;
using Calculator_Line;
using Spectre.Console;

// See https://aka.ms/new-console-template for more information




//  Options

Option<int> precisionOption = new("--precision", "-p")
{
    Description = "Nombre de chiffres significatifs en fontion du format",
    DefaultValueFactory = parse => 2,
    Recursive = true
};

Option<FormatOptions> formatOption = new("--format", "-f")
{
    Description = "Format (F pour excatement n chiffres apres la virgule et G pour exactement n chiffres)",
    DefaultValueFactory = parse => FormatOptions.F,
    Recursive = true,
};
formatOption.AcceptOnlyFromAmong(FormatOptions.G.ToString(), FormatOptions.F.ToString());




// Arguments

Argument<double> divArg1 = new("Dividende");
Argument<double> divArg2 = new("Diviseur");
Argument<List<double>> arguments = new("list integer")
{
    DefaultValueFactory = parse => [0, 0]
};



// Commandes et sous-commandes


Command addCommand = new Command("add", "Take a list of numbers and return their sum") { arguments };
addCommand.SetAction(parseResult => {
    try
    {
        Somme(parseResult.GetValue(arguments));
    }
    catch (Exception ex) { 
        Console.WriteLine(ex);
    }
});
Command subCommand = new Command("sub", "Take a list of numbers and return their difference") { arguments };
subCommand.SetAction(parse => Soustraction(parse.GetValue(arguments)));
Command multiplyCommand = new Command("mty","Take a list of numbers and return their product") { arguments };
multiplyCommand.SetAction(parse => Multiplication(parse.GetValue(arguments)));
Command divCommand = new Command("div", "Take two numbers and return the quotient") { divArg1, divArg2 };
divCommand.SetAction(parse => Division(parse.GetValue(divArg1), parse.GetValue(divArg2)));


Command solveCommand = new Command("solve","Take a string operation or a file and return the result. /// En production");


RootCommand rootCommand = new RootCommand("Fyf Calculator") {
    formatOption,precisionOption,addCommand, subCommand, multiplyCommand, divCommand, solveCommand
};


for (int i = 0; i < rootCommand.Options.Count; i++)
{
    // RootCommand has a default HelpOption; update its Action.
    if (rootCommand.Options[i] is HelpOption defaultHelpOption)
    {
        defaultHelpOption.Action = new Description((HelpAction)defaultHelpOption.Action!);
        break;
    }
}

ParseResult parseResult = rootCommand.Parse(args);

Appconfig.precision = parseResult.GetValue(precisionOption);
Appconfig.format = parseResult.GetValue(formatOption);

rootCommand.Parse(args).Invoke();


// Logique des commandes
double Somme(List<double>? values)
{
    double sum = 0;
    if (values != null)
    {
        foreach (double value in values)
        {
            sum += value;
        }
        //Console.WriteLine($" Resultat :  {sum:G}");
        AfficherResultat(sum);
    }
    else
    {
        //Console.WriteLine("Aucun arguments recus");
        AfficheErreur("Arguments non recus");
    }
    return sum;
}



double Soustraction(List<double>? values)
{
    double diff = 0;
    if (values != null)
    {
        foreach (double value in values)
        {
            diff -= value;
        }
        AfficherResultat(diff);
    }
    else
    {
        AfficheErreur("Arguments non recus");
    }
    return diff;
}


double Multiplication(List<double>? values)
{
    double mty = 1;
    if (values != null)
    {
        foreach (double value in values)
        {
            mty *= value;
        }
        AfficherResultat(mty);
    }
    else
    {
        AfficheErreur("Erreur lors de l'operation");
    }
    return mty;
}



double Division(double dividende, double diviseur)
{
    double quotient = 1;
    if (diviseur != 0)
    {
        quotient = dividende / diviseur;
        AfficherResultat(quotient);
    }
    else
    {
        AfficheErreur("Division Invalide");
    }
    return quotient;
}

//Console.WriteLine("Hello, World!");




//  Affichage des informations e des traitements

void AfficheErreur(string message)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Error.WriteLine($"[WARNING] {message}");
    Console.ResetColor();
}


void AfficherResultat(double result)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"Resultat : {result.ToString($"{Appconfig.format}{Appconfig.precision}")}");
    Console.ResetColor();
}