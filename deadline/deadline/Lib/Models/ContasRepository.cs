using deadline.Connection;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace deadline.Models
{
    public class ContasRepository
    {
        myConnecion myc;
        
        public ContasRepository()
        {
            myc = new myConnecion();
        }

        public List<Contas> getAll()
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();

            List<Contas> contas = new List<Contas>();

            sql.Append("SELECT * FROM contas");

            cmm.CommandText = sql.ToString();

            MySqlDataReader dr = myc.getDataReader(cmm);

            while (dr.Read())
            {
                contas.Add(
                    new Contas
                    {
                        id_conta = (int)dr["id_conta"],
                        data_leitura = (DateTime)dr["data_leitura"],
                        n_leitura = dr["n_leitura"].ToString(),
                        kw_gasto = dr["kw_gasto"].ToString(),
                        valor_pagar = dr["valor_pagar"].ToString(),
                        data_pagamento = (DateTime)dr["data_pagamento"],
                        media_consumo = Convert.ToDouble(dr["media_consumo"])
                    }   
                 );
            }

            dr.Dispose();
            return contas;
        }

        public double GetMedia()
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();
            double total_media = 0;

            sql.Append("SELECT SUM(media_consumo) as media FROM contas");

            cmm.CommandText = sql.ToString();

            MySqlDataReader dr = myc.getDataReader(cmm);

            if (dr.Read())
            {
                total_media = Convert.ToDouble(dr["media"]);
            }

            dr.Dispose();
            return total_media;
        }

        public double GetTotal()
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();
            double total_pagar = 0;

            sql.Append("SELECT SUM(valor_pagar) as total FROM contas");

            cmm.CommandText = sql.ToString();

            MySqlDataReader dr = myc.getDataReader(cmm);

            if (dr.Read())
            {
                total_pagar = Convert.ToDouble(dr["total"]);
            }

            dr.Dispose();
            return total_pagar;
        }


        public String GetMin()
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();
            String menor = "";

            sql.Append("SELECT data_pagamento, MIN(valor_pagar) as minimo FROM contas");

            cmm.CommandText = sql.ToString();

            MySqlDataReader dr = myc.getDataReader(cmm);

            if (dr.Read())
            {
                String data = string.Format("{0:yyyy-MM-dd}", dr["data_pagamento"]);

                menor = String.Concat(dr["minimo"].ToString(), " ", data);
            }

            dr.Dispose();
            return menor;
        }

        public String GetMax()
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();
            String menor = "";

            sql.Append("SELECT data_pagamento, MAX(valor_pagar) as maximo FROM contas");

            cmm.CommandText = sql.ToString();

            MySqlDataReader dr = myc.getDataReader(cmm);

            if (dr.Read())
            {
                String data = string.Format("{0:yyyy-MM-dd}", dr["data_pagamento"]);

                menor = String.Concat(dr["maximo"].ToString(), " ", data);
            }

            dr.Dispose();
            return menor;
        }
        public List<Contas> searchByDate(DateTime data_inicio, DateTime data_final)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();

            List<Contas> contas = new List<Contas>();

            sql.Append("SELECT * FROM contas WHERE data_leitura BETWEEN (@data_inicio) AND (@data_final)");

            cmm.Parameters.AddWithValue("@data_inicio", data_inicio);
            cmm.Parameters.AddWithValue("@data_final", data_final);
            cmm.CommandText = sql.ToString();

            MySqlDataReader dr = myc.getDataReader(cmm);

            while (dr.Read())
            {
                contas.Add(
                    new Contas
                    {
                        id_conta = (int)dr["id_conta"],
                        data_leitura = (DateTime)dr["data_leitura"],
                        n_leitura = dr["n_leitura"].ToString(),
                        kw_gasto = dr["kw_gasto"].ToString(),
                        valor_pagar = dr["valor_pagar"].ToString(),
                        data_pagamento = (DateTime)dr["data_pagamento"],
                        media_consumo = Convert.ToDouble(dr["media_consumo"])
                    }
                 );
            }

            dr.Dispose();
            return contas;
        }
        public void create(Contas contas)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();

            sql.Append("INSERT INTO contas (data_leitura, n_leitura, kw_gasto, valor_pagar, data_pagamento, media_consumo)");
            sql.Append("VALUES (@data_leitura, @n_leitura, @kw_gasto, @valor_pagar, @data_pagamento, @media_consumo)");

            cmm.Parameters.AddWithValue("@data_leitura", contas.data_leitura);
            cmm.Parameters.AddWithValue("@n_leitura", contas.n_leitura);
            cmm.Parameters.AddWithValue("@kw_gasto", contas.kw_gasto);
            cmm.Parameters.AddWithValue("@valor_pagar", contas.valor_pagar);
            cmm.Parameters.AddWithValue("@data_pagamento", contas.data_pagamento);
            cmm.Parameters.AddWithValue("@media_consumo", contas.media_consumo);

            cmm.CommandText = sql.ToString();

            myc.ExecuteCommand(cmm);
        }

        public void Delete(int id)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();

            sql.Append("DELETE FROM contas WHERE id_conta = (@id)");

            cmm.Parameters.AddWithValue("@id", id);
            cmm.CommandText = sql.ToString();

            myc.ExecuteCommand(cmm);
        }

        public Contas getOne(int id)
        {
            var contas = new List<Contas>();

            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();

            sql.Append("SELECT * FROM contas WHERE id_conta = (@id)");

            cmm.Parameters.AddWithValue("@id", id);
            cmm.CommandText = sql.ToString();

            MySqlDataReader dr = myc.getDataReader(cmm);

            if (dr.Read())
            {
                contas.Add(
                        new Models.Contas
                        {
                            id_conta = (int)dr["id_conta"],
                            data_leitura = (DateTime)dr["data_leitura"],
                            n_leitura = dr["n_leitura"].ToString(),
                            kw_gasto = dr["kw_gasto"].ToString(),
                            valor_pagar = dr["valor_pagar"].ToString(),
                            data_pagamento = (DateTime)dr["data_pagamento"],
                            media_consumo = Convert.ToDouble(dr["media_consumo"]),
                        }
                    );
            }

            dr.Dispose();
            return contas.FirstOrDefault();
        }

        public void Edit(Contas contas)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();

            sql.Append("UPDATE contas SET data_leitura = (@data_leitura), n_leitura = (@n_leitura), kw_gasto = (@kw_gasto),");
            sql.Append("valor_pagar = (@valor_pagar), data_pagamento = (@data_pagamento), media_consumo = (@media_consumo)");
            sql.Append("WHERE id_conta = (@id_conta)");

            cmm.Parameters.AddWithValue("@data_leitura", contas.data_leitura);
            cmm.Parameters.AddWithValue("@n_leitura", contas.n_leitura);
            cmm.Parameters.AddWithValue("@kw_gasto", contas.kw_gasto);
            cmm.Parameters.AddWithValue("@valor_pagar", contas.valor_pagar);
            cmm.Parameters.AddWithValue("@data_pagamento", contas.data_pagamento);
            cmm.Parameters.AddWithValue("@media_consumo", contas.media_consumo);
            cmm.Parameters.AddWithValue("@id_conta", contas.id_conta);

            cmm.CommandText = sql.ToString();

            myc.ExecuteCommand(cmm);

        }

    }
}