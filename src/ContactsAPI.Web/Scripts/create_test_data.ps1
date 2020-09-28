$baseUrl = 'https://localhost:44365/api/Contacts'

Function CallApi($path, $method, $body) {
    return Invoke-RestMethod -UseDefaultCredentials -Method $method -Uri ($baseUrl + $path) -Body $body -ContentType 'application/json'
}

$body = @'
{
  "firstName": "Johnny",
  "lastName": "Test",
  "employeeId": "EMP001",
  "email": "test@example.com",
  "cellPhone": "123-456-7890",
  "homePhone": null,
  "officePhone": null,
  "dateOfBirth": "2020-09-28T19:19:36.509Z",
  "dateOfHire": "2020-09-28T19:19:36.509Z",
  "currentlyEmployed": true
}
'@

$result = CallApi '' 'Post' $body


$body = @'
{
  "firstName": "Frank",
  "lastName": "Jones",
  "employeeId": "EMP002",
  "email": "test@example.com",
  "cellPhone": "123-456-7890",
  "homePhone": null,
  "officePhone": null,
  "dateOfBirth": "2020-09-28T19:19:36.509Z",
  "dateOfHire": "2020-09-28T19:19:36.509Z",
  "currentlyEmployed": true,
  "contactAddresses": [
    {
      "address": {
        "line1": "123 Cherry St",
        "line2": null,
        "city": "Oakland",
        "state": "WA",
        "zipCode": "99999"
      },
      "addressType": "Home"
    }
  ],
  "relatedContacts": [
    {
      "relationship": "Spouse",
      "relatedContact": {
          "firstName": "Jane",
          "lastName": "Jones",
          "cellPhone": "123-456-7890"          
      }
    }
  ]
}
'@

$result = CallApi '' 'Post' $body