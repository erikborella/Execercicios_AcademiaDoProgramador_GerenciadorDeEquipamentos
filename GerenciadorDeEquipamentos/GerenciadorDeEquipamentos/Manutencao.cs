using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorDeEquipamentos
{
    class Manutencao
    {
        private string titulo;
        private string descricao;
        private DateTime dataDeAbertura;

        public Manutencao(string titulo, string descricao, DateTime dataDeAbertura)
        {
            this.titulo = titulo;
            this.descricao = descricao;
            this.dataDeAbertura = dataDeAbertura;
        }

        public string Titulo { get => titulo; set => titulo = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public DateTime DataDeAbertura { get => dataDeAbertura; set => dataDeAbertura = value; }
        public int DiasAbertos()
        {
            DateTime hoje = DateTime.Now;
            TimeSpan diferenca = hoje.Subtract(dataDeAbertura);
            return Convert.ToInt32(diferenca.TotalDays);
        }

        public override string ToString()
        {
            return $"Titulo: {titulo}\n" +
                $"Descricao: {descricao}\n" +
                $"Dias Abertos: {DiasAbertos()}";
        }
    }
}
