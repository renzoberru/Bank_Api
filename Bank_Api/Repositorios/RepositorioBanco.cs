using Bank_Api.DTO;
using BaseDatos.DBContext;
using BaseDatos.Modelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bank_Api.Repositorios
{
    public class RepositorioBanco : IRepositorioBanco
    {
        private readonly BancoDbContext _dbcontext;
        public RepositorioBanco(BancoDbContext bdcontext)
        {
            _dbcontext = bdcontext;
        }

        public BancoDto GetBanco(string uid)
        {
            throw new NotImplementedException();
        }

        public async Task<int> InsertarBanco(Banco banco)
        {
            _dbcontext.Banco.Add(banco);
            var filas = await _dbcontext.SaveChangesAsync();
            return filas;
        }

        public async Task<int> PoblarBaseDatosAsync(List<Banco> bancos)
        {
            _dbcontext.Banco.AddRange(bancos);
            var filas = await _dbcontext.SaveChangesAsync();
            return filas;
        }

        public bool UpdateBanco(Banco banco, int id)
        {
            throw new NotImplementedException();
        }
    }
}
