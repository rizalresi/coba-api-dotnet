# How to USE


## Install Postman

This tutorial uses Postman to test the web API.

- Install Postman 
- Start the web app
- Start Postman 
- Disable SSL certificate verification 
- From File > Settings (General tab), disable SSL certificate verification

## Test PostTodoItem with Postman

- Create a new request.

- Set the HTTP method to POST.

- Select the Body tab.

- Select the raw radio button.

- Set the type to JSON (application/json).

- In the request body enter JSON for a to-do item:
  {
  "name":"walk dog",
  "isComplete":true
  }
