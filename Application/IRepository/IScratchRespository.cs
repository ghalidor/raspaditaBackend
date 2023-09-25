
using Domain;

namespace Application.IRepository
{
    public interface IScratchRespository
    {
        Task<IEnumerable<Scratch_Matrix>> GetMatrix();
        Task<IEnumerable<Scratch_Tp>> GetTp();
    }
}
