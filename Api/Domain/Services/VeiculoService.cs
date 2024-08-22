using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using MinimalAPI.Domain.Entities;
using MinimalAPI.Domain.Interfaces;
using MinimalAPI.DTO;
using MinimalAPI.Infrastructure.DB;

namespace MinimalAPI.Domain.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly DbContexto _contexto;
        public VeiculoService(DbContexto contexto)
        {
            _contexto = contexto;
        }

        public void Apagar(Veiculo veiculo)
        {
            _contexto.Veiculos.Remove(veiculo);
            _contexto.SaveChanges();
        }

        public void Atualizar(Veiculo veiculo)
        {
            _contexto.Veiculos.Update(veiculo);
            _contexto.SaveChanges();
        }

        public Veiculo BuscaPorId(int id)
        {
            return _contexto.Veiculos.Where(veiculo => veiculo.Id == id).FirstOrDefault();
        }

        public void Incluir(Veiculo veiculo)
        {
            _contexto.Veiculos.Add(veiculo);
            _contexto.SaveChanges();
        }

        public List<Veiculo> Todos(int? pagina = 1, string nome = null, string marca = null)
        {
            var listaVeiculos = _contexto.Veiculos.AsQueryable();
            if (!string.IsNullOrEmpty(nome))
            {
                listaVeiculos = listaVeiculos.Where(veiculo => veiculo.Nome.ToLower().Contains(nome));
            }
            int itensPorPagina = 10;
            if (pagina != null)
            {
                listaVeiculos = listaVeiculos.Skip(((int)pagina - 1) * itensPorPagina).Take(itensPorPagina);
            }
            return listaVeiculos.ToList();
        }
    }
}