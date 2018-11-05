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
    public class DisponibilitéDataLayer
    {

        public ObservableCollection<ClassDiponibilitéJour> GetJour(string connectionString)
        {
            var LesJours = new ObservableCollection<ClassDiponibilitéJour>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "select Id as IdJour,Jour as MonJour " +
                                         " from Disponiblilite";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var Jour = new ClassDiponibilitéJour();
                            Jour.DisponibiliteID = reader.GetDecimal(0);
                            Jour.DisponibiliteJour = reader.GetString(1);
                            LesJours.Add(Jour);
                        }
                    }



                }
            }
            return LesJours;
        }
    }
}
