# GraphQL server for .NET 5
 <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/1/17/GraphQL_Logo.svg/1024px-GraphQL_Logo.svg.png" alt="drawing" style="width:100px;"/>
 
 The graphql server test covid19 data. The Covid 19 API was borrowed from [Rapid API](https://rapidapi.com/).
 
To run the app it requires docker on your machine.

 <img src="https://pbs.twimg.com/profile_images/1273307847103635465/lfVWBmiW_400x400.png" alt="drawing" style="width:100px;"/>

## Register at RAPID API to get your api key
- https://rapidapi.com/Gramzivi/api/covid-19-data/


## Build the app
```docker
docker build -t gql-covid:latest .
```

## Run the app
```docker
docker run -p 8300:80 -d --name gql-covid gql-covid:latest
```

## Test the APP
Open Banana Cake Pop UI by going to http://localhost:8300/graphql

<img src="https://chillicream.com/static/235c2468b1b6a9b5e818516b74e55e84/d6ebf/bcp-operations.png" alt="drawing" style="width:300px;"/>

