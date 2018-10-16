# REST API Rubicon assignment

The REST API to the example app is described below.

## List Blog Posts

### Request

`GET /api/posts`

    curl -X GET "https://localhost:44345/api/posts" -H 'Accept: application/json'

### Response

<h6>Response header: </h6>

 content-type: application/json; charset=utf-8 <br>
 date: Tue, 16 Oct 2018 14:26:06 GMT <br>
 server: Kestrel <br>
 status: 200 <br>
 x-powered-by: ASP.NET Core 2.1 <br> 

<h6>Response body (example): </h6> 
{ <br>
  "posts": [ <br> 
    { <br> 
      "slug": "title-test", <br> 
      "title": "Title test", <br> 
      "description": "Description test", <br> 
      "body": "Body test", <br> 
      "tagList": [ <br> 
        "tag1", <br> 
        "tag4" <br> 
      ], <br> 
      "createdAt": "2018-10-16T14:00:12.838", <br> 
      "updatedAt": "2018-10-16T14:00:12.838" <br> 
    }, <br> 
    { <br> 
      "slug": "title-test2", <br> 
      "title": "Title test2", <br> 
      "description": "Description test2", <br> 
      "body": "Body test2", <br> 
      "tagList": [ <br> 
        "tag2", <br> 
        "tag3" <br> 
      ], <br> 
      "createdAt": "2018-10-16T14:00:12.838", <br> 
      "updatedAt": "2018-10-16T14:00:12.838" <br> 
    }, <br>

## Get Post By Tag

### Request

`GET /api/posts`

           curl -X GET "https://localhost:44345/api/posts?tag=trends" -H 'Accept: application/json' Provide: tag ( optional ) http://localhost:44345/api/posts

### Response

<h6>Response header: </h6>

 content-type: application/json; charset=utf-8 <br>
 date: Tue, 16 Oct 2018 14:26:06 GMT <br>
 server: Kestrel <br>
 status: 200 <br>
 x-powered-by: ASP.NET Core 2.1 <br> 

<h6>Response body (example - tag = "tag1"): </h6>
{ <br> 
  "posts": [ <br> 
    { <br> 
      "slug": "title-test", <br> 
      "title": "Title test", <br> 
      "description": "Description test", <br> 
      "body": "Body test", <br> 
      "tagList": [ <br> 
        "tag1", <br> 
        "tag4" <br> 
      ], <br> 
      "createdAt": "2018-10-16T14:00:12.838", <br> 
      "updatedAt": "2018-10-16T14:00:12.838" <br> 
    }, <br> 


## Create Post

### Request

`POST /api/posts`

          curl -X POST "https://localhost:44345/api/posts" -H "accept: application/json" -H "Content-Type: application/json-patch+json" -d "{\"title\": \"Internet Trends 2018\", \"description\": \"Ever wonder how?\", \"body\": \"An opinionated commentary, of the most important presentation of the year\", \"tagList\": [\"trends\", \"innovation\", \"2018\"]} 'Accept: application/json' Provide: Title, Description, Body (Required) 

### Response

<h6>Response header: </h6>
 content-type: application/json; charset=utf-8 <br>
 date: Tue, 16 Oct 2018 14:26:06 GMT <br>
 server: Kestrel <br>
 status: 200 <br>
 x-powered-by: ASP.NET Core 2.1 <br> <br>
<h6>Response body: </h6>
{  
  "postId": 5, <br>
  "title": "Internet Trends 2018", <br>
  "slug": "internet-trends-2018", <br>
  "description": "Ever wonder how?", <br>
  "body": "An opinionated commentary, of the most important presentation of the year", <br>
  "createdAt": "2018-10-16T14:43:29.1284552Z", <br>
  "updatedAt": "2018-10-16T14:43:29.1277864Z", <br>
  "tagList": [ <br>
    "trends", <br>
    "innovation", <br>
    "2018" <br>
  ] 
} <br><br>

## Get Blog Post 

### Request

`Get /api/posts/:slug`

        curl -X GET "https://localhost:44345/api/posts/title-test" -H 'Accept: application/json' Provide: Slug (Required) 

### Response


<h6>Response header: </h6>
 content-type: application/json; charset=utf-8 <br>
 date: Tue, 16 Oct 2018 14:26:06 GMT <br>
 server: Kestrel <br>
 status: 200 <br>
 x-powered-by: ASP.NET Core 2.1 <br> <br>

<h6>Response body: </h6>
{ 
  "postId": 5, <br>
  "title": "Internet Trends 2018", <br>
  "slug": "internet-trends-2018", <br>
  "description": "Ever wonder how?", <br>
  "body": "An opinionated commentary, of the most important presentation of the year", <br>
  "createdAt": "2018-10-16T14:43:29.1284552Z", <br>
  "updatedAt": "2018-10-16T14:43:29.1277864Z", <br>
  "tagList": [ <br>
    "trends", <br>
    "innovation", <br>
    "2018" <br>
  ] <br>
} <br>


## Update Blog Post

### Request

`PUT /api/posts/:slug`

           curl -X PUT "https://localhost:44345/api/posts/title-test?title=%22Updated%20title%22" -H 'Accept: application/json' Provide: Slug (Required), Title (optional), Description (optional), Body (optional) http://localhost:44345/api/posts

### Response

 <h6>Response header: </h6>
 content-type: application/json; charset=utf-8 <br>
 date: Tue, 16 Oct 2018 14:26:06 GMT <br>
 server: Kestrel <br>
 status: 200 <br>
 x-powered-by: ASP.NET Core 2.1 <br> <br>

<h6>Response body: </h6>
{ "postId": 5, <br>
  "title": "\"Updated title\", <br>
  "slug": "updated-title",<br>
  "description": "Ever wonder how?", <br>
  "body": "An opinionated commentary, of the most important presentation of the year", <br>
  "createdAt": "2018-10-16T14:43:29.1284552Z", <br>
  "updatedAt": "2018-10-16T14:43:29.1277864Z", <br>
  "tagList": [ <br>
    "trends", <br>
    "innovation", <br>
    "2018" <br>
  ] 
} <br> <br>

## Delete a Thing

### Request

`DELETE /api/posts/:slug

    curl -X DELETE "https://localhost:44345/api/posts/internet-trends-2018" 'Accept: application/json'

### Response

 <h6>Response header: </h6>
 content-type: application/json; charset=utf-8 <br>
 date: Tue, 16 Oct 2018 14:26:06 GMT <br>
 server: Kestrel <br>
 status: 204 <br>
 x-powered-by: ASP.NET Core 2.1 <br> <br>


## Get All Tags

### Request

`DELETE /thing/id`

    curl -X GET "https://localhost:44345/api/tags" -H 'Accept: application/json' -X DELETE http://localhost:7000/thing/1/

### Response

 <h6>Response header: </h6>
 content-type: application/json; charset=utf-8 <br>
 date: Tue, 16 Oct 2018 14:26:06 GMT <br>
 server: Kestrel <br>
 status: 200 <br>
 x-powered-by: ASP.NET Core 2.1 <br> <br>

<h6>Response body: </h6>
{   "tags": [ <br>
    "2018", <br>
    "innovation", <br>
    "tag1", <br>
    "tag2", <br>
    "tag3", <br>
    "tag4", <br>
    "trends" <br>
  ]
} <br>
