using System;
namespace DAL
{
    public class ConnectionString
    {
        public ConnectionString() { }
        public String GetConnectionString()
        {
            return "Server=.\\SQLEXPRESS;Database=LibraryDatabase;Trusted_Connection=True;";
        }
    }
}
