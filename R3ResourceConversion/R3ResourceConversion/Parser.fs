module Parser

open FParsec
open DialogParser
open BaseParsers

// Parser for many dialogs
let manyDialogs = many( ws >>. dialogP .>> ws )
// UTF8 is the default, but it will detect UTF16 or UTF32 byte-order marks automatically
let parseFile fileName encoding =
    runParserOnFile manyDialogs () fileName encoding