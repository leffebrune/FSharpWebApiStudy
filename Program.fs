namespace FSharpWebApiStudy
#nowarn "20"
open System
open System.Collections.Generic
open System.IO
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.HttpsPolicy
open Microsoft.AspNetCore.StaticFiles
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging
open Microsoft.Extensions.FileProviders


module Program =
    let exitCode = 0

    [<EntryPoint>]
    let main args =

        let option = new WebApplicationOptions(Args = args, WebRootPath = "public")
        
        let builder = WebApplication.CreateBuilder(option)

        builder.Services.AddControllers()
        builder.Services.AddDirectoryBrowser()

        let app = builder.Build()

        app.UseHttpsRedirection()

        app.UseAuthorization()
        app.MapControllers()

        let fileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.WebRootPath, "controllers"));
        let requestPath = "/controllers";
        app.UseStaticFiles(new StaticFileOptions(
            FileProvider = fileProvider,
            RequestPath = requestPath,
            ServeUnknownFileTypes = true

        ));

        app.UseDirectoryBrowser(new DirectoryBrowserOptions(
            FileProvider = fileProvider,
            RequestPath = requestPath
        ));


        app.Run()

        exitCode
