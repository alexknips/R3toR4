module Ast

open System

type ControlType = 
  | LTEXT 
  | RTEXT
  | EDITTEXT
  | COMBOBOX
  | CONTROL
  | CHECKBOX
  | CTEXT
  | GROUPBOX
  | DIALOG
  | DIALOGEX
  | LISTBOX
  | PUSHBUTTON

type UpDownControlStyle = 
  | UDS_ALIGNLEFT = 1
  | UDS_ALIGNRIGHT = 2
  | UDS_ARROWKEYS = 3
  | UDS_AUTOBUDDY = 4
  | UDS_HORZ = 5
  | UDS_HOTTRACK = 6 
  | UDS_NOTHOUSANDS= 7
  | UDS_SETBUDDYINT= 8
  | UDS_WRAP = 9

type ComboBoxStyles =
  | CBS_AUTOHSCROLL = 1 
  | CBS_DISABLENOSCROLL = 2
  | CBS_DROPDOWNLIST = 3
  | CBS_DROPDOWN = 4
  | CBS_HASSTRINGS = 5
  | CBS_LOWERCASE = 6
  | CBS_NOINTEGRALHEIGHT = 7
  | CBS_OEMCONVERT = 8
  | CBS_OWNERDRAWFIXED = 9
  | CBS_OWNERDRAWVARIABLE = 10
  | CBS_SIMPLE = 11
  | CBS_SORT = 12
  | CBS_UPPERCASE = 13

type ButtonStyles = 
  | BS_3STATE = 1
  | BS_AUTO3STATE = 2
  | BS_AUTOCHECKBOX = 3
  | BS_AUTORADIOBUTTON = 4
  | BS_BITMAP = 5
  | BS_BOTTOM = 6
  | BS_CENTER = 7
  | BS_CHECKBOX = 8 
  | BS_COMMANDLINK= 9
  | BS_DEFCOMMANDLINK = 10
  | BS_DEFPUSHBUTTON = 11
  | BS_DEFSPLITBUTTON = 12
  | BS_GROUPBOX = 13
  | BS_ICON = 14
  | BS_FLAT = 15
  | BS_LEFTTEXT = 16
  | BS_LEFT = 17
  | BS_MULTILINE = 18
  | BS_NOTIFY = 19
  | BS_OWNERDRAW = 20
  | BS_PUSHBUTTON = 21
  | BS_PUSHLIKE = 22
  | BS_RADIOBUTTON = 23
  | BS_RIGHTBUTTON = 24
  | BS_RIGHT = 25
  | BS_SPLITBUTTON = 26
  | BS_TEXT = 27
  | BS_TOP = 28
  | BS_TYPEMASK = 29
  | BS_USERBUTTON = 30
  | BS_VCENTER = 31

type ListViewStyles = 
  | LVS_ALIGNLEFT       = 1
  | LVS_ALIGNMASK       = 2
  | LVS_ALIGNTOP        = 3
  | LVS_AUTOARRANGE     = 4
  | LVS_EDITLABELS      = 5
  | LVS_ICON            = 6
  | LVS_LIST            = 7
  | LVS_NOCOLUMNHEADER  = 8
  | LVS_NOLABELWRAP     = 9
  | LVS_NOSCROLL        = 10
  | LVS_NOSORTHEADER    = 11
  | LVS_OWNERDATA       = 12
  | LVS_OWNERDRAWFIXED  = 13
  | LVS_REPORT          = 14
  | LVS_SHAREIMAGELISTS = 15
  | LVS_SHOWSELALWAYS   = 16
  | LVS_SINGLESEL       = 17
  | LVS_SMALLICON       = 18
  | LVS_SORTASCENDING   = 19
  | LVS_SORTDESCENDING  = 20
  | LVS_TYPEMASK        = 21
  | LVS_TYPESTYLEMASK   = 22

type ListBoxStyles = 
  | LBS_COMBOBOX          = 1
  | LBS_DISABLENOSCROLL   = 2
  | LBS_EXTENDEDSEL       = 3
  | LBS_HASSTRINGS        = 4
  | LBS_MULTICOLUMN       = 5
  | LBS_MULTIPLESEL       = 6
  | LBS_NODATA            = 7
  | LBS_NOINTEGRALHEIGHT  = 8
  | LBS_NOREDRAW          = 9
  | LBS_NOSEL             = 10
  | LBS_NOTIFY            = 11
  | LBS_OWNERDRAWFIXED    = 12
  | LBS_OWNERDRAWVARIABLE = 13
  | LBS_SORT              = 14
  | LBS_STANDARD          = 15
  | LBS_USETABSTOPS       = 16
  | LBS_WANTKEYBOARDINPUT = 17

type DateTimeStyles = 
  | DTS_APPCANPARSE               = 1
  | DTS_LONGDATEFORMAT            = 2
  | DTS_RIGHTALIGN                = 3
  | DTS_SHOWNONE                  = 4
  | DTS_SHORTDATEFORMAT           = 5
  | DTS_SHORTDATECENTURYFORMAT    = 6
  | DTS_TIMEFORMAT                = 7
  | DTS_UPDOWN                    = 8
                                  
