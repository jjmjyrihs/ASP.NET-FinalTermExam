using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Service
{
    public class SQL_GetCodeTable
    {
        public List<Model.Data> GetCodeTable()
        {
            string sql = "select CodeId, (CodeId+'-'+CodeVal) 'ContactTitle-CodeTable.CodeVal'  from dbo.CodeTable where CodeType = 'TITLE'";
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconn"].ConnectionString);
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return (FillData(dt));            
        }

        private List<Model.Data> FillData(DataTable dt)
        {
            List<Model.Data> result = new List<Model.Data>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new Model.Data
                {
                    CodeId = row["CodeId"].ToString(),
                    ContactTitle = row["ContactTitle-CodeTable.CodeVal"].ToString()
                });
            }
            return result;
        }
    }
}
