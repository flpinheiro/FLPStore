# FLPStore

This is a study store.

See Code coverage [here](https://flpinheiro.github.io/FLPStore/)

## Used Libraries

* MediatR
* Automapper
* EntityFramework Core
* Serilog
* NSwag

## Class Model

![class model](/docs/diagrams/model/model.svg)

## use case

![admin](/docs/diagrams/usecase/admin.svg)

![contributor](/docs/diagrams/usecase/contributor.svg)

![guest](/docs/diagrams/usecase/guest.svg)

![user](/docs/diagrams/usecase/user.svg)

## endpoints

### Products
 
* Create Product
* Update Product
* Delete Product
* Get by Id 
* Get Paginated

### User

* create User
* Login
* address
    * create address
    * update Address
    * delete Address

* Shopping Cart
    * Add product to cart
    * Remove Product from cart
    * update Product on cart
    * Checkout => Create Order
    * clear

* order
    * Get Order by Id
    * Get order paginated

* Wish List
    * Create Whish list
    * Add Product to wish list
    * Remove Product from Wish list
    * Delete Wish list
    * get Wish list by Id
    * get Wish list paginated
    * Update Wish list
    