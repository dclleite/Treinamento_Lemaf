﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAvancado.CadastroPessoas.Repositorio
{
    public interface IRepositorio<T>
    {
        List<T> SelecionarTodos();
        int Adicionar(T objeto);
    }
}