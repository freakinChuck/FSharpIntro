module Parameteruebergabe

type ListItem = {nr:int; name:string}

//Dies ist eine einfache Methode, die zwei Parameter entgegennimmt und die Werte auf die
//Konsole schreibt. Die Parametertypen werden dabei aufgrund der Verwendung hergeleitet.
let basicMethod parm1 parm2 =
    printf "%d) %s\n" parm1 parm2

//Um die Ausgabe der basicMethod zu verzieren, nimmt diese Methode einen Prefix
//entgegen, der ausgegeben wird, bevor die basicMethod aufgerufen wird. Da der
//Parametertyp nicht explizit definiert ist, kann er jeden Wert annehmen, welcher der
//printf-Methode übergeben werden kann.
//Die anderen beiden Parameter werden unverändert der basicMethode übergeben.
let basicMethodWithPrefix prefix parm1 parm2 = 
    printf prefix
    basicMethod parm1 parm2

//displayList ist eine "Higher Order Function", die als zweiten Parameter eine
//Funktion entgegennimmt. Auch hier muss nicht explizit defininert werden, dass nur
//Funktionen übergeben werden dürfen, denn dies, inkl. der genauen Signatur gültiger
//Methoden, geht bereits aus der Verwendung im Funktions-Body hervor.
//Die displayList-Funktion gibt alle Elemente einer ListItem-Liste per mitgegebener
//displayFunction aus.
let displayList list displayFunction =
    list |> List.iter (fun item -> displayFunction item.nr item.name)

//Demo-Funktion, die Listenelemente auf zwei Arten auf der Konsole ausgibt.
let demo () =
    let listItems = [{nr=1; name="Option one"}; {nr=2; name="Option two"}; {nr=3; name="Option three"}]
    displayList listItems basicMethod

    //Hier wird die Signatur der basicMethodWithPrefix verändert, indem ein Parameter
    //fix gebunden wird.
    let fancyDisplayFunction = basicMethodWithPrefix ">> "
    displayList listItems fancyDisplayFunction