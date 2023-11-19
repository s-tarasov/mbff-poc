import {productRecommendations} from "../InspireFront/server.mjs"

function renderOption(ctx, productId, variant, sku) {
    const active = sku === variant.sku ? 'active' : '';
    return `
      <a href="${ctx.pageBaseUrl}/${productId}/${variant.sku}/" class="${active}" type="button" data-sku="${variant.sku}">
        <img src="${variant.image}" alt="${variant.name}" />
      </a>
    `;
  }

  async function renderPage(ctx, apiClient) {    
    const productId = ctx.pageExtraSegments[0] || 1;
    const sku = ctx.pageExtraSegments[1] || 't_porsche';
    const product = (await apiClient.get(`/apigw/productPageBFF/productpage/${productId}/`)).data;
    const variant = product.variants.find((v) => sku === v.sku);
    if (!variant) { return '<pre>no product not found</pre>'; }
    return `
      <h1 id="store">The Model Store</h1>
      <blue-basket id="basket"><!--#include virtual="/blue-basket" --></blue-basket>
      <div id="image"><div><img src="${variant.image}" alt="${variant.name}" /></div></div>
      <h2 id="name">${product.name} <small>${variant.name}</small></h2>
      <div id="options">${product.variants.map((v) => renderOption(ctx, productId, v, sku)).join('')}</div>
      <blue-buy id="buy" sku="${variant.sku}"><!--#include virtual="/blue-buy?sku=${encodeURIComponent(variant.sku)}" --></blue-buy>
      <green-recos id="reco">${productRecommendations.renderServerHtml(ctx, productId)}</green-recos>
    `;
  }

const productPage = {
    type: "product",
    handle: renderPage
};

const pages = [productPage];
export { pages };