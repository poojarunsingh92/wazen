using WazenAdmin.Domain.Entities;
using System.Threading.Tasks;

namespace WazenAdmin.Application.Contracts.Persistence
{   
    public interface IInsuranceCompaniesRepository : IAsyncRepository<InsuranceCompany>
    {
    }    
}
