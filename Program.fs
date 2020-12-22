// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open System.Net
open System.IO

// Define a function to construct a message to print
let from whom =
    sprintf "from %s" whom

type Person = {First: string; Last: string}
type Temp =
    | DegreesC of float
    | DegreesF of float

type Employee =
    | Worker of Person
    | Manager of Employee list

[<EntryPoint>]
let main (argv: string []): int =
    let minInt = 5
    let myFloat =  3.14
    let myString = "hello"
    let twoToFive = [2;3;4;5]
    let oneToFive = 1 :: twoToFive
    let zeroToFive = [0;1] @ twoToFive
    let square x = x * x
    let result = square 3
    let add x y = x + y
    let result1 = add 2 3
    
    let evens list =
        let isEven x = x % 2 = 0
        List.filter isEven list
    
    let evensNumbers = evens oneToFive
    
    let sumOfSquaresTo100 =
        List.sum (List.map square [0..100])
        
    let sumOfSquaresTo100Piped =
        [1..100] |> List.map square |> List.sum
        
    let sumOfSquresTo100WithFun =
        [1..100] |> List.map(fun x -> x * x) |> List.sum
        
    let simplePatternMatch =
        let x = "a"
        match x with
        | "a" -> printfn "x is a"
        | "b" -> printfn "x is b"
        | _ -> printfn "x is something else"
        
    let validValue = Some(99)
    let invalidValue = None
    
    let optionPatternMatch input =
        match input with
            | Some i -> printfn "input is an int=%d" i
            | None -> printfn "input is missing"
            
    optionPatternMatch validValue
    optionPatternMatch invalidValue
    
    let twoTuple = 1,2
    let threeTuple = "a",2,true
    
    let person1 = {First="John"; Last="Doe"}
    let temp = DegreesF 98.6
    
    let jdoe = {First="John"; Last="Doe"}
    let worker = Worker jdoe
    
    printfn "Printing an int %i, a float %f, a bool %b" 1 2.0 true
    printfn "A string %s, and something generic %A" "hello" [1;2;3;4]
    
    printfn "twoTuple=%A,\nPerson=%A,\nTemp=%A,\nEmployee=%A"
        twoTuple person1 temp worker

    let sumOfSquares n =
        [1..n]
        |> List.map square
        |> List.sum
        
    printfn "The sum of squares from 1 to 20 is %i" (sumOfSquares 20)
        
    let rec quicksort list =
        match list with
        | [] -> []
        | firstElement::otherElements ->
            let smallerElements =
                otherElements
                |> List.filter (fun e -> e < firstElement)
                |> quicksort
            let largerElements =
                otherElements
                |> List.filter(fun e -> e >= firstElement)
                |> quicksort
                
            List.concat [smallerElements; [firstElement]; largerElements]
        
    let rec quicksort2 = function
        | [] -> []
        | first::rest ->
            let smaller,larger = List.partition ((>=) first) rest
            List.concat [quicksort2 smaller; [first]; quicksort2 larger]
        
    printfn "%A" (quicksort [1;5;23;28;9;1;3])
        
    let message = from "F#" // Call the function
    printfn "Hello world %s" message
    
    let fetchUrl callback url =
        let request = WebRequest.Create(Uri(url))
        use response = request.GetResponse()
        use stream = response.GetResponseStream()
        use reader = new IO.StreamReader(stream)
        callback reader url
        
    let myCallBack (reader: IO.StreamReader) url =
        let html = reader.ReadToEnd()
        let html1000 = html.Substring(0, 1000)
        printfn "Downloaded %s. First 1000 is %s" url html1000
        html
        
    let google = fetchUrl myCallBack "http://google.com"
    
    let sites = ["http://www.bing.com"
                 "http://www.google.com"
                 "http://www.yahoo.com"]
    
    let fetchUrl2 = fetchUrl myCallBack
    
    sites |> List.map fetchUrl2
    
    0 // return an integer exit code