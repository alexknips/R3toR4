namespace R3ResourceConversion.Tests

open Xunit
open StyleParser
open FParsec

module CarsControllerTest =


    [<Fact>]
    let Get_WhenInvoked_ReturnsAListContainingMultipleElements() = 
        let cars = "SS_NOPREFIX | SS_CENTERIMAGE | SS_SUNKEN | NOT WS_GROUP"
        let parsedResult = run StyleParser.styleParser cars
        Assert.NotNull(parsedResult)

