let input = "3113322113"

let lookAndSay (input:string) =
    input |>
    Seq.fold(fun acc num -> match acc with
                            | (n, x)::tail when x = num -> (n+1, x)::tail
                            | _ -> (1, num)::acc) [] |>
    List.rev |>
    Seq.collect(fun (count, number) -> sprintf "%d%c" count number) |>
    Seq.map (string) |>
    String.concat ""

let fortytimes = [1..40] |>
                    Seq.fold (fun acc _ -> lookAndSay acc) input |>
                    String.length

let fiftytimes = [1..50] |>
                    Seq.fold (fun acc _ -> lookAndSay acc) input |>
                    String.length