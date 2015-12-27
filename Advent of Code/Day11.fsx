let input = "hepxcrrq"

let incPW (pw:string) =
    let rec incArr (i:int) (c:array<char>) =
        let nextChar = c.[i] + char 1
        c.[i] <- match nextChar with
                    | '{' -> 'a'
                    | _ -> nextChar

        match c.[i] with
        | 'a' -> incArr (i+1) c
        | _ -> c

    pw.ToCharArray() |>
    Array.rev |>
    incArr 0 |>
    Array.rev |>
    Array.map string |>
    String.concat ""

let testRules (pw:string) =
    let testRule1 (pw:string) =
        pw.ToCharArray() |>
        Array.windowed 3 |>
        Array.exists (function
                        | [|a; b; c|] when (a + char 1 = b) && (b + char 1 = c) -> true
                        | _ -> false)

    let testRule2 (pw:string) =
        pw |>
        String.exists (function
                        | 'i' | 'o' | 'l' -> true
                        | _ -> false) |>
        not

    let testRule3 (pw:string) =
        pw.ToCharArray() |>
        Array.pairwise |>
        Array.filter (function
                        | (a, b) when (a = b) -> true
                        | _ -> false) |>
        Array.distinct |>
        Array.length >= 2

    testRule1 pw &&
    testRule2 pw &&
    testRule3 pw

let rec newPassword (pw:string) =
    let newpw = incPW pw
    match testRules newpw with
    | true -> newpw
    | false -> newPassword newpw

let part1 = newPassword input

let part2 = newPassword part1