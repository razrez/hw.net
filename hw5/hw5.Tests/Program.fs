open Xunit
[<Fact>]
let Main_ReturnNot0 () =
    Assert.True([|"228";"2";"%%"|] |> Program.main <> 0)
[<Fact>]
let Main_Return0 () =
    Assert.True([|"16.5";"+";"102"|] |> Program.main = 0)  