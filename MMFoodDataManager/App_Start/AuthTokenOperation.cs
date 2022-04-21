using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;

namespace MMFoodDataManager.App_Start
{
    public class AuthTokenOperation : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            //Add the route for /token
            swaggerDoc.paths.Add("/token", new PathItem 
            {
                //Specify that it's aPost
                post = new Operation 
                {
                    //Put the rout in the Auth Category.
                    tags = new List<string> { "Auth" },

                    //Set up the format in witch we expect the data.
                    consumes = new List<string> 
                    { 
                        "application/x-www-form-urlencoded"
                    },

                    parameters = new List<Parameter>
                    {
                        //Create the grant_type parameter.
                        new Parameter
                        {
                            type = "string",
                            name = "grant_type",
                            required = false,
                            @in = "formData",
                            @default = "password"
                        },

                        //Create the username parameter.
                        new Parameter
                        {
                            type = "string",
                            name = "username",
                            required = false,
                            @in = "formData"
                        },

                        //Create the password parameter.
                        new Parameter
                        {
                            type = "string",
                            name = "password",
                            required = true,
                            @in = "formData"
                        }
                    }
                }

            });
        }
    }
}