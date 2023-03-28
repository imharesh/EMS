using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace employee.HRS
{
    public class HR : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; private set; }
        public DateTime HireDate { get; set; }
        public string Desc { get; set; }

        private HR()
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        internal HR(
            Guid id,
            [NotNull] string name,
            DateTime hireDate,
            [CanBeNull] string desc = null)
            : base(id)
        {
            SetName(name);
            HireDate = hireDate;
            Desc = desc;
        }

        internal HR ChangeName([NotNull] string name)
        {
            SetName(name);
            return this;
        }

        private void SetName([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(
                name,
                nameof(name),
                maxLength: HRConsts.MaxNameLength
            );
        }
    }
}
