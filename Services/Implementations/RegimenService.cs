using BusinessObjects;
using RepositoryLayer;
using Services.Interfaces;

namespace Services.Implementations
{
    public class RegimenService : IRegimenService
    {
        private readonly IRegimenRepository _regimenRepository;

        public RegimenService(IRegimenRepository regimenRepository)
        {
            _regimenRepository = regimenRepository;
        }

        public void Add(Regimen regimen) => _regimenRepository.Add(regimen);
        public void Delete(int id) => _regimenRepository.Delete(id);
        public Regimen GetById(int id) => _regimenRepository.GetById(id);
        public List<Regimen> GetAll() => _regimenRepository.GetAll();
        public void Update(Regimen regimen) => _regimenRepository.Update(regimen);
    }
}
