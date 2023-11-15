  function renderOption(variant, sku) {
    const active = sku === variant.sku ? 'active' : '';
    return `
      <a href="/${variant.sku}" class="${active}" type="button" data-sku="${variant.sku}">
        <img src="${variant.image}" alt="${variant.name}" />
      </a>
    `;
  }
  

  async function renderPage(ctx, apiClient) {
    const sku = 't_porsche';
    const product = (await apiClient.get('/apigw/productPageBFF/productpage/1/')).data;
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