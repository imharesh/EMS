using System;
using System.Threading.Tasks;
using employee.Emps;
using employee.HRS;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace employee
{
    public class employeeDataSeederContributor
     : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Emp, Guid> _empRepository;
        private readonly IHRRepository _hrRepository;
        private readonly HRManager _hrManager;
        public employeeDataSeederContributor(IRepository<Emp, Guid> empRepository, IHRRepository authorRepository,
        HRManager authorManager)
        {
            _empRepository = empRepository;
            _hrRepository = authorRepository;
            _hrManager = authorManager;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _empRepository.GetCountAsync() > 0)
            {
                return;
            }
            {
                var haresh = await _hrRepository.InsertAsync(
           await _hrManager.CreateAsync(
               "Haresh Baraiya",
               new DateTime(1903, 06, 25),
               "ABC"
           )
       );

                var divyanshu = await _hrRepository.InsertAsync(
                    await _hrManager.CreateAsync(
                        "Divyanshu Kumar",
                        new DateTime(1952, 03, 11),
                        "XYZ"
                    )
                );


                await _empRepository.InsertAsync(
                    new Emp
                    {
                        HRId = haresh.Id,
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

                        HRId = divyanshu.Id,
                        Name = "Divyanshu",
                        Age = 20,
                        Salary = 50000,
                        Type = Department.ScienceFiction,
                      
                    },
                    autoSave: true
                );
            }

            //if (await _hrRepository.GetCountAsync() <= 0)
            //{
            //    await _hrRepository.InsertAsync(
            //        await _hrManager.CreateAsync(
            //            "User1 user1",
            //            new DateTime(1903, 06, 25),
            //            "Nineteen Eighty-Four (1949)."
            //        )
            //    );

            //    await _hrRepository.InsertAsync(
            //        await _hrManager.CreateAsync(
            //            "User2 user2",
            //            new DateTime(1952, 03, 11),
            //            "self-proclaimed 'radical atheist'."
            //        )
            //    );
            //}
        }
    }
}
