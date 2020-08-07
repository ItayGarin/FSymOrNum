open FSymOrNum.FreqGetter

[<EntryPoint>]
let main argv =
    "Hello World from F#!"
    |> getFreq 
    |> printfn "%A"
    0 // return an integer exit code
