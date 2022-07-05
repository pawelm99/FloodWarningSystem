using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp3.Models;

namespace WinFormsApp3
{
    class DBCrudDapper
    {
        private IDbConnection _connection;
        public DBCrudDapper(string ConnectionString)
        {
               _connection = new SqlConnection(ConnectionString);


        }
        public async Task<IEnumerable<ObszarZagrozony>> GetArea()
        {
            return  await _connection.QueryAsync<ObszarZagrozony>("SELECT * FROM dane.ObszarZagrozony");
        } 
        public async Task<IEnumerable<PomiarMiejscowosc>> GetAreaEndangered()
        {
            return await _connection.QueryAsync<PomiarMiejscowosc>("SELECT * FROM dbo.PomiarMiejscowosc WHERE PoziomWody > StandardowyPoziom");
        }

       

    }
}
