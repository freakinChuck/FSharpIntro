module FunktionaleProgrammierung

let mul x y = x*y
let doMath x y op = op y x

let demo () =     
    printfn "----------------------------------------------------------------"
    printfn "FunktionaleProgrammierung.demo"
    printfn "let mul x y = x*y"
    printfn "let doMath x y op = op y x"
    printfn "let result = doMath 5 6 mul"
    let result = doMath 5 6 mul
    printfn "result = %A" result
    