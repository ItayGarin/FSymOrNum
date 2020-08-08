module Glob
open Microsoft.Extensions.FileSystemGlobbing

let getGlobFiles dir pattern = 
    let matcher = Matcher()
    matcher.AddInclude(pattern) |> ignore 
    MatcherExtensions.GetResultsInFullPath(matcher, dir)
    |> Seq.cast