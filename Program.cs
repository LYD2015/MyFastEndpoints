global using FastEndpoints;
global using FastEndpoints.Security;
global using MyWebApp.Consts;
using FastEndpoints.Swagger;
using MongoDB.Entities;

var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints();//FastEndpoints��ܺ���
builder.Services.AddAuthenticationJWTBearer(SysConst.TokenSigningKey);//���jw��֤
builder.Services.AddSwaggerDoc(addJWTBearerAuth:true);//���swagger,����swagger����ʾ����token�İ�ť

var app = builder.Build();
app.UseAuthentication();//����jw��֤
app.UseAuthorization();
app.UseFastEndpoints();//����FastEndpoints��ܺ���
app.UseOpenApi();//����swaggerɨ��api
app.UseSwaggerUi3(s => s.ConfigureDefaults());//Ĭ����������swagger��ui

await DB.InitAsync(database: "FastEndpoints_TestDB", host: "localhost");//�������ӵ��ұ��ص�MongoDB���ݿ�

app.Run();
