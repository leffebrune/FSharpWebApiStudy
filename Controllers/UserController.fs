namespace FSharpWebApiStudy.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open FSharpWebApiStudy
open Newtonsoft.Json;

[<ApiController>]
[<Route("[controller]")>]
type UserController (logger : ILogger<UserController>) =
    inherit ControllerBase()

    [<HttpGet>]
    member _.Get() =
        "1231312"

    [<HttpGet("test")>]
    member _.GetTest() : string =
        let addStr(x : string) : string = x + "3123123123"
        printfn $"running completed"
        MongoDbContext.connect "root" "root" 
            |> Async.RunSynchronously
            |> JsonConvert.SerializeObject
            |> addStr

