using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCCBarbearia.Db
{
    public class conn
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user=root;password=14154678;database=BdBarbearia");
        public static string msg;
            
        public MySqlConnection ConectarBD()
        {
            try
            {
                con.Open(); 
            }
            catch (Exception error) 
            {
                msg = "Erro de conexão" + error.Message;    
            }
            return con;
        }

        public MySqlConnection DesconectarBD()
        {
            try
            {
                con.Close();
            }
            catch (Exception error)
            {
                msg = "Erro de conexão" + error.Message;
            }
            return con;
        }

    }
}