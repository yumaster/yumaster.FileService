using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json;
using System.IO;
using yumaster.FileService.Authorization;
using yumaster.FileService.Authorization.Codecs;
using yumaster.FileService.Db.Options;
using yumaster.FileService.Service;
using yumaster.FileService.Service.Options;
using yumaster.FileService.Service.ServiceImpls;
using yumaster.FileService.WebApi.AutoReview;
using yumaster.FileService.WebApi.Extensions;
using yumaster.FileService.WebApi.Filters;
using yumaster.FileService.WebApi.Options;
using yumaster.FileService.WebApi.Swagger;

namespace yumaster.FileService.WebApi
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfiguration _cfg;
        private readonly string apiName = "�ļ�����";
        public Startup(IConfiguration cfg, IHostingEnvironment env)
        {
            _cfg = cfg;
            _env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllers();
            ServiceConfigure.AddAuthorization(services, opt =>
             {
                 opt.AppSecret = _cfg["General:AppSecret"];
             });
            services.AddSingleton<IFileTokenCodec, FileTokenCodec>();

            services.AddSingleton<IMimeProvider, MimeProvider>();
            services.AddSingleton<ImageSizeProvider>();
            services.AddSingleton<RawFileHandler>();
            services.AddSingleton<ImageFileHandler>();
            services.AddSingleton(svces => new FileHandlerManager(svces));

            //ע���ڲ�����
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //ѡ��
            services.AddOptions();
            services.Configure<ServerOption>(_cfg.GetSection("Server"));
            services.Configure<GeneralOption>(_cfg.GetSection("General"));
            services.Configure<ImageConverterOption>(_cfg.GetSection("ImageConverter"));
            services.Configure<DbOption>(_cfg.GetSection("Db"));
            services.Configure<ManageOption>(_cfg.GetSection("Manage"));
            services.Configure<ClusterOption>(_cfg.GetSection("Cluster"));
            #region UEditor

            services.AddSingleton<UEditorOption>();

            #endregion

            services.AddMvc(opt =>
            {
                opt.Filters.Add<ValidateModelAttribute>();
            }).AddJsonOptions(opt =>
            {
                var setts = opt.SerializerSettings;
                setts.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local;
                setts.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                setts.DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ssK";
            });

            services.AddCors(opt =>
            {
                opt.AddPolicy("AllowAny", b => b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());
            });

            if (_env.IsDevelopment())
                services.AddSwaggerService(PlatformServices.Default.Application.ApplicationBasePath);

            //ȷ��������������ȷ�ԣ��ŵ�����ע������������
            if (_env.IsDevelopment())
            {
                services.AddAutoReview(
                    new DependencyInjectionAssert()
                    {
                        IgnoreTypes = new[]
                        {
                            "Microsoft.AspNetCore.Mvc.Razor.Internal.TagHelperComponentManager",
                            "Microsoft.Extensions.DependencyInjection.IServiceScopeFactory"
                        }
                    }
                );
            }

        }
#if DEBUG_
            var serviceList = services.Dump();
            System.Diagnostics.Debugger.Break();
#endif


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerService();
            }else
            {
                app.UseExceptionHandler(new GlobalExceptionHandlerOptions());
            }
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseStaticFiles();
            app.UseStatusCodePages("text/html", "<div>There is a problem with the page you're visiting, StatusCode: {0}</div>");
        }
    }
}
