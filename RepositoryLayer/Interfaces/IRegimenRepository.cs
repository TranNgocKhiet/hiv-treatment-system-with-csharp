using BusinessObjects;

namespace RepositoryLayer
{
    public interface IRegimenRepository
    {
        void Add(Regimen regimen);
        void Delete(long id);
        void Update(Regimen regimen);
        Regimen GetById(long id);
        List<Regimen> GetAll();
    }
}
