using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorDeEquipamentos
{
    class ListaDeEquipamentos
    {
        private Equipamento[] equipamentos = new Equipamento[1];
        private int ponteiroEquipamentos = 0;

        public Equipamento[] Equipamentos
        {
            get
            {
                Equipamento[] equis = new Equipamento[ponteiroEquipamentos];

                for (int i = 0; i < ponteiroEquipamentos; i++)
                {
                    equis[i] = equipamentos[i];
                }

                return equis;
            }
        }

        private void VerificarERedimensionOsEquipamentos()
        {
            if (equipamentos.Length == ponteiroEquipamentos)
            {
                int count = 0;
                Equipamento[] novoEquipamentos = new Equipamento[equipamentos.Length * 2];

                foreach (Equipamento equipamento in equipamentos)
                {
                    novoEquipamentos[count] = equipamento;
                    count++;
                }

                this.equipamentos = novoEquipamentos;

                return;
            }
            else
                return;
        }

        public void AdicionarEquipamento(Equipamento equipamento)
        {
            VerificarERedimensionOsEquipamentos();

            equipamentos[ponteiroEquipamentos] = equipamento;
            ponteiroEquipamentos++;
        }

        public bool RemoverEquipamento(int posicao)
        {
            if (posicao >= ponteiroEquipamentos || posicao < 0)
                return false;

            for (int i = posicao; i < ponteiroEquipamentos - 1; i++)
            {
                equipamentos[i] = equipamentos[i + 1];
            }

            ponteiroEquipamentos--;

            return true;
        }
    }
}
