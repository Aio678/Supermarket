using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace XiangMu
{
    class DBHelper
    {
        public static string connstr = "server=华硕;database=supermarket;uid=sa;pwd=5656";
        public static SqlConnection conn = new SqlConnection(connstr);

        // 增删改
        public static int ExecuteNonQuery(string sql)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                int r = cmd.ExecuteNonQuery();
                conn.Close();
                return r;
            }
            catch (Exception ex)
            {

                Console.WriteLine("加载出现异常\t\t原因：" + ex.Message);
                return 0;
            }
        }


        // 逐条查询
        public static DataTable GetDataTable(string sql)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
                adp.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                Console.WriteLine("加载出现异常\t\t原因：" + ex.Message);
                return null;
            }
        }

        // 聚合查询
        public static object ExecuteScalar(string sql)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                object r = cmd.ExecuteScalar();
                conn.Close();
                return r;
            }
            catch (Exception ex)
            {
                Console.WriteLine("加载出现异常\t\t原因：" + ex.Message);
                return null;
            }
        }


    }
}
