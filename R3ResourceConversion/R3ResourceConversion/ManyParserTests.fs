module ManyParserTests

open Xunit
open ControlParsers
open FParsec

let testManyControlsP s = 
  match run manyControls s with
  | Success (v, _, _) -> true
  | Failure (msg, err, _) -> false

module ManyParserTests =

  [<Fact>]
  let CanParseManySimple() = 
    let text = 
      """    LTEXT           "Kartennummer",IDC_STATIC,39,97,52,10,NOT WS_GROUP
    LTEXT           "Prüfnummer",IDC_STATIC,39,117,45,10,NOT WS_GROUP
    LTEXT           "Verfallsdatum",IDC_STATIC,39,136,49,10"""
    let result = testManyControlsP text
    Assert.True(result)

  [<Fact>]
  let CanParseManyControls() = 
    let text = 
      """    LTEXT           " Kunde",IDC_STATIC_INFO_1,3,14,419,14,SS_NOPREFIX | 
                      SS_CENTERIMAGE | SS_SUNKEN | NOT WS_GROUP
      CONTROL         "",IDC_STATIC,"Static",SS_GRAYRECT | SS_SUNKEN,3,32,552,
                      3
      GROUPBOX        " Kreditkarteninfo ",IDC_STATIC,28,43,320,113
      COMBOBOX        IDC_COMBO_KARTENTYP,119,56,220,58,CBS_DROPDOWN | 
                      WS_VSCROLL | WS_TABSTOP
      LTEXT           "Kreditkartentyp",IDC_STATIC,39,58,52,10,NOT WS_GROUP
      EDITTEXT        IDC_KARTE_NAME,119,74,220,14,ES_AUTOHSCROLL
      EDITTEXT        IDC_KARTE_NUMMER,119,94,220,14,ES_AUTOHSCROLL
      EDITTEXT        IDC_KARTE_PRUEFNR,119,114,220,14,ES_AUTOHSCROLL
      EDITTEXT        IDC_KARTE_GUELTIGBIS,119,134,220,14,ES_AUTOHSCROLL
      LTEXT           "Inhabername",IDC_STATIC,39,77,47,10,NOT WS_GROUP
      LTEXT           "Kartennummer",IDC_STATIC,39,97,52,10,NOT WS_GROUP
      LTEXT           "Prüfnummer",IDC_STATIC,39,117,45,10,NOT WS_GROUP
      LTEXT           "Verfallsdatum",IDC_STATIC,39,136,49,10"""
    let result = testManyControlsP text
    Assert.True(result)
    
  [<Fact>]
  let CanParseAlotControls() = 
    let text = """LTEXT           "Nummer",IDC_STATIC,12,5,27,8
    EDITTEXT        IDC_NUMMER,76,3,63,14,ES_RIGHT | ES_MULTILINE | 
                    ES_AUTOHSCROLL
    LTEXT           "Status",IDC_STATIC,147,5,21,8
    COMBOBOX        IDC_STATUS,174,3,97,133,CBS_DROPDOWNLIST | WS_VSCROLL | 
                    WS_TABSTOP
    LTEXT           "Firma",IDC_STATIC,12,21,52,8
    EDITTEXT        IDC_FIRMA,76,18,96,14,ES_AUTOHSCROLL
    EDITTEXT        IDC_FIRMA2,174,18,97,14,ES_AUTOHSCROLL
    LTEXT           "Anrede",IDC_STATIC,12,36,24,8
    COMBOBOX        IDC_ANREDE_FIRMA,76,34,144,128,CBS_DROPDOWN | WS_VSCROLL | 
                    WS_TABSTOP
    LTEXT           "Name",IDC_STATIC,12,53,20,8
    EDITTEXT        IDC_NAME1,76,49,73,14,ES_AUTOHSCROLL
    EDITTEXT        IDC_NAME2,151,49,120,14,ES_AUTOHSCROLL
    LTEXT           "Zusatz",IDC_STATIC,12,69,22,8
    EDITTEXT        IDC_ZUSATZ,76,65,195,14,ES_AUTOHSCROLL
    LTEXT           "Strasse",IDC_STATIC,12,83,24,8
    EDITTEXT        IDC_STRASSE,76,81,144,14,ES_AUTOHSCROLL
    LTEXT           "Ort",IDC_STATIC,12,98,15,8
    EDITTEXT        IDC_PLZ,76,96,40,14,ES_AUTOHSCROLL
    EDITTEXT        IDC_ORT,119,96,152,14,ES_AUTOHSCROLL
    LTEXT           "Land",IDC_STATIC,12,113,17,8
    EDITTEXT        IDC_LAND,76,111,144,14,ES_AUTOHSCROLL
    LTEXT           "Telefon",IDC_STATIC,12,128,25,8
    EDITTEXT        IDC_TELEFON_FIRMA1,76,127,73,14,ES_AUTOHSCROLL
    EDITTEXT        IDC_TELEFON_FIRMA2,151,127,69,14,ES_AUTOHSCROLL
    LTEXT           "Fax",IDC_STATIC,12,144,12,8
    EDITTEXT        IDC_FAX_FIRMA1,76,142,73,14,ES_AUTOHSCROLL
    EDITTEXT        IDC_FAX_FIRMA2,151,142,69,14,ES_AUTOHSCROLL
    LTEXT           "Mobil",IDC_STATIC,12,160,22,8
    EDITTEXT        IDC_MOBIL_FIRMA1,76,157,73,14,ES_AUTOHSCROLL
    EDITTEXT        IDC_MOBIL_FIRMA2,151,157,69,14,ES_AUTOHSCROLL
    LTEXT           "E-Mail",IDC_STATIC,12,175,20,8
    EDITTEXT        IDC_KUNDEEMAIL,76,172,145,14,ES_AUTOHSCROLL
    GROUPBOX        " Ansprechpartner ",IDC_STATIC,4,188,262,148
    LTEXT           "Position",IDC_STATIC,9,199,26,8
    COMBOBOX        IDC_POSITION,76,198,144,128,CBS_DROPDOWN | WS_VSCROLL | 
                    WS_TABSTOP
    LTEXT           "Anrede",IDC_STATIC,9,213,24,8
    COMBOBOX        IDC_ANREDE_AP,76,211,144,128,CBS_DROPDOWN | WS_VSCROLL | 
                    WS_TABSTOP
    LTEXT           "Vorname",IDC_STATIC,9,228,29,8
    EDITTEXT        IDC_AP_NAME1,75,226,144,14,ES_AUTOHSCROLL
    LTEXT           "Name",IDC_STATIC,9,244,20,8
    EDITTEXT        IDC_AP_NAME2,75,241,144,14,ES_AUTOHSCROLL
    LTEXT           "Telefon",IDC_STATIC,9,258,25,8
    EDITTEXT        IDC_TELEFON1,75,257,71,14,ES_AUTOHSCROLL
    EDITTEXT        IDC_TELEFON2,148,257,71,14,ES_AUTOHSCROLL
    LTEXT           "Anrufzeiten",IDC_STATIC,9,273,49,8
    EDITTEXT        IDC_ANRUFZEITEN,75,273,144,14,ES_AUTOHSCROLL
    LTEXT           "Fax",IDC_STATIC,9,290,12,8
    EDITTEXT        IDC_FAX_AP1,75,288,71,14,ES_AUTOHSCROLL
    EDITTEXT        IDC_FAX_AP2,148,288,71,14,ES_AUTOHSCROLL
    LTEXT           "Mobil",IDC_STATIC,9,306,22,8
    EDITTEXT        IDC_MOBIL_AP1,75,303,71,14,ES_AUTOHSCROLL
    EDITTEXT        IDC_MOBIL_AP2,148,303,71,14,ES_AUTOHSCROLL
    LTEXT           "E-Mail",IDC_STATIC,9,320,20,8
    EDITTEXT        IDC_EMAIL,75,318,144,14,ES_AUTOHSCROLL
    CTEXT           "Neu",IDC_AP_POS,231,210,30,12,SS_CENTERIMAGE | 
                    SS_SUNKEN
    CONTROL         "Spin1",IDC_AP_SELECT,"msctls_updown32",UDS_HORZ,231,223,
                    30,12
    GROUPBOX        "",IDC_STATIC,231,249,31,78
    CONTROL         "WORD_SMALL",IDC_BUTTON_WORD,"Button",BS_OWNERDRAW | 
                    WS_TABSTOP,234,256,25,21
    CONTROL         "EMAIL_SMALL",IDC_BUTTON_EMAIL,"Button",BS_OWNERDRAW | 
                    WS_TABSTOP,234,278,25,21
    CONTROL         "ADRESSBUCH",IDC_BUTTON_ADRESSBUCH,"Button",BS_OWNERDRAW | 
                    WS_TABSTOP,234,305,25,21
    LTEXT           "Kurzinfo",IDC_STATIC,5,342,44,8
    CONTROL         "",IDC_KURZINFO,"RICHEDIT",ES_MULTILINE | ES_AUTOVSCROLL | 
                    ES_AUTOHSCROLL | WS_BORDER | WS_VSCROLL | WS_TABSTOP,74,
                    339,144,36
    LTEXT           "Belegversand",IDC_STATIC,277,5,44,8
    COMBOBOX        IDC_BELEGVERSAND,337,3,117,128,CBS_DROPDOWN | WS_VSCROLL | 
                    WS_TABSTOP
    LTEXT           "WWW",IDC_LBL_WWW,277,21,23,8,SS_NOTIFY
    EDITTEXT        IDC_HOMEPAGE,337,18,117,14,ES_AUTOHSCROLL
    CONTROL         "",IDC_STATISTIK,"LogecOpenGLWindow",WS_CLIPCHILDREN | 
                    WS_BORDER | WS_TABSTOP,280,37,265,139
    CONTROL         "",IDC_HTML,"LogecHtmlWindow",WS_CLIPCHILDREN | 
                    WS_TABSTOP,279,182,266,189
    CONTROL         "List1",IDC_GRABSTAETTE,"SysListView32",LVS_REPORT | 
                    LVS_SINGLESEL | LVS_OWNERDRAWFIXED | NOT WS_VISIBLE | 
                    WS_BORDER | WS_TABSTOP,280,37,265,139
    CONTROL         "SWITCH_DISPLAY",IDC_BUTTON_SWITCH,"Button",BS_OWNERDRAW | 
                    WS_TABSTOP,548,37,6,7
    CONTROL         "REPORT_BAR_SMALL",IDC_BARCODE_LISTE,"Button",
                    BS_OWNERDRAW | WS_TABSTOP,234,143,25,21"""
    let result = testManyControlsP text
    Assert.True(result)
