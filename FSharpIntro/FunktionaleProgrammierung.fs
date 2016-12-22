module FunktionaleProgrammierung

let mul x y = x*y

let doMath x y op = op y x
 
let demoFirstClassCitizen () =     
    printfn "----------------------------------------------------------------"
    printfn "FunktionaleProgrammierung.demoFCC"
    printfn "let mul x y = x*y"
    printfn "let doMath x y op = op y x"
    printfn "let result = doMath 5 6 mul"

    let result = doMath 5 6 mul
    printfn "result = %A" result

let aufgabe2Woche8 array = 
    printfn "----------------------------------------------------------------"
    printfn "FunktionaleProgrammierung.aufgabe2Woche8"
    array 
        |> Seq.toList
        |> Seq.iter
            (
                fun number -> 
                    printf "%A: " number
                    printfn "%A" (number*number)
            )
            
let demo () = 
    printfn "FunktionaleProgrammierung.demo"
    let sum = 
        [1..4] 
        |> Seq.filter(fun x -> x < 4) 
        |> Seq.sum

    printfn "let sum = [1..4] |> Seq.filter(fun x -> x < 4) |> Seq.sum"

    printfn "sum = %A" sum
    demoFirstClassCitizen ()
    aufgabe2Woche8 [1..5]


    