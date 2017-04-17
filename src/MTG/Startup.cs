using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MTG.Data;
using MTG.Models;
using MTG.Services;
using Sakura.AspNetCore.Mvc;

namespace MTG
{
	public class Startup
	{
		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

			if (env.IsDevelopment())
			{
				builder.AddUserSecrets<Startup>();
			}

			builder.AddEnvironmentVariables();
			Configuration = builder.Build();
		}

		public IConfigurationRoot Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			services.AddIdentity<ApplicationUser, IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders();

			services.AddMvc(o => o.Conventions.Add(new FeatureConvention()))
				.AddRazorOptions(o =>
				{
					// {0}-Action Name, {1}-Controller Name, {2}-Area Name, {3}-Feature Name
					o.ViewLocationFormats.Clear();
					o.ViewLocationFormats.Add("/Features/{3}/{1}/{0}.cshtml");
					o.ViewLocationFormats.Add("/Features/{3}/{0}.cshtml");
					//options.ViewLocationFormats.Add("/Features/{1}/{0}.csrhtml");
					o.ViewLocationFormats.Add("/Features/Shared/{0}.cshtml");

					o.ViewLocationExpanders.Add(new FeatureViewLocationExpander());
				});

			//Pagination
			services.AddBootstrapPagerGenerator(o => { o.ConfigureDefault(); });
			services.Configure<PagerOptions>(o =>
			{
				o.PagerItemsForEndings = 2;
				o.HideOnSinglePage = true;
				o.ExpandPageItemsForCurrentPage = 3;


				//options.Layout = PagerLayouts.Custom(PagerLayoutElement.GoToFirstPageButton, PagerLayoutElement.Items,  PagerLayoutElement.GoToLastPageButton);
			});

			services.AddTransient<IEmailSender, AuthMessageSender>();
			services.AddTransient<ISmsSender, AuthMessageSender>();


		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
				app.UseBrowserLink();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();

			app.UseIdentity();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=StartUp}/{id?}");
			});
		}
	}
}
