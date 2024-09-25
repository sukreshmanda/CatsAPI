/**
 * @name Enforce [FromBody] attribute for non-primitive parameters in controller methods with specific HTTP method attributes
 * @description This query checks if non-primitive parameters in ASP.NET Core controller methods, which have specific route and HTTP method attributes, are decorated with the [FromBody] attribute.
 * @kind problem
 * @problem.severity error
 * @precision high
 * @tags style
 */

 import csharp

 // Represents a class derived from ControllerBase (i.e., ASP.NET Core controller)
 class AspNetController extends Class {
   AspNetController() {
     this.extends("Microsoft.AspNetCore.Mvc.ControllerBase")
   }
 }
 
 // Represents a method in a controller
 class ControllerMethod extends Method {
   ControllerMethod() {
     this.getDeclaringType() instanceof AspNetController
   }
 }
 
 // Represents a parameter of a method in a controller
 class ControllerParameter extends Parameter {
   ControllerParameter() {
     exists(ControllerMethod m | this = m.getParameter(_))
   }
 }
 
 // Check if a method has any of the Route-related HTTP attributes (Route, HttpPost, HttpPut, HttpDelete, HttpGet)
 predicate hasHttpRouteAttribute(Method m) {
   exists(Attribute a |
     (
       a.getName() = "Route" or
       a.getName() = "HttpPost" or
       a.getName() = "HttpPut" or
       a.getName() = "HttpDelete" or
       a.getName() = "HttpGet"
     ) and
     a.getTarget() = m
   )
 }
 
 // Check if a parameter has the FromBody attribute
 predicate hasFromBodyAttribute(Parameter p) {
   exists(Attribute a |
     a.getName() = "FromBody" and
     a.getTarget() = p
   )
 }
 
 // Helper predicate to check if a type is primitive
 predicate isPrimitiveType(Type t) {
   t instanceof PrimitiveType // This covers all primitive types
 }
 
 // Find methods where a parameter is non-primitive and the method has specific HTTP method attributes, but lacks the [FromBody] attribute
 from ControllerMethod m, ControllerParameter p
 where
   hasHttpRouteAttribute(m) and                // Ensure the method has one of the HTTP method attributes
   not isPrimitiveType(p.getType()) and        // Ensure the parameter is not a primitive type
   not hasFromBodyAttribute(p)                 // Ensure the parameter does not have the [FromBody] attribute
 select p, "The parameter '" + p.getName() + "' in the method '" + m.getName() + "' must have the [FromBody] attribute because the method has a route and the parameter is not a primitive type."
 