using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TP.OracleManage.oracleConnect {
    /// <summary>
    /// oracle 数据库连接
    /// </summary>
    public class OracleExecute {
        /// <summary>
        /// 数据库链接
        /// </summary>
        private OracleConnection conn;
        /// <summary>
        /// 根据指定的数据库链接串 dbStr 开启数据库连接 
        /// </summary>
        /// <param name="dbStr">数据库连接串</param>
        /// <returns></returns>
        public static OracleExecute openConn(String dbStr) {
            OracleExecute orc = new OracleExecute();
            orc.conn =  new OracleConnection();
            orc.conn.ConnectionString = dbStr;
            orc.conn.Open();
            return orc;
        }
        /// <summary>
        /// 执行指定sql 并返回 DataTable
        /// </summary>
        /// <param name="sql">将要执行的sql 语句</param>
        /// <returns></returns>
        public DataTable getDataTable(String sql) {
            DataSet ds = new DataSet();
            OracleCommand cmd = new OracleCommand(sql, conn);
            OracleDataAdapter oda = new OracleDataAdapter();
            oda.SelectCommand = cmd;
            oda.Fill(ds);
            return ds.Tables[0];
        }
        /// <summary>
        /// 执行指定  sql  并返回受影响的行数 
        /// </summary>
        /// <param name="sql">将要执行的sql</param>
        /// <returns></returns>
        public int getNoDataTable(String sql) {
            OracleCommand cmd = new OracleCommand(sql, conn);
            return cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void closeConn() {
            if (conn == null) { return; }
            try {
                if (conn.State != ConnectionState.Closed) {
                    conn.Close();
                }
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            } finally {
                conn.Dispose();
            }
        }
    }
}
