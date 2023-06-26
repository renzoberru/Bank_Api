using AutoMapper;
using Bank_Api.DTO;
using Bank_Api.Repositorios;
using BaseDatos.Modelo;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

namespace Bank_Api.Servicios
{
    public class ServicioBanco : IServicioBanco
    {
        private readonly IRepositorioBanco _repositorioBanco;
        private readonly IMapper _mapeador;
        public ServicioBanco(IRepositorioBanco repositorioBanco, IMapper mapeador)
        {
            _repositorioBanco = repositorioBanco;
            _mapeador = mapeador;
        }

        public async Task<BancoDto> GetBanco(string uid)
        {
            var banco = await _repositorioBanco.GetBanco(uid);
            var bancoDto = _mapeador.Map<BancoDto>(banco);
            return bancoDto;            
        }

        public async Task<bool> InsertarBanco(BancoCreadorDto nuevoBanco)
        {
            if (nuevoBanco == null) 
            {
                return false;
            }
            var banco = _mapeador.Map<Banco>(nuevoBanco);
            banco.FechaCreacion = DateTime.Now;
            var filas = await _repositorioBanco.InsertarBanco(banco);
            if (filas == 0)
            {
                return false;
            }
            return true;
        }

        public async Task<int> PoblarBaseDatos(string jsonBanco)
        {
            var bancosRandom = JsonSerializer.Deserialize<List<Banco>>(jsonBanco);
            foreach (var banco in bancosRandom)
            {
                banco.FechaCreacion = DateTime.Now;
                banco.FechaModificacion = DateTime.Now;
            }
            var filas = await _repositorioBanco.PoblarBaseDatosAsync(bancosRandom);
            return filas;
        }

        public bool UpdateBanco(BancoDto banco, int id)
        {
            throw new NotImplementedException();
        }
    }
}
