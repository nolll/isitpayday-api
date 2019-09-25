using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Web.Settings;

namespace Web.Bootstrapping
{
    public class ServiceConfig
    {
        private readonly AppSettings _settings;
        private readonly IServiceCollection _services;

        public ServiceConfig(AppSettings settings, IServiceCollection services)
        {
            _settings = settings;
            _services = services;
        }

        public void Configure()
        {
            AddCompression();
            AddLogging();
            AddDependencies();
            AddMvc();
            AddCors();
        }

        private void AddCompression()
        {
            _services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<GzipCompressionProvider>();
            });
        }

        private void AddLogging()
        {
            _services.AddLogging(logging =>
            {
                if (_settings.Logging.Loggers.Debug)
                    logging.AddDebug();

                if (_settings.Logging.Loggers.Console)
                    logging.AddConsole();

                logging.SetMinimumLevel(_settings.Logging.LogLevel);
            });
        }

        private void AddDependencies()
        {
            _services.AddSingleton(_settings);
            //_services.AddSingleton(new UrlProvider(_settings.Urls.Api, _settings.Urls.Site));

            //_services.AddSingleton<IAuthorizationHandler, CustomAuthorizationHandler>();
            //_services.AddSingleton<ICacheProvider, MemoryCacheProvider>();
            //_services.AddSingleton<ICacheContainer, CacheContainer>();
            //_services.AddSingleton<SqlServerStorageProvider>();
            //_services.AddSingleton<IUserRepository, UserRepository>();
            //_services.AddSingleton<IAppRepository, AppRepository>();
            //_services.AddSingleton<IBunchRepository, BunchRepository>();
            //_services.AddSingleton<ICashgameRepository, CashgameRepository>();
            //_services.AddSingleton<IEventRepository, EventRepository>();
            //_services.AddSingleton<ILocationRepository, LocationRepository>();
            //_services.AddSingleton<IPlayerRepository, PlayerRepository>();
            //_services.AddSingleton(GetEmailSender());
            //_services.AddSingleton(new SqlServerStorageProvider(_settings.Sql.ConnectionString));
            //_services.AddSingleton<IRandomizer, Randomizer>();

            //// Admin
            //_services.AddSingleton<ClearCache>();
            //_services.AddSingleton<TestEmail>();
            //_services.AddSingleton<EnsureAdmin>();

            //// Auth
            //_services.AddSingleton<Login>();

            //// User
            //_services.AddSingleton<UserDetails>();
            //_services.AddSingleton<UserList>();
            //_services.AddSingleton<EditUser>();
            //_services.AddSingleton<AddUser>();

            //// Bunch
            //_services.AddSingleton<GetBunchList>();
            //_services.AddSingleton<GetBunch>();
            //_services.AddSingleton<AddBunch>();
            //_services.AddSingleton<EditBunch>();

            //// Events
            //_services.AddSingleton<EventDetails>();
            //_services.AddSingleton<EventList>();
            //_services.AddSingleton<AddEvent>();

            //// Locations
            //_services.AddSingleton<GetLocationList>();
            //_services.AddSingleton<GetLocation>();
            //_services.AddSingleton<AddLocation>();

            //// Cashgame
            //_services.AddSingleton<CashgameList>();
            //_services.AddSingleton<CashgameYearList>();
            //_services.AddSingleton<EventCashgameList>();
            //_services.AddSingleton<PlayerCashgameList>();
            //_services.AddSingleton<CurrentCashgames>();
            //_services.AddSingleton<CashgameDetails>();
            //_services.AddSingleton<Buyin>();
            //_services.AddSingleton<Report>();
            //_services.AddSingleton<Cashout>();
            //_services.AddSingleton<AddCashgame>();
            //_services.AddSingleton<EditCashgame>();
            //_services.AddSingleton<DeleteCashgame>();
            //_services.AddSingleton<EditCheckpoint>();
            //_services.AddSingleton<DeleteCheckpoint>();

            //// Player
            //_services.AddSingleton<GetPlayer>();
            //_services.AddSingleton<GetPlayerList>();
            //_services.AddSingleton<AddPlayer>();
            //_services.AddSingleton<DeletePlayer>();
            //_services.AddSingleton<InvitePlayer>();
            //_services.AddSingleton<JoinBunch>();

            //// Apps
            //_services.AddSingleton<VerifyAppKey>();
            //_services.AddSingleton<GetApp>();
            //_services.AddSingleton<AppList>();
            //_services.AddSingleton<AddApp>();
            //_services.AddSingleton<DeleteApp>();
        }

        private void AddMvc()
        {
            _services.AddMvc();
        }

        private void AddCors()
        {
            _services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });
        }
    }
}