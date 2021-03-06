using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SportDash.Data;
using SportDash.Models;
using SportDash.Repository;
using SportDash.Hubs;
using System;
using System.Threading.Tasks;

namespace SportDash
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
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepoitory>();            
            services.AddScoped<IGymPricesRepository, GymPricesRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPlaygroundReservationRepository, PlaygroundReservationRepository>();
            services.AddScoped<IPlaygroundPriceRepository, PlaygroundPriceRepository>();
            services.AddScoped<IConnectedUsersRepository, ConnectedUsersRepository>();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddControllersWithViews()
                    .AddNewtonsoftJson(options =>
                        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    );


            services.AddAuthorization(options =>
            {
                options.AddPolicy("ClubPolicy", policy => { policy.RequireRole("Club"); });
                options.AddPolicy("PlaygroundPolicy", policy => { policy.RequireRole("Playground"); });
                options.AddPolicy("GymPolicy", policy => { policy.RequireRole("Gym"); });
                options.AddPolicy("CoachPolicy", policy => { policy.RequireRole("Coach"); });
                options.AddPolicy("UserPolicy", policy => { policy.RequireRole("User"); });
            });

            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseStatusCodePagesWithRedirects("/Error/Index/{0}");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
                endpoints.MapHub<ChatHub>("/chathub");
            });
        }
    }
}
