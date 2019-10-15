using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria.Models
{
    public class RepositorioInmuebleTipo : RepositorioBase, IRepositorio<InmuebleTipo>
    {
        public RepositorioInmuebleTipo(IConfiguration configuration) : base(configuration)
        {

        }

        public int Create(InmuebleTipo p)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<InmuebleTipo> GetAll()
        {
            IList<InmuebleTipo> listTipo = new List<InmuebleTipo>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT IdInmuebleTipo, InmuebleTipoNombre FROM InmuebleTipo";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        InmuebleTipo tipo = new InmuebleTipo
                        {
                            IdInmuebleTipo = reader.GetInt32(0),
                            InmuebleTipoNombre = reader.GetString(1),
                        };

                        listTipo.Add(tipo);
                    }
                    connection.Close();
                }
            }
            return listTipo;
        }

        public InmuebleTipo GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(InmuebleTipo p)
        {
            throw new NotImplementedException();
        }
    }
}
