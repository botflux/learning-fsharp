type CartItem = string
type EmptyState = NoItems
type ActiveState = { UnpaidItems: CartItem list; }
type PaidForState = { PaidItems : CartItem list
                      Payment : decimal }
type Cart =
    | Empty of EmptyState
    | Active of ActiveState
    | PaidFor of PaidForState
    
let addToEmptyState item =
    Cart.Active { UnpaidItems=[item] }
    
let addToActiveState state itemToAdd =
    let newList = itemToAdd::state.UnpaidItems
    Cart.Active {state with UnpaidItems=newList}
    
let removeFromActiveState state itemToRemove =
    let newList = state.UnpaidItems
                  |> List.filter (fun i -> i<>itemToRemove)
    match newList with
    | [] -> Cart.Empty NoItems
    | _ -> Cart.Active {state with UnpaidItems=newList}

let payForActiveState state amount =
    Cart.PaidFor { PaidItems=state.UnpaidItems; Payment=amount }
    
type EmptyState with
    member this.Add = addToEmptyState

type ActiveState with
    member this.Add = addToActiveState this
    member this.Remove = removeFromActiveState this
    member this.Pay = payForActiveState this
    
let addItemToCart cart item =
    match cart with
    | Empty state -> state.Add item
    | Active state -> state.Add item
    | PaidFor state ->
        printfn "Error: The cart is paid for"
        cart

let removeItemFromCart cart item =
    match cart with
    | Empty state ->
        printfn "ERROR: The cart is empty"
        cart
    | Active state ->
        state.Remove item
    | PaidFor state ->
        printfn "ERROR: The cart is paid for"
        cart

let displayCart cart =
    match cart with
    | Empty state ->
        printfn "The cart is empty"
    | Active state ->
        printfn "The cart contains %A unpaid items" state.UnpaidItems
    | PaidFor state ->
        printfn "The cart contains %A paid items. Amount paid: %f"
            state.PaidItems state.Payment

type Cart with
    static member NewCart = Cart.Empty NoItems
    member this.Add = addItemToCart this
    member this.Remove = removeItemFromCart this
    member this.Display = displayCart this
    
let emptyCart = Cart.NewCart
printf "emptyCart="; emptyCart.Display

let cartA = emptyCart.Add "A"
printf "cartA="; cartA.Display
    
let cartAB = cartA.Add "B"
printf "cartAB="; cartAB.Display

let cartB = cartAB.Remove "A"
printf "cartB="; cartB.Display

let emptyCart2 = cartB.Remove "B"
printf "emptyCart2="; emptyCart2.Display

let emptyCart3 = emptyCart2.Remove "B"
printf "emptyCart3="; emptyCart3.Display

let cartAPaid =
    match cartA with
    | Empty _ | PaidFor _ -> cartA
    | Active state -> state.Pay 100m
    
printf "cartAPaid="; cartAPaid.Display

let cartABPaid =
    match cartAB with
    | Empty _ | PaidFor _ -> cartAB
    | Active state -> state.Pay 100m
    
let cartABPaidAgain =
    match cartABPaid with
    | Empty _ | PaidFor _ -> cartABPaid
    | Active state -> state.Pay 100m
    
//match cartABPaid with
//| Empty state -> state.Pay 100m
//| PaidFor state -> state.Pay 100m
//| Active state -> state.Pay 100m