module Parameteruebergabe

type ListItem = {nr:int; name:string}

let basicMethod parm1 parm2 =
    printf "%d) %s\n" parm1 parm2

let basicMethodWithPrefix prefix parm1 parm2 = 
    printf prefix
    basicMethod parm1 parm2

let displayList list displayFunction =
    list |> List.iter (fun item -> displayFunction item.nr item.name)

let demo () =
    let listItems = [{nr=1; name="Option one"}; {nr=2; name="Option two"}; {nr=3; name="Option three"}]
    displayList listItems basicMethod

    let fancyDisplayFunction = basicMethodWithPrefix ">> "
    displayList listItems fancyDisplayFunction