using System;
using System.Collections.Generic;
using CodeStash3.BLL;
using System.Data.SqlClient;
using System.Windows;

namespace CodeStash3.DAL
{
    public class SqlSnippetRepository : ISnippetRepository
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;

        public SqlSnippetRepository()
        {
            connection = new SqlConnection("server=LAPTOP\\SQLEXPRESS;" +
                                           "Trusted_Connection=yes;" +
                                           "database=CodeStash; " +
                                           "connection timeout=5");
            command = new SqlCommand();
        }

        public List<Snippet> GetAllSnippets()
        {
            List<Snippet> snippetList = new List<Snippet>();

            OpenConnection();
            command.Connection = connection;

            command.CommandText = "SELECT * FROM Snippets ORDER BY Title ASC";
            if (null != command.ExecuteScalar())
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Snippet snippet = new Snippet()
                    {
                        Title = reader["Title"].ToString(),
                        Code = reader["Code"].ToString(),
                        Language = reader["Language"].ToString()
                    };
                    snippetList.Add(snippet);
                }
            }
            connection.Close();
            return snippetList;
        }

        private void OpenConnection()
        {
            try
            {
                connection.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL connection:" + ex.Message);
            }
        }

        public void UpdateAllSnippets(List<Snippet> snippets)
        {
            OpenConnection();

            foreach (var snippet in snippets)
            {
                command.CommandText = String.Format("SELECT * FROM Snippets WHERE Title = '{0}';", snippet.Title);
                if(command.ExecuteScalar() == null)
                {
                    command.CommandText = String.Format("INSERT INTO Snippets (Title, Language, Code) VALUES('{0}','{1}','{2}');",snippet.Title, snippet.Language, snippet.Code);
                    command.ExecuteNonQuery();
                }
            }
            connection.Close();
        }
    }
}
