# Installing Mediator package:

## in this project I am going to use CQRS + Mediator pattern

## Here Mediator job is to transfer HTTP Request form API layer to down Application layer.

The main purpose is to sperate applcaiton logic from the APi Layer to make a clean architecure.
Steps:
            -> Goto the nuget gallery and type Mediator
            -> Select
            MediatR.Extensions.Microsoft.DependencyInjection
            -> Select Application Project and install.


# Installing Fluent Validation: 
## In this project I am not going to use Data annotation. I would use FluentValidation. 

            -> Go to Nuget Gallery and search Fluentvalidation
            -> Select FluentValidation.AspNetCore and install it in Application Project. 
