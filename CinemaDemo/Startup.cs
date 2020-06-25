using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SqlSugar;

namespace CinemaDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSingleton<SqlSugarClient>(new SqlSugarClient(new ConnectionConfig() {
                ConnectionString = Configuration.GetConnectionString("DefaultConnection"),
                DbType = DbType.MySql,//�������ݿ�����
                IsAutoCloseConnection = true,//�Զ��ͷ������������������������������ͷ�
                InitKeyType = InitKeyType.SystemTable    //Ĭ��SystemTable, �ֶ���Ϣ��ȡ, �磺�������ǲ����������ǲ��Ǳ�ʶ�еȵ���Ϣ
        }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Cinema}/{action=Index}/{id?}");
            });
        }
    }
}
