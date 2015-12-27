open System.IO
open System.Text.RegularExpressions

let input = __SOURCE_DIRECTORY__ + "\Day12-Input.txt" |>
            File.ReadAllLines |>
            String.concat("")

Regex.Matches(input, "\-?[0-9]+") |>
Seq.cast<Match> |>
Seq.sumBy (fun m -> int m.Value)