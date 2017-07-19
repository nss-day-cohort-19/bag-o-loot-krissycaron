using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BagOLoot
{
    public class ChildRegister
    {
        private List<string> _children = new List<string>();
        private string _connectionString = $"Data Source={Environment.GetEnvironmentVariable("BAGOLOOT_DB")}";
        private SqliteConnection _connection;

        public ChildRegister()
        {
            _connection = new SqliteConnection(_connectionString);
        }

        public bool AddChild (string child) 
        {
            int _lastId = 0; // Will store the id of the last inserted record
            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand ();

                // Insert the new child
                dbcmd.CommandText = $"insert into child values (null, '{child}', 0)";
                Console.WriteLine(dbcmd.CommandText);
                //selecting not querying. 
                dbcmd.ExecuteNonQuery ();

                // Get the id of the new row that was added to the database. includes the auto created Id
                dbcmd.CommandText = $"select last_insert_rowid()";
                using (SqliteDataReader dr = dbcmd.ExecuteReader()) 
                {
                    


                    //if I am able to read the data, insert the data 
                    if (dr.Read()) {
                        //dr =data reader .. select the column ,,, which is a 0 based list 0= column 1, 1 = cl 2 ....
                        _lastId = dr.GetInt32(0);
                    } else {
                        throw new Exception("Unable to insert value");
                    }
                }

                // clean up
                dbcmd.Dispose ();
                _connection.Close ();
            }

            return _lastId != 0;
        }

        public List<string> GetChildren ()
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand();

                //select the id and name of every child 
                dbcmd.CommandText = "select id, name from child";
 
                using (SqliteDataReader dr = dbcmd.ExecuteReader())
                {
                    // Read Each Row in the result set. 
                    while (dr.Read())
                    {
                        _children.Add(dr[0].ToString()); //add child name to list
                    }
                }

                dbcmd.Dispose();
                _connection.Close();

            }
            return new List<string>();
        }

        public string GetChild (string name)
        {
            var child = _children.SingleOrDefault(c => c == name);

            // Inevitably, two children will have the same name. Then what?

            return child;
        }
    }
}