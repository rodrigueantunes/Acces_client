# Accès Client - Gestion des fichiers

## Description

Accès Client est une application Windows Forms en C# qui permet de gérer des fichiers situés dans différents répertoires. L'application charge les fichiers à partir d'un répertoire spécifié et les organise en catégories (Any, RDS, VPN) selon leur nom. Les fichiers sont affichés dans des boutons interactifs, et lorsque l'utilisateur clique sur un bouton, le fichier correspondant est ouvert avec l'application par défaut de Windows.

L'interface utilisateur est simple et utilise des `FlowLayoutPanel` pour afficher dynamiquement les fichiers sous forme de boutons. Le programme supprime les préfixes "Any-", "RDS-" et "VPN-" du nom des fichiers affichés sur les boutons, et retire également les extensions des fichiers.

## Fonctionnalités

- Chargement dynamique des répertoires et fichiers à partir du répertoire spécifié.
- Classification des fichiers en 3 catégories : **Any**, **RDS**, et **VPN**.
- Affichage des fichiers sous forme de boutons dans l'interface graphique.
- Lors du clic sur un bouton, le fichier est ouvert avec l'application associée par défaut.
- Suppression des préfixes (`Any-`, `RDS-`, `VPN-`) et des extensions des noms de fichiers sur les boutons.

## Prérequis

Pour faire fonctionner cette application, vous devez disposer des éléments suivants :

- **Visual Studio** ou un autre éditeur C# compatible.
- **.NET Framework 4.7.2** ou supérieur (la version minimale du framework doit être compatible avec Windows Forms).
- **C# 8.0** ou supérieur.
- L'accès à un répertoire contenant des fichiers avec les préfixes spécifiés (`Any-`, `RDS-`, `VPN-`).

## Installation

1. Téléchargez la dernière Release
2. Exécutez le programme.

## Fonctionnement de l'application

### 1. Chargement des répertoires
Lorsque l'application démarre, elle tente de charger les répertoires situés sous `C:\Application\Clients\`. Pour chaque répertoire trouvé, un bouton est ajouté à l'interface utilisateur.

### 2. Chargement des fichiers
Lorsque l'utilisateur clique sur un bouton représentant un répertoire, l'application charge les fichiers de ce répertoire et les trie en fonction de leur préfixe (`Any-`, `RDS-`, ou `VPN-`). Chaque fichier est représenté par un bouton.

### 3. Ouverture des fichiers
Lorsque l'utilisateur clique sur un fichier, celui-ci s'ouvre avec l'application par défaut associée à son extension. Si le fichier est un document texte, une image, ou tout autre type de fichier, il sera ouvert dans l'application appropriée.

## Structure du Code

### `Form1.cs`
Le fichier principal de l'application. Il contient la logique nécessaire pour afficher les répertoires et fichiers, ainsi que pour gérer les événements de clic sur les boutons représentant les répertoires et fichiers.

- `LoadDirectories()` : Charge les répertoires et crée des boutons pour chacun d'eux.
- `LoadFiles()` : Charge les fichiers d'un répertoire et les trie en fonction de leur préfixe.
- `DirectoryButton_Click()` : Gère l'événement de clic sur un bouton représentant un répertoire.
- `FileButton_Click()` : Gère l'événement de clic sur un bouton représentant un fichier et ouvre ce fichier avec le programme par défaut.

## Fichiers et Répertoires

- Les répertoires sont chargés à partir du chemin `C:\Application\Clients\`.
- Les fichiers sont affichés dans trois catégories en fonction du préfixe de leur nom :
  - **Any-** : Fichiers qui commencent par "Any-".
  - **RDS-** : Fichiers qui commencent par "RDS-".
  - **VPN-** : Fichiers qui commencent par "VPN-".

## Contribuer

Les contributions sont les bienvenues ! Si vous avez des améliorations ou des corrections de bugs à proposer, veuillez créer une branche et soumettre une pull request. Assurez-vous de bien documenter vos changements.

## Licence

Ce projet est sous la licence MIT. 

### Conclusion

Le fichier `README.md` est maintenant entièrement structuré et formalisé au format GitHub pour offrir une documentation claire et détaillée de votre projet. Il est prêt à être intégré dans votre repository GitHub.
