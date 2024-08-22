using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MinimalAPI.Domain.Entities;
using MinimalAPI.Domain.Interfaces;
using MinimalAPI.DTO;
using MinimalAPI.Infrastructure.DB;

namespace MinimalAPI.Domain.Services
{
    public class AdministradorService : IAdministradorService
    {
        private readonly DbContexto _contexto;
        public AdministradorService(DbContexto contexto)
        {
            _contexto = contexto;
        }

        public Administrador BuscaPorId(int id)
        {
            return _contexto.Administradores.Find(id);
        }

        public Administrador Incluir(Administrador administrador)
        {
            _contexto.Administradores.Add(administrador);
            _contexto.SaveChanges();
            return administrador;
        }

        public Administrador Login(LoginDTO loginDTO)
        {
            var adm = _contexto.Administradores.Where(adm => adm.Email == loginDTO.Email && adm.Senha == loginDTO.Senha).FirstOrDefault();
            return adm;
        }

        public List<Administrador> Todos(int? pagina)
        {
            var listaAdministradores = _contexto.Administradores.AsQueryable();

            int itensPorPagina = 10;
            if (pagina != null)
            {
                listaAdministradores = listaAdministradores.Skip(((int)pagina - 1) * itensPorPagina).Take(itensPorPagina);
            }
            return listaAdministradores.ToList();
        }
    }
}