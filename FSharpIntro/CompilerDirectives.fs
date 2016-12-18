module CompilerDirectives

//Die wichtigste Compiler-Direktive ist das if-Statement. Dieses kann auf definierte Compile-Konstanten reagieren.
//Im Nachfolgenden wird die Funktion "doFunction" auf zwei unterschiedliche Arten definiert. Falls 
#if DEBUG
//Die folgende Funktionsdefinition wird nur dann in den Build aufgenommen, falls die Konstante "DEBUG" auf true 
//gesetzt ist. Sinnigerweise wird dies gemacht, wenn ein Debug-Build erstellt wird.
let doFunction action actionName =
    action ()
    printf "'%s' completed.\n" actionName
#else
//Die alternative Definition wird hingegen nur dann inkludiert, wenn "DEBUG" nicht auf true gesetzt ist.
let doFunction action actionName =
    action ()
#endif

//Die INTERACTIVE Varible ist auf true gesetzt, wenn der Code als Script ausgeführt wird (just in time kompiliert).
#if INTERACTIVE
    printf "You are in scripting mode"
#else
    printf "You are in non scripting mode"
#endif

let demo () =
    doFunction (fun () -> printf "Doing something...\n") "Some function"