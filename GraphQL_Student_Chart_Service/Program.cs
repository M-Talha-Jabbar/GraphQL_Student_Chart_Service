using GraphQL;
using GraphQL.Types;
using GraphQL_Student_Chart_Service;
using GraphQL_Student_Chart_Service.Interfaces;
using GraphQL_Student_Chart_Service.Mutations;
using GraphQL_Student_Chart_Service.Queries;
using GraphQL_Student_Chart_Service.Schema;
using GraphQL_Student_Chart_Service.Services;
using GraphQL_Student_Chart_Service.Types;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// JWT Configuration
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"])),

        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"], 

        ValidateAudience = true,
        ValidAudience = builder.Configuration["JwtSettings:Audience"],

        ValidateLifetime = true, 

        ClockSkew = TimeSpan.Zero // The default value of ClockSkew is 5 minutes. That means if you haven't set it, your JWT will be valid for Expiry Time + 5 mins.
        // If you want to expire your JWT on the exact time (i.e. Expiry Time) you will need to set ClockSkew to zero.
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Trusted", policy =>
        policy.RequireAuthenticatedUser() // Similar to adding [Authorize] attribute where we just authenticate the subsequent request by checking if the User have valid JWT based upon how authentication has been configured.

     );
});

builder.Services.AddSingleton<StudentType>();
builder.Services.AddSingleton<WaiverCountType>();
builder.Services.AddSingleton<StudentCountType>();
builder.Services.AddSingleton<UserType>();

builder.Services.AddSingleton<AppQuery>();
builder.Services.AddSingleton<AppMutation>();

builder.Services.AddSingleton<ISchema, AppSchema>();

builder.Services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

builder.Services.AddSingleton<IAuthInterface, AuthService>();
builder.Services.AddSingleton<IStudentInterface, StudentService>();

// Register GraphQL
builder.Services.AddGraphQL(options =>
     options.AddSystemTextJson() // For JSON serialization
     .AddAuthorizationRule() // This middleware enforces any policies you set and it's for GraphQL Endpoints.
);

builder.Services.AddCors(options =>
{
    options.AddPolicy("GraphQL_Student_Chart_Client", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyHeader()
               .WithMethods("POST");
    });
});

var app = builder.Build();

app.UseCors("GraphQL_Student_Chart_Client");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // add altair UI to development only
    app.UseGraphQLAltair();
}

app.UseHttpsRedirection();

app.UseAuthentication(); // This middleware is responsible for validating the JWT token in incoming requests and it's for both REST & GraphQL Endpoints.
app.UseAuthorization(); // This middleware enforces any policies you set and it's for REST Endpoints.

app.MapControllers();

// Register GraphQL endpoint
app.UseGraphQL<ISchema>("/graphql"); // URL to host GraphQL endpoint

app.Run();
