import Koa from 'koa';
import Router from 'koa-router';
import axios  from 'axios';

const inspireMsClient = axios.create({
    baseURL: 'http://localhost:5209'
  });

  const productMsClient = axios.create({
    baseURL: 'http://localhost:5087'
  });

const app = new Koa();
const router = new Router();


router.get('/recommendations', async (ctx) => {
    var forProductId = ctx.request.query.forProductId || 1;
    const recommendations = (await inspireMsClient.get(`recomendations?forProductId=${forProductId}`)).data;
    const recommendedProductId = recommendations[0].productId;
    const product = (await productMsClient.get(`/products/${recommendedProductId}`)).data;
    var result = [];
    recommendations.forEach(recommendation => {
        var variant = product.variants.find(v => v.sku === recommendation.sku);
        result.push({...variant, productId: product.id });
    });
    ctx.body = result;
  });

app.use(router.routes());
app.listen(8008);