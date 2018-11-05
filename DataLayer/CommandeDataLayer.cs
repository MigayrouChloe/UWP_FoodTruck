using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTruck.Models;

namespace FoodTruck.DataLayer
{
    public class CommandeDataLayer
    {

        public void AddCommande(ClasseCommande commandeAAjouter, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText =
                    "INSERT INTO Commande (DateDeCommande, DateDeLivraison, TypeDeLivraisonId, ClientId, AdresseLivraison_Numero, AdresseLivraison_Voie, AdresseLivraison_CodePostal, AdresseLivraison_Ville ) " +
                    $"VALUES('{commandeAAjouter.DateDeCommande}', '{commandeAAjouter.DateDeLivraison}' ,{commandeAAjouter.TypdeDeLivraisonId}, {commandeAAjouter.ClientId}, {commandeAAjouter.Numero}, '{commandeAAjouter.Voie}', {commandeAAjouter.CodePostal} , '{commandeAAjouter.Ville}');";
                    command.ExecuteNonQuery();


                    command.CommandText = "Select Max(Id) " +
                                          "From Commande ;";
                    decimal IdCommande = (decimal) command.ExecuteScalar();

                    foreach (var item in commandeAAjouter.PanierDeLaCommande.ProduitDuPanier)
                    {
                        command.CommandText = "INSERT INTO CommandeProduit(CommandeId, ProduitId, Quantite) " +
                                              $"Values({IdCommande}, {item.ProductID}, 1)";
                        command.ExecuteNonQuery();

                    }

                }
            }

        }

    }
}
