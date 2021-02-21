module ISS_Location


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


