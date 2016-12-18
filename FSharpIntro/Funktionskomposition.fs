module Funktionskomposition

// define Method "Square(x)"
let square x = x*x
// define Method "inc(x)"
let inc x = x+1

// define Method "sqareAndInc(x)" by Concatinating "square" and "inc"
//      Operator |> Verkettet den Output von "square(x)" als Input von "inc" 
let squareAndInc x = square x |> inc


// Demoausgabe
let demo () = 
    printfn "----------------------------------------------------------------"
    printfn "Funktionskomposition.demo"
    let fiveSquareAndThenInc = squareAndInc 5 
    printfn "squareAndInc x = square x |> inc"
    printfn "x = %A" fiveSquareAndThenInc