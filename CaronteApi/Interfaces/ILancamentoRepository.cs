﻿
using System.Collections.Generic;
using CaronteCore.Models;
using CaronteCore.Models.DTO;

namespace CaronteApi.Interfaces
{
    public interface ILancamentoRepository : IBaseRepository<Lancamento>
    {
        List<GraficoLinhaDTO> GraficoLinha(int IdUsuario);
        List<GraficoDonutDTO> GraficoDonut(int IdUsuario);
        List<Lancamento> BuscarMensal(int IdUsuario);
    }
}
