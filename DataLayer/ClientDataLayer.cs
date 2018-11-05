using FoodTruck.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruck.DataLayer
{
    public class ClientDataLayer
    {

        public void AddClient(ClasseClient client, string connectionString)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Client (Nom, Prenom, DateDeNaissance, Adresse_Numero, Adresse_Voie, Adresse_CodePostal, Adresse_Ville, Login, MotDePasse, Email, Id_TypeDeClient, Id_Civilite) " +
                                          $"VALUES ('{client.Nom}', '{client.Prenom}', '{client.DateDeNaissance}', {client.Numero}, '{client.Voie}',{client.CodePostal}, '{client.Ville}','{client.Login}', '{client.MotDePasse}', '{client.Email}', {client.TypeClientId} , {client.CiviliteId});";

                    command.ExecuteNonQuery();
                }
            }

        }
        public bool LoginExistant(string login, string connectionString)
        {
            var client = new ClasseClient();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT Login AS Login " +
                                          "FROM Client " +
                                          $"WHERE Login = '{login}';";

                    if (command.ExecuteScalar() == null)
                        return true;
                    else return false;

                }
            }

        }

        public ClasseClient GetByLogin(string login, string connectionString)
        {
            ClasseClient client = new ClasseClient();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT Id as Identifiant, Login as Login, MotDePasse AS MotDePasse, Prenom as Prenom, Nom as Nom, Adresse_Numero as Numero, Adresse_Voie as Voie, Adresse_CodePostal as CodePostal, Adresse_Ville as Ville " +
                                            "FROM client " +
                                            $"WHERE Login = '{login}';";

                    using (SqlDataReader lecture = command.ExecuteReader())
                    {
                        while (lecture.Read())
                        {
                            client.ClientID = (decimal)lecture["Identifiant"];
                            client.Login = lecture["Login"].ToString();
                            client.MotDePasse = lecture["MotDePasse"].ToString();
                            client.Prenom = lecture["Prenom"].ToString();
                            client.Nom = lecture["Nom"].ToString();
                            client.Numero = (int)lecture["Numero"];
                            client.Voie = lecture["Voie"].ToString();
                            client.CodePostal = (int)lecture["CodePostal"];
                            client.Ville = lecture["Ville"].ToString();

                        }
                        return client;
                    }
                }
            }

        }

    }
}

