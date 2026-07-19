using EduMS.Application.M4_AssetLogistics.DTOs.AssetFinancialAuditArchives;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetFinancialAuditArchives;

public class CreateAssetFinancialAuditArchiveCommand : IRequest<long>
{
    public CreateAssetFinancialAuditArchiveDto Dto { get; set; } = new();
}

public class UpdateAssetFinancialAuditArchiveCommand : IRequest<bool>
{
    public UpdateAssetFinancialAuditArchiveDto Dto { get; set; } = new();
}

public class DeleteAssetFinancialAuditArchiveCommand : IRequest<bool>
{
    public long Id { get; set; }
}