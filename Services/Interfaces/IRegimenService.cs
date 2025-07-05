using BusinessObjects;

namespace Services.Interfaces
{
    public interface IRegimenService
    {
        void Add(Regimen regimen);
        void Update(Regimen regimen);
        void Delete(long id);
        Regimen? GetById(long id);
        List<Regimen> GetAll();
        List<Regimen> GetByDoctorIdAndNull(long doctorId);

    }
}
