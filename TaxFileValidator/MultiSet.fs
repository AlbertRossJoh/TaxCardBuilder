module internal MultiSet
    
    open Types
    type MultiSet = Map<TaxRecord, uint> // replace with your type


    type MSError = MSError of string

    type MS<'a> = R of (MultiSet -> Result<'a * MultiSet, MSError>)



    let evalSM (s : MultiSet) (R a : MS<'a>) : Result<'a, MSError> =
        match a s with
        | Ok (result, _) -> Ok result
        | Error error -> Error error

    let bind (f : 'a -> MS<'b>) (R a : MS<'a>) : MS<'b> =
        R (fun s ->
              match a s with
              | Ok (b, s') -> 
                match f b with 
                | R g -> g s'
              | Error err     -> Error err)

    let ret (v : 'a) : MS<'a> = R (fun s -> Ok (v, s))
    let fail err     : MS<'a> = R (fun s -> Error err)

    let (>>=)  x f = bind f x
    let (>>>=) x f = x >>= (fun () -> f)

    let mkMs lst : MultiSet = 
        Map.ofList lst

    let mapMs f = 
        R(fun s -> Ok(f s, s))

    let updateMs f =
        R(fun s -> Ok((), f s))

    let toString =
        mapMs _.ToString()

    let empty : MultiSet=
        Map.empty

    let isEmpty =
        mapMs Map.isEmpty

    let size = 
        mapMs (Map.values >> Seq.sum)

    let contains key =
        mapMs (Map.containsKey key)

    let numItems key =
        contains key >>= fun containsKey ->
        if containsKey then mapMs (Map.find key)
        else ret 0u

    let add key n : MS<unit> =
        contains key >>= fun containsKey ->
        if containsKey then 
            numItems key >>= fun res -> 
            (+) res n |> Map.add key |> updateMs
        else n |> Map.add key |> updateMs

    let addSingle key = add key 1u

    let remove key n =
        contains key >>= fun containsKey ->
        if containsKey then 
            numItems key >>= fun res -> 
            if res <= n then Map.remove key |> updateMs
            else res - n |> Map.add key |> updateMs
        else ret ()

    let removeSingle key = remove key 1u

    let fold f acc = 
        Map.fold f acc |> mapMs

    let foldBack f acc = 
        R (fun s -> Ok(Map.foldBack f s acc, s))

    let ofList (lst: TaxRecord list) = 
        let rec inner lst =
            match lst with
            | [] -> ret ()
            | x::xs -> 
                addSingle x >>>= inner xs
        inner lst 

    let toList = 
        fold (fun acc key value -> 
            acc @ (
                Seq.init (int value) (fun _ -> key) 
                |> Seq.toList)) []

    let map f =
        mapMs f

    //// Cannot use R(s) instead... the compiler gets mad
    //let map (f: 'a->'b) (s : MultiSet<'a>): MultiSet<'b> =
    //    match s with
    //    | R m ->
    //        let rec inner (acc : MultiSet<'b>) (xs: ('a*uint32) list) =
    //            match xs with
    //            | [] -> acc
    //            | x::xs ->
    //                let k, v = x
    //                inner (add (f k) v acc) xs
    //        inner empty (Map.toList m)
    //
    //let union (a : MultiSet<'c>) (b : MultiSet<'c>) : MultiSet<'c> =
    //    let aLst = fold (fun state k v ->
    //        if contains k b then
    //            if numItems k a > numItems k b then
    //                [for _ in 0..(int v)-1 do k] @ state
    //            else
    //                let bItems = numItems k b
    //                [for _ in 0..(int bItems)-1 do k] @ state
    //        else
    //            [for _ in 0..(int v)-1 do k] @ state) [] a
    //    
    //    let bLst = fold (fun state k v ->
    //        if contains k a then
    //            [] @ state
    //        else
    //            [for _ in 0..(int v)-1 do k] @ state) [] b
    //    aLst |> (@) bLst |> ofList
    //    
    //let sum (a : MultiSet<'a>) (b : MultiSet<'a>) : MultiSet<'a> =
    //    (a |> toList) @ (b |> toList) |> ofList
    //
    //let subtract (s1 : MultiSet<'a>) (s2 : MultiSet<'a>) : MultiSet<'a> =
    //    fold (fun state k v ->
    //        if contains k s2 then
    //            if numItems k s2 >= v then
    //                [] @ state
    //            else
    //                let bItems = v-(numItems k s2)
    //                [for _ in 0..(int bItems)-1 do k] @ state
    //        else
    //            [for _ in 0..(int v)-1 do k] @ state) [] s1
    //    |> ofList
    //
    //let intersection (a : MultiSet<'a>) (b : MultiSet<'a>) : MultiSet<'a> =
    //    fold (fun state k v ->
    //        if contains k b then
    //            let bItems = numItems k b
    //            if v <= bItems then
    //                [for _ in 0..(int v)-1 do k] @ state
    //            else
    //                [for _ in 0..(int bItems)-1 do k] @ state
    //        else
    //            [] @ state) [] a
    //    |> ofList
       
    
