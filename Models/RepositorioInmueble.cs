using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria.Models
{
    public class RepositorioInmueble : RepositorioBase, IRepositorioInmueble
    {
        public RepositorioInmueble(IConfiguration configuration) : base(configuration)
        {

        }
        public int Create(Inmueble inmueble)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"INSERT INTO Inmueble (InmuebleDomicilio, InmuebleLatitud, InmuebleLongitud, InmueblePrecio," +
                    $" InmuebleAmbientes, InmuebleEstado, IdInmuebleUso, IdInmuebleTipo, IdUsuario) " +
                    $"VALUES ('{inmueble.InmuebleDomicilio}','{inmueble.InmuebleLatitud}','{inmueble.InmuebleLongitud}','{inmueble.InmueblePrecio}'," +
                    $"'{inmueble.InmuebleAmbientes}','{inmueble.InmuebleEstado}','{inmueble.IdInmuebleUso}','{inmueble.IdInmuebleTipo}','{inmueble.IdUsuario}')";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    res = command.ExecuteNonQuery();
                    command.CommandText = "SELECT SCOPE_IDENTITY()";
                    var id = command.ExecuteScalar();
                    inmueble.IdUsuario = Convert.ToInt32(id);
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
                string sql = $"DELETE FROM Inmueble WHERE IdInmueble = {id}";
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

        public IList<Inmueble> GetAll()
        {
            IList<Inmueble> res = new List<Inmueble>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT i.IdInmueble, i.InmuebleDomicilio, i.InmuebleLatitud, " +
                    $"i.InmuebleLongitud, i.InmueblePrecio, " +
                    $"i.InmuebleAmbientes, i.InmuebleEstado, " +
                    $"i.IdInmuebleUso, i.IdInmuebleTipo, i.IdUsuario, iu.InmuebleUsoNombre, it.InmuebleTipoNombre, u.UsuarioNombre, u.UsuarioDni " +
                    $"FROM Inmueble i  JOIN Usuario u ON u.IdUsuario = i.IdUsuario " +
                    $" JOIN InmuebleTipo it ON it.IdInmuebleTipo = i.IdInmuebleTipo " +
                    $" JOIN InmuebleUso iu ON iu.IdInmuebleUso = i.IdInmuebleUso " +
                    $" WHERE u.IdUsuarioTipo = 3" ;
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Inmueble entidad = new Inmueble
                        {
                            IdInmueble = reader.GetInt32(0),
                            InmuebleDomicilio = reader.GetString(1),
                            InmuebleLatitud = reader.GetDecimal(2),
                            InmuebleLongitud = reader.GetDecimal(3),
                            InmueblePrecio = reader.GetDecimal(4),
                            InmuebleAmbientes = reader.GetInt32(5),
                            InmuebleEstado = reader.GetByte(6),
                            IdInmuebleUso = reader.GetInt32(7),
                            IdInmuebleTipo = reader.GetInt32(8),
                            IdUsuario = reader.GetInt32(9),

                            InmuebleUso = new InmuebleUso
                            {
                                IdInmuebleUso = reader.GetInt32(7),
                                InmuebleUsoNombre = reader.GetString(10),
                            },

                            InmuebleTipo = new InmuebleTipo
                            {
                                IdInmuebleTipo = reader.GetInt32(8),
                                InmuebleTipoNombre = reader.GetString(11),
                            },

                            Usuario = new Usuario
                            {
                                IdUsuarioTipo = reader.GetInt32(9),
                                UsuarioNombre = reader.GetString(12),
                                UsuarioDni = reader.GetString(13),
                            }
                        };
                        res.Add(entidad);
                    }
                    connection.Close();
                }
            }
            return res;
        }

        public Inmueble GetAllById(int id)
        {
            Inmueble entidad = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT i.IdInmueble, i.InmuebleDomicilio, i.InmuebleLatitud, " +
                    $"i.InmuebleLongitud, i.InmueblePrecio, " +
                    $"i.InmuebleAmbientes, i.InmuebleEstado, " +
                    $"i.IdInmuebleUso, i.IdInmuebleTipo, i.IdUsuario, iu.InmuebleUsoNombre, it.InmuebleTipoNombre, u.UsuarioNombre, u.UsuarioDni " +
                    $"FROM Inmueble i  JOIN Usuario u ON u.IdUsuario = i.IdUsuario " +
                    $" JOIN InmuebleTipo it ON it.IdInmuebleTipo = i.IdInmuebleTipo " +
                    $" JOIN InmuebleUso iu ON iu.IdInmuebleUso = i.IdInmuebleUso " +
                    $" WHERE u.IdUsuarioTipo = 3 AND i.IdInmueble = @id";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                         entidad = new Inmueble
                        {
                            IdInmueble = reader.GetInt32(0),
                            InmuebleDomicilio = reader.GetString(1),
                            InmuebleLatitud = reader.GetDecimal(2),
                            InmuebleLongitud = reader.GetDecimal(3),
                            InmueblePrecio = reader.GetDecimal(4),
                            InmuebleAmbientes = reader.GetInt32(5),
                            InmuebleEstado = reader.GetByte(6),
                            IdInmuebleUso = reader.GetInt32(7),
                            IdInmuebleTipo = reader.GetInt32(8),
                            IdUsuario = reader.GetInt32(9),

                            InmuebleUso = new InmuebleUso
                            {
                                IdInmuebleUso = reader.GetInt32(7),
                                InmuebleUsoNombre = reader.GetString(10),
                            },

                            InmuebleTipo = new InmuebleTipo
                            {
                                IdInmuebleTipo = reader.GetInt32(8),
                                InmuebleTipoNombre = reader.GetString(11),
                            },

                            Usuario = new Usuario
                            {
                                IdUsuarioTipo = reader.GetInt32(9),
                                UsuarioNombre = reader.GetString(12),
                                UsuarioDni = reader.GetString(13),
                            }
                        };
                    }
                    connection.Close();
                }
            }
            return entidad;
        }

        public IList<Inmueble> GetByCriterio(BusquedaView busqueda)
        {
            if (busqueda.Tipo == 1) { busqueda.Campo = "u.UsuarioDni"; }
            else if (busqueda.Tipo == 2) { busqueda.Campo = "u.UsuarioNombre"; }
            else if (busqueda.Tipo == 3) { busqueda.Campo = "i.InmuebleAmbientes"; }
            else if (busqueda.Tipo == 4) { busqueda.Campo = "i.InmuebleEstado"; busqueda.Criterio = "0"; }
            else { busqueda.Campo = "i.InmuebleEstado"; busqueda.Criterio = "1"; }

            IList<Inmueble> res = new List<Inmueble>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT i.IdInmueble, i.InmuebleDomicilio, i.InmuebleLatitud, " +
                     $"i.InmuebleLongitud, i.InmueblePrecio, " +
                     $"i.InmuebleAmbientes, i.InmuebleEstado, " +
                     $"i.IdInmuebleUso, i.IdInmuebleTipo, i.IdUsuario, iu.InmuebleUsoNombre, it.InmuebleTipoNombre, u.UsuarioNombre, u.UsuarioDni " +
                     $"FROM Inmueble i  JOIN Usuario u ON u.IdUsuario = i.IdUsuario " +
                     $" JOIN InmuebleTipo it ON it.IdInmuebleTipo = i.IdInmuebleTipo " +
                     $" JOIN InmuebleUso iu ON iu.IdInmuebleUso = i.IdInmuebleUso " +
                     $" WHERE u.IdUsuarioTipo = 3 and {busqueda.Campo} LIKE '%{busqueda.Criterio}%' ";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Inmueble entidad = new Inmueble
                        {
                            IdInmueble = reader.GetInt32(0),
                            InmuebleDomicilio = reader.GetString(1),
                            InmuebleLatitud = reader.GetDecimal(2),
                            InmuebleLongitud = reader.GetDecimal(3),
                            InmueblePrecio = reader.GetDecimal(4),
                            InmuebleAmbientes = reader.GetInt32(5),
                            InmuebleEstado = reader.GetByte(6),
                            IdInmuebleUso = reader.GetInt32(7),
                            IdInmuebleTipo = reader.GetInt32(8),
                            IdUsuario = reader.GetInt32(9),

                            InmuebleUso = new InmuebleUso
                            {
                                IdInmuebleUso = reader.GetInt32(7),
                                InmuebleUsoNombre = reader.GetString(10),
                            },

                            InmuebleTipo = new InmuebleTipo
                            {
                                IdInmuebleTipo = reader.GetInt32(8),
                                InmuebleTipoNombre = reader.GetString(11),
                            },

                            Usuario = new Usuario
                            {
                                IdUsuarioTipo = reader.GetInt32(9),
                                UsuarioNombre = reader.GetString(12),
                                UsuarioDni = reader.GetString(13),
                            }
                        };
                        res.Add(entidad);
                    }
                    connection.Close();
                }
            }
            return res;
        }

        public IList<Inmueble> GetByStatus(int status)
        {

            IList<Inmueble> res = new List<Inmueble>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT i.IdInmueble, i.InmuebleDomicilio, i.InmuebleLatitud, " +
                     $"i.InmuebleLongitud, i.InmueblePrecio, " +
                     $"i.InmuebleAmbientes, i.InmuebleEstado, " +
                     $"i.IdInmuebleUso, i.IdInmuebleTipo, i.IdUsuario, iu.InmuebleUsoNombre, it.InmuebleTipoNombre, u.UsuarioNombre, u.UsuarioDni " +
                     $"FROM Inmueble i  JOIN Usuario u ON u.IdUsuario = i.IdUsuario " +
                     $" JOIN InmuebleTipo it ON it.IdInmuebleTipo = i.IdInmuebleTipo " +
                     $" JOIN InmuebleUso iu ON iu.IdInmuebleUso = i.IdInmuebleUso " +
                     $" WHERE u.IdUsuarioTipo = 3 and i.InmuebleEstado = {status} ";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Inmueble entidad = new Inmueble
                        {
                            IdInmueble = reader.GetInt32(0),
                            InmuebleDomicilio = reader.GetString(1),
                            InmuebleLatitud = reader.GetDecimal(2),
                            InmuebleLongitud = reader.GetDecimal(3),
                            InmueblePrecio = reader.GetDecimal(4),
                            InmuebleAmbientes = reader.GetInt32(5),
                            InmuebleEstado = reader.GetByte(6),
                            IdInmuebleUso = reader.GetInt32(7),
                            IdInmuebleTipo = reader.GetInt32(8),
                            IdUsuario = reader.GetInt32(9),

                            InmuebleUso = new InmuebleUso
                            {
                                IdInmuebleUso = reader.GetInt32(7),
                                InmuebleUsoNombre = reader.GetString(10),
                            },

                            InmuebleTipo = new InmuebleTipo
                            {
                                IdInmuebleTipo = reader.GetInt32(8),
                                InmuebleTipoNombre = reader.GetString(11),
                            },

                            Usuario = new Usuario
                            {
                                IdUsuarioTipo = reader.GetInt32(9),
                                UsuarioNombre = reader.GetString(12),
                                UsuarioDni = reader.GetString(13),
                            }
                        };
                        res.Add(entidad);
                    }
                    connection.Close();
                }
            }
            return res;
        }

        public int Update(Inmueble i)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString)) 
            {
                string sql = $"UPDATE Inmueble SET InmuebleDomicilio='{i.InmuebleDomicilio}', InmuebleLatitud='{i.InmuebleLatitud}', " +
                    $"InmuebleLongitud='{i.InmuebleLongitud}', InmueblePrecio='{i.InmueblePrecio}', InmuebleAmbientes='{i.InmuebleAmbientes}', " +
                    $"InmuebleEstado='{i.InmuebleEstado}', IdInmuebleUso='{i.IdInmuebleUso}',  IdInmuebleTipo='{i.IdInmuebleTipo}', IdUsuario='{i.IdUsuario}' " +
                    $"WHERE IdInmueble = '{i.IdInmueble}' ";
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
