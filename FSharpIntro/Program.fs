// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

type MenuItem = { name:string; action:(unit->unit) }

let menuItems = [
        { name="Agentenprogrammierung"; action=Agentenprogrammierung.demo }
        { name="Parameteruebergabe"; action=Parameteruebergabe.demo }
        { name="Compilerdirektiven"; action=CompilerDirectives.demo }
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