type DialogStyles =               
  | DS_3DLOOK = 1                 
  | DS_ABSALIGN = 2                
  | DS_CENTER = 3               
  | DS_CENTERMOUSE = 4
  | DS_CONTEXTHELP = 5
  | DS_CONTROL = 6
  | DS_FIXEDSYS = 7
  | DS_LOCALEDIT = 8
  | DS_MODALFRAME = 9
  | DS_NOFAILCREATE = 10
  | DS_NOIDLEMSG = 11
  | DS_SETFONT = 12
  | DS_SETFOREGROUND = 13
  | DS_SHELLFONT = 14
  | DS_SYSMODAL = 15

type EditControlStyles = 
  | ES_AUTOHSCROLL = 1
  | ES_AUTOVSCROLL = 2
  | ES_CENTER = 3
  | ES_LEFT = 4
  | ES_LOWERCASE = 5
  | ES_MULTILINE = 6
  | ES_NOHIDESEL = 7
  | ES_NUMBER = 8
  | ES_OEMCONVERT = 9
  | ES_PASSWORD = 10
  | ES_READONLY = 11
  | ES_RIGHT = 12
  | ES_UPPERCASE = 13
  | ES_WANTRETURN = 14

type StaticStyle = 
  | SS_BITMAP = 1
  | SS_BLACKFRAME = 2 
  | SS_BLACKRECT = 3
  | SS_CENTERIMAGE = 4
  | SS_CENTER = 5
  | SS_EDITCONTROL = 6
  | SS_ENDELLIPSIS = 7
  | SS_ENHMETAFILE = 8
  | SS_ETCHEDFRAME = 9
  | SS_ETCHEDHORZ = 10
  | SS_ETCHEDVERT = 11
  | SS_GRAYFRAME = 12
  | SS_GRAYRECT = 13
  | SS_ICON = 14
  | SS_LEFT = 15
  | SS_LEFTNOWORDWRAP = 16
  | SS_NOPREFIX = 17
  | SS_NOTIFY = 18
  | SS_OWNERDRAW = 19
  | SS_PATHELLIPSIS = 20
  | SS_REALSIZECONTROL = 21
  | SS_REALSIZEIMAGE = 22
  | SS_RIGHT = 23
  | SS_RIGHTJUST = 24
  | SS_SIMPLE = 25
  | SS_SUNKEN = 26
  | SS_TYPEMASK = 27
  | SS_WHITEFRAME = 28
  | SS_WHITERECT = 29
  | SS_WORDELLIPSIS = 30


type WindowStyle = 
  | WS_BORDER = 1
  | WS_CAPTION = 2
  | WS_CHILD = 3
  | WS_CHILDWINDOW = 4 
  | WS_CLIPCHILDREN = 5 
  | WS_CLIPSIBLINGS = 6 
  | WS_DISABLED = 7
  | WS_DLGFRAME = 8 
  | WS_GROUP = 9
  | WS_HSCROLL = 10 
  | WS_ICONIC = 11
  | WS_MAXIMIZE = 12 
  | WS_MAXIMIZEBOX = 13 
  | WS_MINIMIZE = 14
  | WS_MINIMIZEBOX = 15 
  | WS_OVERLAPPED = 16
  | WS_OVERLAPPEDWINDOW = 17 
  | WS_POPUP = 18
  | WS_POPUPWINDOW = 19 
  | WS_SIZEBOX = 20
  | WS_SYSMENU = 21
  | WS_TABSTOP = 22
  | WS_THICKFRAME = 23 
  | WS_TILED = 24
  | WS_TILEDWINDOW = 25 
  | WS_VISIBLE = 26
  | WS_VSCROLL = 27

type Style = 
  | StaticStyle of StaticStyle
  | WindowStyle of WindowStyle
  | EditControlStyles of EditControlStyles
  | UpDownControlStyle of UpDownControlStyle
  | ComboBoxStyles of ComboBoxStyles
  | ButtonStyles of ButtonStyles
  | ListViewStyles of ListViewStyles
  | DialogStyles of DialogStyles
  | ListBoxStyles of ListBoxStyles
  | DateTimeStyles of DateTimeStyles

type StyleNegated = Style * bool
type Coordinates = { x: int; y: int; width: int; height: int }
type ControlId = string
type ControlText = string
type ControlClass = string


// actual controls
type Control = 
  | LTEXT of ControlText * ControlId * Coordinates * StyleNegated list option
  | RTEXT  of ControlText * ControlId * Coordinates * StyleNegated list option
  | CHECKBOX of ControlText * ControlId * Coordinates * StyleNegated list option
  | CTEXT of ControlText * ControlId * Coordinates * StyleNegated list option
  | GROUPBOX of ControlText * ControlId * Coordinates * StyleNegated list option
  | PUSHBUTTON of ControlText * ControlId * Coordinates * StyleNegated list option
  | CONTROL of ControlText * ControlId * ControlClass * Coordinates * StyleNegated list * StyleNegated list option
  | EDITTEXT of ControlId * Coordinates * StyleNegated list option
  | COMBOBOX of ControlId * Coordinates * StyleNegated list option
  | LISTBOX of ControlId * Coordinates * StyleNegated list option
  | Error

type Dialog = 
  | DIALOG of string * Control list
  | DIALOGEX of string * Control list
  | Error

// You can define labels on their own line with a semicolon.
type ResourceLine = Type of ControlType * int

[<StructuredFormatDisplay("{StructuredFormatDisplay}")>]
type Resource
          = RString of string
          | Type    of ControlType
          | RInt of int
         with
            member private t.StructuredFormatDisplay =
                match t with
                | RString s -> box ("\"" + s + "\"")
                | Type    t -> box t
                | RInt    i -> box i