module Aufgaben

let diagonaleBerechnen laenge breite = 
    sqrt ((laenge*laenge) + (breite*breite))

let woche5Aufgabe3Demo () = 
    let laenge = 30.0
    let breite = 40.0
    let diagonale = diagonaleBerechnen laenge breite
    printfn "let laenge = %A" laenge
    printfn "let breite = %A" breite
    printfn "let diagonale = diagonaleBerechnen laenge breite"
    printfn "diagonale = %A" diagonale
