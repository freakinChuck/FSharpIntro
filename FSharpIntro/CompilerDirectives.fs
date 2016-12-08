module CompilerDirectives

#if DEBUG
let doFunction action actionName =
    action ()
    printf "'%s' completed.\n" actionName
#else
let doFunction action actionName =
    action ()
#endif

let demo () =
    doFunction (fun () -> printf "Doing something...\n") "Some function"