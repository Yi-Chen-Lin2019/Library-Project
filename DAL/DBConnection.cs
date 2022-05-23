using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using Domain.Entities;

namespace DAL
{
    public class DBConnection
    {
        IDbConnection conn;

        public DBConnection()
        {
            conn = new SqlConnection(new ConnectionString().GetConnectionString());
        }

        public String ConnectionState()
        {
            conn.Open();
            String result = conn.State.ToString();
            conn.Close();
            return result;
        }

        /*public String ChangeItemDescriptorType()
        {
            conn.Open();
            for (int i = 1; i <= 1500; i++) {
                Book book = conn.Query<Book>("SELECT [ID], [ISBN], [Subject], [Edition] FROM [Book] WHERE [ID] = @Id", new { Id = i }).SingleOrDefault();
                Map map = conn.Query<Map>("SELECT ID FROM Map WHERE Id = @Id", new { Id = i }).SingleOrDefault();
                Article article = conn.Query<Article>("SELECT ID, Subject, ReleaseDate FROM Article WHERE ID = @Id", new { Id = i }).SingleOrDefault();

                if (null != book)
                {
                    conn.Execute("UPDATE [ItemDescriptor] SET ItemDescriptor_Type = 'Book' WHERE ID = @Id", new { Id = i});
                }
                if (null != map)
                {
                    conn.Execute("UPDATE [ItemDescriptor] SET ItemDescriptor_Type = 'Map' WHERE ID = @Id", new { Id = i });
                }
                if (null != article)
                {
                    conn.Execute("UPDATE [ItemDescriptor] SET ItemDescriptor_Type = 'Article' WHERE ID = @Id", new { Id = i });
                }
            }
            conn.Close();
            return "Yes";
        }*/

    }
}
