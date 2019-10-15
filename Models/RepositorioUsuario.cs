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
        public int Create(Usuario entidad)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"INSERT INTO Usuario (UsuarioNombre, UsuarioApellido, UsuarioDni, UsuarioTelefono," +
                    $" UsuarioEmail, UsuarioClave, UsuarioSalt, UsuarioDomicilio, IdUsuarioTipo" +
                    $") " +
                    $"VALUES ('{entidad.UsuarioNombre}','{entidad.UsuarioApellido}','{entidad.UsuarioDni}','{entidad.UsuarioTelefono}'," +
                    $"'{entidad.UsuarioEmail}','{entidad.UsuarioClave}','{entidad.UsuarioSalt}','{entidad.UsuarioDomicilio}','{entidad.IdUsuarioTipo}')";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    res = command.ExecuteNonQuery();
                    command.CommandText = "SELECT SCOPE_IDENTITY()";
                    var id = command.ExecuteScalar();
                    entidad.IdUsuario = Convert.ToInt32(id);
                    connection.Close();
                }
            }
            return res;
        }

        public int Delete(int id)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"DELETE FROM Usuario WHERE IdUsuario = {id}";
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

        public IList<Usuario> GetAll()
        {
            IList<Usuario> res = new List<Usuario>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT u.IdUsuario, u.UsuarioNombre, u.UsuarioApellido, " +
                    $"u.UsuarioDni, u.UsuarioTelefono, " +
                    $"u.UsuarioEmail, u.UsuarioClave, " +
                    $"u.UsuarioSalt, u.UsuarioDomicilio, u.IdUsuarioTipo, ut.UsuarioTipoRol" +
                    $" FROM Usuario u INNER JOIN UsuarioTipo ut ON u.IdUsuarioTipo = ut.IdUsuarioTipo ";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                        while (reader.Read())
                    {
                        Usuario entidad = new Usuario
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
                            IdUsuarioTipo = reader.GetInt32(9),
                            Tipo = new UsuarioTipo
                            {
                                IdUsuarioTipo = reader.GetInt32(9),
                                UsuarioTipoRol = reader.GetString(10),
                            }
                        };
                        res.Add(entidad);
                    }
                    connection.Close();
                }
            }
            return res;
        }

        public IList<Usuario> GetByCriterio(BusquedaView busqueda)
        {
            if (busqueda.Tipo == 1)
            { busqueda.Campo = "ut.UsuarioTipoRol"; }
            else if (busqueda.Tipo == 2)
            { busqueda.Campo = "u.UsuarioNombre"; }
            else if (busqueda.Tipo == 3)
            { busqueda.Campo = "u.UsuarioDni"; }
            else { busqueda.Campo = "u.UsuarioApellido"; }

            IList<Usuario> res = new List<Usuario>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT u.IdUsuario, u.UsuarioNombre, u.UsuarioApellido, " +
                    $"u.UsuarioDni, u.UsuarioTelefono, " +
                    $"u.UsuarioEmail, u.UsuarioClave, " +
                    $"u.UsuarioSalt, u.UsuarioDomicilio, u.IdUsuarioTipo, ut.UsuarioTipoRol" +
                    $" FROM Usuario u INNER JOIN UsuarioTipo ut ON u.IdUsuarioTipo = ut.IdUsuarioTipo " +
                    $"WHERE {busqueda.Campo} LIKE '%{busqueda.Criterio}%'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Usuario entidad = new Usuario
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
                            IdUsuarioTipo = reader.GetInt32(9),
                            Tipo = new UsuarioTipo
                            {
                                IdUsuarioTipo = reader.GetInt32(9),
                                UsuarioTipoRol = reader.GetString(10),
                            }
                        };
                        res.Add(entidad);
                    }
                    connection.Close();
                }
            }
            return res;
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
                            Tipo = new UsuarioTipo
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
                string sql = $"SELECT u.IdUsuario, u.UsuarioNombre, u.UsuarioApellido, " +
                    $"u.UsuarioDni, u.UsuarioTelefono, " +
                    $"u.UsuarioEmail, u.UsuarioClave, " +
                    $"u.UsuarioSalt, u.UsuarioDomicilio, u.IdUsuarioTipo , ut.UsuarioTipoRol " +
                    $"FROM Usuario u INNER JOIN UsuarioTipo ut ON u.IdUsuarioTipo = ut.IdUsuarioTipo " +
                    $"WHERE u.UsuarioEmail=@email";
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
                            IdUsuarioTipo = reader.GetInt32(9),
                            Tipo = new UsuarioTipo
                            {
                                IdUsuarioTipo = reader.GetInt32(9),
                                UsuarioTipoRol = reader.GetString(10),
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

        public IList<Usuario> GetByType(int tipo)
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
                    $"WHERE u.IdUsuarioTipo=@tipo";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add("@tipo", SqlDbType.Int).Value = tipo;
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
                            Tipo = new UsuarioTipo
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
