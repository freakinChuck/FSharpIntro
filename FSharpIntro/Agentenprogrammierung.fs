module Agentenprogrammierung

open System
open System.Threading

type ChatMessage = { sender:string; text:string }

//Der Chatroom stellt einen Agenten dar, welcher auf eingehende Nachrichten reagiert.
//Konkret schreibt er den Absender und den Inhalt der Nachrichten auf die Konsole als
//eine Art Chatlog.
type Chatroom () =

    //Der Variable "chat" wird ein MailboxProcessor zugewiesen, eine von F# zur 
    //Verfügung gestellter Agent für Nachrichtenaustausch (Messaging). Durch den Aufruf 
    //der statischen "Start"-Funktion wird eine neue MailboxProcessor-Instanz erzeugt.
    //Dieser Funktion muss eine asynchrone Methode mitgegeben werden, welche die
    //Inbox entgegennimmt und eingehende Nachrichten verarbeitet.
    let chat = MailboxProcessor.Start (fun inbox -> 

        //Damit nicht nur die erste, sondern alle Nachrichten, empfangen werden, wird
        //das Verhalten in eine rekursive Funktion gepackt. Der Rückgabetyp ist dabei
        //eine asynchrone Funktion, wie von der MailboxProcessor.Start-Funktion
        //verlangt.
        let rec receiveLoop () = async{
            let! message = inbox.Receive () //Warten, bis eine Nachricht ankommt
            printf "[%s] %s\n" message.sender message.text  //Nachricht auf Konsole schreiben
            return! receiveLoop ()  //Unendliche Rekursion für Loop
            }

        receiveLoop()   //Loop starten
    )

    //Public interface des Typs Chatroom
    member this.post message = chat.Post message

//Der MessengerClient speichert einen Benutzernamen und kreiert die Nachrichten, die
//an den Chat gepostet werden sollen.
type MessengerClient (username, chatroom:Chatroom) = 
    member this.post message =
        chatroom.post {sender=username; text=message}

//Hilfsvariable für Zeitverzögerung, hat nichts mit Agentenprogrammierung zu tun.
let randomGenerator = new Random ()    

//Hilfsfunktion, um einen Thred für eine zufällige Zeit zwischen 100 und 3000
//Millisekunden schlafenzulegen, hat nichts mit Agentenprogrammierung zu tun.
let randomSleep () =
    Thread.Sleep (randomGenerator.Next(100, 500)) 

//Hilfsfunktion, um eine Funktion in zufälligen Abständen n mal asynchron
//aufzurufen, hat nichts mit Agentenprogrammierung zu tun.
let doRandomly task n =
     async{
        [0..n] |> List.iter (fun i -> 
            task ()
            randomSleep ()
            )
        }

//Demo-Funktion, die einen Chatroom mit zwei Teilnehmern aufbaut und die beiden
//Clients in zufälligen Abständen immer wieder Nachrichten an den Chat schicken lässt.
let demo () = 
    let chatroom = Chatroom ()
    let client1 = MessengerClient (username="Hans", chatroom=chatroom)
    let client2 = MessengerClient (username="Fritz", chatroom=chatroom)
    let client1Actions = doRandomly (fun () -> client1.post "Ich bin Hans") 10
    let client2Actions = doRandomly (fun () -> client2.post "Halt's Maul!") 10
    [client1Actions;client2Actions] |> Async.Parallel |> Async.RunSynchronously |> ignore