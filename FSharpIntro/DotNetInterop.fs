module DotNetInterop

// Importiere Namespace/Modul "CSharpCode"
open CSharpCode

let permutate array = 
    // call static Method Permutate in Class CSharpCode.Permutations
    Permutations.Permutate array


// Demoausgabe
let demo () = 
    printfn "----------------------------------------------------------------"
    printfn "DotNetInterop.demo"
    printfn "Permutations.Permutate [ 1 ; 2; 3 ]"
    let tmp = permutate [ 1 ; 2 ; 3 ]
    for item in tmp do
        printfn "%A" item
