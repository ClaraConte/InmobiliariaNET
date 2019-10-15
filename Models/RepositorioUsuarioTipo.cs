using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria.Models
{
    public class RepositorioUsuarioTipo : RepositorioBase, IRepositorio<UsuarioTipo>
    {
        public RepositorioUsuarioTipo(IConfiguration configuration) : base(configuration)
        {

        }

        public int Create(UsuarioTipo p)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<UsuarioTipo> GetAll()
        {
            IList<UsuarioTipo> listTipo = new List<UsuarioTipo>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT IdUsuarioTipo, UsuarioTipoRol FROM UsuarioTipo";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        UsuarioTipo tipo = new UsuarioTipo
                        {
                            IdUsuarioTipo = reader.GetInt32(0),
                            UsuarioTipoRol = reader.GetString(1),
                        };

                        listTipo.Add(tipo);
                    }
                    connection.Close();
                }
            }
            return listTipo;
        }

        public UsuarioTipo GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(UsuarioTipo p)
        {
            throw new NotImplementedException();
        }
    }
 }
