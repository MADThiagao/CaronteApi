using CaronteApi.Interfaces;
using CaronteCore.Models;
using CaronteCore.Models.DTO;

namespace CaronteApi.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Usuario Logar(LoginDTO login);
    }
}
