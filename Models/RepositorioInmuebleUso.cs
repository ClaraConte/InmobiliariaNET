using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria.Models
{
    public class RepositorioInmuebleUso : RepositorioBase, IRepositorio<InmuebleUso>
    {
        public RepositorioInmuebleUso(IConfiguration configuration) : base(configuration)
        {

        }

        public int Create(InmuebleUso p)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<InmuebleUso> GetAll()
        {
            IList<InmuebleUso> listTipo = new List<InmuebleUso>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT IdInmuebleUso, InmuebleUsoNombre FROM InmuebleUso";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        InmuebleUso tipo = new InmuebleUso
                        {
                            IdInmuebleUso = reader.GetInt32(0),
                            InmuebleUsoNombre = reader.GetString(1),
                        };

                        listTipo.Add(tipo);
                    }
                    connection.Close();
                }
            }
            return listTipo;
        }

        public InmuebleUso GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(InmuebleUso p)
        {
            throw new NotImplementedException();
        }
    }
}
