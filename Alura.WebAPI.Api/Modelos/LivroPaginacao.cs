﻿using Alura.ListaLeitura.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.WebAPI.Api.Modelos
{
    public class LivroPaginacao
    {
        public int Pagina { get; set; } = 1;
        public int Tamanho { get; set; } = 25;
    }

    public class LivroPaginado
    {
        public int Total { get; set; }

        public int TamanhoPagina { get; set; }
        public int NumeroPagina { get; set; }
        public int TotalPaginas { get; set; }
        public IList<LivroApi> Resultado { get; set; }
        public string Anterior { get; set; }
        public string ProximaPagina { get; set; }
    }

    public static class LivroPaginadoExtensions
    {
        public static LivroPaginado ToLivroPaginado(this IQueryable<LivroApi> query, LivroPaginacao paginacao)
        {
            int totalItens = query.Count();
            int totalPaginas = (int)Math.Ceiling(totalItens / (double)paginacao.Tamanho);

            return new LivroPaginado
            {
                Total = totalItens,
                TotalPaginas = totalPaginas,
                NumeroPagina = paginacao.Pagina,
                TamanhoPagina = paginacao.Tamanho,
                Resultado = query
                    .Skip(paginacao.Tamanho * (paginacao.Pagina - 1))
                    .Take(paginacao.Tamanho).ToList(),
                Anterior = (paginacao.Pagina > 1) ? $"livros?tamanho={paginacao.Tamanho}&pagina={paginacao.Pagina - 1}" : string.Empty,
                ProximaPagina = (paginacao.Pagina < totalPaginas) ? $"livros?tamanho{paginacao.Tamanho}&pagina={paginacao.Pagina + 1}" : string.Empty,
            };
        }
    }
}
