const productPage = {
    type: "product",
    handle: function (ctx)
    {

        ctx.body = "hello product!" + ctx.request.url;


    }
};

const pages = [productPage];
export { pages };