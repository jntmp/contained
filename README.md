# muzzle
Simple contained statement execution.

``` c# 
var test = new Container<int>()
    .Try(() => { return 1 + 2; })
    .Catch(ex => { Console.WriteLine(ex.Message); }
);

if(!test.HasError)
  Console.WriteLine(test.PayLoad);
```
