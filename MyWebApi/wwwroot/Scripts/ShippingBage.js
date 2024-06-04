
window.addEventListener("load", async function () {
    console.log("startup ShoppingBag");
    try {
        await getAllMyProducts();
        showAmountAndPrice();
    } catch (error) {
        console.error("Error loading products:", error);
    }
});

const getAllMyProducts = async () => {
    try {
        const userBasket = JSON.parse(sessionStorage.getItem("basket")) || [];
        console.log(userBasket);
        const template = document.getElementById('temp-row');
        userBasket.forEach(basket => displayProduct(basket, template));
    } catch (error) {
        console.error("Failed to get products from basket:", error);
    }
};

const displayProduct = (basket, template) => {
    try {
        console.log(basket.productName);
        const clone = template.content.cloneNode(true);
        const item = clone.querySelector(".item-row");
        item.querySelector(".nameColumn").textContent = basket.productName;
        item.querySelector(".descriptionColumn").textContent = basket.description;
        item.querySelector(".quantityColumn").textContent = basket.quentity;
        item.querySelector(".priceColumn").textContent = basket.price * basket.quentity;

        const deleteButton = clone.querySelector('.DeleteButton');
        deleteButton.addEventListener('click', () => removeProductFromBasket(basket));

        document.querySelector(".items tbody").appendChild(clone);
    } catch (error) {
        console.error("Error displaying product:", error);
    }
};

const showAmountAndPrice = () => {
    try {
        const userBasket = JSON.parse(sessionStorage.getItem("basket")) || [];
        console.log(userBasket);
        let totalPrice = 0;
        let amount = 0;

        userBasket.forEach(product => {
            totalPrice += product.price * product.quentity;
            amount += product.quentity;
        });

        document.getElementById("itemCount").textContent = amount;
        document.getElementById("totalAmount").textContent = totalPrice;
        console.log(totalPrice, amount);
    } catch (error) {
        console.error("Error calculating total amount and price:", error);
    }
};

const placeOrder = async () => {
    try {
        await createOrder();
        sessionStorage.setItem("basket", "[]");
        clearScreen();
        showAmountAndPrice();
    } catch (error) {
        console.error("Failed to place order:", error);
    }
};

const createOrder = async () => {
    try {
        const products = await getProductsFromBasket();
        console.log("products", products);
        const data = formatOrderData(products);
        console.log("data", data);

        const response = await fetch("api/Order", {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(data)
        });

        if (!response.ok) {
            alert("Request failed");
            return;
        }

        const result = await response.json();
        if (!result) {
            alert("Order not found");
        } else {
            alert("Order added to your account: " + result.id);
            return result;
        }
    } catch (error) {
        console.error("Error creating order:", error);
        alert("An error occurred while creating the order");
    }
};

const getProductsFromBasket = async () => {
    try {
        const products = JSON.parse(sessionStorage.getItem("basket")) || [];
        return products.map(product => ({
            productId: product.productId,
            price: product.price,
            quentity: product.quentity
        }));
    } catch (error) {
        console.error("Failed to get products from basket:", error);
        return [];
    }
};

const formatOrderData = (products) => {
    try {
        return {
            userId: JSON.parse(sessionStorage.getItem("userID")),
            orderItems: products
        };
    } catch (error) {
        console.error("Error formatting order data:", error);
    }
};

const clearScreen = () => {
    try {
        const parentElement = document.querySelector(".items tbody");
        while (parentElement.firstChild) {
            parentElement.removeChild(parentElement.firstChild);
        }
    } catch (error) {
        console.error("Error clearing the screen:", error);
    }
};

const removeProductFromBasket = async (product) => {
    try {
        let userBasket = JSON.parse(sessionStorage.getItem("basket")) || [];
        userBasket.forEach(p => {
            if (isSameProduct(p, product)) {
                p.quentity -= 1;
            }
        });
        await updateBasket(userBasket);
        location.reload();
    } catch (error) {
        console.error("Failed to remove product from basket:", error);
    }
};

const isSameProduct = (prod, product) => {
    return (
        prod.productName === product.productName &&
        prod.price === product.price &&
        prod.categoryId === product.categoryId &&
        prod.description === product.description
    );
};

const updateBasket = (userBasket) => {
    try {
        userBasket = userBasket.filter(prod => prod.quentity > 0);
        sessionStorage.setItem("basket", JSON.stringify(userBasket));
    } catch (error) {
        console.error("Failed to update basket:", error);
    }
};