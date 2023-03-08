Application Service

Application Data API
Application object
Create Application
Get Applications
Get Application
Get Application History
Update Application
Application Data API
Application object
Properties
Property
Type
Description
applicationId
string
Unique identifier. 

Note: this will map to vendor_application_id in Fusion API.
status
string
IN_PROGRESS, SUBMITTED, WITHDRAWN, DECLINED, APPROVED, BOOKED
parties
individual[]
Array of parties to the application. For now we will just support individuals.







Individual object
Properties
Property
Type
Description
firstName
string
Individual first name. 
Note: maps to Fusion Submit API individual.first_name which has a 100 character limit.
lastName
string
Individual last name. 

Note: maps to Fusion Submit API individual.last_name which has a 100 character limit.
streetAddressLine1
string
Individual current street address.

Note: maps to Fusion Submit API individual.street_address_line_1 which has a 100 character limit.
streetAddressLine2
string
Individual current street address.

Note: maps to Fusion Submit API individual.street_address_line_2 which has a 100 character limit.
city
string
Individual current city

Note: maps to Fusion Submit API individual.city which has a 100 character limit.
stateCode
string
Individual current state code

Note: maps to Fusion Submit API individual.state_code which has a 2 character limit.
zipCode
string
Individual current zip code 

Note: maps to Fusion Submit API zip_code (format = 99999 or 999999999).
emailAddress


Individual email address

Note: maps to Fusion Submit API email_address (format = XXX@XXX.XXX).
mobile_phone_number


Individual mobile phone number

Note: maps to Fusion Submit API individual.mobile_phone_number which has a 10 digit limit.
dateOfBirth
date
Individual date of birth

Note: maps to Fusion Submit API individual.date_of_birth (Format = YYYY-MM-DD).
householdIncome
number
Individual total household income annually (between -2,000,000,000 and 2,000,000,000)

Note: maps to Fusion Submit API individual.household_income which has a 100 character limit.
controlPersonIndicator
boolean
Control person indicator
Allowable Values:
• true – Yes
• false – No

Note: maps to Fusion Submit API individual.control_person_ind 
primaryApplicantIndicator
boolean
Primary applicant indicator
Allowable Values:
• true – Yes
• false – No
taxIdentification
taxId
Maps to Fusion Submit API individual.extended_data.individual_tax_identification.

TaxId object
Properties
Property
Type
Description
number
string
The Tax ID number
isSocialSecurityNumber
bool
Indicates the number is a social security number.



ApplicationHistoryRecord object
Properties
Property
Type
Description
applicationId




timestamp
timestamp


userId
string


updates
ApplicationHistoryRecordFieldUpdate[]



ApplicationHistoryRecordFieldUpdate object
Properties
Property
Type
Description
fieldName
string
Flattened name of field. Example: “application.parties[0].firstName”
previousValue
string
The value of the field before the update.
updatedValue
string
The value of the field after the update.


Create Application
Create a new application.
Permissions
Name
Description
Application.Create
Allows the creation of an application

HTTP request
POST /application
Request headers
Header
Value
Authorization
Bearer {token}. Required
Content-Type
application/json
X-User-Id
The user id of the user making the request.
X-User-Permissions
List of the user’s permissions.

Request body
In the request body, supply a JSON representation with the following fields.
Field
Type
Description













Response
If successful, this method returns 201 Created response code and application object in the response body.
Events
Event name
Payload properties
Description
Application.Created
Application Id
The event is triggered when a Application is created.


Get Applications
Permissions
Name
Description
Application.Get.All
Allows the retrieval of all applications.

HTTP request
GET /applications
Request headers
Header
Value
Authorization
Bearer {token}. Required
Content-Type
application/json
X-User-Id
The user id of the user making the request.
X-User-Permissions
List of the user’s permissions.

Request body
Do not supply a request body for this method.
Response
If successful, this method returns 200 OK response code and an array of application objects in the response body.

Get Application
Permissions
Name
Description
Application.Get
Allows the retrieval of the application.





HTTP request
GET /application/{application_id}
Request headers
Header
Value
Authorization
Bearer {token}. Required
Content-Type
application/json
X-User-Id
The user id of the user making the request.
X-User-Permissions
List of the user’s permissions.

Request body
Do not supply a request body for this method.
Response
If successful, this method returns 200 OK response code and the application object in the response body.
Get Application History
Permissions
Name
Description
Application.History.Get
Allows the retrieval of the application history.





HTTP request
GET /application/{application_id}/history
Request headers
Header
Value
Authorization
Bearer {token}. Required
Content-Type
application/json
X-User-Id
The user id of the user making the request.
X-User-Permissions
List of the user’s permissions.

Request body
Do not supply a request body for this method.
Response
If successful, this method returns 200 OK response code and the application audit history in the response body.
Update Application
Update the properties of an Application object and log changes to the audit table.
Permissions
Name
Description
Application.Update







HTTP request
PATCH /application/{application_id}
Request headers
Header
Value
Authorization
Bearer {token}. Required
Content-Type
application/json-patch+json
X-User-Id
The user id of the user making the request.
X-User-Permissions
List of the user’s permissions.

Request body
In the request body, supply a JSON patch document. See https://jsonpatch.com/, https://datatracker.ietf.org/doc/html/rfc6902/, and https://learn.microsoft.com/en-us/aspnet/core/web-api/jsonpatch.  
Response
If successful, this method returns 200 OK response code and the application object in the response body.
