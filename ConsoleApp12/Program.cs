using ConsoleApp12;
using LINQ.DataSources;


var result = Source.ProductList
    .Where(p => p.Category == "Seafood")
    .Select(p => new{p.ProductName, p.UnitPrice });

foreach (var item in result)
{
    //Console.WriteLine(item);
}

//2
var result2 = Source.ProductList
    .Select(p => new { p.ProductName });

foreach (var item in result2)
{
    //Console.WriteLine(item);
}

//3

var result3 = Source.ProductList
    .OrderBy(p => p.UnitPrice)
    .Select(p => new { p.ProductName, p.UnitPrice });

foreach (var item in result3)
{
    //Console.WriteLine(item);
}

//4

var result4 = Source.ProductList
    .Where(p => p.UnitPrice is >= 10m and <= 30m)
    ;

foreach (var item in result4)
{
    //Console.WriteLine(item);
}

//5

var result5 = Source.ProductList
    .Where(p => p.UnitsInStock > 0 && p.Category == "Condiments");

foreach (var item in result5)
{
    //Console.WriteLine(item);
}

//6

var result6 = Source.ProductList
    .Select(p => new
    {
        p.ProductName,
        p.UnitPrice,
        StockStatus = p.UnitsInStock > 0 ? "Available" : "Out Of Stock"
    });

foreach (var item in result6)
{
    //Console.WriteLine(item);
}

//7

var result7 = Source.ProductList
    .Select((p, index) => new { Index = index + 1, p.ProductName });

foreach (var item in result7)
{
    //Console.WriteLine(item);
}

//8

var result8 = Source.ProductList
    .OrderBy(p => p.Category)
    .ThenByDescending(p=> p.UnitPrice);

foreach (var item in result8)
{
    //Console.WriteLine(item);
}


//9

var result9 = Source.ProductList
    .Where(p => p.Category == "Beverages")
    .OrderByDescending(p => p.UnitsInStock)
    .Select(p => new { p.ProductName, p.UnitsInStock });

foreach (var item in result9)
{
   // Console.WriteLine(item);
}

//10

var result10 = from c in Source.CustomerList
               from o in c.Orders
               where o.OrderDate.Year >= 1997
               select new { c.CustomerID, o.OrderDate };

foreach (var item in result10)
{
    //Console.WriteLine(item);
}

//11

var result11 = Source.ProductList
    .Select((p, index) => new { Index = index + 1, p.ProductName });

foreach (var item in result11)
{
    //Console.WriteLine("Position: " + item.Index + "  Item: " + item.ProductName);
}

//12

String[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

var result12 = Arr
    .OrderBy(element => element.Length)
    .ThenBy(element => element, StringComparer.OrdinalIgnoreCase);

foreach (var item in result12)
{
    //Console.WriteLine(item);
}

//13

