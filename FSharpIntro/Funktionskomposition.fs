module Funktionskomposition

let square x = x*x

let inc x = x+1

let squareAndInc x = square x |> inc

let demo () = 
    printfn "----------------------------------------------------------------"
    printfn "Funktionskomposition.demo"
    let fiveSquareAndThenInc = squareAndInc 5 
    printfn "squareAndInc x = square x |> inc"
    printfn "x = %A" fiveSquareAndThenInc