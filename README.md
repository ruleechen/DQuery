# DQuery
Dynamic query builder to let you to do linq query with json string. DQuery parse json query clauses to C# expression for linq. We can use it on common linq query and even EntityFromework.

Sample Entity for query
------------
```c#
public class SampleEntity
{
    public string billno { get; set; }
    public string cusclass { get; set; }
    public string cusname { get; set; }
}
```

Sample JSON for query
------------
```javascript
[
  {
    "fieldname": "billno",
    "operator": "=",
    "value": "002"
  },
  {
    "condition": "and",
    "items": [
      {
        "fieldname": "cusclass",
        "operator": "like",
        "value": "A"
      },
      {
        "condition": "or",
        "fieldname": "cusname",
        "operator": "like",
        "value": "YUN",
        "exfuc": {
          "name": "isnull",
          "params": ["bYUNb"]
        }
      }
    ]
  }
]

// associated expression preview
// x => ((x.billno == "002") And (x.cusclass.Contains("A") Or IIF((x.cusname == null), "bYUNb", x.cusname).Contains("YUN")))
```

Useage
------------
```C#
using (var dataContext = new DemoEntities())
{
    var json = LoadJson()
    var result = dataContext.Properties.Where(json).ToList();
}
```
