# F# Making Rest Calls


A simple F# app to call a rest service.

In this sample we call a rest web service to the location of the international space station.   

We will use the HttpClient to call the rest service async

     let getISSLocation =
        async {
             let url = "http://api.open-notify.org/iss-now.json"
             use httpClient = new System.Net.Http.HttpClient()
             let! location = 
             getAsync httpClient url
             let data = Json.deserialize<ISSLocation> location
             printfn "Returned Locatiom: %s" location
       }

    let getAsync (client:HttpClient) (url:string) = 
        async {
              let! response = client.GetStringAsync(url) |> Async.AwaitTask
              return response
        }




To make an async call you need the async block.  The let! tells it to wait until the result is returned.

I use the NuGet Package FSharp.JSON to deserialize the data into this class

    [<CLIMutable>]
    type location =
        {
            longitude : string
            latitude : string
        }

    [<CLIMutable>]
    type ISSLocation =
        {
            timestamp : int
            message : string
           iss_position : location
        }
