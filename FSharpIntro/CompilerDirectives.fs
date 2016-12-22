module CompilerDirectives

#if DEBUG
let doFunction action actionName =
    action ()
    printf "'%s' completed.\n" actionName
#else
let doFunction action actionName =
    action ()
#endif

#if INTERACTIVE
    printf "You are in scripting mode"
#else
    printf "You are in non scripting mode"
#endif

let demo () =
    doFunction (fun () -> printf "Doing something...\n") "Some function"