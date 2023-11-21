const $app = document.getElementById('app');
const $basket = document.getElementById('basket');
const $buy = document.getElementById('buy');

var basketCount = undefined;
async function getBasketSize() {
    return 1;
}

function addToCart() {
    if (basketCount === undefined)
        return;

    basketCount += 1;
    console.log('"blue:basket:changed"');
    updateBasketBlock();
}

function updateBasketBlock() {
    $basket.innerHTML = renderBasket(basketCount);

    function renderBasket(count) {
        if (basketCount === undefined)
            return '';
        const classname = count === 0 ? 'empty' : 'filled';
        return `<div class="${classname}">basket: ${count} item(s)</div>`;
    }
}

setTimeout(async function () {
    basketCount = await getBasketSize();
    updateBasketBlock();
}, 1000);

buy.firstChild.addEventListener('click', addToCart);