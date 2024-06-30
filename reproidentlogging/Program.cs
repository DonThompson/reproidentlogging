
using api_logic;
using Microsoft.Identity.Web;

namespace reproidentlogging;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        //dummy code to reference api-logic project
        string s = SampleAPILogic.ReturnAString();
        Console.WriteLine(s);
        //end dummy code

        //repro use of Identity.Web
        builder.Services.AddMicrosoftIdentityWebApiAuthentication(builder.Configuration);
        //end use

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

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
    }
}
