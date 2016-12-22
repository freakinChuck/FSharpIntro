module Exercises3_4

let rec listFilter predicate list =
    match list with
        | [] -> []
        | head :: rest when predicate head -> head :: (listFilter predicate rest)
        | _ :: rest -> listFilter predicate rest

let exercise7 () =
    let isMultipleOf nr testSubject =
        testSubject % nr = 0

    printf "%s" ([0..100] |> listFilter (isMultipleOf 3) |> List.fold (fun state item -> state + (item.ToString ()) + "\n") "")