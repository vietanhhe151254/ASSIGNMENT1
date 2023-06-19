using BusinessObject.Models;
using BusinessObjects;
using DataAccess.Repository;
using DataAccess.IRepository;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Octopus.Client.Repositories.Async;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
}); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<DataAccess.IRepository.IUserRepository, UserRepository>();
builder.Services.AddSwaggerGen(c =>
{
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});
builder.Services.AddControllers().AddOData(option 
=> option.Select().Filter().Count().OrderBy()
.Expand().SetMaxTop(100).
AddRouteComponents("odata", GetEdmModel()));
builder.Services.AddDbContext<MyDbContext>(option => option.UseInMemoryDatabase("BookStore"));

static IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder oDataConventionModelBuilder = new ODataConventionModelBuilder();
    oDataConventionModelBuilder.EntitySet<Book>("Books");
    oDataConventionModelBuilder.EntitySet<User>("Users");
    return oDataConventionModelBuilder.GetEdmModel();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseODataBatching();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
