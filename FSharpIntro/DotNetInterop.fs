module DotNetInterop

open CSharpCode

let permutate array = 
    Permutations.Permutate array

let demo () = 
    printfn "----------------------------------------------------------------"
    printfn "DotNetInterop.demo"
    printfn "Permutations.Permutate [ 1 ; 2; 3 ]"
    let tmp = permutate [ 1 ; 2 ; 3 ]
    for item in tmp do
        printfn "%A" item
