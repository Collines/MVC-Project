    console.log('inside cart.js')
    function renderCartItems(cartItems) {
        debugger;
        var html = "";

        cartItems.forEach(function (data) {
            html +=
                `
                    <li id="newAdded${data.productId}" data-id="${data.productId}">
                    <a href="/Product/Details/${data.productId}" class="minicart-product-image">
                        <img src="${data.imageURI}" alt="cart products">
                    </a>
                    <div class="minicart-product-details">
                        <h6><a href="/Product/Details/${data.productId}">${data.name}</a></h6>
                        <span>${data.priceAfterDiscount} x ${data.quantity}</span>
                    </div>
                    <button class="close removeCartItem" data-id="${data.productId}">
                        <i class="fa fa-close"></i>
                    </button>
                    </li>
                `;
        });

        return html;
    }

    $(document).on("click", ".add-to-cart", function () {
        console.log("Item added to cart");

        var recoredToAdd = $(this).attr("data-id");
        if (recoredToAdd != '') {
            $.post("/ShoppingCart/AddToCart_v2/" + recoredToAdd,
                function (data) {
                    debugger;
                    $('#cartItemCount').text(data.cartCount);
                    $("#MiniCartTotalPrice").text(data.cartTotalPrice);
                    $('#MiniCartTotalPrice2').text(data.cartTotalPrice);

                    debugger;
                    document.getElementsByClassName("minicart-product-list")[0].innerHTML = renderCartItems(data.cartItems);
                });
        }
    });

    $(document).on("click", ".removeCartItem", function () {
        // Get the id from the link
        var recordToDelete = $(this).attr("data-id");
        var clicked = $(this);
        if (recordToDelete != '') {
            // Perform the ajax post
            $.post("/ShoppingCart/RemoveFromCart/" + recordToDelete,
                function (data) {
                    debugger;
                    $('#cartItemCount').text(data.cartCount);
                    $("#MiniCartTotalPrice").text(data.cartTotalPrice);
                    $('#MiniCartTotalPrice2').text(data.cartTotalPrice);

                    debugger;
                    document.getElementsByClassName("minicart-product-list")[0].innerHTML = renderCartItems(data.cartItems);
                });
        }
    });
