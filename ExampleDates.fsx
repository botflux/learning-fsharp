type DateScale = Hour | Hours | Day | Days | Week | Weeks
type DateDirection = Ago | Hence

let getDate interval scale direction =
    let absHours = match scale with
        | Hour | Hours -> 1 * interval
        | Day | Days -> 24 * interval
        | Week | Weeks -> 24 * 7 * interval
    let signedHours = match direction with
        | Ago -> -1 * absHours
        | Hence -> absHours
    System.DateTime.Now.AddHours(float signedHours)

let example1 = getDate 5 Days Ago
let example2 = getDate 1 Hour Hence

printfn "example1 = %s" (example1.ToString())
printfn "example2 = %s" (example2.ToString())