using System;
using System.Threading.Tasks;
using employee.Emps;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace employee
{
    public class employeeDataSeederContributor
     : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Emp, Guid> _empRepository;

        public employeeDataSeederContributor(IRepository<Emp, Guid> empRepository)
        {
            _empRepository = empRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _empRepository.GetCountAsync() <= 0)
            {
                await _empRepository.InsertAsync(
                    new Emp
                    {
                        Name = "Haresh",
                        Age = 22,
                        Salary = 40000,
                        Type = Department.Dystopia,
                      
                    },
                    autoSave: true
                );

                await _empRepository.InsertAsync(
                    new Emp
                    {
                        Name = "Divyanshu",
                        Age = 20,
                        Salary = 50000,
                        Type = Department.ScienceFiction,
                      
                    },
                    autoSave: true
                );
            }
        }
    }
}
