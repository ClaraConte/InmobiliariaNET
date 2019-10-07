using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria.Models
{
    public class RepositorioUsuario : RepositorioBase, IRepositorioUsuario
    {
        public RepositorioUsuario(IConfiguration configuration) : base(configuration)
        {

        }
        public int Add(Usuario u)
        {
            throw new NotImplementedException();
        }

        public int Delete(Usuario u)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> GetAll()
        {
            throw new NotImplementedException();
        }

        public Usuario GetAllById(int id)
        {
            Usuario u = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT IdUsuario, UsuarioNombre, UsuarioApellido, " +
                    $"UsuarioDni, UsuarioTelefono, " +
                    $"UsuarioEmail, UsuarioClave, " +
                    $"UsuarioSalt, UsuarioDomicilio, IdUsuarioTipo " +
                    $"FROM Usuario" +
                    $" WHERE IdUsuario=@id";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        u = new Usuario
                        {
                            IdUsuario = reader.GetInt32(0),
                            UsuarioNombre = reader.GetString(1),
                            UsuarioApellido = reader.GetString(2),
                            UsuarioDni = reader.GetString(3),
                            UsuarioTelefono = reader.GetString(4),
                            UsuarioEmail = reader.GetString(5),
                            UsuarioClave = reader.GetString(6),
                            UsuarioSalt = reader.GetString(7),
                            UsuarioDomicilio = reader.GetString(8),
                            IdUsuarioTipo = new UsuarioTipo
                            {
                                IdUsuarioTipo = reader.GetInt32(9),
                            }
                        };
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                    connection.Close();
                }
            }
            return u;
        }

        public Usuario GetByEmail(string email)
        {
            Usuario u = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT IdUsuario, UsuarioNombre, UsuarioApellido, " +
                    $"UsuarioDni, UsuarioTelefono, " +
                    $"UsuarioEmail, UsuarioClave, " +
                    $"UsuarioSalt, UsuarioDomicilio, IdUsuarioTipo " +
                    $"FROM Usuario" +
                    $" WHERE UsuarioEmail=@email";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        u = new Usuario
                        {
                            IdUsuario = reader.GetInt32(0),
                            UsuarioNombre = reader.GetString(1),
                            UsuarioApellido = reader.GetString(2),
                            UsuarioDni = reader.GetString(3),
                            UsuarioTelefono = reader.GetString(4),
                            UsuarioEmail = reader.GetString(5),
                            UsuarioClave = reader.GetString(6),
                            UsuarioSalt = reader.GetString(7),
                            UsuarioDomicilio = reader.GetString(8),
                            IdUsuarioTipo = new UsuarioTipo
                            {
                                IdUsuarioTipo = reader.GetInt32(9),
                            }
                        };
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                    connection.Close();
                }
            }
            return u;
        }

        public IList<Usuario> GetByType(int idUsuarioTipo)
        {

            List<Usuario> res = new List<Usuario>();
            Usuario entidad = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT u.IdUsuario, u.UsuarioNombre, u.UsuarioApellido, " +
                    $"u.UsuarioDni, u.UsuarioTelefono, " +
                    $"u.UsuarioEmail, " +
                    $"u.UsuarioSalt, u.UsuarioDomicilio, u.IdUsuarioTipo , ut.UsuarioTipoRol " +
                    $"FROM Usuario u INNER JOIN UsuarioTipo ut ON u.IdUsuarioTipo = ut.IdUsuarioTipo " +
                    $"WHERE u.IdUsuarioTipo=@idUsuarioTipo";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add("@idUsuarioTipo", SqlDbType.Int).Value = idUsuarioTipo;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        entidad = new Usuario
                        {
                            IdUsuario = reader.GetInt32(0),
                            UsuarioNombre = reader.GetString(1),
                            UsuarioApellido = reader.GetString(2),
                            UsuarioDni = reader.GetString(3),
                            UsuarioTelefono = reader.GetString(4),
                            UsuarioEmail = reader.GetString(5),
                            UsuarioSalt = reader.GetString(6),
                            UsuarioDomicilio = reader.GetString(7),
                            IdUsuarioTipo = new UsuarioTipo
                            {
                                IdUsuarioTipo = reader.GetInt32(8),
                                UsuarioTipoRol = reader.GetString(9),
                            }
                        };
                        res.Add(entidad);
                    }
                    connection.Close();
                }
            }
            return res;
        }

        public int Update(Usuario u)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"UPDATE Usuario SET UsuarioNombre='{u.UsuarioNombre}', UsuarioApellido='{u.UsuarioApellido}', " +
                    $"UsuarioDni='{u.UsuarioDni}', UsuarioTelefono='{u.UsuarioTelefono}', UsuarioEmail='{u.UsuarioEmail}', " +
                    $"UsuarioClave='{u.UsuarioClave}' " +
                    $"WHERE IdUsuario = {u.IdUsuario}";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    res = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return res;
        }
    }
}
