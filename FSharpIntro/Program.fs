// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

let rec selectAction () =
    System.Console.Clear ()
    printf "**********************\n"
    printf "* F# Demos           *\n"
    printf "**********************\n"
    printf "1) Agentenprogrammierung\n"
    printf "2) Parameteruebergabe\n"
    printf "q) Abbrechen\n"
    printf "Auswahl: "
    let input = System.Console.ReadLine ()
    match input with
        | "1" -> Option.Some Agentenprogrammierung.demo
        | "2" -> Option.Some Parameteruebergabe.demo
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
