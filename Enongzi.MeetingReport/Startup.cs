using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enongzi.MeetingReport.Data;
using Enongzi.MeetingReport.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Enongzi.MeetingReport
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
            services.AddDbContext<MeetingDbContext>(options=>
            {
                options.UseSqlServer(Configuration.GetConnectionString("MssqlConn"));
            });
            services.AddIdentity<Manager, ManagerRole>()
                .AddEntityFrameworkStores<MeetingDbContext>()
                .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options=> {

            });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            InitDatabase(app);
        }

        public void InitDatabase(IApplicationBuilder app)
        {
            using(var scope = app.ApplicationServices.CreateScope())
            {
                var meetingContext = scope.ServiceProvider.GetRequiredService<MeetingDbContext>();

                if (!meetingContext.Meetings.Any())
                {
                    meetingContext.Meetings.Add(new Models.Meeting
                    {
                        Name = "2018马铃薯会",
                        Summary = "2018马铃薯会",

                    });
                    meetingContext.SaveChanges();
                }
                
            }
        }
    }
}
