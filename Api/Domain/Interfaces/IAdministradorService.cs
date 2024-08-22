using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MinimalAPI.Domain.Entities;
using MinimalAPI.DTO;

namespace MinimalAPI.Domain.Interfaces
{
    public interface IAdministradorService
    {
        Administrador Login(LoginDTO loginDTO);
        Administrador Incluir(Administrador administrador);
        Administrador BuscaPorId(int id);
        List<Administrador> Todos(int? pagina);
    }
}