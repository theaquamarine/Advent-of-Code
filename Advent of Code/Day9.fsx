open System.IO
let input = __SOURCE_DIRECTORY__ + "\Day9-Input.txt" |> File.ReadAllLines

let parseLine (x:string) =
    let x = x.Split([|' '|])
    let a = x.[0]
    let b = x.[2]
    let dist = int x.[4]
    [((a, b), dist); ((b, a), dist)]

let distances = input |> Seq.collect parseLine |> dict

let places = distances.Keys |> Seq.map (fun (a, b) -> a) |> Seq.distinct |> Seq.toList

let routeLength (route:list<string>) : int =
    route |>
    List.pairwise |>
    List.sumBy (fun (a, b) -> distances.[(a, b)])

let rec distribute e = function
  | [] -> [[e]]
  | x::xs' as xs -> (e::xs)::[for xs in distribute e xs' -> x::xs]

let rec permute = function
  | [] -> [[]]
  | e::xs -> List.collect (distribute e) (permute xs)

let shortest = places |> permute |> List.map (fun x -> (x, routeLength x)) |> List.minBy (fun (x, y) -> y)

let longest = places |> permute |> List.map (fun x -> (x, routeLength x)) |> List.maxBy (fun (x, y) -> y)