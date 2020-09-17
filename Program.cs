using System;
using System.Data.SqlClient;

namespace DZ6
{
    class Program
    {
        private static SqlConnection conn;

        public static object Label1 { get; private set; }

        static void Main(string[] args)
        {

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = @"DESKTOP-O33O61B",
                InitialCatalog = "Sample",
                IntegratedSecurity = true,
            };
            
            string queryString = "Buyer(ID int IDENTITY(1,1) not null , Имя nvarchar(50) not null, Фамилия nvarchar(50) not null, PRIMARY KEY (ID))";
            SqlCommand cmdCreateTableBuyer = new SqlCommand(queryString, conn);

            queryString =  "Sellers(ID int IDENTITY(1,1) not null , Имя nvarchar(50) not null, Фамилия nvarchar(50) not null, PRIMARY KEY (ID))";
            SqlCommand cmdCreateTableSellers = new SqlCommand(queryString, conn);

            queryString =  "Sales(ID int IDENTITY(1,1) not null , IDBuyer int not null FOREIGN KEY REFERENCES Buyer(ID) ON DELETE CASCADE," +
                         " IDSeller int not null FOREIGN KEY REFERENCES Sellers(ID) ON DELETE CASCADE," +
                         " Sum decimal not null, Date date not null, PRIMARY KEY (ID))";
            SqlCommand cmdCreateTableSales = new SqlCommand(queryString, conn);

                cmdCreateTableBuyer.ExecuteNonQuery();
                cmdCreateTableSellers.ExecuteNonQuery();
                cmdCreateTableSales.ExecuteNonQuery();
              
        }
    }
}
