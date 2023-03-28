using System;
using System.Linq;
using System.Threading.Tasks;
using Shouldly;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Validation;
using Xunit;

namespace employee.Emps
{
    public class EmpAppService_Tests : employeeApplicationTestBase
    {
        private readonly IEmpAppService _empAppService;

        public EmpAppService_Tests()
        {
            _empAppService = GetRequiredService<IEmpAppService>();
        }

        [Fact]
        public async Task Should_Get_List_Of_Emps()
        {
            //Act
            var result = await _empAppService.GetListAsync(
                new PagedAndSortedResultRequestDto()
            );

            //Assert
            result.TotalCount.ShouldBeGreaterThan(0);
            result.Items.ShouldContain(b => b.Name == "Haresh");
        }

        [Fact]
        public async Task Should_Create_A_Valid_Emp()
        {
            //Act
            var result = await _empAppService.CreateAsync(
                new CreateUpdateEmpDto
                {
                   
                   
                    Name = "Krishn",
                    Age = 22,
                    Salary = 40050,
                    Type = Department.ScienceFiction
                }
            );

            //Assert
            result.Id.ShouldNotBe(Guid.Empty);
            result.Name.ShouldBe("New name");
        }

        [Fact]
        public async Task Should_Not_Create_A_Emp_Without_Name()
        {
            var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
            {
                await _empAppService.CreateAsync(
                    new CreateUpdateEmpDto
                    {
                       
                       
                        Name = "",
                        Age = 25,
                        Salary = 44000,
                        Type = Department.ScienceFiction
                    }
                );
            });

            exception.ValidationErrors
                .ShouldContain(err => err.MemberNames.Any(mem => mem == "Name"));
        }
    }
}
