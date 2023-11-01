
using MySqlConnector;
using Primat_ATM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primat_ATM.Repository
{
    public class TransactionRepository : RepositoryBase, ITransactionRepository
    {
        public void Add(Transaction transaction)
        {
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "insert into transaction(timestamp, fromId, toId, amount) values (@timestamp, @fromId, @toId, @amount)";
                command.Parameters.Add("@timestamp", MySqlDbType.Timestamp).Value = transaction.Timestamp;
                command.Parameters.Add("@fromId", MySqlDbType.Int32).Value = transaction.FromId;
                command.Parameters.Add("@toId", MySqlDbType.Int32).Value = transaction.ToId;
                command.Parameters.Add("@amount", MySqlDbType.Float).Value = transaction.Amount;
                command.ExecuteNonQuery();
            }
        }

        public Transaction GetByTransactionId(int transactionId)
        {
            Transaction transaction = null;
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from transaction where transactionId=@transactionId";
                command.Parameters.Add("@transactionId", MySqlDbType.Int32).Value = transactionId;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int ordId = reader.GetOrdinal("transactionId");
                        int ordTimestamp = reader.GetOrdinal("timestamp");
                        int ordFromId = reader.GetOrdinal("fromId");
                        int ordToId = reader.GetOrdinal("toId");
                        int ordAmount = reader.GetOrdinal("amount");
                        

                        transaction = new Transaction
                        {
                            TransactionId = reader.GetInt32(ordId),
                            Timestamp = reader.GetDateTime(ordTimestamp),
                            FromId = reader.GetInt32(ordFromId),
                            ToId = reader.GetInt32(ordToId),
                            Amount = reader.GetFloat(ordAmount),
                        };
                    }

                }
            }
            return transaction;
        }

        List<Transaction> ITransactionRepository.GetByFromId(int fromId)
        {
            List<Transaction> transactions = new List<Transaction>();
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from transaction where fromId=@fromId";
                command.Parameters.Add("@fromId", MySqlDbType.Int32).Value = fromId;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int ordId = reader.GetOrdinal("transactionId");
                        int ordTimestamp = reader.GetOrdinal("timestamp");
                        int ordFromId = reader.GetOrdinal("fromId");
                        int ordToId = reader.GetOrdinal("toId");
                        int ordAmount = reader.GetOrdinal("amount");


                        Transaction transaction = new Transaction
                        {
                            TransactionId = reader.GetInt32(ordId),
                            Timestamp = reader.GetDateTime(ordTimestamp),
                            FromId = reader.GetInt32(ordFromId),
                            ToId = reader.GetInt32(ordToId),
                            Amount = reader.GetFloat(ordAmount),
                        };

                        transactions.Add(transaction);
                    }

                }
            }
            return transactions;
        }

        List<Transaction> ITransactionRepository.GetByToId(int toId)
        {
            List<Transaction> transactions = new List<Transaction>();
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from transaction where toId=@toId";
                command.Parameters.Add("@toId", MySqlDbType.Int32).Value = toId;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int ordId = reader.GetOrdinal("transactionId");
                        int ordTimestamp = reader.GetOrdinal("timestamp");
                        int ordFromId = reader.GetOrdinal("fromId");
                        int ordToId = reader.GetOrdinal("toId");
                        int ordAmount = reader.GetOrdinal("amount");


                        Transaction transaction = new Transaction
                        {
                            TransactionId = reader.GetInt32(ordId),
                            Timestamp = reader.GetDateTime(ordTimestamp),
                            FromId = reader.GetInt32(ordFromId),
                            ToId = reader.GetInt32(ordToId),
                            Amount = reader.GetFloat(ordAmount),
                        };

                        transactions.Add(transaction);
                    }

                }
            }
            return transactions;
        }
    }
}
