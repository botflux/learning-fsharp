[<Measure>]
type cm

[<Measure>]
type inches

[<Measure>]
type feet =
    static member toInches (feet: float<feet>): float<inches> =
        feet * 12.0<inches/feet>
        
let meter = 100.0<cm>
let yard = 3.0<feet>

let yardInInches = feet.toInches(yard)

[<Measure>]
type GBP

[<Measure>]
type USD

let gbp10 = 10.0<GBP>
let usd10 =10.0<USD>

gbp10 + gbp10
// Fails
//gbp10 + usd10
// Fails
//gbp10 + 1.0
gbp10 + 1.0<_>