﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    interface ICategoriaRepository
    {
        int Inserir(Categoria categoria);

        List<Categoria> ObterTodos();

        bool Update(Categoria categoria);

        Categoria ObterPeloId(int id);

        bool Delete(int id);
    }
}
