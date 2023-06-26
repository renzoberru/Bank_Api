using Bank_Api.DTO;
using BaseDatos.Modelo;

namespace Bank_Api.Repositorios
{
    public interface IRepositorioBanco
    {
        public Task<int> PoblarBaseDatosAsync(List<Banco> bancos);
        public Task<Banco> GetBanco(string uid);
        public Task<int> InsertarBanco(Banco banco);
        public bool UpdateBanco(Banco banco, int id);
    }
}
