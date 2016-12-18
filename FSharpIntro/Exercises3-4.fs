module Exercises3_4
//Die siebte Aufgabe des Übungsblocks 3-4 zu Scheme verlangte die Erstellung eines eigenen Prädikats,
//welches auf die Teilbarkeit durch einen variablen Wert prüft. Dies kann mit F# ganz ähnlich gelöst werden:

//Die "listFilter"-Funktion fügt nur diejenigen Element einer vorgegebenen Liste der Ausgabe hinzu, welche
//das angegebene Prädikat erfüllen. Die Implementierung ähnelt derjenigen aus Scheme sehr. Allerdings führt
//das Patternmatching zu einem übersichtlicheren und einfacher verständlicheren Code.
let rec listFilter predicate list =
    match list with
        //Fall leere Liste:
        | [] -> []
        //Fall Prädikat erfüllt:
        | head :: rest when predicate head -> head :: (listFilter predicate rest)
        //Fall Prädikat nicht erfüllt:
        | _ :: rest -> listFilter predicate rest

let exercise7 () =
    //Die Funktion "isMultipleOf" stellt das Prädikat zur Prüfung auf Teilbarkeit dar.
    let isMultipleOf nr testSubject =
        testSubject % nr = 0

    //Der "listFilter"-Funktion kann nun das Prädikat mitgegeben werden. Dabei wird lediglich der Erste Parameter (nr)
    //gebunden, was zur Folge hat, dass sich die Signatur der Prädikatsfunktion ändert und somit für den Einsatz in
    //der "listFilter"-Funktion geeignet ist.
    printf "%s" ([0..100] |> listFilter (isMultipleOf 3) |> List.fold (fun state item -> state + (item.ToString ()) + "\n") "")