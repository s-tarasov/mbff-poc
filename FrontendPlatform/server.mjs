import Koa from 'koa';

const app = new Koa();

app.use(async ctx => {
  if (ctx.request.path == "/")
    ctx.body = 'Hello World';
});

app.listen(5500);