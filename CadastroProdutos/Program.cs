using CadastroProdutos.Services;
using CadastroProdutos.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

namespace CadastroProdutos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

            builder.Services.AddDbContext<DbContext.AplicationDbContext>(options =>
            {
                options.UseSqlite("Data Source=Produtos.db");
            });

            builder.Services.AddEndpointsApiExplorer(); //Swagger
            //builder.Services.AddSwaggerGen(); //Swagger

            builder.Services.AddSwaggerGen(sg =>
            {
                sg.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "Insira o token JWT sem o prefixo 'Bearer '",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT"
                });

                sg.AddSecurityRequirement(document => new()
                {
                    [new OpenApiSecuritySchemeReference("Bearer", document)] = []
                });
            });
                
            //builder.Services.AddScoped<IProduct, ProdutoService>();
            builder.Services.AddScoped<IProduct, ProdutoDataBaseService>();

            var jwtSettings = builder.Configuration.GetSection("Jwt");
            var key = System.Text.Encoding.ASCII.GetBytes(jwtSettings["Key"]);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key)
                };
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapSwagger(); //Swagger
                app.UseSwaggerUI(); //Swagger
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}