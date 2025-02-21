module internal TaxFileValidator

open System.IO
open Microsoft.FSharp.Collections
open Microsoft.FSharp.Core
open Types
open StateMonad


let getRecordType (s: string) =
    match s[7..10] with
    | "1000" -> Ok TaxRecord.Record1000
    | "2001" -> Ok TaxRecord.Record2001
    | "2101" -> Ok TaxRecord.Record2101
    | "2111" -> Ok TaxRecord.Record2111
    | "3101" -> Ok TaxRecord.Record3101
    | "4101" -> Ok TaxRecord.Record4101
    | "5000" -> Ok TaxRecord.Record5000
    | "6000" -> Ok TaxRecord.Record6000
    | "6001" -> Ok TaxRecord.Record6001
    | "6002" -> Ok TaxRecord.Record6002
    | "6003" -> Ok TaxRecord.Record6003
    | "6004" -> Ok TaxRecord.Record6004
    | "6005" -> Ok TaxRecord.Record6005
    | "6102" -> Ok TaxRecord.Record6102
    | "6202" -> Ok TaxRecord.Record6202
    | "6111" -> Ok TaxRecord.Record6111
    | "8001" -> Ok TaxRecord.Record8001
    | "9999" -> Ok TaxRecord.Record9999
    | _ -> Error(ParseError(sprintf $"Record %A{s} of unknown type"))



let parseFile (stream: FileStream) =
    let sreader = new StreamReader(stream)
    let rec reader acc =
        let line = sreader.ReadLine()
        if line = null then Ok(acc)
        else
            getRecordType line
            |> Result.bind (fun x -> reader (x :: acc))
    reader []
    |> Result.map List.rev
    


let tryFind (r: TaxRecord) = 
    S(fun s -> 
        match Map.tryFind r s.state with
        | Some e -> Ok(e, s)
        | None -> 
            sprintf $"Record of type %A{r} was not expected in %A{s.prevRecord}"
            |> UnexpectedRecordError
            |> Error)

let add (r: TaxRecord) =
    tryFind r >>= (fun s -> s.)

let checkOccurrences (data: State) (r: TaxRecord) (c: Cardinality) =
    let current_count =
        ({ occurrences = 0 }, Map.tryFind r data)
        ||> Option.defaultValue
    Map.add r {current_count with occurrences = current_count.occurrences+1 } data,
    match c with
    | One ->
        if current_count.occurrences = 1 then
            Some("Expected record cardinality of exactly one")
        else
            None
    | OneOrMore -> failwith "todo"
    | ZeroOrOne -> failwith "todo"
    | AnyAmount -> failwith "todo"
    | ZeroToThree -> failwith "todo"

let validate (records: TaxRecord list) =
    let checkOccurrences (data: State) (r: TaxRecord) (c: Cardinality) =
        let current_count =
            ({ occurrences = 0 }, Map.tryFind r data)
            ||> Option.defaultValue
        Map.add r {current_count with occurrences = current_count.occurrences+1 } data,
        match c with
        | One ->
            if current_count.occurrences = 1 then
                Some("Expected record cardinality of exactly one")
            else
                None
        | OneOrMore -> failwith "todo"
        | ZeroOrOne -> failwith "todo"
        | AnyAmount -> failwith "todo"
        | ZeroToThree -> failwith "todo"
    let rec validate_internal data prev lst (order: Map<TaxRecord, RecordNode>) =
        match lst with
        | [] -> None
        | x::xs -> accessRecord data prev lst order x xs
    and accessRecord data prev lst order x xs =
        match Map.tryFind x order with
        | None -> Some(sprintf $"Child record %A{x} was unexpected in parent record %A{prev}")
        | Some e ->
            
            None
    if records[0] <> TaxRecord.Record1000 then
        Some("First record must be a record 1000")
    else
        validate_internal Map.empty TaxRecord.Record1000 records recordStructure
        
