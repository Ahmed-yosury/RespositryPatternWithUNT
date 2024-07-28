
using Microsoft.EntityFrameworkCore;
using RespositryPatternWithUNT.core.AutoMapper;
using RespositryPatternWithUNT.core.Interfaces;
using RespositryPatternWithUNT.core.Service;
using RespositryPatternWithUNT.ef;
using RespositryPatternWithUNT.ef.Respositres;

namespace RespositryPatternWithUNT.api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            //builder.Services.addDbContext<ApplicationDbContext>

            // Add services to the container.


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection"),
            b=>b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            //builder.Services.AddTransient(typeof(IBaseRespositry<>), typeof(BaseRespositry<>));
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //  if (app.Environment.IsDevelopment())
            //{
            app.UseSwagger();
            app.UseSwaggerUI();
            //}

            

           
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors("AllowAll");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
