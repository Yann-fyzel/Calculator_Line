# Fyf Calculator (`fcalc`)

Fyf Calculator est une application console en .NET 9 permettant d'effectuer des opérations arithmétiques de base (addition, soustraction, multiplication, division) en ligne de commande, avec gestion du format et de la précision d'affichage.

## Fonctionnalités

- Addition, soustraction, multiplication et division sur des listes de nombres ou deux nombres.
- Personnalisation du format d'affichage (`F` pour un nombre fixe de décimales, `G` pour un nombre significatif de chiffres).
- Précision configurable du résultat.
- Affichage coloré des résultats et des avertissements.
- Commande `solve` prévue pour des opérations avancées (en développement).

## Prérequis

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) (pour le développement ou l'exécution via `dotnet run`)
- **OU** le runtime .NET 9 uniquement (pour exécuter l'exécutable autonome)
- Les packages NuGet suivants sont utilisés :
  - `System.CommandLine`
  - `Spectre.Console`

## Utilisation

### Si vous avez le SDK ou le runtime .NET 9 installé

Lancez l'application depuis la ligne de commande : `dotnet run -- [commande] [arguments] [options]`

Ou, après publication : `fcalc [commande] [arguments] [options]`

### Si vous n'avez PAS le runtime .NET installé

1. Récupérez le fichier `fcalc.exe` généré dans le dossier correspondant a votre systeme `ex: win-x64`.
2. **Option 1 :** Ajoutez le dossier contenant `fcalc.exe` à votre variable d'environnement `PATH` pour pouvoir l'exécuter depuis n'importe où.
3. **Option 2 :** Exécutez les commandes directement dans le dossier où se trouve `fcalc.exe` : `./fcalc.exe [commande] [arguments] [options]`
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

Addition de deux nombres avec 3 décimales : `fcalc add 10.124 20.276 -p 3`

Soustraction de plusieurs nombres avec format significatif : `fcalc sub 100 20 5 -f G -p 4`

Multiplication de plusieurs nombres : `fcalc mty 2 3 4`

Division de deux nombres avec 5 décimales : `fcalc div 10 3 -f F -p 5`

## Aide

Pour afficher l'aide : `fcalc --help`

Pour afficher l'aide d'une commande spécifique : `fcalc [commande] --help`

## Structure du projet

- `Program.cs` : Point d'entrée, définition des commandes et logique principale.
- `Description.cs` : Personnalisation de l'affichage de l'aide.
- `Calculator_Line.csproj` : Fichier projet et dépendances.
- `README.md` : Documentation du projet.

## Contribution
Les contributions sont les bienvenues ! N'hésitez pas à ouvrir des issues ou des pull requests pour améliorer l'application.