module Exercise5_6

type MessageType = GET_ALL = 0 | GET_FOR_NAME = 1 | INSERT_NEW = 2
type Message = {messageType:MessageType; payload:string list}
type DirEntry = {name:string; phone:string}
    
type PhoneDir (printFunction:((DirEntry list) -> unit)) =
    let messageQueue = MailboxProcessor.Start (fun inbox ->
        let rec receiveLoop (phoneList:DirEntry list) = async{
            let! nextMessage = inbox.Receive ()
            match nextMessage with
                | {messageType=t; payload=_} when t = MessageType.GET_ALL -> 
                    printFunction phoneList
                    return! receiveLoop phoneList
                | {messageType=t; payload=p} when t = MessageType.GET_FOR_NAME ->
                    printFunction (phoneList |> List.filter (fun x -> x.name = (List.item 0 p)))
                    return! receiveLoop phoneList
                | {messageType=t; payload=p} when t = MessageType.INSERT_NEW ->
                    let newEntry = {name=(List.item 0 p); phone=(List.item 1 p)}
                    return! receiveLoop (newEntry :: phoneList)
                | _ -> 
                    return! receiveLoop phoneList
            }

        receiveLoop [{name="Adam"; phone="4711"}; {name="Eva"; phone="4712"}]
        )

    member this.add entry =
        messageQueue.Post {messageType=MessageType.INSERT_NEW; payload=[entry.name; entry.phone]}

    member this.get name =
        messageQueue.Post {messageType=MessageType.GET_FOR_NAME; payload=[name]}

    member this.getAll () = 
        messageQueue.Post {messageType=MessageType.GET_ALL; payload=[]}

type Terminal () =
    let printFunction entries = 
        entries |> List.iter (fun x -> printf "%s %s\n" x.name x.phone)
    let directory:PhoneDir = new PhoneDir(printFunction)
    member this.printAll = directory.getAll
    member this.lookAt = directory.get
    member this.addEntry = directory.add

let exercise7 () =
    let terminal = new Terminal ()
    terminal.lookAt "Adam"
    terminal.lookAt "Erna"
    terminal.addEntry {name="Erna"; phone="4715"}
    terminal.lookAt "Erna"