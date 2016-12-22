module Agentenprogrammierung

open System
open System.Threading

type ChatMessage = { sender:string; text:string }

type Chatroom () =
    let chat = MailboxProcessor.Start (fun inbox -> 
        let rec receiveLoop () = async{
            let! message = inbox.Receive ()
            printf "[%s] %s\n" message.sender message.text
            return! receiveLoop ()
            }

        receiveLoop()
    )

    member this.post message = chat.Post message

type MessengerClient (username, chatroom:Chatroom) = 
    member this.post message =
        chatroom.post {sender=username; text=message}

let randomGenerator = new Random ()    

let randomSleep () =
    Thread.Sleep (randomGenerator.Next(100, 500)) 

let doRandomly task n =
     async{
        [0..n] |> List.iter (fun i -> 
            task ()
            randomSleep ()
            )
        }

let demo () = 
    let chatroom = Chatroom ()
    let client1 = MessengerClient (username="Hans", chatroom=chatroom)
    let client2 = MessengerClient (username="Fritz", chatroom=chatroom)
    let client1Actions = doRandomly (fun () -> client1.post "Ich bin Hans") 10
    let client2Actions = doRandomly (fun () -> client2.post "Halt's Maul!") 10
    [client1Actions;client2Actions] |> Async.Parallel |> Async.RunSynchronously |> ignore