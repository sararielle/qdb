using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;



namespace QDB
{
    public class QuoteDB
    {
        public static IDbConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);

        public QuoteDB()
        {
        }

        public Models.QuoteModel GetQuote(int id)
        {
            Models.QuoteModel quote = new Models.QuoteModel();

            dbConnection.Open();
            IDbCommand cmd = dbConnection.CreateCommand();
            cmd.CommandText = @"SELECT Id, PostTime, PostText FROM Quote WHERE Id = " + id;
            IDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);

            reader.Read();

            quote.Id = id;
            quote.DateSubmitted = (DateTime)reader.GetValue(1);
            string str = (string)reader.GetValue(2);
            str = REPLACETHEMOTHERFUCKERS(str);
            quote.Quote = str;
            reader.Close();
            dbConnection.Close();

            return quote;
        }

        public static string REPLACETHEMOTHERFUCKERS(string str)
        {
            str = str.Replace("<", "&lt;");
            str = str.Replace(">", "&gt;");
            str = str.Replace("\n", " <br /> ");

            return str;
        }

        public IEnumerable<Models.QuoteModel> GetQuotes()
        {
            IList<Models.QuoteModel> quotes = new List<Models.QuoteModel>();

            dbConnection.Open();
            IDbCommand cmd = dbConnection.CreateCommand();
            cmd.CommandText = @"SELECT Id, PostTime, PostText FROM Quote";
            IDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Models.QuoteModel quote = new Models.QuoteModel();
                quote.Id = (int)reader.GetValue(0);
                quote.DateSubmitted = (DateTime)reader.GetValue(1);
                quote.Quote = (string)reader.GetValue(2);
                quote.Quote = REPLACETHEMOTHERFUCKERS(quote.Quote);
                quotes.Add(quote);
            }

            reader.Close();
            dbConnection.Close();

            return quotes;
        }
    }
}