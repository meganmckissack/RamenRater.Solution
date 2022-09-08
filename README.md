## Description

dotnet api project for a ramen rating app

[Article on entity framework plural table names issue](https://edspencer.me.uk/posts/2012-03-13-entity-framework-plural-and-singular-table-names/#:~:text=By%20default%2C%20the%20Entity%20Framework,to%20be%20pluralised%20when%20created)

API versioning tutorials
https://neelbhatt.com/2018/04/21/api-versioning-in-net-core/

https://code-maze.com/aspnetcore-api-versioning/ \
used the line \
` o.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);` \
from this tutorial in configure services to make the first tutorial work

route for version 2.0 is \
`http://localhost:5004/api/ramens?api-version=2.0`


Swagger and Versioning implimentation

Tutorials
https://referbruv.com/blog/integrating-aspnet-core-api-versions-with-swagger-ui/ \
https://www.meziantou.net/versioning-an-asp-net-core-api.htm#integration-with-ope


Current issues \
https://github.com/dotnet/aspnet-api-versioning/issues/309 \
https://github.com/dotnet/aspnet-api-versioning/issues/434 \
https://stackoverflow.com/questions/65623399/the-type-or-namespace-name-apiversiondescription-could-not-be-found-are-you-m