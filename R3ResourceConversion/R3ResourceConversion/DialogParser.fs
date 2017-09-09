module DialogParser
open FParsec
open BaseParsers
open System
open Ast
open StyleParser
open ControlParsers
open CharParsers

// nameID DIALOG x, y, width, height  [optional-statements] {control-statement  . . . }
// nameID DIALOGEX x, y, width, height [ , helpID] [optional-statements]  {control-statements}
let dialogTypeP = 
  stringReturn "DIALOG" ControlType.DIALOG <|> stringReturn "DIALOGEX" ControlType.DIALOGEX

let dialogHeader =
   tuple7 exceptWs (ws >>. dialogTypeP) (ws >>. exceptWs) (ws >>. coordinates )
    (opt (ws >>? str "STYLE" >>. stylesParser))
    (opt (ws >>? str "CAPTION" >>. ws >>. stringLiteral))
    (opt (ws >>? str "FONT" >>. ws >>. pint8 >>. str ", " >>. stringLiteral .>> skipRestOfLine false))

let dialogP : Parser<Dialog, unit> = 
   tuple2 dialogHeader (ws >>. str "BEGIN" >>. manyControls .>> ws .>> str "END")
   |>> (fun ((name,diagogType,_,_,_,_,_), controls) -> 
    match diagogType with 
    | ControlType.DIALOG   -> Dialog.DIALOG (name, controls)
    | ControlType.DIALOGEX -> Dialog.DIALOGEX (name, controls)
    | _                    -> Dialog.Error
    )