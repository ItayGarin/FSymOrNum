module FreqGetter
open System.IO
open FSharpPlus

let private incMapEntry map key =
    let currVal = Map.tryFind key map
    let nextVal =
        match currVal with
        | Some v -> v + 1
        | None -> 1
    Map.add key nextVal map

let getFreq seq =
    seq
    |> Seq.fold incMapEntry Map.empty

let getFileFreq path =
    path
    |> File.ReadAllText
    |> getFreq 

let mergeFreqs maps =
    let folder = Map.unionWith (+) 
    Seq.fold folder Map.empty maps

let getFilesFreq paths =
    paths
    |> Seq.map getFileFreq
    |> mergeFreqs