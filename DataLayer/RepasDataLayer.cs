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
    public class RepasDataLayer
    {
        public ObservableCollection<ClasseRepas> GetRepas(string connectionString)
        {
            var Repas = new ObservableCollection<ClasseRepas>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = $"select  Repas.Id as IdRepas, Repas.Type AS TypeRepas " +
                                          $"from Repas ";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var repas = new ClasseRepas();
                            repas.RepasID = reader.GetDecimal(0);
                            repas.RepasType = reader.GetString(1);
                            Repas.Add(repas);
                        }
                    }



                }
            }
            return Repas;
        }
    }


}

