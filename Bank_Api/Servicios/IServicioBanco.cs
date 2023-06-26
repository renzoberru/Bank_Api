using Bank_Api.DTO;

namespace Bank_Api.Servicios
{
    public interface IServicioBanco
    {
        public Task<int> PoblarBaseDatos(string jsonBanco);
        public BancoDto GetBanco(string uid);
        public bool InsertarBanco(BancoCreadorDto nuevoBanco);
        public bool UpdateBanco(BancoDto banco, int id);
    }
}
