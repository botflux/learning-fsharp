let (|MultOf3|_|) i = if i % 3 = 0 then Some MultOf3 else None
let (|MultOf5|_|) i = if i % 5 = 0 then Some MultOf5 else None

let fizzBuzz i =
    match i with
    | MultOf3 & MultOf5 -> printfn "FizzBuzz, "
    | MultOf3 -> printfn "Fizz, "
    | MultOf5 -> printfn "Buzz, "
    | _ -> printfn "%i," i
    
[1..20] |> List.iter fizzBuzz
