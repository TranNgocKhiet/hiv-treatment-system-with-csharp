using BusinessObjects;
using DataAccessLayer;
using DataAccessObjects;

namespace RepositoryLayer
{
    public class RegimenRepository : IRegimenRepository
    {
        private readonly RegimenDAO _regimenDao;

        public RegimenRepository(HivDbContext context)
        {
            _regimenDao = new RegimenDAO(context);
        }

        public void Add(Regimen regimen) => _regimenDao.Add(regimen);
        public void Delete(long id) => _regimenDao.Delete(id);
        public void Update(Regimen regimen) => _regimenDao.Update(regimen);
        public Regimen GetById(long id) => _regimenDao.GetById(id);
        public List<Regimen> GetAll() => _regimenDao.GetAll();
    }
}
