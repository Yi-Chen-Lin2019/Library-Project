using System;
using System.Collections.Generic;
using System.Text;

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
