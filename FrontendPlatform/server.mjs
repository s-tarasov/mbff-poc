import Koa from 'koa';
import render from 'koa-ejs';
import { dirname } from 'path';
import { fileURLToPath } from 'url';
import { pages as productPages } from "../ProductFront/server.mjs";
import axios  from 'axios';

const apiClient = axios.create({
  baseURL: 'http://localhost:5001/'
});

const __dirname = dirname(fileURLToPath(import.meta.url));

const app = new Koa();
render(app, {
  root: __dirname,
  cache: false
});

app.use(async ctx => {
  var page = productPages.find(p => p.type === ctx.request.headers['x-page']);
  if (page)
  {
      ctx.pageBaseUrl = ctx.request.headers['x-page-base-url'];
      const requestSegments = ctx.request.path.split('/').filter(s => s);
      ctx.pageExtraSegments = requestSegments.slice(ctx.pageBaseUrl.match(/\//g).length);
      var html = await page.handle(ctx, apiClient);
      var script = `document.pageBaseUrl = "${ctx.pageBaseUrl}";`;
      await ctx.render("layout", { html, script });
      return;
  }    
});

app.listen(5500);