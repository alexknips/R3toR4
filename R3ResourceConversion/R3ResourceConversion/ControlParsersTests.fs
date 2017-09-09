module ControlParsersTests

open Xunit
open ControlParsers
open FParsec

module ControlParsersTests =
  let testTextControlP s = 
    match run textControlP s with
    | Success (v, _, _) -> true
    | Failure (msg, err, _) -> false

  let testControlWithoutTextP s = 
    match run controlWithoutTextP s with
    | Success (v, _, _) -> true
    | Failure (msg, err, _) -> false

  let testControlP s = 
    match run controlP s with
    | Success (v, _, _) -> true
    | Failure (msg, err, _) -> false

  [<Fact>]
  let CanParseLTEXT() = 
    let text = """LTEXT           "E-Mail",IDC_STATIC,12,175,20,8"""
    let result = testTextControlP text
    Assert.True(result)

  [<Fact>]
  let CanParseLTEXTWithoutStatic() = 
    let text = """LTEXT           " Kunde",IDC_STATIC_INFO_1,3,14,445,14,SS_NOPREFIX | SS_CENTERIMAGE | SS_SUNKEN | NOT WS_GROUP"""
    let result = testTextControlP text
    Assert.True(result)

  [<Fact>]
  let CanParseLTEXTMultiLine() = 
    let text = """LTEXT           " Kunde",IDC_STATIC_INFO_1,3,14,445,14,SS_NOPREFIX |  
                  SS_CENTERIMAGE | SS_SUNKEN | NOT WS_GROUP"""
    let result = testTextControlP text
    Assert.True(result)

  [<Fact>]
  let CanParseRTEXTWithout() = 
    let text = """RTEXT            "E-Mail",IDC_STATIC,12,175,20,8"""
    let result = testTextControlP text
    Assert.True(result)

  [<Fact>]
  let CanParseCTEXT() =
    let text = """CTEXT           "Neu",IDC_AP_POS,192,18,30,12,SS_CENTERIMAGE | SS_SUNKEN"""
    let result = testTextControlP text
    Assert.True(result)

  [<Fact>]
  let CanParseGROUPBOX() =
    let text = """GROUPBOX        " Kreditkarteninfo ",IDC_STATIC,28,43,320,113"""
    let result = testTextControlP text
    Assert.True(result)
  
  [<Fact>]
  let CanParseEDITTEXT() = 
    let text = """EDITTEXT        IDC_TERMIN_BEMERKUNG,178,68,159,14,ES_AUTOHSCROLL"""
    let result = testControlWithoutTextP text
    Assert.True(result)

  [<Fact>]
  let CanParseCOMBOBOX() = 
    let text = """COMBOBOX        IDC_TERMIN_GRUND,77,68,96,105,CBS_DROPDOWN | WS_VSCROLL | WS_TABSTOP"""
    let result = testControlWithoutTextP text
    Assert.True(result)

  [<Fact>]
  let CanParseCONTROL() = 
    let text = """CONTROL         "Spin1",IDC_AP_SELECT,"msctls_updown32",UDS_HORZ,231,223,
                    30,12"""
    let result = testControlP text
    Assert.True(result)