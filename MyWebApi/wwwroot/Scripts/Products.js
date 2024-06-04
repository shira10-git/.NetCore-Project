
var categoriesCheckBox = [];
var max = -1;
var min = -1;
var byName = null;
var categoryString = "";

window.addEventListener("load", function () {
    console.log("startUp");
    uploadAllProducts();
    uploadCategories();
    updateAmmount();
});

const uploadAllProducts = async () => {
    try {
        const response = await fetch("api/Product", { method: 'GET' });
        const products = await response.json();
        if (products) {
            console.log(products);
            showProducts(products);
            updateAmmountOfProducts(products.length);
        }
    } catch {
        alert("try again");
    }
};

const showProducts = (products) => {
    const template = document.querySelector("#temp-card");
    products.forEach(prod => showProduct(prod, template));
};

const showProduct = (product, template) => {
    console.log(product);
    const clone = template.content.cloneNode(true);
    let item = clone.querySelector("div");
    item.querySelector("h1").textContent = product.productName;
    item.querySelector(".description").textContent = product.description;
    item.querySelector(".price").textContent = product.price;

    const imgElement = clone.querySelector('.img-w img');
    imgElement.src = product.image;

    var addToBasketButton = clone.querySelector('button');
    addToBasketButton.addEventListener('click', function () {
        addToBasket(product);
    });
    document.getElementById("PoductList").appendChild(clone);
};

const uploadCategories = async () => {
    try {
        const response = await fetch("api/Category", { method: 'GET' });
        const categories = await response.json();
        if (categories) {
            console.log(categories);
            showCategories(categories);
            addCheckboxEventListeners();
        }
    } catch {
        alert("try again");
    }
};

const showCategories = (categories) => {
    const divCategories = document.getElementById("categoryList");
    categories.forEach(category => {
        let br = document.createElement('br');
        divCategories.appendChild(br);
        let cb = document.createElement('input');
        cb.type = 'checkbox';
        cb.name = "category";
        cb.value = category.categoryId;
        cb.id = "categoryCB";
        let lbl = document.createElement('label');
        divCategories.appendChild(cb);
        lbl.append(document.createTextNode(category.categoryName));
        divCategories.appendChild(lbl);
    });
};

const addCheckboxEventListeners = () => {
    const checkboxes = document.querySelectorAll('input[type="checkbox"]');
    checkboxes.forEach(checkbox => {
        checkbox.addEventListener('change', function (event) {
            if (event.target.checked) {
                categoriesCheckBox.push(event.target.value);
                console.log(`Checkbox with value ${event.target.value} changed`);
                filterProducts();
            } else {
                categoriesCheckBox = categoriesCheckBox.filter(ct => ct != event.target.value);
                console.log(`Checkbox with value ${event.target.value} changed back`, categoriesCheckBox);
                filterProducts();
            }
        });
    });
};

const updateAmmountOfProducts = (len) => {
    document.getElementById("counter").innerHTML = len;
};

const filterProducts = () => {
    byName = document.getElementById("nameSearch").value;
    min = document.getElementById("minPrice").value;
    max = document.getElementById("maxPrice").value;
    categoryString = categoriesCheckBox.map(id => `&categoryIds=${id}`).join('');
    uploadFiltered();
};

const uploadFiltered = async () => {
    try {
        const response = await fetch(`api/Product?desc=${byName}&minPrice=${min}&maxPrice=${max}${categoryString}`, { method: 'GET' });
        const products = await response.json();
        if (products) {
            categoryString = "";
            console.log(products);
            cleanTheScreen();
            showProducts(products);
            updateAmmountOfProducts(products.length);
        }
    } catch {
        cleanTheScreen();
        showProducts([]);
        updateAmmountOfProducts(0);
    }
};

const cleanTheScreen = () => {
    const parentElement = document.getElementById('PoductList');
    while (parentElement.firstChild) {
        parentElement.removeChild(parentElement.firstChild);
    }
};

const addToBasket = (product) => {
    let userBasket = JSON.parse(sessionStorage.getItem("basket"));
    let flag = false;

    userBasket.map(prod => {
        if (checkIfSame(prod, product) == true) {
            prod.quentity += 1;
            flag = true;
        }
    });
    if (!flag) {
        product.quentity = 1;
        userBasket.push(product);
    }
    window.sessionStorage.setItem("basket", JSON.stringify(userBasket));
    updateAmmount();
};

const checkIfSame = (prod, product) => {
    return (
        prod.productName == product.productName &&
        prod.price == product.price &&
        prod.categoryId == product.categoryId &&
        prod.description == product.description
    );
};

const updateAmmount = () => {
    let userBasket = JSON.parse(sessionStorage.getItem("basket"));
    let ammount = 0;
    userBasket.map(prod => {
        ammount += prod.quentity;
    });
    document.getElementById("ItemsCountText").innerHTML = ammount;
};

const trackLinkID = () => {
    window.location.replace("User.html");
};

