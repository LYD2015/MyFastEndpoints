global using FastEndpoints;
global using FastEndpoints.Security;
global using MyWebApp.Consts;
using FastEndpoints.Swagger;
using MongoDB.Entities;

var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints();//FastEndpoints框架核心
builder.Services.AddAuthenticationJWTBearer(SysConst.TokenSigningKey);//添加jw认证
builder.Services.AddSwaggerDoc(addJWTBearerAuth:true);//添加swagger,并在swagger上显示输入token的按钮

var app = builder.Build();
app.UseAuthentication();//启用jw认证
app.UseAuthorization();
app.UseFastEndpoints();//启用FastEndpoints框架核心
app.UseOpenApi();//启用swagger扫描api
app.UseSwaggerUi3(s => s.ConfigureDefaults());//默认配置启用swagger的ui

await DB.InitAsync(database: "FastEndpoints_TestDB", host: "localhost");//配置连接到我本地的MongoDB数据库

app.Run();
