open System;

type ContactId = {Id:string; Source:string;}
type NotificationId = Guid
type PendingNotification = {ContactId: ContactId
                            Message: string
                            NotificationId: NotificationId;}
type ProcessedNotification = {ContactId: ContactId
                              Message: string
                              NotificationId: NotificationId;}

type Notification =
    | Pending of PendingNotification
    | Processed of ProcessedNotification
    
let createNotification notificationId contactId message =
    Notification.Pending {NotificationId=notificationId
                          ContactId=contactId
                          Message=message;}

let processPendingNotification (notification: PendingNotification) =
    Notification.Processed { NotificationId=notification.NotificationId
                             ContactId=notification.ContactId
                             Message=notification.Message }

let displayNotification notification =
    match notification with
    | Pending state ->
        printfn "'%s' has to be sent to '%s' from '%s'" state.Message state.ContactId.Id state.ContactId.Source
    | Processed state ->
        printfn "'%s' was sent to '%s' from '%s'" state.Message state.ContactId.Id state.ContactId.Source


type PendingNotification with
    member this.Process = processPendingNotification this
    
    
let processNotification notification =
    match notification with
    | Pending state -> state.Process
    | Processed state ->
        printfn "ERROR: The notification is already sent."
        notification
    
type Notification with
    static member Create contactId message =
        let notificationId = NotificationId.NewGuid()
        createNotification notificationId contactId message
        
    member this.Display = displayNotification this
    member this.Process = processNotification this
        
let john = { Id="John"; Source="BoundedContext A" }
let helloWorldToJohn = Notification.Create john "Hello world John"
helloWorldToJohn.Display
let sentHelloWorldToJohn = helloWorldToJohn.Process
sentHelloWorldToJohn.Display