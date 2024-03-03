using FluentValidation;
using Gringotts.Banking.Application.Contracts.Accounts;
using Gringotts.Banking.Application.Contracts.Transactions;
using Gringotts.Banking.Application.Contracts.Users;
using Gringotts.Banking.Application.Services;
using Gringotts.Banking.Domain;
using Gringotts.Banking.Domain.Repositories.Accounts;
using Gringotts.Banking.Domain.Repositories.Transactions;
using Gringotts.Banking.Domain.Repositories.Users;
using Gringotts.Banking.HttpApi;
using Gringotts.Banking.HttpApi.Authentication;
using Gringotts.Banking.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Gringotts.Banking.Domain.Interceptors;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork<BankingDbContext>>();

builder.Services.TryAddSingleton<UpdateAuditableInterceptor>();

builder.Services.TryAddSingleton<UpdateSoftDeletableInterceptor>();

builder.AddBasicAuthentication();

builder.Services.AddDbContext<BankingDbContext>(options =>
{
    //the change occurs here.
    //builder.cofiguration and not just configuration
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));

});

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers().RequireAuthorization();

app.Run();
