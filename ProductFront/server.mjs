
const product = {
    name: 'Tractor',
    variants: [
      {
        sku: 't_porsche',
        color: 'red',
        name: 'Porsche-Diesel Master 419',
        image: '/static/ProductFront/images/tractor-red.jpg',
        thumb: '/static/ProductFront/images/tractor-red-thumb.jpg',
        price: '66,00 €',
      },
      {
        sku: 't_fendt',
        color: 'green',
        name: 'Fendt F20 Dieselroß',
        image: '/static/ProductFront/images/tractor-green.jpg',
        thumb: '/static/ProductFront/images/tractor-green-thumb.jpg',
        price: '54,00 €',
      },
      {
        sku: 't_eicher',
        color: 'blue',
        name: 'Eicher Diesel 215/16',
        image: '/static/ProductFront/images/tractor-blue.jpg',
        thumb: '/static/ProductFront/images/tractor-blue-thumb.jpg',
        price: '58,00 €',
      },
    ],
  };
  
  function renderOption(variant, sku) {
    const active = sku === variant.sku ? 'active' : '';
    return `
      <a href="/${variant.sku}" class="${active}" type="button" data-sku="${variant.sku}">
        <img src="${variant.thumb}" alt="${variant.name}" />
      </a>
    `;
  }
  

  function renderPage(sku = 't_porsche') {
    const variant = product.variants.find((v) => sku === v.sku);
    if (!variant) { return '<pre>no product not found</pre>'; }
    return `
      <h1 id="store">The Model Store</h1>
      <blue-basket id="basket"><!--#include virtual="/blue-basket" --></blue-basket>
      <div id="image"><div><img src="${variant.image}" alt="${variant.name}" /></div></div>
      <h2 id="name">${product.name} <small>${variant.name}</small></h2>
      <div id="options">${product.variants.map((v) => renderOption(v, sku)).join('')}</div>
      <blue-buy id="buy" sku="${variant.sku}"><!--#include virtual="/blue-buy?sku=${encodeURIComponent(variant.sku)}" --></blue-buy>
      <green-recos id="reco" sku="${variant.sku}"><!--#include virtual="/green-recos?sku=${encodeURIComponent(variant.sku)}" --></green-recos>
    `;
  }



const productPage = {
    type: "product",
    handle: renderPage
};

const pages = [productPage];
export { pages };