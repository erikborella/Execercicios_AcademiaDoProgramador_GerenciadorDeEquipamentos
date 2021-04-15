using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorDeEquipamentos
{
    class Equipamento
    {
        private string nome;
        private float preco;
        private string serie;
        private DateTime dataDeFabricacao;
        private string fabricante;

        private int ponteiroManutencoes = 0;
        private Manutencao[] manutencaos = new Manutencao[1];

        public Equipamento(string nome, float preco, string serie, DateTime dataDeFabricacao, string fabricante)
        {
            this.nome = nome;
            this.preco = preco;
            this.serie = serie;
            this.dataDeFabricacao = dataDeFabricacao;
            this.fabricante = fabricante;
        }

        public string Nome { get => nome; set => nome = value; }
        public float Preco { get => preco; set => preco = value; }
        public string Serie { get => serie; set => serie = value; }
        public DateTime DataDeFabricacao { get => dataDeFabricacao; set => dataDeFabricacao = value; }
        public string Fabricante { get => fabricante; set => fabricante = value; }
        public Manutencao[] Manutencaos 
        {
            get
            {
                Manutencao[] mans = new Manutencao[ponteiroManutencoes];

                for (int i = 0; i < ponteiroManutencoes; i++)
                {
                    mans[i] = manutencaos[i];
                }

                return mans;
            }
        }

        private void VerificarERedimensionAsManutencoes()
        {
            if (manutencaos.Length == ponteiroManutencoes)
            {
                int count = 0;
                Manutencao[] novaManutencoas = new Manutencao[manutencaos.Length * 2];

                foreach(Manutencao manutencao in manutencaos)
                {
                    novaManutencoas[count] = manutencao;
                    count++;
                }

                this.manutencaos = novaManutencoas;

                return;
            } else
                return;
        }

        public void AdicionarManutencao(Manutencao manutencao)
        {
            VerificarERedimensionAsManutencoes();

            manutencaos[ponteiroManutencoes] = manutencao;
            ponteiroManutencoes++;
        }

        public bool RemoverManutencao(int posicao)
        {
            if (posicao >= ponteiroManutencoes || posicao < 0)
                return false;

            for (int i = posicao ; i < ponteiroManutencoes - 1; i++)
            {
                manutencaos[i] = manutencaos[i + 1];
            }

            ponteiroManutencoes--;

            return true;
        }

        public override string ToString()
        {
            return $"nome: {nome}\n" +
                $"Preco: {preco}\n" +
                $"Serie: {serie}\n" +
                $"Data De fabricacao: {dataDeFabricacao.ToString("dd/MM/yyyy")}\n" +
                $"fabricante: {fabricante}";
        }

    }
}
