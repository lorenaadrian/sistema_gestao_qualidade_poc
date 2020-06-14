using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using SistemaGestaoQualidade.WebApi.Contracts;
using SistemaGestaoQualidade.WebApi.Repository;
using SistemaGestaoQualidade.WebApi.Shared;

namespace SistemaGestaoQualidade.WebApi
{
    public class Startup
    {
        // Configuração CORS >> https://docs.microsoft.com/pt-br/aspnet/core/security/cors?view=aspnetcore-3.1
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        readonly string SpecificOrigins = "_specificOrigins";
        private readonly string Secret = "4Bms3ZBc9GpI18k3yJR54Fcdj9IjP8iyKy3wTKsh+l5caz1OESmINdnYJw2Onf5fVouHSWKqs8EAsxa6jdUH0Q==";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
            services.AddScoped<INãoConformidadeRepository, NaoConformidadeRepository>();
            services.AddScoped<IClassificacaoNaoConformidadeRepository, ClassificacaoNaoConformidadeRepository>();
            services.AddScoped<ITipoRequisitoRepository, TipoRequisitoRepository>();
            services.AddScoped<ICausaRaizRepository, CausaRaizRepository>();
            services.AddScoped<IAcaoCorretivaRepository, AcaoCorretivaRepository>();
            services.AddScoped<ICatalogoNorma, CatalogoNorma>();
            services.AddSingleton<IAuthentication, AuthenticationCore>();
            services.AddSingleton<IAuthorizationCore, AuthorizationCore>();

            services.AddScoped<IDatabaseAccess, DataBaseAccess>();

            var key = Encoding.ASCII.GetBytes(Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKeys = new[] { new SymmetricSecurityKey(key) },
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddCors(options =>
            {
                options.AddPolicy(SpecificOrigins,
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(SpecificOrigins);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
