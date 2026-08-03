using EduMS.Application.M5_FinancialManagement.DTOs.Accounts;
using MediatR;

namespace EduMS.Application.M5_FinancialManagement.Commands.Accounts;

public class CreateAccountCommand : IRequest<long>
{
    public CreateAccountDto Dto { get; set; } = new();
}

public class UpdateAccountCommand : IRequest<bool>
{
    public UpdateAccountDto Dto { get; set; } = new();
}

public class DeleteAccountCommand : IRequest<bool>
{
    public long Id { get; set; }
}