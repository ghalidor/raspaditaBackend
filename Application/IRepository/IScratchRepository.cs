
using Domain;

namespace Application.IRepository
{
    public interface IScratchRepository
    {
        Task<IEnumerable<Scratch_Matrix>> GetMatrix();
        Task<Scratch_Matrix> GetMatrixPosicion(Int64 id);
        Task<IEnumerable<Scratch_Tp>> GetTp();
        Task<Int64> GetCount();
        Task<Scratch_codigo> getLastCode(string ip);
    }
}
