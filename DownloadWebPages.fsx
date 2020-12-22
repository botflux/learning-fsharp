open System.Net
open System
open System.IO
open Microsoft.FSharp.Control.CommonExtensions

let fetchUrl url =
    async {
        let request = WebRequest.Create(Uri(url))
        use! response = request.AsyncGetResponse()
        use stream = response.GetResponseStream()
        use reader = new StreamReader(stream)
        let html = reader.ReadToEnd()
        printfn "finished downloading %s" url
    }
    
let sites = ["http://www.bing.com";
             "http://www.google.com";
             "http://www.microsoft.com";
             "http://www.amazon.com";
             "http://www.yahoo.com"]

#time
sites
|> List.map fetchUrl
|> Async.Parallel
|> Async.RunSynchronously
#time

let childTask() =
    for i in [1..1000] do
        for i in [1..1000] do
            do "Hello".Contains("H") |> ignore
            
#time
childTask()
#time

let parentTask =
    childTask
    |> List.replicate 20
    |> List.reduce (>>)
    
#time
parentTask()
#time
   