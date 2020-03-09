using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test2
{
    /// <summary>
    /// SqlHelper 数据库帮助类
    /// </summary>
    class SqlHelper
    {
        static string connStr = ConfigurationManager.ConnectionStrings["str"].ConnectionString;

        static SqlConnection conn = new SqlConnection(connStr);
        /// <summary>
        /// ExcuteNonQuery 用于执行增删改方法
        /// </summary>
        /// <param name="strSql">增删改Sql语句</param>
        /// <param name="paras">Sql参数数组</param>
        /// <returns>返回一个整数值,用于判断是否操作成功</returns>
        public static int ExcuteNonQuery(string strSql, params SqlParameter[] paras)
        {
            SqlCommand cmd = new SqlCommand(strSql, conn); //执行sql指令 外面调用需传入2个参数 Sql查询语句和 Sql连接
            cmd.Parameters.AddRange(paras);                //添加 查询语句执行的参数数组
            conn.Open();                                   //执行前 需打开数据库连接
            int n = cmd.ExecuteNonQuery();                 //执行 cmd指令操作 返回成功操作的行数
            conn.Close();                                  //用完关闭数据库 节约资源
            return n;                                      //返回成功操作的行数
        }

        /// <summary>
        /// ExecuteDataTable 用于执行 查 方法
        /// </summary>
        /// <param name="strSql">Sql Select语句</param>
        /// <returns>返回 查询结果表</returns>
        public static DataTable ExecuteDataTable(string strSql)
        {
            SqlCommand cmd = new SqlCommand(strSql, conn); //执行sql指令 外面调用需传入2个参数 Sql查询语句和 Sql连接
            SqlDataAdapter da = new SqlDataAdapter(cmd);   //使用SqlDataAdapter数据适配器来加载cmd操作指令
            DataTable dt = new DataTable();                //创建 DataTable 
            da.Fill(dt);                                   //将SqlDataAdapter 获取的结果集 填充到 DataTable中
            return dt;                                     //返回 DataTable
        }
    }
}
