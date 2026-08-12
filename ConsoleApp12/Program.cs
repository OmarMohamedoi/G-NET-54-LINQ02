using ConsoleApp12;
using LINQ.DataSources;


//1
var results1 = Source.ProductList
    .OrderByDescending(p => p.UnitPrice)
    .Take(3);

foreach (var item in results1)
{
    //Console.WriteLine(item);
}


//2

var results2 = Source.ProductList
    .Skip(5)
    .Take(5);

//3

var results3 = Source.ProductList
    .OrderBy(p => p.UnitPrice)
    .TakeWhile(p=> p.UnitPrice <25);

foreach (var item in results3)
{
    //Console.WriteLine(item);
}

//4

var BoolResults4 = Source.ProductList // if true means there is a seafood with no stock
    .Any(p => p.Category.Equals( "SeaFood", StringComparison.OrdinalIgnoreCase )&& p.UnitsInStock == 0);

//Console.WriteLine(BoolResults4);

//5
int[] ids = { 3, 9, 13, 18 };
var boolREsults5 = ids
    .Contains(9);

//Console.WriteLine(boolREsults5);

//6

var results6 = Source.ProductList
    .GroupBy(p => p.Category)
    .Select(g => new { g.Key, Count = g.Count() });

foreach (var item in results6)
{
    //Console.WriteLine(item);
}


//7

var results7 = Source.ProductList
    .GroupBy(p => p.Category)
    .Select(g => new { g.Key, ProductNames = g.Select(p=> p.ProductName).ToList() });


foreach (var item in results7)
{
    //Console.WriteLine("Category: " + item.Key);
    foreach (var item2 in item.ProductNames)
    {
        //Console.WriteLine(item2);
    }
}

//8

var results8 = Source.ProductList
    .GroupBy(p => p.Category)
    .Where(p => p.Count() > 3)
    .Select(p => new { p.Key, Count = p.Count(),Products = p.Select(p => p.ProductName) });

foreach (var item in results8)
{
    //Console.WriteLine(item);
    foreach (var item2 in item.Products)
    {
       // Console.WriteLine(item2);
    }
}

//9

var results9 = from p in Source.CustomerList
               group p by p.Country into g
               select new {g.Key, Count = g.Count(), TotalOrderValue = g.SelectMany(c=> c.Orders).Sum(o=> o.Total) };

foreach (var item in results9)
{
    //Console.WriteLine(item);
}

//10

var results10 = Source.ProductList
    .Count(p => p.UnitsInStock > 0);

//Console.WriteLine(results10);


//11

var results11 = Source.ProductList
    .OrderBy(p => p.UnitPrice)
    .ToList();

    var minProduct = results11.First();
    var maxProduct = results11.Last();

//Console.WriteLine($"MaxProduct:{maxProduct}, Min Product:{minProduct}");

//12


var results12 = Source.ProductList
    .GroupBy(p => p.Category)
    //.Distinct()
    .Select(g=> g.Key);

foreach (var item in results12)
{
    //Console.WriteLine($"{item}");
    
}

//13 

int[] setA = { 1, 3, 5, 7, 9, 11, 13 };
int[] setB = { 3, 6, 9, 12, 15, 13 };

var result13 = setA.Except(setB);

foreach (var item in result13)
{
   // Console.WriteLine(item);
}

//14

string[] list1 = { "Germany", "France", "UK", "Spain" };
string[] list2 = { "france", "SPAIN", "Italy" };

var results14 = list1.Except(list2, StringComparer.OrdinalIgnoreCase);

foreach (var item in results14)
{
    //Console.WriteLine(item);
}

//15

Dictionary<int, Product> dict15 = new();
foreach (var item in Source.ProductList)
{
    dict15.TryAdd(item.ProductID, item);
}

//Console.WriteLine(dict15[18]);


//16


var results16 = Source.ProductList
    .First(p => p.UnitPrice > 50);

//Console.WriteLine(results16);


//17

var results17 = Source.ProductList
    .FirstOrDefault(p => p.UnitPrice > 500, null);

//Console.WriteLine(results17);

//18


var result = Enumerable.Range(1, 10)
    .Select(i=> $"7 * {i} = {7*i}");

foreach (var item in result)
{
    //Console.WriteLine(item);
}

//19

var result19 = Enumerable.Range(1, 30)
    .Where(i => i % 2 == 0);

foreach (var item in result19)
{
   // Console.WriteLine(item);
}


//20

var prods = Source.ProductList
    .Take(3)
    .Select(p => p.ProductName);

var customers = Source.CustomerList
    .Take(3)
    .Select(c => c.CompanyName);

var concated = prods.Concat(customers);

foreach (var item in concated)
{
    //Console.WriteLine(item);
}

//21


var prods1 = Source.ProductList
    .Select(p => p.ProductName);

var customers1 = Source.CustomerList
    .Select(c => c.CompanyName);

var concated1 = prods1.Zip(customers1, (name, company) => $"Item {name} sold to {company}");

foreach (var item in concated1)
{
    Console.WriteLine(item);
}


