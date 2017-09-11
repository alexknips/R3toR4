module UwpWriter

open Ast
open DialogParser

let convertAstToUwp (dialogs : Dialog list) =
  dialogs
    