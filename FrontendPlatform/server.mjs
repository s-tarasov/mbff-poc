import Koa from 'koa';
import { pages as productPages } from "../ProductFront/server.mjs";

const app = new Koa();

app.use(async ctx => {

  var page = productPages.find(p => p.type === ctx.request.headers['x-page']);
  if (page)
  {
      page.handle(ctx);
      return;
  }

  ctx.body = 'Hello World headers:' + JSON.stringify(ctx.request.headers);
    
});

app.listen(5500);