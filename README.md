# Contained
Simple contained statement execution.

[![Build status](https://ci.appveyor.com/api/projects/status/p1h8h61ab5rfuhxb/branch/master?svg=true)](https://ci.appveyor.com/project/jntmp/contained/branch/master)

###### Try/catch
``` c# 
var test = mApi.Contain<int>(
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
var val = mApi.Parse<float>("1", -1f);

if(val == -1f)
  Console.WriteLine("parse failed");
```

###### Loops
``` c# 
var list = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
var sum = 0;

mApi.Iterate<int>(list, 
    li => sum += li,
	i => Console.WriteLine($"{i} of {list.Count}"),
    ex => Console.WriteLine(ex.Message),
    threads: 3
    });
```
