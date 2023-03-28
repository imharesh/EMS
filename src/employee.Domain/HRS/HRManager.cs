using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace employee.HRS
{
    public class HRManager : DomainService
    {
        private readonly IHRRepository _hrRepository;

        public HRManager(IHRRepository hrRepository)
        {
            _hrRepository = hrRepository;
        }

       public async Task<HR> CreateAsync(
       [NotNull] string name,
       DateTime hireDate,
       [CanBeNull] string desc = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var existingHR = await _hrRepository.FindByNameAsync(name);
            if (existingHR != null)
            {
                throw new HRAlreadyExistsException(name);
            }

            return new HR(
                GuidGenerator.Create(),
                name,
                hireDate,
                desc
            );
        }

        public async Task ChangeNameAsync(
       [NotNull] HR hr,
       [NotNull] string newName)
        {
            Check.NotNull(hr, nameof(hr));
            Check.NotNullOrWhiteSpace(newName, nameof(newName));

            var existingHR = await _hrRepository.FindByNameAsync(newName);
            if (existingHR != null && existingHR.Id != hr.Id)
            {
                throw new HRAlreadyExistsException(newName);
            }

            hr.ChangeName(newName);
        }
    }
}
