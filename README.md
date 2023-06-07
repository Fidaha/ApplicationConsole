#Session C# Mai 2023 - Projet 1 - Application Console - 2 Semaines
# ApplicationConsole

Introduction :

Afin de r�volutionner le syst�me informatique de l'�ducation nationale, nous souhaitons la cr�ation d'une application console permettant de r�aliser la saisie des notes des �l�ves. En tant qu'�ducation nationale, nous regroupons des cursus de formation divers et vari�s avec des professeurs et des �tudiants multi-ethniques. La condition d'obtention du dipl�me n�cessite bien �videmment la r�ussite des examens. Examens cat�goris�s par mati�res, et donnant lieu � une note ainsi qu'une appr�ciation de la part du professeur.

Technologies :

C#.Net : Le programme sera d�velopp� dans le langage C# en utilisant le framework .Net Core 7.0

Nuget : Les paquets Nuget pourront �tre utilis�s pour l'inclusion de d�pendances externes.

Newtonsoft.JSON : La persistence se fera dans un simple fichier texte au format JSON.

La librairie Newtonsoft.JSON sera utilis�e pour la manipulation des donn�es au format JSON

Visual Studio Code : Les d�veloppements et compilations seront r�alis�s sur l'outil Visual Studio Code

Github : Les sources de l'application sont � d�poser sur un d�pot Github. Les binaires ne doivent pas �tre versionn�s (utilisez un .gitignore)

L'application : 

Le besoin : 

Le papier �tant vou� � disparaitre, une solution digitale permettant aux professeurs de saisir les notes et appr�ciations de leurs diff�rents �l�ves devient indispensable. 
Les ordinateurs de l'�ducation nationale �tant � la pointe de la technologie, la saisie des informations se fera uniquement au clavier et sur des �crans 4k. Les interfaces graphiques (web ou applicatives) 
sont � proscrire afin de ne pas heurter les potentiels utilisateurs daltonniens. Afin d'�viter toute fuite de donn�es, 
aucun syst�me de gestion en ligne ne doit �tre utilis�. Toutes les donn�es saisies et manipul�es dans l'application doivent �tre enregistr�es dans un fichier texte au format JSON 
afin de pouvoir facilement �tre �chang�es sur support amovible (disquette/CD-ROM/cl� USB).

L'environnement d'ex�cution :
L'application sera mono-poste et fonctionnera sans base de donn�es. L'application pourra s'ex�cuter sur MacOs, Linux, ou Windows 10 et sup�rieur.

Sp�cification fonctionnelle :

Fichier de donn�es

Le fichier de donn�es JSON � utiliser sera pass� en argument au programme lors du lancement.
Il peut se trouver sur n'importe quel disque dur ou amovible tant que les acc�s en �criture sont bien pr�sents.

Menu :

Au lancement de l'application, un menu permettra � l'utilisateur de choisir entre ces entr�es :
El�ves
Cours

Le menu El�ves permettra quant � lui de :

Lister les �l�ves
Cr�er un nouvel �l�ve
Consulter un �l�ve existant
Ajouter une note et une appr�ciation pour un cours sur un �l�ve existant
Revenir au menu principal

Le menu Cours permettra de son c�t� de :

Lister les cours existants
Ajouter un nouveau cours au programme
Supprimer un cours par son identifiant
Revenir au menu principal
La notion d'�l�ve
Un �l�ve sera compos� des attributs suivants :

Un identifiant unique au format num�rique
Un nom au format texte
Un pr�nom au format texte
Une date de naissance
Un liste de notes (nombre � virgule) et d'appr�ciation du professeur (texte) pour chaque cours
La moyenne de ses notes qui sera calcul�e � la vol�e et ne sera pas enregistr�e dans le fichier
La notion de Cours
Les cours seront compos�s des attributs suivants :

Un identifiant unique au format num�rique
Un nom au format texte
La suppression d'un cours
Quand un cours est supprim� du programme, il faut �galement supprimer les notes et appr�ciations de ce cours pour tous les �l�ves.

