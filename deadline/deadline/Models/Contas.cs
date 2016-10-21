using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace deadline.Models
{
    public class Contas
    {
        public int id_conta { get; set; }
        public DateTime data_leitura { get; set; }
        public String n_leitura { get; set; }
        public String kw_gasto { get; set; }
        public String valor_pagar { get; set; }
        public DateTime data_pagamento { get; set; }
        public double media_consumo { get; set; }
    }
}