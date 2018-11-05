using FoodTruck.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruck.DataLayer
{
    public class ProduitRepasDataLayer
    {

        public ObservableCollection<ClasseProduit> GetProduitRepas(string connectionString, string TypeRepas)
        {
            var NosProduit = new ObservableCollection<ClasseProduit>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText =
                                            "SELECT Produit.Id as IdentifiantProduit, Produit.Nom as ProduitNom, Produit.Description as ProduitDescription, Produit.Prix as ProduitPrix, Produit.QuantiteDisponible as ProduitQtiteDispo " +
                                            "From ProduitRepas " +
                                            "inner join Produit on ProduitRepas.Id_Produit = Produit.Id " +
                                            "inner join Repas on ProduitRepas.Id_Repas = Repas.Id " +
                                            $"WHERE Repas.Type = '{TypeRepas}';";


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ClasseProduit prdt = new ClasseProduit();
                            prdt.ProductID = (decimal)reader["IdentifiantProduit"];
                            prdt.ProductNom = reader["ProduitNom"].ToString();
                            prdt.ProductDescription = reader["ProduitDescription"].ToString();
                            prdt.ProductPrix = (double)reader["ProduitPrix"];
                            prdt.ProductQuantiteDisponible = (int)reader["ProduitQtiteDispo"];

                            NosProduit.Add(prdt);

                        }
                        reader.Close();

                    }


                    foreach (var item in NosProduit)
                    {
                        command.CommandText = "select Produit.Id as IdentifiantProduit, Produit.Nom as produitNom,Disponiblilite.Jour as JourDispo" +
                                " from DisponibliliteProduit" +
                                " inner join Produit on DisponibliliteProduit.ProduitId = Produit.Id" +
                                " inner join Disponiblilite on DisponibliliteProduit.DisponibiliteId = Disponiblilite.Id" +
                                $" where Produit.Nom = '{item.ProductNom}';";

                        using (SqlDataReader readerJour = command.ExecuteReader())
                        {
                            while (readerJour.Read())
                            {
                                item.JoursDispo.Add(readerJour["JourDispo"].ToString());
                            }
                        }
                    }


                }
            }
            return NosProduit;
        }
           


    public ClasseProduit GetProduitCarte(string connectionString, string NomProduit)
    {
        var prdtobtenu = new ClasseProduit();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {

            connection.Open();
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = "select Produit.Nom as ProduitNom,Produit.Description as ProduitDescription,Produit.Prix as ProduitPrix,Produit.QuantiteDisponible As ProduitQuantiteDisponible" +
                    " from Produit " +
                    $" where Produit.Nom = '{ NomProduit}'";

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        prdtobtenu.ProductNom = reader["ProduitNom"].ToString();
                        prdtobtenu.ProductDescription = reader["ProduitDescription"].ToString();
                        prdtobtenu.ProductPrix = (double)reader["ProduitPrix"];
                        prdtobtenu.ProductQuantiteDisponible = (int)reader["ProduitQuantiteDisponible"];
                    }
                    return prdtobtenu;
                }
            }
        }
    }
}
}

            



