using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace cadastroPessoa.Service
{
    public class connectiondbs
    {

        private string connectionString;

        public string getConnectionString()
        {
            connectionString = ConfigurationManager.ConnectionStrings["cadastroPessoa.Properties.Settings.cadastroConnectionString"].ConnectionString;
            return connectionString;
        }

    }
}