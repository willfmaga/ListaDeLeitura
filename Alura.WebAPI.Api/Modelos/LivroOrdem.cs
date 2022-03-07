﻿using Alura.ListaLeitura.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace Alura.WebAPI.Api.Modelos
{
    public class LivroOrdem
    {
        public string OrdernarPor { get; set; } = "id asc";
    }

    public static class LivroOrdemExtensions
    {
        public static IQueryable <Livro> AplicaOrdem(this IQueryable<Livro> query, LivroOrdem ordem)
        {
            if(ordem != null)
            {
                query = query.OrderBy(ordem.OrdernarPor);

            }
            return query;
        }
    }
}
