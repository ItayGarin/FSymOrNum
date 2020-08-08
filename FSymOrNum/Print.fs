module Print

let prettyPrint a =
    printf "%A" a
    a

let printSeq f seq =
    Seq.iter f seq
    seq

let printStrings strings =
    printSeq (printfn "%s") strings

let prettyPrintSeq seq =
    printSeq (printfn "%A") seq
