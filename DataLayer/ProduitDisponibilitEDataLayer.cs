using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruck.DataLayer
{
    public class ProduitDisponibilitEDataLayer
    {

        public ObservableCollection<ClasseProduit> GetProduitDisp(string connectionString, string JourSaisi)
        {
            var NosProduitDis = new ObservableCollection<ClasseProduit>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT Produit.Id as IdentifiantProduit, Produit.Nom as ProduitNom, Produit.Description as ProduitDescription, Produit.Prix as ProduitPrix, Produit.QuantiteDisponible as ProduitQtiteDispo " +
                        " from DisponibliliteProduit " +
                        " inner join Produit on DisponibliliteProduit.ProduitId = Produit.Id " +
                        " inner join Disponiblilite on DisponibliliteProduit.DisponibiliteId = Disponiblilite.Id "+
                        $"where Disponiblilite.Jour = '{JourSaisi}';";
                    



                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ClasseProduit prdtDis = new ClasseProduit();
                            prdtDis.ProductID = (decimal)reader["IdentifiantProduit"];
                            prdtDis.ProductNom = reader["ProduitNom"].ToString();
                            prdtDis.ProductDescription = reader["ProduitDescription"].ToString();
                            prdtDis.ProductPrix = (double)reader["ProduitPrix"];
                            prdtDis.ProductQuantiteDisponible = (int)reader["ProduitQtiteDispo"];



                            NosProduitDis.Add(prdtDis);
                        }
                        return NosProduitDis;
                    }
                }
            }
        }
    }
}
