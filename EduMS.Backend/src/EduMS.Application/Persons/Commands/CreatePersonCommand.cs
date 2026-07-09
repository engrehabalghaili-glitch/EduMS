using EduMS.Application.Common.CQRS;

namespace EduMS.Application.Persons.Commands;

public record CreatePersonCommand(
    string FullNameAr,
    string FullNameEn,
    string NationalId,
    int Gender,
    string? ContactNumber,
    string? MedicalInfo
) : ICommand<long>;
