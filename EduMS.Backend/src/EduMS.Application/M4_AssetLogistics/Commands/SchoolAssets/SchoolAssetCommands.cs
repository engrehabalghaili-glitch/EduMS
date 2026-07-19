using EduMS.Application.M4_AssetLogistics.DTOs.SchoolAssets;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.SchoolAssets;

public class CreateSchoolAssetCommand : IRequest<long>
{
    public CreateSchoolAssetDto Dto { get; set; } = new();
}

public class UpdateSchoolAssetCommand : IRequest<bool>
{
    public UpdateSchoolAssetDto Dto { get; set; } = new();
}

public class DeleteSchoolAssetCommand : IRequest<bool>
{
    public long Id { get; set; }
}