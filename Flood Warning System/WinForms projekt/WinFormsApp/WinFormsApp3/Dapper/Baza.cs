using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp3.Models;

namespace WinFormsApp3
{
    class Baza
    {
        public async Task<string> BaseGetTownship()
        {
            var DB = new DBCrudDapper(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            var text = new StringBuilder();
            foreach (var obszar in await DB.GetArea())
            {
                text.AppendLine(obszar.Miejscowosc);
            }
            return text.ToString();
            
        }
        public async Task<string> BaseGetCity()
        {
            var DB = new DBCrudDapper(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            var text = new StringBuilder();
            foreach (var obszar in await DB.GetArea())
            {
                text.AppendLine(obszar.Miasto);
            }
            return text.ToString();

        }

        public async Task<IEnumerable<PomiarMiejscowosc>> BaseGetMeasureData()
        {
            var DB = new DBCrudDapper(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            var text = new StringBuilder();
            var collection = DB.GetAreaEndangered();
            return await collection;

        }

        public async Task<List<string>> BaseGetTownshipList()
        {
            var DB = new DBCrudDapper(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            List<String>list = new List<String>();
            foreach (var obszar in await DB.GetArea())
            {
                list.Add(obszar.Miejscowosc);
            }
            return list;

        }

    }
}
