﻿type MenuItem = { name:string; action:(unit->unit) }

let menuItems = [
        { name="Agentenprogrammierung"; action=Agentenprogrammierung.demo }
        { name="Parameteruebergabe"; action=Parameteruebergabe.demo }
        { name="Compilerdirektiven"; action=CompilerDirectives.demo }
        { name="DotNetInterop (Aufgabe 6 Woche 7)"; action=DotNetInterop.demo }
        { name="Funktionale Programmierung (Aufgabe 2 Woche 8)"; action=FunktionaleProgrammierung.demo }
        { name="Funktionskomposition"; action=Funktionskomposition.demo }
        { name="Aufgabe 3 Woche 5"; action=Aufgaben.woche5Aufgabe3Demo }
        { name="Uebung3-4_7"; action=Exercises3_4.exercise7}
        { name="Uebung3-5_6"; action=Exercise5_6.exercise7}
    ]

let (|Int|_|) string = 
    match System.Int32.TryParse(string) with
        | (true, int) -> Some int
        | _ -> None

let (|InRange|_|) low high integer = 
    match integer with
        | i when i >= low && i <= high -> Some integer
        | _ -> None

let rec selectAction () =
    System.Console.Clear ()
    printf "**********************\n"
    printf "* F# Demos           *\n"
    printf "**********************\n"
    menuItems |> List.fold (fun i item ->
        printf "%d) %s\n" i item.name
        i + 1
        ) 1 |> ignore
    printf "q) Abbrechen\n"
    printf "Auswahl: "
    let input = System.Console.ReadLine ()
    match input with
        | Int i when i > 0 && i <= menuItems.Length -> Option.Some (menuItems.Item (i - 1)).action
        | "q" -> Option.None
        | _ -> selectAction ()

[<EntryPoint>]
let rec main argv = 
    let action = selectAction ()
    System.Console.Clear ()
    match action with
        | Some x -> 
            x ()
            printf "\nFortfahren mit [Enter]"
            System.Console.ReadLine () |> ignore
            main argv |> ignore
        | None -> ()
    0 // return an integer exit code
