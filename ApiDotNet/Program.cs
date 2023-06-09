using Microsoft.AspNetCore.StaticFiles;

var builder = WebApplication.CreateBuilder(args);

#region container
// Add services to the container.
builder.Services.AddControllers(option =>
{
    option.ReturnHttpNotAcceptable=true;
}
).AddXmlDataContractSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//create just one instance for all requests in project
// addscoped => for any user one instance
builder.Services.AddSingleton<FileExtensionContentTypeProvider>();
#endregion

var app = builder.Build();


#region Middlewares
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.UseRouting();

app.UseAuthorization();

app.MapControllers();  //Domain.suffix/ControllerName/Action/id(optional)
#endregion

app.Run();
