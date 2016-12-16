module FunktionaleProgrammierung

//definiere den Operator "mul"
let mul x y = x*y
//Methode DoMath, welche zwei Zahlen und einen Operator entgegennimmt
let doMath x y op = op y x

let demo () =     
    printfn "----------------------------------------------------------------"
    printfn "FunktionaleProgrammierung.demo"
    printfn "let mul x y = x*y"
    printfn "let doMath x y op = op y x"
    printfn "let result = doMath 5 6 mul"
    // rufe die Methide DoMath für die Berechnung von (5 * 6) auf
    let result = doMath 5 6 mul
    printfn "result = %A" result
    