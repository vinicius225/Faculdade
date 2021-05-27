using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Faculdade.Banco
{
    interface CRUD<T> where T : class
    {
        void adicionar(T obj);
        void excluir(int id);
        void atualizar(T obj);
        T consultarID(int id);
        List<T> Consultar();
    }
}