﻿using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorios
{
    public class UsuariosRepositorio : IUsuariosRepositorio
    {
        private readonly Contexto _dbContext;

        public UsuariosRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UsuariosModel>> GetAll()
        {
            return await _dbContext.Usuario.ToListAsync();
        }

        public async Task<UsuariosModel> GetById(int id)
        {
            return await _dbContext.Usuario.FirstOrDefaultAsync(x => x.UsuarioId == id);
        }

        public async Task<UsuariosModel> Login(UsuariosModel usuario)
        {
            return await _dbContext.Usuario.FirstOrDefaultAsync(x => x.UsuarioEmail == usuario.UsuarioEmail 
                                                                       && x.UsuarioSenha == usuario.UsuarioSenha);
        }

        public async Task<UsuariosModel> InsertUsuario(UsuariosModel usuario)
        {
            await _dbContext.Usuario.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<UsuariosModel> UpdateUsuario(UsuariosModel usuario, int id)
        {
            UsuariosModel usuarios = await GetById(id);
            if (usuarios == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                usuarios.UsuarioNome = usuario.UsuarioNome;
                usuarios.UsuarioEmail = usuario.UsuarioEmail;
                usuarios.UsuarioTelefone = usuario.UsuarioTelefone;
                usuarios.UsuarioSenha = usuario.UsuarioSenha;
                _dbContext.Usuario.Update(usuarios);
                await _dbContext.SaveChangesAsync();
            }
            return usuarios;

        }

        public async Task<bool> DeleteUsuario(int id)
        {
            UsuariosModel usuarios = await GetById(id);
            if (usuarios == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Usuario.Remove(usuarios);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
