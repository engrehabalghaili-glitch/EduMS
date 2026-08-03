using EduMS.Application.M4_AssetLogistics.DTOs.AssetLoans;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetLoans;

public class CreateAssetLoanCommand : IRequest<long>
{
    public CreateAssetLoanDto Dto { get; set; } = new();
}

public class UpdateAssetLoanCommand : IRequest<bool>
{
    public UpdateAssetLoanDto Dto { get; set; } = new();
}

public class DeleteAssetLoanCommand : IRequest<bool>
{
    public long Id { get; set; }
}