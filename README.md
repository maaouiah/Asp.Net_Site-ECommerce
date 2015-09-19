Projet Développement .Net : Site web E-commerce
===================

Projet .NET : Développement d’un site web E-commerce spécialisé dans la vente des vêtements.

Dans ce projet, je vais utiliser :

	- Visual Studio 2013 : est un ensemble complet d'outils de développement permettant de générer des applications Web ASP.NET, des Services Web XML, des applications bureautiques et des applications mobiles.

	- Le langage de programmation C# qui est un langage orienté objet de type sécurisé et élégant qui permet aux développeurs de générer diverses applications fiables qui s'exécutent sur le .NET Framework.
	
	- Modèle-Vue-Contrôleur (MVC). MVC est un schéma de conception qui sépare l'application en trois composants.principaux : le modèle, la vue et le contrôleur.

##L’objectif: 
L’objectif principal du projet est la conception et le développement d’un site web E-commerce spécialisé dans la vente des vêtements. Le site web sera destiné à une clientèle masculine et féminine avec un catalogue varié et riche. L’accessibilité de la solution est aussi considéré comme primordiale avec une implémentation d’interfaces adaptables aux résolutions des smartphones , des tablettes ainsi que les ordinateur du bureau. Le paiement est aussi mis en avant , avec une intégration des moyens de payement les plus utilisées chez des individus âgés entre 18 et 25 ans tel que Paypal.

##Spécifications fonctionnelles :
A fin de décrire au mieux les différentes fonctionnalités de l’application, nous avons décidé d’organiser les différentes tâches sous un ensemble de modules.

	+ Module : Utilisateurs
	Le module utilisateurs permet à toute personne visitant le site de pouvoir s’enregistrer , se connecter et de modifier leur profil. 
		- Inscription
		- Connexion
		- Consultation du profil
		- Modification du profil

	+ Module : Panier
	Le module «panier» constitue une partie très importante du processus de développement du site web. En fait c’est le module qui va permettre aux clients de gérer leurs différentes commandes et de les valider définitivement pour passer à l’étape du payement.
		- Ajouter au panier
		- Modifier le panier
		- Supprimer du panier
		- Valider le contenu du panier

	+ Module : Commande
	La commande est l’étape avant dernière dans le processus d’achat d’un article. la création du commande passe premièrement pas le traitement du contenu du panier et la validation des quantités des articles et des dates de disponibilité. si le traitement est effectué avec succès on sauvegarde les informations et on déclenche le processus de traitement des transactions bancaires pour le payement.
		- Générer un commande
		- Modifier une commande 
		- Supprimer une commande
		- Modifier une commande
		- Consulter un commande
		- Annuler une commande
		
	+ Module : Article
	Chaque article est associé à des catégories et un genre. ces associations sont utilisées principalement pour permettre aux utilisateurs d’affiner le résultat de leurs recherches.
		- Ajouter un article
		- Modifier un article
		- Supprimer un article
		- Modifier un article
		- Associer un article à une catégorie
		- Associer un article à un genre

	+ Module : Fournisseurs 
	Le fournisseur ici, est intégré à la solution d’un manière partielle pour le seul objectif de donner aux utilisateurs la possibilité de trier les article selon la marque.
		- Ajouter fournisseur
		- Supprimer fournisseur
		- Modifier fournisseur
		- Consulter fournisseur 

	+ Module : Administration
	Le module administration regroupe un ensemble de tâches issues des autres modules à fin d’assurer et administrer le bon fonctionnement global de l’application.Il comporte aussi les tâches liés à la gestion des utilisateurs du site et la configuration globale.
		- Gérer les utilisateur 
			- Supprimer un utilisateur
			- Modifier un utilisateur
			- Ajouter un utilisateur

		- Gestion d’articles ( Module : article )
		- Gestion de commandes 
			- Valider les commandes
			- Annuler les commandes 
			- Consulter une commande
		- Gérer les fournisseurs
