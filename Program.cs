using DotNetCoreBasicProject.CustomMiddleware;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();
builder.Services.AddControllers().AddXmlSerializerFormatters();
builder.Services.AddControllersWithViews();
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
//simple  play with asp .net

/*app.Run(async (HttpContext context) =>
{
    String path = context.Request.Path;
    String method = context.Request.Method;
    await context.Response.WriteAsync("From Middleware 3");
    context.Response.Headers["Content-type"] = "text/html";
    if (context.Request.Method == "GET")
    {
        if (context.Request.Query.ContainsKey("id"))
        {
            string id = context.Request.Query["id"];
            await context.Response.WriteAsync($"<p>{id}</p></br>");
        }
    }
    if (context.Request.Headers.ContainsKey("User-Agent"))
    {
        string userAgent = context.Request.Headers["User-Agent"];
        await context.Response.WriteAsync($"<p>{userAgent}</p></br>");
    }
    await context.Response.WriteAsync($"<p>{path}</p></br>");
    await context.Response.WriteAsync($"<p>{method}</p></br>");
});*/

// middleware with asp .net

//middlware 1
/*app.Use(async (HttpContext context, RequestDelegate next) => {
    await context.Response.WriteAsync("From Midleware 1");
    await next(context);
});


//middleware 2
//app.UseMiddleware<MyCustomMiddleware>();
app.UseMyCustomMiddleware();
app.UseHelloCustomMiddleware();
//middleware 3
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("From Middleware 3");
});*/

//Routing in .net
//enable routing

/*app.UseRouting();
app.Use(async (context, next) =>
{
    Microsoft.AspNetCore.Http.Endpoint? endPoint = context.GetEndpoint();
    if (endPoint != null)
    {
        await context.Response.WriteAsync($"Endpoint: {endPoint.DisplayName}\n");
    }

    await next(context);
});

//creating endpoints
app.UseEndpoints(endpoints =>
{
    //add your endpoints here
    endpoints.MapGet("map1", async (context) => {
        await context.Response.WriteAsync("In Map 1");
    });

    endpoints.MapPost("map2", async (context) => {
        await context.Response.WriteAsync("In Map 2");
    });
});

app.Run(async context => {
    await context.Response.WriteAsync($"Request received at {context.Request.Path}");
});*/
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
