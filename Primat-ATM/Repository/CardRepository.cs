using MySqlConnector;
using Primat_ATM.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Primat_ATM.Repository
{
    public class CardRepository : RepositoryBase, ICardRepository
    {
        public void Add(Card card)
        {
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "insert into Card(cardNumber, balance, email, pin, sendNotification) values (@cardNumber, @balance, @email, @pin, @sendNotification)";
                command.Parameters.Add("@cardNumber", MySqlDbType.VarChar).Value = card.CardNumber;
                command.Parameters.Add("@balance", MySqlDbType.Float).Value = card.Balance;
                command.Parameters.Add("@email", MySqlDbType.VarChar).Value = card.Email;
                command.Parameters.Add("@pin", MySqlDbType.Int32).Value = card.Pin;
                command.Parameters.Add("@sendNotification", MySqlDbType.Bit).Value = card.SendNotification;
                command.ExecuteNonQuery();
            }
        }

        public bool AuthenticateCard(NetworkCredential credential)
        {
            bool isValid;
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from Card where cardNumber=@cardNumber and pin=@pin";
                command.Parameters.Add("@cardNumber", MySqlDbType.VarChar).Value = credential.UserName;
                command.Parameters.Add("@pin", MySqlDbType.VarChar).Value = credential.Password;
                isValid = command.ExecuteScalar() != null;
            }
            return isValid;
        }

        public void Edit(Card card)
        {
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "update Card set cardNumber=@cardNumber, balance=@balance, email=@email, pin=@pin, sendNotification=@sendNotification where cardId=@cardId";
                command.Parameters.Add("@cardNumber", MySqlDbType.VarChar).Value = card.CardNumber;
                command.Parameters.Add("@balance", MySqlDbType.Float).Value = card.Balance;
                command.Parameters.Add("@email", MySqlDbType.VarChar).Value = card.Email;
                command.Parameters.Add("@pin", MySqlDbType.Int32).Value = card.Pin;
                command.Parameters.Add("@sendNotification", MySqlDbType.Bit).Value = card.SendNotification;
                command.Parameters.Add("@cardId", MySqlDbType.Int32).Value = card.CardId;
                command.ExecuteNonQuery();
            }
        }

        public Card GetByCardNumber(string cardNumber)
        {
            Card card = null;
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from Card where cardNumber=@cardNumber";
                command.Parameters.Add("@cardNumber", MySqlDbType.VarChar).Value = cardNumber;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int ordId = reader.GetOrdinal("cardId");
                        int ordBalance = reader.GetOrdinal("balance");
                        int ordNotification = reader.GetOrdinal("sendNotification");

                        card = new Card
                        {
                            CardId = reader.GetInt32(ordId),
                            CardNumber = reader[1].ToString(),
                            Balance = reader.GetFloat(ordBalance),
                            Email = reader[3].ToString(),
                            Pin = reader[4].ToString(),
                            SendNotification = reader.GetBoolean(ordNotification),
                        };
                    }
                    
                }
            }
            return card;
        }

        public Card GetById(int id)
        {
            Card card = null;
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from Card where cardId=@cardId";
                command.Parameters.Add("@cardId", MySqlDbType.Int32).Value = id;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int ordId = reader.GetOrdinal("cardId");
                        int ordBalance = reader.GetOrdinal("balance");
                        int ordNotification = reader.GetOrdinal("sendNotification");

                        card = new Card
                        {
                            CardId = reader.GetInt32(ordId),
                            CardNumber = reader[1].ToString(),
                            Balance = reader.GetFloat(ordBalance),
                            Email = reader[3].ToString(),
                            Pin = reader[4].ToString(),
                            SendNotification = reader.GetBoolean(ordNotification),
                        };
                    }

                }
            }
            return card;
        }

        public void Remove(int id)
        {
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "delete from Card where cardId=@cardId";
                command.Parameters.Add("@cardId", MySqlDbType.Int32).Value = id;
                command.ExecuteNonQuery();
            }
        }
    }
}
