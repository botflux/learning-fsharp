type EmailAddress = EmailAddress of string

let sendEmail (EmailAddress email) =
    printfn "sent an email to %s" email
    
let aliceEmail = EmailAddress "alice@example.com"
sendEmail aliceEmail