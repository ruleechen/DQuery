# DQuery
Dynamic Query Builder for yundangnet

Sample JSON for query
------------
```javascript
[
  {
    "operator": "=",
    "value": "001",
    "fieldname": "billno",
    "exfuc": "pyszm"
  },
  {
    "condition": "and",
    "items": [
      {
        "operator": "like",
        "value": "A",
        "fieldname": "cusclass"
      },
      {
        "operator": "like",
        "condition": "or",
        "value": "YUN",
        "fieldname": "cusname",
        "exfuc": "isnull"
      }
    ]
  }
]
```
