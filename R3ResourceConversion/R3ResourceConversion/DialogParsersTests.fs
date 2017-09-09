module DialogParserTests

open Xunit
open DialogParser
open FParsec

module DialogParserTests =
  let testDialogP s = 
    match run dialogP s with
    | Success (v, _, _) -> true
    | Failure (msg, err, _) -> false
  let testDialogHeader s = 
    match run dialogHeader s with
    | Success (v, _, _) -> true
    | Failure (msg, err, _) -> false
    

  [<Fact>]
  let CanParseDIALOG() = 
    let text = """IDD_FV_KUNDE_DOKUMENTENVERWALTUNG DIALOG DISCARDABLE  0, 0, 555, 375"""
    let result = testDialogHeader text
    Assert.True(result)

  [<Fact>]
  let CanParseDIALOGWithStyle() = 
    let text = """IDD_FV_KUNDE_ALLGEMEIN DIALOG DISCARDABLE  0, 0, 555, 375
STYLE DS_CONTROL | WS_CHILD
FONT 8, "MS Sans Serif"
BEGIN
    LTEXT           "Nummer",IDC_STATIC,12,5,27,8
    EDITTEXT        IDC_NUMMER,76,3,63,14,ES_RIGHT | ES_MULTILINE | 
                    ES_AUTOHSCROLL
    LTEXT           "Status",IDC_STATIC,147,5,21,8
    COMBOBOX        IDC_STATUS,174,3,97,133,CBS_DROPDOWNLIST | WS_VSCROLL | 
                    WS_TABSTOP
END"""
    let result = testDialogP text
    Assert.True(result)
    