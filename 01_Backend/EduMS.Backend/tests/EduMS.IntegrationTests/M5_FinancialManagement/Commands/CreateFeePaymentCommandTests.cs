using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;
using EduMS.Application.M5_FinancialManagement.Commands.FeePayments;
using EduMS.Domain.Entities;
using EduMS.Infrastructure.Common.Persistence;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace EduMS.IntegrationTests.M5_FinancialManagement.Commands;

public class CreateFeePaymentCommandTests : IntegrationTestBase<Program, EduMSDbContext>
{
    public CreateFeePaymentCommandTests(CustomWebApplicationFactory<Program> factory) 
        : base(factory)
    {
    }

    [Fact]
    public async Task CreateFeePayment_PartialPayment_ShouldUpdateInvoiceRemainingBalance()
    {
        // Arrange
        using var setupScope = Factory.Services.CreateScope();
        var setupDbContext = setupScope.ServiceProvider.GetRequiredService<EduMSDbContext>();
        
        var school = setupDbContext.Set<School>().First();
        var student = setupDbContext.Set<Student>().First();

        var studentAccount = new StudentAccount { StudentId = student.Id, SchoolId = school.Id, AccountNumber = "SA-001" };
        setupDbContext.Set<StudentAccount>().Add(studentAccount);
        await setupDbContext.SaveChangesAsync();
        
        var invoice = new StudentInvoice 
        { 
            StudentAccountId = studentAccount.Id, 
            StudentId = student.Id,
            SchoolId = school.Id,
            InvoiceNumber = "INV-001",
            TotalAmount = 1000m,
            RemainingAmount = 1000m,
            PaidAmount = 0m,
            PaymentStatus = 1 // Unpaid
        };
        
        var cmd1 = setupDbContext.Database.GetDbConnection().CreateCommand();
        cmd1.CommandText = "PRAGMA foreign_keys = OFF;";
        cmd1.ExecuteNonQuery();

        setupDbContext.Set<StudentInvoice>().Add(invoice);
        await setupDbContext.SaveChangesAsync();

        var command = new CreateFeePaymentCommand
        {
            Dto = new EduMS.Application.M5_FinancialManagement.DTOs.FeePayments.CreateFeePaymentDto
            {
                StudentAccountId = studentAccount.Id,
                StudentId = student.Id,
                SchoolId = school.Id,
                InvoiceId = invoice.Id,
                Amount = 400m, // Partial payment
                PaymentNumber = "PAY-001",
                PaymentDate = DateTime.UtcNow,
                Currency = "SAR"
            }
        };

        // Act
        var resultId = await Mediator.Send(command);

        // Assert
        resultId.Should().BeGreaterThan(0);

        using var scope = Factory.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EduMSDbContext>();
        
        var savedInvoice = await dbContext.Set<StudentInvoice>().FindAsync(invoice.Id);
        savedInvoice.Should().NotBeNull();
        savedInvoice!.PaidAmount.Should().Be(400m);
        savedInvoice.RemainingAmount.Should().Be(600m);
        savedInvoice.PaymentStatus.Should().Be(2); // PartiallyPaid
        
        // Verify M7 Communication Queue Event Dispatch
        var messageQueue = await dbContext.Set<MessageQueue>()
            .Where(m => m.RecipientAddress == "guardian@test.com")
            .OrderByDescending(m => m.Id)
            .FirstOrDefaultAsync();
            
        messageQueue.Should().NotBeNull();
        messageQueue!.Subject.Should().Contain("Test Student");
        messageQueue.Status.Should().Be("Pending");
    }
}
