using BusinessObjects;

namespace Services.Interfaces
{
    public interface IRegimenService
    {
        void Add(Regimen regimen);
        void Update(Regimen regimen);
        void Delete(int id);
        Regimen GetById(int id);
        List<Regimen> GetAll();
    }
}
