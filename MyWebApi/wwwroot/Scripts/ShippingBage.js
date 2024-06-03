window.addEventListener("load", function () {
    console.log("startUp ShippingBag");
    getAllMyProducts();
    showAmmontPrice()
});


const getAllMyProducts =async  () => {
    let userBasket =await JSON.parse(sessionStorage.getItem("basket"));
    console.log(userBasket);
    //const template = document.querySelector("#item-row");
    const template = document.getElementById('temp-row');
    userBasket.forEach(basket => ShowBasketProducts(basket, template));
}

const ShowBasketProducts = (basket, template) => {
    console.log(basket.productName)
    const clone = template.content.cloneNode(true);
    //let item = clone.querySelector("td");
    let item = clone.querySelector(".item-row");
    item.querySelector(".nameColumn").textContent = basket.productName;
    item.querySelector(".descriptionColumn").textContent = basket.description;
    item.querySelector(".quantityColumn").textContent = basket.quentity;
    item.querySelector(".priceColumn").textContent = basket.price * basket.quentity;
    const deleteButton = clone.querySelector('.DeleteButton');

    deleteButton.addEventListener('click', function () {
        deleteProductFromBasket(basket)
    });

    document.querySelector(".items tbody").appendChild(clone);
}

const showAmmontPrice = () => {
    let userBasket = JSON.parse(sessionStorage.getItem("basket"));
    console.log(userBasket)
    let totalPrice = 0;
    let ammount = 0;
    userBasket.map(prod => {
        totalPrice += prod.price*prod.quentity;
        ammount +=prod.quentity;
    })
    document.getElementById("itemCount").innerHTML=ammount
    document.getElementById("totalAmount").innerHTML=totalPrice
    console.log(totalPrice,ammount)
}

const placeOrder =async () => {
    //send to server
    await creatOrder()
    window.sessionStorage.setItem("basket", "[]");
    CleanTheScreen()
    showAmmontPrice()
}

const creatOrder = async() => {
    let products = JSON.parse(window.sessionStorage.getItem("basket"));
    products = products.map(ele => {
        return {
            productId: ele.productId, price: ele.price,quentity: ele.quentity };
    })
    console.log(products)
    const data = {
        userId: JSON.parse(window.sessionStorage.getItem("userID")),
        orderItems: products
    }

    console.log(data)
    const respones = await fetch("api/Order",
        {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(data)
        });
    if (!respones.ok) {
        alert("in correct")
    }
    else {
        const result = await respones.json()
        if (!result) {
            alert("not found")
        }
        else {
            //console.log("bcbcbnv",result.id)
            alert("added to yuor account " + result.id)
        }
        return result
    }
}

const CleanTheScreen = () => {
    const parentElement = document.getElementById('items');
    while (parentElement.firstChild) {
        parentElement.removeChild(parentElement.firstChild);
    }
}

const deleteProductFromBasket = (product) => {
    let userBasket = JSON.parse(sessionStorage.getItem("basket"));
    userBasket.map(prod => { 
    if (prod.productName == product.productName && prod.price == product.price && prod.categoryId == product.categoryId && prod.description == product.description ) {
        prod.quentity -= 1;
        
    }
    })
    userBasket = userBasket.filter(prod => prod.quentity > 0)
    window.sessionStorage.setItem("basket", JSON.stringify(userBasket));
    location.reload()
}