using BanHopDongSo1.Models; 
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);  //tạo ứng dụng web

// Add services to the container.
builder.Services.AddDbContext<CategoryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllersWithViews();  // add service
//mỗi lần add servce vui lòng add ở đây
//dưới var builder và trên var app

var app = builder.Build();  // chạy đối tượng web lên

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();//cấu hìn điều hướng vs http
app.UseStaticFiles(); // sử dụng file tĩnh

app.UseRouting(); // cấu hình định tuyến


app.UseAuthorization(); //cơ ché xác thực phân qyềnn
//phân quyền bằng secsion cokki

//cấu hình cách thức để truy cập

//https: local1234 / controllernAME / actionName/ {id}
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
