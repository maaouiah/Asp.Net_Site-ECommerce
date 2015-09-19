using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASPMaster.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<Database>
    {
        protected override void Seed(Database db)
        {

            // On crée un nouvelle user Admin
            var Gestionutilisateurs = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db)); 
            var GestionRole = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            string RAdmin = "Admin";
            string RUser = "User";
 
            //Create Role Admin if it does not exist
            if (!GestionRole.RoleExists(RAdmin))
            {
                var roleresult = GestionRole.Create(new IdentityRole(RAdmin));
            }
            //Create Role User if it does not exist
            if (!GestionRole.RoleExists(RUser))
            {
                var roleresult = GestionRole.Create(new IdentityRole(RUser));
            }
            //Creer compte administrateur
            var user = new ApplicationUser();
            user.UserName = "admin";
            user.Email = "admin@gmail.com";
            var adminresult = Gestionutilisateurs.Create(user, "admin");

            //Creer compte utilisateur
            var user2 = new ApplicationUser();
            user2.UserName = "hamza";
            user2.Email = "maaouiahamza1@gmail.com";
            var userresult = Gestionutilisateurs.Create(user2, "user");

    
            //Add User Admin to Role Admin
            if (adminresult.Succeeded)
            {
                //Ajoute l'utilisateur 'user' en rôle Admin
                var result = Gestionutilisateurs.AddToRole(user.Id, RAdmin);
            }
            if (userresult.Succeeded)
            {
                // Ajoute l'utilisateur 'user2' en rôle User    
                var result = Gestionutilisateurs.AddToRole(user2.Id, RUser);
            }
            base.Seed(db);


            // Liste des types
            var types = new List<Type>
            {
                new Type{Nom = "Homme"},
                new Type{Nom = "Femme"},
                new Type{Nom = "Bebe"},
                
            };

            foreach (var type in types)
            {
                db.Types.Add(type);
            }
            db.SaveChanges();

            // Categories
            var categories = new List<Categorie>
            {
                new Categorie{Nom = "Ceinture"},
                new Categorie{Nom = "Chaussette"},
                new Categorie{Nom = "chemise"},
                new Categorie{Nom = "jean"},
                new Categorie{Nom = "jaquette"},
                new Categorie{Nom = "chapeau"},
                new Categorie{Nom = "Veste"},
            };
            foreach (var temp in categories)
            {
                db.Categories.Add(temp);
            }
            db.SaveChanges();


            // Produits
            var produits = new List<Produit>
            {
                new Produit{
                    Nom = "Veste Cuire",
                    Description = "Derniere collection de veste !",
                    CategorieId = 7, 
                    TypeId = 1 , 
                    Prix = 99,  
                    DateAjout = DateTime.Parse("2015-01-10") , 
                    Quantite = 70,
                },
              new Produit{
                    Nom = "Ceinture Cuire",
                    Description = "Derniere collection de ceinture !",
                    CategorieId = 1, 
                    TypeId = 2 , 
                    Prix = 29,  
                    DateAjout = DateTime.Parse("2015-01-10") , 
                    Quantite = 50,
                },
            new Produit{
                    Nom = "Jaquette noire",
                    Description = "Derniere collection de jaqette pour les bebes !",
                    CategorieId = 5, 
                    TypeId = 3 , 
                    Prix = 25,  
                    DateAjout = DateTime.Parse("2015-01-10") , 
                    Quantite = 10,
                },
            };

            foreach (var temp in produits)
            {
                db.Produits.Add(temp);
            }
            db.SaveChanges();

    }
}
}