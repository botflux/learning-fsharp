let getFileInfo filePath =
    let fi = System.IO.FileInfo(filePath)
    if fi.Exists then Some(fi) else None
    
let goodFile = "good.txt"
let badFile = "bad.txt"

let goodFileInfo = getFileInfo goodFile
let badFileInfo = getFileInfo badFile

let printFileFullName (fileInfo: Option<System.IO.FileInfo>) =
    match fileInfo with
    | Some fileInfo -> printfn "The file %s exists" fileInfo.FullName
    | None -> printfn "The file doesn't exist"
    
printFileFullName goodFileInfo
printFileFullName badFileInfo