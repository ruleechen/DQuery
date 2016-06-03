# DQuery
Dynamic Query Builder for yundangnet. DQuery parse json query clauses to C# expression for Linq. We can use it on common linq query and EntityFromework.

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
```
C# Expression 
------------
```C#
x => ((x.billno == "002") And (x.cusclass.Contains("A") Or IIF((x.cusname == null), "bYUNb", x.cusname).Contains("YUN")))
```
