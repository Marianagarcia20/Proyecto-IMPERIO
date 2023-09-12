﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_IMPERIO
{
    internal class SQLControl
    {
        public SqlConnection cnn =
            new SqlConnection(@"Server=DESKTOP-6PGHB34;Database=Imperio_Vestidos;Integrated Security=True");

        public int login(string usuario, string pass)
        {
            try
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand("spLogin", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("pass", pass);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    return dr.GetInt32(0);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                cnn.Close();
            }
            return -1;
        }
    }
}
