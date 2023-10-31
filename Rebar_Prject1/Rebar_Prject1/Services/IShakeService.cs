using Rebar_Prject1.Models;

namespace Rebar_Prject1.Services
{
    public interface IShakeService
    {
        List<Shake> Get();
        Shake Get(string id);
        Shake Create(Shake s);
        void Update(string id, Shake s);
        void Remove(string id);
    }
}
