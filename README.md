# DQuery
Dynamic Query Builder for yundangnet

[
  {
    "operator": "=",
    "valuetype": "string",
    "value": "001",
    "fieldname": "billno",
    "exfuc": "pyszm"
  },
  {
    "valuetype": "array",
    "condition": "and",
    "items": [
      {
        "operator": "like",
        "valuetype": "string",
        "value": "A",
        "fieldname": "cusclass"
      },
      {
        "operator": "like",
        "valuetype": "string",
        "condition": "or",
        "value": "YUN",
        "fieldname": "cusname",
        "exfuc": "isnull"
      }
    ]
  }
]
