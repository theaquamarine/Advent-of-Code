open System.Security.Cryptography

let md5 = MD5.Create()

let secretKey = "bgvyzdsv"

let mutable answer = 0

let hash (answer:int) =
    secretKey + answer.ToString() |>
    System.Text.Encoding.ASCII.GetBytes |>
    md5.ComputeHash |>
    BitConverter.ToString

let testHash (answer:int) =
    if (hash answer:string).StartsWith("00-00-0") then
        true
    else
        false

while not (testHash answer) do
    answer <- answer + 1

answer
