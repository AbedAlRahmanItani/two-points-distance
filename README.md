# Calculate the distance betwee two geographical points
A Web API to calculate the distance between two geographical points.

## Postman localhost testing
- URL:
```sh
GET https://localhost:44378/api/DistanceCalculation
```

- Request Body:
```sh
{
  "latitudeA": 53.297975,
  "longitudeA": -6.372663,
  "latitudeB": 41.385101,
  "longitudeB": -81.440440
}
```

- Request Headers:
```sh
Accept-Language (en-US, es-ES, etc)
```

- Sample Response:
```sh
{
  "distance": 3439.909856,
  "unit": "mile"
}
```

## Notes
- The Accept-Language header is used to determine the locale, for now, if the provided value is en-US, then the calculation result is returned in mile, otherwise in km.
- If the Accept-Language not provided, en-US is used to calculate the distance.
- The following reference can be used to validate the calculation result: http://www.movable-type.co.uk/scripts/latlong.html