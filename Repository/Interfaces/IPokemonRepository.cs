using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    interface IPokemonRepository
    {
        int Inserir(Pokemon pokemon);

        bool Update(Pokemon pokemon);

        bool Delete(int id);

        List<Pokemon> ObterTodos(string pesquisa);

        Pokemon ObterPeloId(int id);
    }
}
