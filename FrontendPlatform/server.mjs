import Koa from 'koa';

const app = new Koa();

app.use(async ctx => {
  if (ctx.request.path == "/")
    ctx.body = 'Hello Main';
  else
    ctx.body = 'Hello World headers:' + JSON.stringify(ctx.request.headers);
});

app.listen(5500);