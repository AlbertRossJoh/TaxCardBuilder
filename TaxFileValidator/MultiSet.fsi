module internal MultiSet
    open Types

    type MultiSet<'a when 'a : comparison> = Map<'a, uint> // replace with your type


    type MSError = MSError of string

    type MS<'a, 'b when 'b : comparison> = R of (MultiSet<'b> -> Result<'a * MultiSet<'b>, MSError>)

    val toString<'b when 'b : comparison> : MS<string, 'b>
    
    val empty<'b when 'b : comparison> : MultiSet<'b>
    
    val isEmpty<'b when 'b : comparison> : MS<bool, 'b>

    val size<'b when 'b : comparison> : MS<uint, 'b>
    
    val contains<'b when 'b : comparison> : 'b -> MS<bool,'b>

    val numItems<'b when 'b : comparison> : 'b -> MS<uint, 'b>
    
    val add<'b when 'b : comparison> : 'b -> uint -> MS<unit, 'b>
    
    val addSingle<'b when 'b : comparison> : 'b -> MS<unit, 'b>

    val remove<'b when 'b : comparison> : 'b -> uint -> MS<unit, 'b>
    
    val removeSingle<'b when 'b : comparison> : 'b -> MS<unit, 'b>
    
    val fold<'a, 'b when 'b : comparison> : ('a -> 'b -> uint -> 'a) -> 'a -> MS<'a, 'b>
    
    val foldBack<'a, 'b when 'b : comparison> : ('b -> uint -> 'a -> 'a) -> 'a -> MS<'a, 'b>

    val ofList<'b when 'b : comparison> : 'b list -> MS<unit, 'b>
    
    val toList<'b when 'b : comparison> : MS<'b list, 'b>
    
    val map<'b, 'a when 'a : comparison> : ('a -> 'b) -> MS<'b, 'a>
    
