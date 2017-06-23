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
    public class SQL_Inquire
    {
        public List<Model.Data> GetData(Model.Data Data)
        {
            string where = "where ";
            //整理空值
            if (Data.CodeId != "null")
            {
                where += "CodeId = '" + Data.CodeId + "' and ";
            }
            if (Data.CompanyName != null)
            {
                where += "CompanyName = '"+Data.CompanyName+"' and ";
            }
            if (Data.CustomerID != null)
            {
                where += "CustomerID = '" + Data.CustomerID + "' and ";
            }
            if (Data.ContactName != null)
            {
                where += "ContactName = '"+Data.ContactName+"' and ";
            }

            if (where == "where ")
            {
                where = "where CodeType = 'TITLE'";
            }else
            {
                where += "  CodeType = 'TITLE'";
            }

            


            string sql = "select CustomerID, CompanyName, ContactName, (CodeId+'-'+CodeVal) 'ContactTitle-CodeTable.CodeVal' from dbo.CodeTable a join sales.customers b on a.CodeId = b.ContactTitle " + where;
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
                    CustomerID = row["CustomerID"].ToString(),
                    CompanyName = row["CompanyName"].ToString(),
                    ContactName = row["ContactName"].ToString(),
                    ContactTitle = row["ContactTitle-CodeTable.CodeVal"].ToString()
                });
            }
            return result;
        }
    }
}
