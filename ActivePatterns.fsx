let (|Int|_|) str =
    match System.Int32.TryParse(str: string) with
    | (true, int) -> Some(int)
    | _ -> None
    
let (|Bool|_|) str =
    match System.Boolean.TryParse(str: string) with
    | (true, bool) -> Some(bool)
    | _ -> None
    
let testParser str =
    match str with
    | Int i -> printfn "The value is an int '%i'" i
    | Bool b -> printfn "The value is a bool '%b'" b
    | _ -> printfn "The value '%s' is something else" str
    
testParser "12"
testParser "true"
testParser "Hello world"

#quit