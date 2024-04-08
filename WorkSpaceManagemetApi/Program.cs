using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WorkspaceManagement.BusinessLayer.IServices;
using WorkspaceManagement.BusinessLayer.Services;
using WorkspaceManagement.DataAccessLayer.Data;
using WorkspaceManagement.DataAccessLayer.Interfaces;
using WorkSpaceManagemetApi.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<WorkSpaceDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStringForRooms"), builder => builder.MigrationsAssembly("WorkSpaceManagemetApi")));


//services injection for business layer
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IDeskBookingService, DeskBookingService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IRoomBookingService, RoomBookingService>();
builder.Services.AddScoped<IRoomDetailService, RoomDetailService>();

//interface and repository injection for data access layer
builder.Services.AddScoped<IEmployee, EmployeeRepository>();
builder.Services.AddScoped<ILocation, LocationRepository>();
builder.Services.AddScoped<IEvent, EventRepository>();
builder.Services.AddScoped<INotification, NotificationRepository>();
builder.Services.AddScoped<IDeskBooking, DeskBookingRepository>();
builder.Services.AddScoped<IRoomBooking, RoomBookingRepository>();
builder.Services.AddScoped<IRoomDetail, RoomDetailRepository>();
builder.Services.AddScoped<IDepartment, DepartmentRepository>();

builder.Services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSetting:Token").Value)),
    ValidateIssuer = false,
    ValidateAudience = false,
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowOrigin");

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();
app.MapControllers();

app.Run();
