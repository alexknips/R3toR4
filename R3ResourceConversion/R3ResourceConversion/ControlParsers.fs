module ControlParsers

open FParsec
open BaseParsers
open System
open Ast
open StyleParser

// General parser
// CP P1, P2, ..., PN
//let rec listParser parserList = 
//  p1 >> str "," >> listParser p1 pr
let generalParser2 cp p1 p2 =           
  tuple3 cp (ws >>. p1) (opt (skipComma >>. p2))
let generalParser3 cp p1 p2 p3 =        
  tuple4 cp (ws >>. p1) (skipComma >>. p2) (opt (skipComma >>. p3))
let generalParser4 cp p1 p2 p3 p4 =     
  tuple5 cp (ws >>. p1) (skipComma >>. p2) (skipComma >>. p3 ) (opt (skipComma >>. p4))
let generalParser5 cp p1 p2 p3 p4 p5 =  
  tuple6 cp (ws >>. p1) (skipComma >>. p2) (skipComma >>. p3 ) ( skipComma >>. p4 ) (opt (skipComma >>. p5))
let generalParser6 cp p1 p2 p3 p4 p5 p6 =  
  tuple7 cp (ws >>. p1) (skipComma >>. p2) (skipComma >>. p3 ) ( skipComma >>. p4 ) ( skipComma >>. p5 ) (opt (skipComma >>. p6))

// Parser for coordinate 
// x, y, width, height
let coordinates : Parser<(int * int *int *int ), unit> = tuple4 (pint32 .>> str "," .>> ws) (pint32 .>> str "," .>> ws) (pint32 .>> str "," .>> ws) (pint32)

// Parser for
// LISTBOX id, x, y, width, height [, style [, extended-style]]
// EDITTEXT id, x, y, width, height [, style [, extended-style]]
// COMBOBOX id, x, y, width, height [, style [, extended-style]]
let controlTypeP : Parser<ControlType, unit> =
  stringReturn "EDITTEXT" ControlType.EDITTEXT  
  <|> stringReturn "COMBOBOX" ControlType.COMBOBOX
  <|> stringReturn "LISTBOX" ControlType.LISTBOX
let controlWithoutTextP : Parser<Control, unit> = 
  generalParser3 controlTypeP exceptComma coordinates stylesParser
  |>> (fun (controlType, id, (x,y,w,h), styleOptions) -> 
    match controlType with 
    | ControlType.EDITTEXT -> Control.EDITTEXT (id, { x = x; y = y; width = w; height = h }, styleOptions)
    | ControlType.COMBOBOX -> Control.COMBOBOX (id, { x = x; y = y; width = w; height = h }, styleOptions)
    | ControlType.LISTBOX -> Control.LISTBOX (id, { x = x; y = y; width = w; height = h }, styleOptions)
    | _                 -> Control.Error
    )

// Parser for

// LTEXT text, id, x, y, width, height [, style [, extended-style]]
// RTEXT text, id, x, y, width, height [, style [, extended-style]]
// CHECKBOX text, id, x, y, width, height [, style [, extended-style]]
// CTEXT text, id, x, y, width, height [, style [, extended-style]]
// GROUPBOX text, id, x, y, width, height [, style [, extended-style]]
// PUSHBUTTON text, id, x, y, width, height [, style [, extended-style]]
let lrtext = 
  stringReturn "LTEXT" ControlType.LTEXT  
  <|> stringReturn "RTEXT" ControlType.RTEXT
  <|> stringReturn "CHECKBOX" ControlType.CHECKBOX
  <|> stringReturn "CTEXT" ControlType.CTEXT
  <|> stringReturn "GROUPBOX" ControlType.GROUPBOX
  <|> stringReturn "PUSHBUTTON" ControlType.PUSHBUTTON
let textControlP : Parser<Control, unit> = 
  generalParser4 lrtext stringLiteral exceptComma coordinates stylesParser
  |>> (fun (controlType, text, id, (x,y,w,h), styleOptions) -> 
    match controlType with 
    | ControlType.LTEXT      -> Control.LTEXT (text, id, { x = x; y = y; width = w; height = h }, styleOptions)
    | ControlType.RTEXT      -> Control.RTEXT (text, id, { x = x; y = y; width = w; height = h }, styleOptions)
    | ControlType.CHECKBOX   -> Control.CHECKBOX (text, id, { x = x; y = y; width = w; height = h }, styleOptions)
    | ControlType.CTEXT      -> Control.CTEXT (text, id, { x = x; y = y; width = w; height = h }, styleOptions)
    | ControlType.GROUPBOX   -> Control.GROUPBOX (text, id, { x = x; y = y; width = w; height = h }, styleOptions)
    | ControlType.PUSHBUTTON -> Control.PUSHBUTTON (text, id, { x = x; y = y; width = w; height = h }, styleOptions)
    | _                      -> Control.Error
    )

// Parser for
// CONTROL text, id, class, style, x, y, width, height [, extended-style]
let controlType2P = stringReturn "CONTROL" ControlType.CONTROL
 
let controlP : Parser<Control, unit> = 
  generalParser6 controlType2P stringLiteral exceptComma stringLiteral stylesParser coordinates stylesParser
  |>> (fun (controlType, text, id, classType, style, (x,y,w,h), styleOptions) -> 
    match controlType with 
    | ControlType.CONTROL -> Control.CONTROL (text, id, classType, { x = x; y = y; width = w; height = h }, style, styleOptions)
    | _                   -> Control.Error
    )


// Parser for different controls
let controlChoices : Parser<Control, unit> = 
  choice [ 
    controlP
    textControlP
    controlWithoutTextP
  ] 
// Parser for many controls
let manyControls = many( ws >>. controlChoices .>> ws )