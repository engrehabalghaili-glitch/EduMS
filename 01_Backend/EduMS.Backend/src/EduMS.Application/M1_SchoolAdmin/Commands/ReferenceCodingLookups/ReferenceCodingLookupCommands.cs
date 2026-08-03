using EduMS.Application.M1_SchoolAdmin.DTOs.ReferenceCodingLookups;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.ReferenceCodingLookups;

public class CreateReferenceCodingLookupCommand : IRequest<long>
{
    public CreateReferenceCodingLookupDto Dto { get; set; } = new();
}

public class UpdateReferenceCodingLookupCommand : IRequest<bool>
{
    public UpdateReferenceCodingLookupDto Dto { get; set; } = new();
}

public class DeleteReferenceCodingLookupCommand : IRequest<bool>
{
    public long Id { get; set; }
}