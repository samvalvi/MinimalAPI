var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/user", (string name)=> $"Hola {name}!");

app.MapGet("/data/{firstname}/{lastname}/{age}", (string firstname, string lastname, int age)=> 
    $"Firstname: {firstname} \nLastname: {lastname} \nAge: {age}"
);

app.MapGet("/response", async ()=> 
{
    HttpClient client = new HttpClient();
    //Get data
    var response = await client.GetAsync("https://jsonplaceholder.typicode.com/todos/1");
    //Ensure response success
    response.EnsureSuccessStatusCode();
    //Data
    string responseBody = await response.Content.ReadAsStringAsync();
    //Return data
    return responseBody;
});

app.Run();