Une demande de confirmation devra �tre effectu�e afin de s'assurer qu'il ne sagit pas d'une erreur.

L'ajout d'une note et appr�ciation
Lors de l'ajout d'une note et d'une appr�ciation sur un �l�ve, un menu devra permettre d'indiquer le cours pour lequel la saisie doit �tre faite.

L'appr�ciation du professeur est facultative. Seule la note est obligatoire.

Un r�capitulatif de la saisie, ainsi qu'une demande de confirmation permettront de valider l'ajout de la saisie � l'�l�ve.

L'enregistrement des donn�es
Toute modification faite par l'utilisateur (ajout/suppression de cours, ajout de note etc...) donnera lieux � une sauvegarde au format JSON dans le fichier.

Lors du lancement du programme, le fichier JSON sera lu afin d'initialiser les donn�es existantes sur le poste de l'utilisateur.

La moyenne
La moyenne est une information calcul�e � la vol�e. Il ne faut donc pas l'enregistrer dans le fichier JSON.

La moyenne est arrondie � 1 chiffre apr�s la virgule. Exemple :

12 => 12/20
12.2 => 12/20
12.3 => 12.5/20
12.6 => 13/20
Affichage
Afin de b�n�ficier de toute la puissance mise � disposition par la console, la mise en page des donn�es devra permettre une lecture claire et a�r�e des informations.

Exemple :

----------------------------------------------------------------------
Informations sur l'�l�ve : 

Nom               : Arus
Pr�nom            : Joshua
Date de naissance : 01/01/1980

R�sultats scolaires:

    Cours : Math�matiques
        Note : 18/20
        Appr�ciation : Continue comme �a ! 

    Cours : Anglais
        Note : 6/20
        Appr�ciation : Aie aie aie, �a va pas du tout...

    Cours : Programmation
        Note : 13/20
        Appr�ciation : 

    Moyenne : 12.5/20
----------------------------------------------------------------------
La gestion des erreurs
Toutes les saisies utilisateurs devront �tre contr�l�es afin d'�viter les erreurs de saisie.

Dans le cas o� la saisie de correspondrait pas � un choix valide, la question sera r�affich�e, et la saisie redemand�e.

Exemple : lors de la saisie d'une note, le cours doit obligatoirement exister dans l'application et �tre un choix propos�. Sinon, on demande � l'utilisateur de refaire sa saisie.

Fichier de log
Chaque action utilisateur devra �tre enregistr�e dans un fichier de log. Aussi bien les modifications de donn�es que les consultations.

Hormi l'horodatage, la mise en page est libre mais doit permettre d'interpr�ter clairement l'action r�alis�e Le fichier de log aura le m�me nom que le fichier JSON (� l'extension pr�s) et sera stock� au m�me endroit

Exemple :

2021-09-01 14:00:00 Consultation de la liste des �l�ves
2021-09-01 14:00:02 Consultation des d�tails de l'�l�ve XXX
2021-09-01 14:00:10 Saisie d'une note pour l'�l�ve XXX : "Anglais" 6/20 "Aie aie aie, �a va pas du tout..."
2021-09-01 14:00:15 Retour au menu principal
Objectifs bonus facultatifs
Dans le cas o� toutes les demandes fonctionnelles seraient remplies (et, j'insiste, seulement dans ce cas l�), on pourra aller plus loin en impl�mentant la notion de "Promotion" avec les impacts suivants :

Chaque �l�ve est rattach� � une promotion
La liste des promotions est d�duites des �l�ves existants (pas stock�es dans le fichier JSON)
Une nouvelle entr�e dans le menu principal permet d'afficher la liste des promotions existantes
Un �cran permettant d'afficher la liste des �l�ves dans une promotion (nom/pr�nom/etc... pas les notes)
Un �cran permettant d'afficher la moyenne par cours de tous les �l�ves d'une promotion donn�e
Sur l'�cran qui liste les cours, la moyenne de chaque promotion par cours
Une saisie en mode console un peu plus "interactive" pourra �tre propos�e. Vous �tes libres de la r�aliser comme vous le souhaitez.
