using System;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace employee.HRS
{
    public class HRAppService_Tests : employeeApplicationTestBase
    {
        private readonly IHRAppService _hrAppService;

        public HRAppService_Tests()
        {
            _hrAppService = GetRequiredService<IHRAppService>();
        }

        [Fact]
        public async Task Should_Get_All_HRS_Without_Any_Filter()
        {
            var result = await _hrAppService.GetListAsync(new GetHRListDto());

            result.TotalCount.ShouldBeGreaterThanOrEqualTo(2);
            result.Items.ShouldContain(hr => hr.Name == "User1 user1");
            result.Items.ShouldContain(hr => hr.Name == "User2 user2");
        }

        [Fact]
        public async Task Should_Get_Filtered_HRS()
        {
            var result = await _hrAppService.GetListAsync(
                new GetHRListDto { Filter = "User1 user1" });

            result.TotalCount.ShouldBeGreaterThanOrEqualTo(1);
            result.Items.ShouldContain(hr => hr.Name == "user1");
            result.Items.ShouldNotContain(hr => hr.Name == "user2");
        }

        [Fact]
        public async Task Should_Create_A_New_HRS()
        {
            var hrDto = await _hrAppService.CreateAsync(
                new CreateHRDto
                {
                    Name = "user3",
                    HireDate = new DateTime(1880, 05, 22),
                    Desc = "Edward  was an American author..."
                }
            );

            hrDto.Id.ShouldNotBe(Guid.Empty);
            hrDto.Name.ShouldBe("Edward Bellamy");
        }

        [Fact]
        public async Task Should_Not_Allow_To_Create_Duplicate_HRS()
        {
            await Assert.ThrowsAsync<HRAlreadyExistsException>(async () =>
            {
                await _hrAppService.CreateAsync(
                    new CreateHRDto
                    {
                        Name = "Douglas Adams",
                        HireDate = DateTime.Now,
                        Desc = "..."
                    }
                );
            });
        }
    }
}
