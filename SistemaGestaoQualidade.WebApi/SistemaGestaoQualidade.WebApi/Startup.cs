using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NaoConformidadeModule.WebApi.Contracts;
using NaoConformidadeModule.WebApi.Repository;
using NaoConformidadeModule.WebApi.Shared;

namespace NaoConformidadeModule.WebApi
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
            services.AddSingleton<IAuthorization, AuthorizationCore>();

            services.AddScoped<IDatabaseAccess, DataBaseAccess>();

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
