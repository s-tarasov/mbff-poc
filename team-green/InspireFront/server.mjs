const productRecommendations = {
    renderServerHtml: function(ctx, productId)
    {
        return `<h3>Related Products</h3><div id="recitems" productid="${productId}"><img src="/static/team-green/InspireFront/loader.gif"/></div>`
    }
};
export { productRecommendations };