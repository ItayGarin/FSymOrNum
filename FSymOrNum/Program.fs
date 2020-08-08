open System.IO
open Glob
open FreqGetter
open Print

let help () =
    printf "%s: <base-dir> <glob-pattern>" "FSymOrNum"

let mainImpl dir pattern =
    getGlobFiles dir pattern
    |> printStrings
    |> getFilesFreq
    |> prettyPrintSeq 
    |> ignore

[<EntryPoint>]
let main argv =
    if argv.Length > 1 then
        let dir, pattern = argv.[0], argv.[1]
        mainImpl dir pattern
    else
        help ()

    0 // return an integer exit code
