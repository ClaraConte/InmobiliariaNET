using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria.Models
{
    public class RepositorioContratoGarantia :  RepositorioBase, IRepositorio<ContratoGarantia>
    {
        public RepositorioContratoGarantia(IConfiguration configuration) : base(configuration)
        {

        }

        public int Create(ContratoGarantia garantia)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"INSERT INTO ContratoGarantia (IdUsuario, IdContrato) " +
                    $"VALUES ('{garantia.IdUsuario}','{garantia.IdContrato}')";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    res = command.ExecuteNonQuery();
                    command.CommandText = "SELECT SCOPE_IDENTITY()";
                    var id = command.ExecuteScalar();
                    garantia.IdContratoGarantia = Convert.ToInt32(id);
                    connection.Close();
                }
            }
            return res;
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<ContratoGarantia> GetAll()
        {
            throw new NotImplementedException();
        }

        public ContratoGarantia GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(ContratoGarantia p)
        {
            throw new NotImplementedException();
        }


    }
}
