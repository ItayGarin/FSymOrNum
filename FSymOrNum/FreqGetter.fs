namespace FSymOrNum

module FreqGetter =

    let incMapEntry map key =
        let currVal = Map.tryFind key map
        let nextVal =
            match currVal with
            | Some v -> v + 1
            | None -> 1
        Map.add key nextVal map

    let getFreq seq =
        seq
        |> Seq.fold incMapEntry Map.empty