module BaseParsers

open FParsec

// some abbreviations
let ws = spaces // eats any whitespace
let skipComma : Parser<unit, unit> = skipChar ',' .>> ws
  //skipAnyOf [',']
  //spaces <|> skipNewline <|> skipChar ','  <|> (skipChar ',' .>> spaces )
let str s = pstring s

// this string literal expression is from the JSON parser and a little overkill
let stringLiteral : Parser<string, unit> =
  let normalChar = satisfy (fun c -> c <> '\\' && c <> '"')
  let unescape c = match c with
                    | 'n' -> '\n'
                    | 'r' -> '\r'
                    | 't' -> '\t'
                    | c   -> c
  let escapedChar = pstring "\\" >>. (anyOf "\\nrt\"" |>> unescape)
  between (pstring "\"") (pstring "\"")
          (manyChars (normalChar <|> escapedChar))

// all chars except comma
let exceptComma : Parser<string, unit> =
  charsTillString "," false 50

let exceptWs : Parser<string, unit> =
  charsTillString " " false 50

let tuple6 p1 p2 p3 p4 p5 p6 =
  pipe2 p1 (tuple5 p2 p3 p4 p5 p6)
    (fun x1 (x2, x3, x4, x5, x6) -> (x1, x2, x3, x4, x5, x6))

let tuple7 p1 p2 p3 p4 p5 p6 p7  =
  pipe2 p1 (tuple6 p2 p3 p4 p5 p6 p7)
    (fun x1 (x2, x3, x4, x5, x6, x7) -> (x1, x2, x3, x4, x5, x6, x7))