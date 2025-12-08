using DataAccessService.Domain.ValueObjects.Ref;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessService.InfrastructurePostgres.Converters
{
    public class TestCategoryConverter : ValueConverter<TestCategory, string>
    {
        public TestCategoryConverter()
            : base(
                vo => vo.Value,
                str => TestCategory.Create(str)
            )
        { }
    }
}