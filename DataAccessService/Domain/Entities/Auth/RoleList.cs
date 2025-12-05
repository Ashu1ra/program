using DataAccessService.Domain.ValueObjects.Auth;

namespace DataAccessService.Domain.Entities.Auth
{
    public class RoleList
    {
        public long Id { get; set; }
        public RoleName Name { get; set; }
        public string? Description { get; set; }
    }
}