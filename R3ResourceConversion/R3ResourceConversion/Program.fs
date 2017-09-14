module Main

open FParsec.CharParsers
open Parser
open System
open XamlGeneration

[<EntryPoint>]
let main(args: string[]) =
    if args.Length <> 1 then
        printf "usage: mfcparser.exe <file>\n"
        exit 1

    // The parser is run on the file path in args.[0].
    // If the file has no byte order marks, System.Text.Encoding.Default
    // is assumed to be the encoding.
    // The parser result will be the abstract syntax tree of the input file.
    let result = parseFile args.[0] System.Text.Encoding.Default
    // for the moment we just print out the AST
    match result with
    | Success (v, _, _) ->
        printf "The AST of the input file is:\n%A\n" v
        v |> List.iter (saveToFile "output.txt") 
        
    | Failure (msg, err, _) ->
        printfn "%s" msg

    Console.ReadKey() |> ignore
    0

