let square x = x * x
let add x y = x + y
let add2 x = add x 2

let squareAndAdd2 = square >> add2

printfn "Square and add 2 for 4 = %i" (squareAndAdd2 4) 

printfn "Square of 2 is %i" (square 2)

let rec fact x =
    match x with
    | 0 -> 1
    | _ -> x * (fact (x - 1))

printfn "Fact of 3 is %i" (fact 3)
printfn "Fact of 7 is %i" (fact 7)



#quit