# muzzle
Simple contained statement execution.

###### Try/catch
``` c# 
var test = Api.Instance.Contain<int>(
    () => { return 1 + 2; }
);

if(!test.HasError)
  Console.WriteLine(test.PayLoad);
```
OR
``` c# 
var test = new Container<int>()
    .Try(() => { return 1 + 2; })
    .Catch(ex => { Console.WriteLine(ex.Message); }
);

if(!test.HasError)
  Console.WriteLine(test.PayLoad);
```

###### Parsing
``` c# 
var val = Parse.Float("abc", -1f);

if(val == -1f)
  Console.WriteLine("parse failed");
```

###### Loops
``` c# 
var list = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
var sum = 0;

Loop.Each<int>(list, 
    (li) => 
    {
        sum += li;
    },
    new Loop.Options
    {
        Parallel = true,
        Threads = 3,
        OnError = (ex) => { Console.WriteLine(ex.Message); },
        OnIteration = (i) => { Console.WriteLine($"{i} of {list.Count}"); }
    });
```
