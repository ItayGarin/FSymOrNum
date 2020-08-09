module FreqGetter

open System.IO
open FSharpPlus
open System.Collections.Generic

// --------------- Immutable getFreq ------------------

let incMapEntry map key =
    let currVal = Map.tryFind key map
    let nextVal =
        match currVal with
        | Some v -> v + 1
        | None -> 1
    Map.add key nextVal map

let getFreq str =
    str
    |> Seq.fold incMapEntry Map.empty

// --------------- Mutable getFreq ------------------

let incMapEntryMut (dict: Dictionary<char, int>) (key: char) =
    let mutable curr = 0
    if dict.TryGetValue(key, &curr) then
        dict.[key] <- curr + 1
    else
        dict.TryAdd(key, 1) |> ignore
    dict

let inline toMap kvps =
    kvps
    |> Seq.map (|KeyValue|)
    |> Map.ofSeq

let getFreqMut str =
    let dict = new Dictionary<char, int>()
    str
    |> Seq.fold incMapEntryMut dict
    |> toMap

// --------------- GetFileFreq(s) ------------------

let getFileFreq path =
    async {
        let! text = File.ReadAllTextAsync path |> Async.AwaitTask
        return getFreqMut text
    }

let mergeFreqs maps =
    let folder = Map.unionWith (+) 
    Seq.fold folder Map.empty maps

let getFilesFreqEx filter paths =
    paths
    |> Seq.map getFileFreq
    |> Async.Parallel
    |> Async.RunSynchronously
    |> mergeFreqs

let getFilesFreq paths =
    getFilesFreqEx id paths