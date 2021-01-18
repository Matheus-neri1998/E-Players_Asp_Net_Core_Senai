using System.Collections.Generic;
using E_Players_Asp_Net_Core.Models;

namespace E_Players_Asp_Net_Core_Senai.Interfaces
{
    public interface IJogador
    {
         // Criar
         void Create(Jogador j);
         // ler
         List<Jogador> ReadAll();
         // Alterar
         void Update(Jogador j);
        // Excluir
        void Delete(int id);



    }
}