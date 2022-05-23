using System;
using RestSharp;
using System.Text.Json;

bool actualPokemon = false;
Pokemon pokemon1;
Pokemon pokemon2;
Pokemon pokemon3;

RestClient client = new RestClient("https://pokeapi.co/api/v2/");
System.Console.WriteLine("Write the name of three pokemons");
string poke1 = Console.ReadLine();
string poke2 = Console.ReadLine();
string poke3 = Console.ReadLine();
RestRequest request = new RestRequest("pokemon/" + poke1);
RestRequest request2 = new RestRequest("pokemon/" + poke2);
RestRequest request3 = new RestRequest("pokemon/" + poke3);
RestResponse result = await client.GetAsync(request);
RestResponse result2 = await client.GetAsync(request2);
RestResponse result3 = await client.GetAsync(request3);
string content = result.Content;
string content2 = result2.Content;
string content3 = result3.Content;
while (!actualPokemon)
{
    if (result.StatusCode == System.Net.HttpStatusCode.NotFound || result2.StatusCode == System.Net.HttpStatusCode.NotFound || result3.StatusCode == System.Net.HttpStatusCode.NotFound)
    {
        System.Console.WriteLine("One of those were not real pokemon");
        System.Console.WriteLine("Write the name of three pokemons");
        poke1 = Console.ReadLine();
        poke2 = Console.ReadLine();
        poke3 = Console.ReadLine();
    }
    else
    {
        actualPokemon = true;
    }
}
pokemon1 = JsonSerializer.Deserialize<Pokemon>(content);
pokemon2 = JsonSerializer.Deserialize<Pokemon>(content2);
pokemon3 = JsonSerializer.Deserialize<Pokemon>(content3);







weightRanking();

Console.ReadLine();

void weightRanking()
{

    if (pokemon1.weight > pokemon2.weight && pokemon1.weight > pokemon3.weight)
    {
        if (pokemon2.weight > pokemon3.weight)
        {
            Console.Write(pokemon1.name + ", ");
            Console.WriteLine("weight: " + pokemon1.weight);
            Console.Write(pokemon2.name + ", ");
            Console.WriteLine("weight: " + pokemon2.weight);
            Console.Write(pokemon3.name + ", ");
            Console.WriteLine("weight: " + pokemon3.weight);
        }
        if (pokemon2.weight < pokemon3.weight)
        {
            Console.Write(pokemon1.name + ", ");
            Console.WriteLine("weight: " + pokemon1.weight);
            Console.Write(pokemon3.name + ", ");
            Console.WriteLine("weight: " + pokemon3.weight);
            Console.Write(pokemon2.name + ", ");
            Console.WriteLine("weight: " + pokemon2.weight);
        }
    }
    if (pokemon2.weight > pokemon1.weight && pokemon2.weight > pokemon3.weight)
    {
        if (pokemon1.weight > pokemon3.weight)
        {
            Console.Write(pokemon2.name + ", ");
            Console.WriteLine("weight: " + pokemon2.weight);
            Console.Write(pokemon1.name + ", ");
            Console.WriteLine("weight: " + pokemon1.weight);
            Console.Write(pokemon3.name + ", ");
            Console.WriteLine("weight: " + pokemon3.weight);
        }
        if (pokemon1.weight < pokemon3.weight)
        {
            Console.Write(pokemon2.name + ", ");
            Console.WriteLine("weight: " + pokemon2.weight);
            Console.Write(pokemon3.name + ", ");
            Console.WriteLine("weight: " + pokemon3.weight);
            Console.Write(pokemon1.name + ", ");
            Console.WriteLine("weight: " + pokemon1.weight);
        }
    }
    if (pokemon3.weight > pokemon2.weight && pokemon3.weight > pokemon1.weight)
    {
        if (pokemon1.weight > pokemon2.weight)
        {
            Console.Write(pokemon3.name + ", ");
            Console.WriteLine("weight: " + pokemon3.weight);
            Console.Write(pokemon1.name + ", ");
            Console.WriteLine("weight: " + pokemon1.weight);
            Console.Write(pokemon2.name + ", ");
            Console.WriteLine("weight: " + pokemon2.weight);
        }
        if (pokemon1.weight < pokemon2.weight)
        {
            Console.Write(pokemon3.name + ", ");
            Console.WriteLine("weight: " + pokemon3.weight);
            Console.Write(pokemon2.name + ", ");
            Console.WriteLine("weight: " + pokemon2.weight);
            Console.Write(pokemon1.name + ", ");
            Console.WriteLine("weight: " + pokemon1.weight);
        }
    }


}