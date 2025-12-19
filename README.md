# PO3L--Chess-DB

## Introduction

Dans le cadre du projet Chess DB, nous devions développer une application de gestion pour une fédération d’échecs afin de faciliter la gestion administrative des joueurs, des compétitions et des parties jouées

L’application est conçue pour être utilisée par le personnel administratif, qui encode les informations sur base des échanges avec les joueurs et des deroulements des tournois.

L’application permet de

- gérer les joueurs
- d’organiser des compétitions
- d’inscrire les joueurs à celles-ci et d’encoder
  les parties avec leurs coups et leurs résultats
- calculer automatiquement le classement ELO

## Fonctionnalité supplementaire

2 "fonctionnalité" supplémentaire ont été choisies :

- Une page <b>Ranking</b> qui permet d’afficher les joueurs classés automatiquement selon leur score ELO, du plus élevé au plus faible

  ![Ranking](/Images/Ranking.png)

  <p align="center">
  Figure 1 – Home
  </p>

- Une page <b>Home</b> qui permet de voir certaines statistiques globales (nombre de joueurs, elo Moyen, tournois actifs). Elle propose egalement des <b>quick actions</b> permettant d’accéder facilement aux fonctionnalités les plus utilisées (ajout d’un joueur, création d’une compétition, enregistrement d'un joueur).

  ![Home](/Images/Home.png)
  <p align="center">
  Figure 2 – Ranking
  </p>

## Diagrammes

### Diagramme de classe

Le diagramme de classes a été utilisé afin de représenter les entités principales, les entités "Metier" de l’application et les relations entre elles, les ViewModel et Services n'ont pas été inclus car nous estimons qu'elle n'ont pas vraiment leur place dans ce diagramme de classe elle le rendrait juste illisible. Il permet de visualiser clairement la structure des données, telles que les joueurs, les parties et les compétitions.

## ![Diagramme de classe](/Images/Class_diagram.svg)

### Diagramme de sequence

Le diagramme de séquence a été choisi pour illustrer le déroulement d’un scénario clé de l’application, à savoir l’encodage d’une partie, le calcul du score ELO et la sauvegarde des données. Il permet de montrer l’ordre des interactions entre les différents composants du système et les services impliqués.

## ![Diagramme de sequence](/Images/Sequence_EncodeGame_ApplyElo.svg)

### Diagramme d'activité

Le diagramme d’activité a été utilisé pour décrire la logique des actions réalisées par l’utilisateur lors de la gestion des inscriptions . Il met en évidence les différentes étapes du processus ainsi que les décisions possibles.

![Diagramme d'activité](/Images/Activity_ManageRegistration.svg)

## Adaptabilité du projet à une autre fédération.

Le projet a été pensé dès le départ pour pouvoir être adapté à une autre fédération, pas forcément liée aux échecs. Pour ça, on a séparé ce qui est générique (valable pour n’importe quel sport/jeu) de ce qui est spécifique aux échecs.

Concrètement, certaines classes sont volontairement abstraites et servent de base : par exemple Person, Tournament et Game. Elles contiennent les informations communes (identité d’un participant, informations d’une compétition, résultat d’un match, etc.). Ensuite, les classes spécifiques héritent de ces bases, comme Player qui hérite de Person, ou Chess_Tournament et ChessGame qui héritent respectivement de Tournament et Game. Grâce à cette structure, pour adapter l’application à un autre sport, il suffirait de créer de nouvelles classes spécialisées (ex : FootballGame, FootballTournament) en gardant la même structure générale.

De plus, les règles propres aux échecs (couleur, coups, calcul ELO, etc.) sont isolées dans des éléments dédiés (ex : ChessColor, GameResult, EloService). Cela évite de “polluer” les classes génériques avec des détails spécifiques. Pour une autre fédération, on pourrait remplacer ou adapter ces parties sans devoir refaire toute l’application.

En résumé, l’utilisation de l’héritage et la séparation entre classes génériques et classes spécialisées rendent le projet plus modulaire. Cela facilite la réutilisation du code et permet d’adapter l’application à d’autres fédérations avec des changements limités.

## Principes SOLID utilisés

### Single Responsibility Principle (SRP)

Le principe SRP est respecté dans le projet car chaque classe a une responsabilité bien définie. Les classes métier (Player, Game, Tournament, etc.) servent uniquement à représenter les données du domaine, sans contenir de logique technique ou de persistance.
Les traitements spécifiques, comme le calcul du score ELO ou la sauvegarde des données, sont gérés par des services distincts (EloService, FileService, GameFileService). Cette séparation rend le code plus lisible et facilite les modifications sans impacter l’ensemble de l’application.

### Open/Closed Principle (OCP)

Le principe Open/Closed est appliqué grâce à l’utilisation de classes abstraites et de l’héritage. Des classes génériques comme Game ou Tournament définissent une base commune, tandis que des classes spécifiques comme ChessGame ou Chess_Tournament étendent ces comportements sans modifier le code existant.
Cette approche permet d’ajouter facilement de nouveaux types de jeux ou de compétitions en créant de nouvelles classes spécialisées, tout en conservant la structure générale de l’application.

## Conclusion
