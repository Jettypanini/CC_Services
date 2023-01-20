var express = require('express');
var { graphqlHTTP } = require('express-graphql');
var { buildSchema } = require('graphql');

// Construct a schema, using GraphQL schema language
var schema = buildSchema(`
  type Query {
    addUser(name: String!, admin: Int, genre_pref: String): Int
  }
`);

// The root provides a resolver function for each API endpoint
var root = {
  addUser: ({name, admin}) => {
    var output = [];
    if (admin == 0 || admin == null) {
        output = 54321;
    } else if(admin == 1) {
        output = 12345;
    } else {
        output = 0;
    }
    return output;
  }
};

var app = express();
app.use('/graphql', graphqlHTTP({
  schema: schema,
  rootValue: root,
  graphiql: true,
}));
app.listen(4000);
console.log('Running a GraphQL API server at localhost:4000/graphql');