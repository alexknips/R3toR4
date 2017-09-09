module StyleParser

open FParsec
open BaseParsers
open System
open Ast

// Parser for:
// [, style [, extended-style]]

let staticStyles: Parser<String, unit> list = 
  Enum.GetNames(typeof<StaticStyle>) |> Array.map str |> Array.toList
let windowStyles : Parser<String, unit> list = 
  Enum.GetNames(typeof<WindowStyle>) |> Array.map str |> Array.toList
let editControlStyles : Parser<String, unit> list = 
  Enum.GetNames(typeof<EditControlStyles>) |> Array.map str |> Array.toList
let upDownControlStyles : Parser<String, unit> list = 
  Enum.GetNames(typeof<UpDownControlStyle>) |> Array.map str |> Array.toList
let comboBoxStyles : Parser<String, unit> list = 
  Enum.GetNames(typeof<ComboBoxStyles>) |> Array.map str |> Array.toList
let buttonStyles : Parser<String, unit> list = 
  Enum.GetNames(typeof<ButtonStyles>) |> Array.map str |> Array.toList
let listViewStyles : Parser<String, unit> list = 
  Enum.GetNames(typeof<ListViewStyles>) |> Array.map str |> Array.toList
let dialogStyles : Parser<String, unit> list = 
  Enum.GetNames(typeof<DialogStyles>) |> Array.map str |> Array.toList
let listBoxStyles : Parser<String, unit> list = 
  Enum.GetNames(typeof<ListBoxStyles>) |> Array.map str |> Array.toList
let dateTimeStyles : Parser<String, unit> list = 
  Enum.GetNames(typeof<DateTimeStyles>) |> Array.map str |> Array.toList

  
  
// functions to get the Style DU from string
// first get Enum then parse as specific enum, then create DU with it's constructor
let getWindowStyleFromString x = Enum.Parse(typedefof<WindowStyle>, x) :?> WindowStyle |> (fun y -> WindowStyle(y))
let getStaticStyleFromString x = Enum.Parse(typedefof<StaticStyle>, x) :?> StaticStyle |> (fun y -> StaticStyle(y))
let getEditControlStyleFromString x = Enum.Parse(typedefof<EditControlStyles>, x) :?> EditControlStyles |> (fun y -> EditControlStyles(y))
let getUpDownControlStyleFromString x = Enum.Parse(typedefof<UpDownControlStyle>, x) :?> UpDownControlStyle |> (fun y -> UpDownControlStyle(y))
let getComboBoxStyleFromString x = Enum.Parse(typedefof<ComboBoxStyles>, x) :?> ComboBoxStyles |> (fun y -> ComboBoxStyles(y))
let getButtonStyleFromString x = Enum.Parse(typedefof<ButtonStyles>, x) :?> ButtonStyles |> (fun y -> ButtonStyles(y))
let getListViewStyleFromString x = Enum.Parse(typedefof<ListViewStyles>, x) :?> ListViewStyles |> (fun y -> ListViewStyles(y))
let getDialogStyleFromString x = Enum.Parse(typedefof<DialogStyles>, x) :?> DialogStyles |> (fun y -> DialogStyles(y))
let getListBoxStyleFromString x = Enum.Parse(typedefof<ListBoxStyles>, x) :?> ListBoxStyles |> (fun y -> ListBoxStyles(y))
let getDateTimeStyleFromString x = Enum.Parse(typedefof<DateTimeStyles>, x) :?> DateTimeStyles |> (fun y -> DateTimeStyles(y))

let staticStyleChoices = choice staticStyles |>> getStaticStyleFromString
let windowStyleChoices = choice windowStyles |>> getWindowStyleFromString
let editControlStyleChoices = choice editControlStyles |>> getEditControlStyleFromString
let upDownControlStyleChoices = choice upDownControlStyles |>> getUpDownControlStyleFromString
let comboBoxStyleChoices = choice comboBoxStyles |>> getComboBoxStyleFromString
let buttonStyleChoices = choice buttonStyles |>> getButtonStyleFromString
let listViewStyleChoices = choice listViewStyles |>> getListViewStyleFromString
let dialogStyleChoices = choice dialogStyles |>> getDialogStyleFromString
let listboxStyleChoices = choice listBoxStyles |>> getListBoxStyleFromString
let dateTimeStylesChoices = choice dateTimeStyles |>> getDateTimeStyleFromString

// static style or window style
let styleChoiceParser = 
  staticStyleChoices <|> windowStyleChoices 
  <|> editControlStyleChoices <|> upDownControlStyleChoices
  <|> comboBoxStyleChoices <|> buttonStyleChoices
  <|> listViewStyleChoices <|> dialogStyleChoices
  <|> listboxStyleChoices <|> dateTimeStylesChoices

let styleChoiceWithOptionalNot = pipe2 (opt (str "NOT ")) styleChoiceParser (fun x y -> 
  match x, y with
    | Some(_), x -> (x, true)
    | _, x -> (x, false)
)

// TODO: unit test this parser as it seems dogdy
let stylesParser: Parser<StyleNegated list, unit> = 
  ws >>. sepBy styleChoiceWithOptionalNot 
    ((skipString " | " >>? ws) <|> (skipString " | "))