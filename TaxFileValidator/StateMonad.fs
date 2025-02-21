module internal StateMonad

    open Types
    type Error =
        | ParseError of string
        | UnexpectedRecordError of string

    type State = {
        state: Map<TaxRecord, record_data>
        prevRecord: TaxRecord
    }

    type SM<'a> = S of (State -> Result<'a * State, Error>)

    let mkState lst r =
        { 
            state = Map.ofList lst
            prevRecord = r
        }


    let evalSM (s : State) (S a : SM<'a>) : Result<'a, Error> =
        match a s with
        | Ok (result, _) -> Ok result
        | Error error -> Error error

    let bind (f : 'a -> SM<'b>) (S a : SM<'a>) : SM<'b> =
        S (fun s ->
              match a s with
              | Ok (b, s') -> 
                match f b with 
                | S g -> g s'
              | Error err     -> Error err)

    let ret (v : 'a) : SM<'a> = S (fun s -> Ok (v, s))
    let fail err     : SM<'a> = S (fun s -> Error err)

    let (>>=)  x f = bind f x
    let (>>>=) x f = x >>= (fun () -> f)



