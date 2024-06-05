using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorios
{
    public class ObservacoesRepositorio : IObservacoesRepositorio
    {
        private readonly Contexto _dbContext;

        public ObservacoesRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ObservacoesModel>> GetAll()
        {
            return await _dbContext.Observacoes.ToListAsync();
        }

        public async Task<ObservacoesModel> GetById(int id)
        {
            return await _dbContext.Observacoes.FirstOrDefaultAsync(x => x.ObservacoesId == id);
        }

        public async Task<ObservacoesModel> InsertObservacao(ObservacoesModel observacao)
        {
            await _dbContext.Observacoes.AddAsync(observacao);
            await _dbContext.SaveChangesAsync();
            return observacao;
        }

        public async Task<ObservacoesModel> UpdateObservacao(ObservacoesModel observacao, int id)
        {
            ObservacoesModel observacoes = await GetById(id);
            if (observacoes == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                observacoes.ObservacoesDescricao = observacoes.ObservacoesDescricao;
                observacoes.ObservacoesLocal = observacoes.ObservacoesLocal;
                observacoes.ObservacoesData = observacoes.ObservacoesData;
                observacoes.AnimaisId = observacoes.AnimaisId;
                observacoes.UsuarioId = observacoes.UsuarioId;
                _dbContext.Observacoes.Update(observacoes);
                await _dbContext.SaveChangesAsync();
            }
            return observacoes;

        }

        public async Task<bool> DeleteObservacao(int id)
        {
            ObservacoesModel observacoes = await GetById(id);
            if (observacoes == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Observacoes.Remove(observacoes);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
