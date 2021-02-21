// Learn more about F# at http://fsharp.org

open System
open System.Net.Http
open FSharp.Json
open ISS_Location

 let getAsync (client:HttpClient) (url:string) = 
      async {
            let! response = client.GetStringAsync(url) |> Async.AwaitTask
            return response
       }

 let getISSLocation =
     async {
         let url = "http://api.open-notify.org/iss-now.json"
         use httpClient = new System.Net.Http.HttpClient()
         let! location = 
             getAsync httpClient url
         let data = Json.deserialize<ISSLocation> location
         printfn "Returned Locatiom: %s" location
      }


[<EntryPoint>]
let main argv =
    getISSLocation
    |> Async.RunSynchronously
    0

