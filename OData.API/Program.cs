using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Microsoft.OpenApi.Models;
using OData.Common.ComplexType;
using OData.Common.Enum;
using OData.Data.DAO;
using OData.Data.DataContext;
using OData.Data.Models;
using OData.Data.Repositories;
using OData.Service;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
                .AddOData(option => option.Select()
                                          .Filter()
                                          .Count()
                                          .OrderBy()
                                          .Expand()
                                          .SetMaxTop(100)
                                          // register a route, passing along the Edm model to associate it with.
                                          .AddRouteComponents("odata", GetEdmModel()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "OData Demo",
        Version = "v1"
    });
});

builder.Services.AddDbContext<ODataDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// DI
builder.Services.AddScoped(typeof(IGenericDAO<>), typeof(GenericDAO<>));
builder.Services.AddScoped<IGadgetRepository, GadgetRepository>();
builder.Services.AddScoped<IGadgetService, GadgetService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static IEdmModel GetEdmModel()
{
    // being used to build the Edm model
    // 1. explicit model builder
    //EdmModel model = new EdmModel();

    // 2. Implicit, non-convention modelbuilder or fluent API
    // create an IEdmModel object by directly call fluent APIs
    //var builder = new ODataModelBuilder();
    //var product = builder.EntityType<Gadget>();
    //product.HasKey(p => p.Id);

    //builder.EntitySet<Gadget>("GadgetOdata");

    // 3. Implicit, convention model builder
    // auto map model, no need for config data
    var modelBuilder = new ODataConventionModelBuilder();
    // register Gadget as an entity set
    // this means Odata will create an endpoint for Gadget collection 
    modelBuilder.EntitySet<Gadget>("GadgetsOdata");

    // enum
    var color = modelBuilder.EnumType<Color>();
    color.Name = "Color";

    // complex type
    var address = modelBuilder.ComplexType<Address>();
    address.Property(a => a.Country);
    address.Property(a => a.City);

    // derived complex type
    var subAddress = modelBuilder.ComplexType<SubAddress>();
    subAddress.DerivesFrom<Address>();
    subAddress.Property(r => r.Street);

    return modelBuilder.GetEdmModel();
}

// when call GET /odata/name
// 1. odata find name + controller
// 2. odata call GET() method from this controller
// 3. return collection of item.

// /odata/$metadata
// define structure of Odata