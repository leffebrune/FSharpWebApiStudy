namespace FSharpWebApiStudy

open Couchbase
open Microsoft.Extensions.Options
open FSharpWebApiStudy.Models
open System.IO


module MongoDbContext =
    let connect id password = 
        async {
            let options = new ClusterOptions(UserName = "Administrator", Password = "password")
            let connectionString =  "couchbase://localhost"
            let! t = Cluster.ConnectAsync(connectionString, options) |> Async.AwaitTask

            let! bucket = t.BucketAsync("TestBucket").AsTask() |> Async.AwaitTask
            let! scope = bucket.ScopeAsync("_default").AsTask() |> Async.AwaitTask
            let! collection = scope.CollectionAsync("user").AsTask() |> Async.AwaitTask

            let! tt = t.BucketAsync("TestBucket").AsTask() |> Async.AwaitTask

            let newUser = UserModel("tttaaa")
            newUser.Stamina <- 10
            
            printfn $"{newUser}"

            printfn $"async?"

            collection.UpsertAsync("key111", newUser) |> Async.AwaitTask |> ignore

            return newUser
    }
        

    

