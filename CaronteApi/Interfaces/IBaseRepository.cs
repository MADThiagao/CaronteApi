using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaronteApi.Interfaces
{
    public interface IBaseRepository<T>
    {
        void Adicionar(T entidade);
        IEnumerable<T> BuscarTodos(int id);
        T Buscar(int id);
        void Remover(T entidade);
        void Atualizar(T entidade);
    }
}