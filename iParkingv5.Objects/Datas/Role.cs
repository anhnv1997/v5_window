using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Text;

namespace iParkingv6.Objects.Datas
{
    public class Role
    {
        public string Id { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Active { get; set; } = true;

        public ICollection<string> VoucherTypeIds { get; set; }
        public ICollection<string> VoucherReleaseUnitIds { get; set; }
        public ICollection<string> CardGroupIds { get; set; }
    }

    public class RoleDto
    {
        public string Id { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Active { get; set; } = true;
        public string VoucherTypeIds { get; set; } = string.Empty;
        public string VoucherReleaseUnitIds { get; set; } = string.Empty;
        public string CardGroupIds { get; set; } = string.Empty;

        private static Expression<Func<Role, RoleDto>> Projection
        {
            get
            {
                return model => new RoleDto()
                {
                    Id = model.Id,
                    RoleName = model.RoleName,
                    Description = model.Description,
                    Active = model.Active,
                    CardGroupIds = model.CardGroupIds != null ? string.Join(',', model.CardGroupIds) : string.Empty,
                    VoucherTypeIds = model.VoucherTypeIds != null ? string.Join(',', model.VoucherTypeIds) : string.Empty,
                    VoucherReleaseUnitIds = model.VoucherReleaseUnitIds != null
                        ? string.Join(',', model.VoucherReleaseUnitIds)
                        : string.Empty,
                };
            }
        }

        private static Func<Role, RoleDto> Converter => Projection.Compile();

        public static RoleDto Create(Role model)
        {
            return model != null ? Converter(model) : null;
        }
    }

    public class RoleCustom
    {
        public string Id { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Active { get; set; } = true;
        public string UserId { get; set; } = string.Empty;
    }
}
