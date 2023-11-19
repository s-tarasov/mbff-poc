(async () => {
    const container = document.getElementById('recitems');
    var productId = container.getAttribute('productid');
    const response = await fetch('/apigw/inspireBFF/recommendations/?forProductId=' + productId);
    const json = await response.json();

    function getUrl (rec) { return `${document.pageBaseUrl}/${rec.productId}/${rec.sku}/`; }

    container.innerHTML = json.map((rec) => `<a href="${getUrl(rec)}"><img src="${rec.image}" alt="${rec.name}" /></a>`).join('');
})();

