using EduMS.Application.M4_AssetLogistics.DTOs.AssetComplianceAudits;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetComplianceAudits;

public class CreateAssetComplianceAuditCommand : IRequest<long>
{
    public CreateAssetComplianceAuditDto Dto { get; set; } = new();
}

public class UpdateAssetComplianceAuditCommand : IRequest<bool>
{
    public UpdateAssetComplianceAuditDto Dto { get; set; } = new();
}

public class DeleteAssetComplianceAuditCommand : IRequest<bool>
{
    public long Id { get; set; }
}