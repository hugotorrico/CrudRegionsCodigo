using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DRegion
    {

        public void Insert(Region region)
        {
            using (var connection = new SqlConnection(Coneccion.cadena))
            {

                connection.Open();
                SqlCommand command = new SqlCommand("USP_InsertRegion", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter("@RegionName", SqlDbType.VarChar, 50);
                parameter.Value = region.RegionName;
                command.Parameters.Add(parameter);
        

                command.ExecuteNonQuery();

            }
        }

        public List<Region> Get(Region region)
        {
            List<Region> roles = new List<Region>();

            using (var connection = new SqlConnection(Coneccion.cadena))
            {
                //Usar el procedimiento almacenado
                SqlCommand cmd = new SqlCommand("USP_GetRegions", connection);
                cmd.CommandType = CommandType.StoredProcedure;


                //Enviar los parámetros
                SqlParameter parameter = new SqlParameter("@RegionName", SqlDbType.VarChar, 50);
                parameter.Value = region.RegionName;
                cmd.Parameters.Add(parameter);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                //Recorrer el data reader
                while (reader.Read())
                {

                    int RegionId = reader["RegionId"] != DBNull.Value ? Convert.ToInt32(reader["RegionId"]) : 0;
                    string RegionName = reader["RegionName"] != DBNull.Value ? Convert.ToString(reader["RegionName"]) : "";
                    roles.Add(new Region { RegionId = RegionId, RegionName = RegionName });

                }
                reader.Close();
            }
            return roles;

        }
    }
}
