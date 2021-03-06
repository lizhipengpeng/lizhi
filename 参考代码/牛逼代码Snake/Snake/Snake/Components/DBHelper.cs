﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace Snake.Components
{
    class DBHelper
    {
        //创建链接字符串
        //static string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConectionString"];
        static string connectionString = @"Provider = Microsoft.ACE.OLEDB.12.0;Data Source = ../../data.accdb";
        //创建连接对象
        public static OleDbConnection conn = new OleDbConnection();

        //打开数据库连接，成功返回true
        public static bool open()
        {
            //连接属性赋值
            conn.ConnectionString = connectionString;

            //尝试打开连接
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        //关闭连接
        public static bool close()
        {
            if (conn.State == ConnectionState.Open)
            {
                try
                {
                    conn.Close();
                    return true;
                }
                catch
                {
                    return false;
                }

            }
            else
            {
                return true;
            }
        }



        //增删改
        public static bool update(string sqlstr)
        {
            open();

            try
            {
                OleDbCommand sqlCommand = new OleDbCommand(sqlstr, conn);
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("操作成功！");
                return true;
            }
            catch
            {
                MessageBox.Show("异常");
                return false;
            }
            finally
            {
                close();
            }
        }
    }
}
