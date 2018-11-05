using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace FoodTruck
{
    public class ProduitDataLayer
    {

        public ObservableCollection<ClasseProduit> GetProducts(string connectionString)
        {
            var products = new ObservableCollection<ClasseProduit>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = $"select  Produit.Id as IdProduit, Produit.Nom AS NomProduit, Produit.Description as DescriptionProduit, Produit.Prix as PrixProduit " +
                                          $"from Produit ";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var product = new ClasseProduit();
                            product.ProductID = reader.GetDecimal(0);
                            product.ProductNom = reader.GetString(1);
                            product.ProductDescription = reader["DescriptionProduit"].ToString();
                            product.ProductPrix = (double)reader["PrixProduit"];
                            products.Add(product);
                        }
                    }



                }
            }
            return products;
        }
    }
}
