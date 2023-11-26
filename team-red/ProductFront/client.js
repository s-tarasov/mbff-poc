(async function () {

    const $basket = document.getElementById('basket');
    const $buy = document.getElementById('buy');

    var basketCount = undefined;
    async function getBasketSize() {
        const response = await fetch('/apigw/productPageBFF/basketcount');
        const json = await response.json();
        return json.count;
    }

    async function addToCart() {
        if (basketCount === undefined)
            return;

        basketCount += 1;
        console.log('"blue:basket:changed"');
        updateBasketBlock();

        const response = await fetch('/apigw/productPageBFF/add-basket-item', { method: 'POST' });
        const json = await response.json();
        basketCount = json.count;
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
    $buy.firstChild.addEventListener('click', addToCart);

    basketCount = await getBasketSize();
    updateBasketBlock();
})();