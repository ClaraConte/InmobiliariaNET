using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria.Models
{
    public class RepositorioContrato : RepositorioBase, IRepositorioContrato
    {
        public RepositorioContrato(IConfiguration configuration) : base(configuration)
    {

    }
        public int Create(Contrato contrato)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"INSERT INTO Contrato (ContratoDetalle, ContratoFechaInicio, ContratoFechaFin," +
                    $" ContratoPrecio, ContratoEstado, IdInmueble, IdUsuario ) " +
                    $"VALUES ('{contrato.ContratoDetalle}','{contrato.ContratoFechaInicio}','{contrato.ContratoFechaFin}','{contrato.ContratoPrecio}'," +
                    $"'{contrato.ContratoEstado}','{contrato.IdInmueble}','{contrato.IdUsuario}')";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    res = command.ExecuteNonQuery();
                    command.CommandText = "SELECT SCOPE_IDENTITY()";
                    var id = command.ExecuteScalar();
                    contrato.IdContrato= Convert.ToInt32(id);
                    connection.Close();
                }
            }
            return contrato.IdContrato;
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Contrato> GetAll()
        {
            IList<Contrato> res = new List<Contrato>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT c.IdContrato, c.ContratoDetalle, c.ContratoFechaInicio, c.ContratoFechaFin," +
                    $" c.ContratoPrecio, c.ContratoEstado, c.IdInmueble, c.IdUsuario," +
                    $" i.InmuebleDomicilio, i.IdUsuario, u.UsuarioDni, u.UsuarioNombre " +
                    $"FROM Contrato c INNER JOIN Inmueble i ON c.IdInmueble = i.IdInmueble " +
                    $"INNER JOIN Usuario u ON u.IdUsuario = c.IdUsuario ";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Contrato entidad = new Contrato
                        {
                            IdContrato = reader.GetInt32(0),
                            ContratoDetalle = reader.GetString(1),
                            ContratoFechaInicio = reader.GetDateTime(2),
                            ContratoFechaFin = reader.GetDateTime(3),
                            ContratoPrecio = reader.GetDecimal(4),
                            ContratoEstado = reader.GetByte(5),
                            IdInmueble = reader.GetInt32(6),
                            IdUsuario = reader.GetInt32(7),

                            Inmueble = new Inmueble
                            {
                                InmuebleDomicilio = reader.GetString(8),
                                IdUsuario = reader.GetInt32(9),
                            },

                            Usuario = new Usuario
                            {
                                UsuarioDni = reader.GetString(10),
                                UsuarioNombre = reader.GetString(11),
                            }
                        };
                        res.Add(entidad);
                    }
                    connection.Close();
                }
            }
            return res;
        }

        public Contrato GetAllById(int id)
        {
            Contrato entidad = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT c.IdContrato, c.ContratoDetalle, c.ContratoFechaInicio, c.ContratoFechaFin," +
                    $" c.ContratoPrecio, c.ContratoEstado, c.IdInmueble, c.IdUsuario " +
                    $"FROM Contrato c INNER JOIN Inmueble i ON c.IdInmueble = i.IdInmueble " +
                    $"INNER JOIN Usuario u ON u.IdUsuario = c.IdUsuario" +
                    $" WHERE c.IdContrato=@id";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                         entidad = new Contrato
                        {
                            IdContrato = reader.GetInt32(0),
                            ContratoDetalle = reader.GetString(1),
                            ContratoFechaInicio = reader.GetDateTime(2),
                            ContratoFechaFin = reader.GetDateTime(3),
                             ContratoPrecio = reader.GetDecimal(4),
                            ContratoEstado = reader.GetByte(5),
                            IdInmueble = reader.GetInt32(6),
                            IdUsuario = reader.GetInt32(7),

                            Inmueble = new Inmueble
                            {
                                IdUsuario = reader.GetInt32(6),
                            },

                            Usuario = new Usuario
                            {
                                IdUsuario = reader.GetInt32(7),
                            }
                        };
                       
                    }
                    connection.Close();
                }
            }
            return entidad;
        }

        public IList<Contrato> GetByPropietario(Usuario propietario)
        {
            throw new NotImplementedException();
        }

        public int Update(Contrato contrato)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"UPDATE Contrato SET ContratoFechaFin='{contrato.ContratoFechaFin}', ContratoEstado='{contrato.ContratoEstado}' WHERE IdContrato = '{contrato.IdContrato}' "; 
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    res = command.ExecuteNonQuery();
                    command.CommandText = "SELECT SCOPE_IDENTITY()";
                    var id = command.ExecuteScalar();
                    
                    connection.Close();
                }
            }
            return res;
        }


    }
}
