# Fyf Calculator (`fcalc`)

Fyf Calculator est une application console en .NET 9 permettant d'effectuer des opérations arithmétiques de base (addition, soustraction, multiplication, division) en ligne de commande, avec gestion du format et de la précision d'affichage.

## Fonctionnalités

- Addition, soustraction, multiplication et division sur des listes de nombres ou deux nombres.
- Personnalisation du format d'affichage (`F` pour un nombre fixe de décimales, `G` pour un nombre significatif de chiffres).
- Précision configurable du résultat.
- Affichage coloré des résultats et des avertissements.
- Commande `solve` prévue pour des opérations avancées (en développement).

## Prérequis

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Les packages NuGet suivants sont utilisés :
  - `System.CommandLine`
  - `Spectre.Console`

## Installation

Clonez le dépôt et restaurez les dépendances NuGet :

git clone <votre-repo> cd <votre-repo> dotnet restore

## Utilisation

Lancez l'application depuis la ligne de commande :
dotnet run -- [commande] [arguments] [options]

### Commandes disponibles

- `add` : Additionne une liste de nombres.
- `sub` : Soustrait une liste de nombres.
- `mty` : Multiplie une liste de nombres.
- `div` : Divise deux nombres.
- `solve` : (En développement) Résout une opération à partir d'une chaîne ou d'un fichier.

### Options globales

- `-p`, `--precision` : Nombre de chiffres significatifs ou décimales (défaut : 2).
- `-f`, `--format` : Format d'affichage (`F` ou `G`, défaut : `F`).

### Exemples

Addition de deux nombres avec 3 décimales :		dotnet run -- add 10.124 20.276 -p 3

Soustraction de plusieurs nombres avec format significatif :		dotnet run -- sub 100 20 5 -f G -p 4

Multiplication de plusieurs nombres :		dotnet run -- mty 2 3 4

Division de deux nombres avec 5 décimales :		dotnet run -- div 10 3 -f F -p 5


## Aide

Pour afficher l'aide :		dotnet run -- --help
Pour afficher l'aide d'une commande spécifique :		dotnet run -- [commande] --help


## Structure du projet

- `Program.cs` : Point d'entrée, définition des commandes et logique principale.
- `Description.cs` : Personnalisation de l'affichage de l'aide.
- `Calculator_Line.csproj` : Fichier projet et dépendances.
- `README.md` : Documentation du projet.

## Contribution
Les contributions sont les bienvenues ! N'hésitez pas à ouvrir des issues ou des pull requests pour améliorer l'application.

## Licence
Ce projet est sous licence MIT. Voir le fichier LICENSE pour plus de détails.
