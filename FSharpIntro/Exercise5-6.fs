module Exercise5_6

//In der Aufgabe 7 des Aufgabenblocks 5-6 wurde verlangt, mit Scheme ein Telefonverzeichnis zu
//erstellen, von welchem man mittels Methodenaufruf Einträge anhand des Namens anzeigen lassen
//und neue Einträge hinzufügen kann. Um dies zu bewerkstelligen, musste beim Einfügen eines neuen
//Eintrags die Variable, welcher die Liste mit den Einträgen zugewiesen wurde, neu gesetzt werden.
//Dies ist in der funktionalen Programmierung grundsätzlich nicht erwünscht, da es sich hierbei um
//einen Seiteneffekt des Methdoenaufrufs handelt, lässt sich allerdings nicht immer vermeiden.
//Implementiert man dasselbe Beispiel in F#, dann kann dank Agentenprogrammierung auf diese
//Unschönheit verzichtet werden. Wie, zeigt der folgende Code:

//Als erstes werden die benötigten Datentypen erstellt. Beim "MessageType" handelt es sich um einen
//Enum, der die Art der Anfrage an das Telefonverzeichnis spezifiziert.
type MessageType = GET_ALL = 0 | GET_FOR_NAME = 1 | INSERT_NEW = 2
type Message = {messageType:MessageType; payload:string list}
type DirEntry = {name:string; phone:string}
    
//Das Herzstück stellt das Telefonverzeichnis dar. Der Typ "PhoneDir" versteckt im Innern eine
//MessageQueue, um alle Anfragen zu sammeln und asynchron abzuarbeiten. Im Konstruktor wird eine
//Methode übergeben, die ausgeführt wird, um Resultate anzuzeigen. Da der agentenbasierte Ansatz
//voll und ganz auf asynchrone Programmierung setzt, kann kein Ergebnis direkt zurückggegeben
//werden.
type PhoneDir (printFunction:((DirEntry list) -> unit)) =
    let messageQueue = MailboxProcessor.Start (fun inbox ->
        //Innerhalb der Queue wird in einer Endlos-Schleife auf die nächste Nachricht gewartet und
        //diese dann verarbeitet. Dies geschieht asynchron, blockiert den Haupt-Thread also nicht.
        let rec receiveLoop (phoneList:DirEntry list) = async{
            //Mit let! wird die asynchrone Methode "Receive" sofort ausgeführt und es wird auf die
            //Antwort gewartet. Mit let (also ohne !) würde der Variable "nextMessage" lediglich
            //die Methode zur späteren Ausführung übergeben werden.
            let! nextMessage = inbox.Receive ()
            //Durch Patternmatching wird auf die unterschiedlichen Nachrichtentypen reagiert. In
            //jedem Fall wird die Loop-Methode am schluss rekursiv aufgerufen (es handelt sich
            //also genau genommen um eine endlose Rekursion, statt um einen Loop). Falls ein neuer
            //Eintrag hinzugefügt werden soll, wird der Eintrag mit der jetzigen Liste zusammen-
            //gesetzt. Ansonsten wird der alte Zustand unverändert übergeben.
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

    //Die interne Handhabung der Telefonliste durch Messaging wird vom Interface des Typs versteckt.
    member this.add entry =
        messageQueue.Post {messageType=MessageType.INSERT_NEW; payload=[entry.name; entry.phone]}

    member this.get name =
        messageQueue.Post {messageType=MessageType.GET_FOR_NAME; payload=[name]}

    member this.getAll () = 
        messageQueue.Post {messageType=MessageType.GET_ALL; payload=[]}

//Das Terminal ist eine weitere Abstraktion. Sie erzeugt ein neues Telefonverzeichnis und gibt die
//Funktion für die Textausgabe vor.
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