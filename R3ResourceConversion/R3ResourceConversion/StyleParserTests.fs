module Tests

open Xunit
open StyleParser
open FParsec

module StyleParserTests =
    open System
    open Ast

    let parseStyles s = run stylesParser s

    let testStyles s = 
      match parseStyles s with
      | Success (v, _, _) -> true
      | Failure (msg, err, _) -> false

    [<Fact>]
    let CanParseStyleList() = 
      let styles = "SS_NOPREFIX | SS_CENTERIMAGE | SS_SUNKEN | WS_GROUP"
      let result = testStyles styles
      Assert.True(result)

    [<Fact>]
    let CanParseStyleListWithNot() = 
      let styles = "SS_NOPREFIX | SS_CENTERIMAGE | SS_SUNKEN | NOT WS_GROUP"
      let result = testStyles styles
      Assert.True(result)

    [<Fact>]
    let CanParseStyleListWithOneElement() = 
      let styles = "SS_NOPREFIX"
      let result = testStyles styles
      Assert.True(result)

    [<Fact>]
    let StyleParserShouldEatLeadingWhiteSpace() = 
      let styles = " SS_NOPREFIX"
      let result = testStyles styles
      Assert.True(result)

    [<Fact>]
    let StyleParserShouldParseCBS() = 
      let styles = "CBS_DROPDOWN"
      let result = testStyles styles
      Assert.True(result)

    [<Fact>]
    let EnumParse() = 
      let myEnumValue = Enum.Parse(typedefof<WindowStyle>, "WS_MINIMIZE") :?> WindowStyle
      Assert.Equal(WindowStyle.WS_MINIMIZE, myEnumValue)
