using GLOVO.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GLOVO.Data
{
    internal class FoodDAO
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FastFood;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public List<FoodModel> FetchAll()
        {
            List<FoodModel> returnList = new List<FoodModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * from [dbo].[Food]";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        FoodModel food = new FoodModel();
                        food.Id = reader.GetInt32(0);
                        food.FoodName = reader.GetString(1);
                        food.FoodDescription = reader.GetString(2);
                        food.Price = reader.GetInt32(3);
                        food.ImageUrl = reader.GetString(4);
                        food.FoodWeight = reader.GetInt32(5);
                        food.OrdersCount = reader.GetInt32(6);

                        returnList.Add(food);

                    }
                }
            }

            return returnList;
        }

        internal int Delete(int ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sqlQuery = "DELETE FROM dbo.Food WHERE ID = @ID";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = ID;

                connection.Open();

                int deletedID = command.ExecuteNonQuery();


                return deletedID;
            }
        }

        internal List<FoodModel> SearchForName(string searchPhrase)
        {
            List<FoodModel> returnList = new List<FoodModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * from [dbo].[Food] WHERE FOODNAME LIKE @searchForMe";


                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@searchForMe", System.Data.SqlDbType.NVarChar).Value = "%" + searchPhrase + "%";

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        FoodModel food = new FoodModel();
                        food.Id = reader.GetInt32(0);
                        food.FoodName = reader.GetString(1);
                        food.FoodDescription = reader.GetString(2);
                        food.Price = reader.GetInt32(3);
                        food.ImageUrl = reader.GetString(4);
                        food.FoodWeight = reader.GetInt32(5);
                        food.OrdersCount = reader.GetInt32(6);

                        returnList.Add(food);

                    }
                }
            }

            return returnList;
        }
        internal List<FoodModel> SearchForDescription(string searchPhrase)
        {
            List<FoodModel> returnList = new List<FoodModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * from [dbo].[Food] WHERE FOODDESCRIPTION LIKE @searchForMe";


                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@searchForMe", System.Data.SqlDbType.NVarChar).Value = "%" + searchPhrase + "%";

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        FoodModel food = new FoodModel();
                        food.Id = reader.GetInt32(0);
                        food.FoodName = reader.GetString(1);
                        food.FoodDescription = reader.GetString(2);
                        food.Price = reader.GetInt32(3);
                        food.ImageUrl = reader.GetString(4);
                        food.FoodWeight = reader.GetInt32(5);
                        food.OrdersCount = reader.GetInt32(6);

                        returnList.Add(food);

                    }
                }
            }

            return returnList;
        }

        public FoodModel FetchOne(int ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * from [dbo].[Food] WHERE ID = @ID";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = ID;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                FoodModel food = new FoodModel();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        food.Id = reader.GetInt32(0);
                        food.FoodName = reader.GetString(1);
                        food.FoodDescription = reader.GetString(2);
                        food.Price = reader.GetInt32(3);
                        food.ImageUrl = reader.GetString(4);
                        food.FoodWeight = reader.GetInt32(5);
                        food.OrdersCount = reader.GetInt32(6);



                    }
                }
                return food;
            }

        }
        //create new
        public int CreateOrUpdate(FoodModel foodModel)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "";
                if (foodModel.Id <= 0)
                {
                    sqlQuery = "INSERT INTO dbo.Food Values(@FoodName, @FoodDescription, @Price, @ImageUrl, @FoodWeight, @OrdersCount)";
                }
                else
                {

                    sqlQuery = "UPDATE dbo.Food SET FoodName = @FoodName, FoodDescription = @FoodDescription, Price = @Price, ImageUrl = @ImageUrl, FoodWeight = @FoodWeight, OrdersCount = @OrdersCount WHERE ID = @ID";

                }


                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = foodModel.Id;
                command.Parameters.Add("@FoodName", System.Data.SqlDbType.VarChar, 50).Value = foodModel.FoodName;
                command.Parameters.Add("@FoodDescription", System.Data.SqlDbType.VarChar, 255).Value = foodModel.FoodDescription;
                command.Parameters.Add("@Price", System.Data.SqlDbType.Int).Value = foodModel.Price;
                command.Parameters.Add("@ImageUrl", System.Data.SqlDbType.VarChar, 100).Value = foodModel.ImageUrl;
                command.Parameters.Add("@FoodWeight", System.Data.SqlDbType.Int).Value = foodModel.FoodWeight;
                command.Parameters.Add("@OrdersCount", System.Data.SqlDbType.Int).Value = foodModel.OrdersCount;

                connection.Open();
                int newID = command.ExecuteNonQuery();


                return newID;
            }

        }

        public FoodDAO()
        {
        }
    }
}