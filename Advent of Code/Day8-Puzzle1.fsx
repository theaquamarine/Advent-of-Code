open System.IO
open System.Text.RegularExpressions

let input = __SOURCE_DIRECTORY__ + "\Day8-Input.txt" |> File.ReadAllLines

let unescape (x:string) =
    let filterSlashes (x:string) =
        x.Replace("\\\\", "?")
        //have to replace with non-backslash character, else string "\\xce"
        //gets reduced as a hex code, apparently incorrectly.

    let filterQuotes (x:string) =
        x.Replace("\\\"", "\"")

    let filterHex (x:string) =
        Regex.Replace(x, @"\\x[0-9a-f]{2}", "?")

    x.Trim('"') |>
    filterSlashes |>
    filterQuotes |>
    filterHex

let escape (x:string) =
    let escapeSlashes (x:string) =
        x.Replace("\\", "\\\\")

    let escapeQuotes (x:string) =
        x.Replace("\"", "\\\"")

    let padString (x:string) =
        "\"" + x + "\""

    x |>
    escapeSlashes |>
    escapeQuotes |>
    padString

let codeCount:int = input |> Array.sumBy Seq.length

let stringCount:int = input |> Array.map unescape |> Array.sumBy Seq.length

let part1 = codeCount - stringCount

let escapedCount = input |> Array.map escape |> Array.sumBy Seq.length

let part2 = escapedCount - codeCount